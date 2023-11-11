using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ZedGraph;

namespace mini_scope_pc
{
    public partial class Form1 : Form
    {
        // graph object
        GraphPane graphPane;
        
        //trigger line buffer
        LineObj trs_line;

        //serial data buffer
        double[] buffer = new double[600];
        int buff_pointer = 0;
        bool data_ready;

        delegate void serialCalback(string val);

        //volt divs in [V]
        double[] volt_divs = new double[10] { 0.01, 0.02, 0.05, 0.1, 0.2, 0.5, 1, 2, 5,10 };
        int volt_divs_pointer = 6;

        //time divs in [ms]
        double[] time_divs = new double[13] { 0.05, 0.10, 0.20, 0.50, 1,2,5,10,20,5,100,200,500};
        int time_divs_pointer = 4;

        //sampling rate div
        int sampling_rate_div = 1;

        //AC / DC coupling AC ->true DC-> false
        bool ac_dc = false;

        //cursor value
        double cursor_ax_value, cursor_ay_value, cursor_bx_value, cursor_by_value;

        bool rising = true;

        

        //trigger line dissapear counter
        int trigger_line_delete_delay = 0; 

        public Form1()
        {
            InitializeComponent();
            
            //init graph
            graphPane = zedGraphControl1.GraphPane;
            graphPane.Title.IsVisible = true;
            graphPane.Chart.Fill = new Fill(Color.Black);
            graphPane.XAxis.Color = Color.White;
            graphPane.XAxis.MajorGrid.IsVisible = true;
            graphPane.XAxis.MajorGrid.Color = Color.Gray;
            graphPane.XAxis.Scale.IsVisible = false;
            graphPane.XAxis.Title.IsVisible = false;
            graphPane.YAxis.MajorGrid.IsVisible = true;
            graphPane.YAxis.MajorGrid.Color = Color.Gray;
            graphPane.YAxis.Color = Color.Gray;
            graphPane.YAxis.Scale.IsVisible = false;
            graphPane.YAxis.Title.IsVisible = false;
            graphPane.Legend.IsVisible = false;
            
            
            
            //Voltage dim set for startup (1V/div)
            voltage_div.Text = volt_divs[volt_divs_pointer].ToString() + " V/div";
            zedGraphControl1.GraphPane.YAxis.Scale.Min = -4 * volt_divs[volt_divs_pointer];
            zedGraphControl1.GraphPane.YAxis.Scale.Max = 4 * volt_divs[volt_divs_pointer];
            graphPane.YAxis.Scale.MajorStep = volt_divs[volt_divs_pointer];

            //time div set 1ms/divs
            time_div.Text = time_divs[time_divs_pointer].ToString() + " ms/div";
            zedGraphControl1.GraphPane.XAxis.Scale.Min = -1 * (buffer.Length / 2);
            zedGraphControl1.GraphPane.XAxis.Scale.Max =  1 * (buffer.Length / 2);
            graphPane.XAxis.Scale.MajorStep = buffer.Length / 12;

            //set the cursor panel
            cursor_panel.Visible = false;
            cursor_a_b.Enabled = false;
            cursor_select_axix.Enabled = false;
            cursor_value.Enabled = false;

            //list available serial ports
            string[] ports = System.IO.Ports.SerialPort.GetPortNames();
            com_port_list.Items.AddRange(ports);
            DrawsinCurve();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void DrawsinCurve() 
        {
            PointPairList pointPairs = new PointPairList();
            Random rnd = new Random();

            for (int i = 0; i < buffer.Length; i++) 
            {
                // buffer[i] = rnd.NextDouble();
                buffer[i] = Math.Sin(i * Math.PI / 180.0);
                double x = i;
                double y = buffer[i];
                PointPair pointPair = new PointPair(x, y);
                
                pointPairs.Add(pointPair);
            }
            
            LineItem lineItem = graphPane.AddCurve("Sin Curve", pointPairs, Color.Yellow, SymbolType.None);
            lineItem.Line.IsSmooth = true;
            zedGraphControl1.AxisChange();
            
        }

        //run/stop the graph
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
            Control_message();
        }

        //30 Hz display refresh
        private void timer1_Tick(object sender, EventArgs e)
        {
            //átrakni  a data readyhez
            Control_message();
            debug.Text = buffer[buff_pointer].ToString();
            //clear trigger line after a sec
            if (trigger_line_delete_delay > 0) trigger_line_delete_delay--;
            else graphPane.GraphObjList.Clear();
            
            //y axis segéd
            LineObj y_zero = new LineObj(Color.Gray, 0,graphPane.YAxis.Scale.Min,0, graphPane.YAxis.Scale.Max);
            graphPane.GraphObjList.Add(y_zero);

            //cursor enable
            if (cursor_enable.Checked)
            {
                //cursor lines
                LineObj ax = new LineObj(Color.White, cursor_ax_value, graphPane.YAxis.Scale.Min, cursor_ax_value, graphPane.YAxis.Scale.Max);
                LineObj bx = new LineObj(Color.White, cursor_bx_value, graphPane.YAxis.Scale.Min, cursor_bx_value, graphPane.YAxis.Scale.Max);
                LineObj ay = new LineObj(Color.White, graphPane.XAxis.Scale.Min, cursor_ay_value, graphPane.XAxis.Scale.Max, cursor_ay_value);
                LineObj by = new LineObj(Color.White, graphPane.XAxis.Scale.Min, cursor_by_value, graphPane.XAxis.Scale.Max, cursor_by_value);
                graphPane.GraphObjList.Add(ax);
                graphPane.GraphObjList.Add(bx);
                graphPane.GraphObjList.Add(ay);
                graphPane.GraphObjList.Add(by);
                bx.Line.Style = System.Drawing.Drawing2D.DashStyle.Dash;
                by.Line.Style = System.Drawing.Drawing2D.DashStyle.Dash;

                //display cursor values 
                double display_cursor_value_ax = (cursor_ax_value / buffer.Length) * 12 * time_divs[time_divs_pointer];
                double display_cursor_value_bx = (cursor_bx_value / buffer.Length) * 12 * time_divs[time_divs_pointer];
                double display_cursor_value_ay = (cursor_ay_value / (2 * graphPane.YAxis.Scale.Max)) * 8 * volt_divs[volt_divs_pointer];
                double display_cursor_value_by = (cursor_by_value / (2 * graphPane.YAxis.Scale.Max)) * 8 * volt_divs[volt_divs_pointer];

                //cursor A X axis
                if ((display_cursor_value_ax < 1)&&(display_cursor_value_ax > -1)) cursor_ax.Text = (display_cursor_value_ax*1000).ToString() + " us";
                else cursor_ax.Text = display_cursor_value_ax.ToString() + " ms";

                //cursor B X axis
                if ((display_cursor_value_bx < 1) && (display_cursor_value_bx > -1)) cursor_bx.Text = (display_cursor_value_bx * 1000).ToString() + " us";
                else cursor_bx.Text = display_cursor_value_bx.ToString() + " ms";

                //cursor A Y axis
                if ((display_cursor_value_ay < 1)&&(display_cursor_value_ay > -1)) cursor_ay.Text = Math.Round((display_cursor_value_ay * 1000),3).ToString() + " mV";
                else cursor_ay.Text = Math.Round(display_cursor_value_ay,3).ToString() + " V";

                //cursor B X axis
                if ((display_cursor_value_by < 1) && (display_cursor_value_by > -1)) cursor_by.Text = (display_cursor_value_by * 1000).ToString() + " mV";
                else cursor_by.Text = display_cursor_value_by.ToString() + " V";

                //cursor B A difference X axis
                if (((display_cursor_value_bx - display_cursor_value_ax) < 1)&&((display_cursor_value_bx - display_cursor_value_ax) > -1)) x_diff.Text = ((display_cursor_value_bx - display_cursor_value_ax)*1000).ToString() + " us";
                else x_diff.Text = (display_cursor_value_bx - display_cursor_value_ax).ToString() + " ms";

                //cursor B A difference Y axis
                if (((display_cursor_value_by - display_cursor_value_ay) < 1) && ((display_cursor_value_by - display_cursor_value_ay) > -1)) y_diff.Text = Math.Round(((display_cursor_value_by - display_cursor_value_ay) * 1000),3).ToString() + " mV";
                else y_diff.Text = Math.Round((display_cursor_value_by - display_cursor_value_ay),3).ToString() + " V";

                //cursor B A difference X axis -> frequency
                if (Math.Abs(1 / (display_cursor_value_bx - display_cursor_value_ax)) > 1) freq.Text = Math.Round(Math.Abs(1 / (display_cursor_value_bx - display_cursor_value_ax)),3).ToString() + " kHz";
                else freq.Text = Math.Round(Math.Abs(1 / (display_cursor_value_bx - display_cursor_value_ax)*1000), 1).ToString() + " Hz";
            }

            //draw the graph from buffer
            if (data_ready == true)
            {
                data_ready = false;
                PointPairList pointPairs = new PointPairList();

                for (int i = 0; i < buffer.Length; i++)
                {

                    //buffer[i] = Math.Sin(i * Math.PI / 180.0);
                    buffer[i] = buffer[i] / 4094.0;
                    buffer[i] = buffer[i] * 5.0;
                    buffer[i] = buffer[i] - 2.5;
                    double x = i - buffer.Length / 2;
                    double y;
                    
                    //add voltage offset and probe control
                    if (probe_div.Text == "1X") y = buffer[i] + (Convert.ToDouble(voltage_offset_track.Value) / 100.0);
                    else y = 10 * buffer[i] + (Convert.ToDouble(voltage_offset_track.Value) / 100.0);
                    //PointPair pointPair = new PointPair(x, y);

                    pointPairs.Add(x, y);

                }

                zedGraphControl1.GraphPane.CurveList.Clear();

                LineItem lineItem = graphPane.AddCurve("Sin Curve", pointPairs, Color.Yellow, SymbolType.None);
                lineItem.Line.Width = 2;
                lineItem.Line.IsSmooth = false;

                /*
                //send control packet function
                //reset buff pointer
                 */
                
            }
            
            zedGraphControl1.AxisChange();
            zedGraphControl1.Refresh();

            //calculate avg min and max value
            max_value.Text = Math.Round(buffer.Max(),2).ToString() + " V";
            min_value.Text = Math.Round(buffer.Min(),2).ToString() + " V";
            avg_value.Text = Math.Round(buffer.Average(),2).ToString() + " V";
            
        }

        //set the coupling AC/DC
        private void coupling_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (coupling.Text == "DC") ac_dc = false;
            else ac_dc = true;
        }


        //modify trigger line
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            graphPane.GraphObjList.Clear();

            trigger_lvl.Text = (Convert.ToDouble(trackBar1.Value)/100.0).ToString() + " V";
            double trsh_y =  Convert.ToDouble(trackBar1.Value)/100.0;

            trs_line = new LineObj(Color.Orange, graphPane.XAxis.Scale.Min, trsh_y, graphPane.XAxis.Scale.Max, trsh_y);
            trs_line.Line.Style = System.Drawing.Drawing2D.DashStyle.Dash;
            graphPane.GraphObjList.Add(trs_line);
            trigger_line_delete_delay = 30;
        }

        //add voltage offset
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            voltage_offset.Text = (Convert.ToDouble(voltage_offset_track.Value) / 100.0).ToString() + " V";
        }

        //set higher voltage div
        private void volt_div_down_Click(object sender, EventArgs e)
        {
            if (volt_divs_pointer < volt_divs.Length - 1) volt_divs_pointer++;
            if (volt_divs[volt_divs_pointer] < 1) voltage_div.Text = (volt_divs[volt_divs_pointer] * 1000).ToString() + " mV/div";
            else voltage_div.Text = volt_divs[volt_divs_pointer].ToString() + " V/div";
            zedGraphControl1.GraphPane.YAxis.Scale.Min = -4 * volt_divs[volt_divs_pointer];
            zedGraphControl1.GraphPane.YAxis.Scale.Max =  4 * volt_divs[volt_divs_pointer];
            graphPane.YAxis.Scale.MajorStep = volt_divs[volt_divs_pointer];
            zedGraphControl1.Refresh();

        }

        //set lower voltage div
        private void volt_div_up_Click(object sender, EventArgs e)
        {
            if (volt_divs_pointer > 0) volt_divs_pointer--;
            if (volt_divs[volt_divs_pointer] < 1) voltage_div.Text = (volt_divs[volt_divs_pointer] * 1000).ToString() + " mV/div";
            else voltage_div.Text = volt_divs[volt_divs_pointer].ToString() + " V/div";
            zedGraphControl1.GraphPane.YAxis.Scale.Min = -4 * volt_divs[volt_divs_pointer];
            zedGraphControl1.GraphPane.YAxis.Scale.Max = 4 * volt_divs[volt_divs_pointer];
            graphPane.YAxis.Scale.MajorStep = volt_divs[volt_divs_pointer];
            zedGraphControl1.Refresh();
        }

        //set higher time div
        private void time_div_down_Click(object sender, EventArgs e)
        {
            if (time_divs_pointer < time_divs.Length - 1) time_divs_pointer++;
            if (time_divs[time_divs_pointer] < 1.0) time_div.Text = (time_divs[time_divs_pointer] * 1000).ToString() + " us/div";
            else time_div.Text = (time_divs[time_divs_pointer]).ToString() + " ms/div";

            //set buffer size
            switch (time_divs[time_divs_pointer]) 
            {
                case 0.05:
                    sampling_rate_div = 1;
                    break;
                case 0.10:
                    sampling_rate_div = 2;
                    break;
                case 0.20:
                    sampling_rate_div = 4;
                    break;
                case 0.50:
                    sampling_rate_div = 10;
                    break;
                case 1.00:
                    sampling_rate_div = 20;
                    break;
                case 2.00:
                    sampling_rate_div = 40;
                    break;
                case 5.00:
                    sampling_rate_div = 100;
                    break;
                case 10.0:
                    sampling_rate_div = 200;
                    break;
                case 20.0:
                    sampling_rate_div = 400;
                    break;
                case 50.0:
                    sampling_rate_div = 1000;
                    break;
                case 100.0:
                    sampling_rate_div = 2000;
                    break;
                case 200.0:
                    sampling_rate_div = 4000;
                    break;
                case 500.0:
                    sampling_rate_div = 10000;
                    break;
            }

            zedGraphControl1.GraphPane.XAxis.Scale.Min = -1 * (buffer.Length / 2);
            zedGraphControl1.GraphPane.XAxis.Scale.Max = 1 * (buffer.Length / 2);
            graphPane.XAxis.Scale.MajorStep = buffer.Length / 12;
        }

        //set lower time div
        private void time_div_up_Click(object sender, EventArgs e)
        {
            if (time_divs_pointer > 0) time_divs_pointer--;
            if (time_divs[time_divs_pointer] < 1.0) time_div.Text = (time_divs[time_divs_pointer] * 1000).ToString() + " us/div";
            else time_div.Text = (time_divs[time_divs_pointer]).ToString() + " ms/div";
            
            //set buffer size
            switch (time_divs[time_divs_pointer])
            {
                case 0.05:
                    sampling_rate_div = 1;
                    break;
                case 0.10:
                    sampling_rate_div = 2;
                    break;
                case 0.20:
                    sampling_rate_div = 4;
                    break;
                case 0.50:
                    sampling_rate_div = 10;
                    break;
                case 1.00:
                    sampling_rate_div = 20;
                    break;
                case 2.00:
                    sampling_rate_div = 40;
                    break;
                case 5.00:
                    sampling_rate_div = 100;
                    break;
                case 10.0:
                    sampling_rate_div = 200;
                    break;
                case 20.0:
                    sampling_rate_div = 400;
                    break;
                case 50.0:
                    sampling_rate_div = 1000;
                    break;
                case 100.0:
                    sampling_rate_div = 2000;
                    break;
                case 200.0:
                    sampling_rate_div = 4000;
                    break;
                case 500.0:

                    sampling_rate_div = 10000;
                    break;
            }

            zedGraphControl1.GraphPane.XAxis.Scale.Min = -1 * (buffer.Length / 2);
            zedGraphControl1.GraphPane.XAxis.Scale.Max = 1 * (buffer.Length / 2);
            graphPane.XAxis.Scale.MajorStep = buffer.Length / 12;
        }

        //enable cursor
        private void cursor_enable_CheckedChanged(object sender, EventArgs e)
        {
            //enable/disable cursor controls
            if (cursor_enable.Checked)
            {
                cursor_panel.Visible = true;
                cursor_a_b.Enabled = true;
                cursor_select_axix.Enabled = true;
                cursor_value.Enabled = true;

            }
            else 
            {
                cursor_panel.Visible = false;
                cursor_a_b.Enabled = false;
                cursor_select_axix.Enabled = false;
                cursor_value.Enabled = false;
                graphPane.GraphObjList.Clear();
            }
        }

        private void com_conn_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serialPort1.BaudRate = 115200;
                serialPort1.DataBits = 8;
                serialPort1.StopBits = System.IO.Ports.StopBits.One;
                serialPort1.Parity = System.IO.Ports.Parity.None;
                serialPort1.Handshake = System.IO.Ports.Handshake.None;
                serialPort1.ReceivedBytesThreshold = 2; //1 packet contains 2 bytes
                serialPort1.PortName = com_port_list.Text;
                serialPort1.Open();
                //serialPort1.Write("0");
                com_conn.Text = "Disconnect";
            }
            else 
            {
                com_conn.Text = "Connect";
                serialPort1.Close();
            }
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                if (buff_pointer < buffer.Length - 1)
                {

                    int temp = serialPort1.ReadByte();
                    temp = temp << 8;
                    temp = temp | serialPort1.ReadByte();
                    buffer[buff_pointer] = Convert.ToDouble(temp);
                    buff_pointer++;
                    serialPort1.DiscardInBuffer();
                }
                else
                {
                    buff_pointer = 0;
                    data_ready = true;
                }
            }
            catch (Exception ex){ MessageBox.Show(ex.Message); }
            

        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(serialPort1.IsOpen)serialPort1.Close();
        }

        private void print_screen_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            //select the file path to save picture
            saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveFileDialog1.DefaultExt = "png";
            saveFileDialog1.Filter = "png files (*.png)|*.png|All files (*.*)|*.*";
            saveFileDialog1.ShowDialog();
            
            //set the cursor value to back for print
            cursor_panel.SendToBack();
            panel1.SendToBack();

            //create and save the picture
            Bitmap bmp = new Bitmap(save_graph.Width,save_graph.Height);
            save_graph.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
            bmp.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Png);

            //reset the cursor value from print
            cursor_panel.BringToFront();
            panel1.BringToFront();

            timer1.Enabled = true;
        }

        //select A/B cursor
        private void cursor_a_b_Click(object sender, EventArgs e)
        {
            if (cursor_a_b.Text == "CursorA") cursor_a_b.Text = "CursorB";
            else cursor_a_b.Text = "CursorA";
        }

        private void trigger_select_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (trigger_select.Text == "Rising") rising = true;
            else rising = false;
        }

        //select axis
        private void cursor_select_axix_Click(object sender, EventArgs e)
        {
            if (cursor_select_axix.Text == "| |") cursor_select_axix.Text = "==";
            else cursor_select_axix.Text = "| |";
        }

        //modify cursor value
        private void cursor_value_Scroll(object sender, EventArgs e)
        {
            if (cursor_select_axix.Text == "| |")
            {
                cursor_value.Minimum = -1 * (buffer.Length / 2);
                cursor_value.Maximum = 1 * (buffer.Length / 2);

                if (cursor_a_b.Text == "CursorA") cursor_ax_value = Convert.ToDouble(cursor_value.Value);
                else cursor_bx_value = Convert.ToDouble(cursor_value.Value);
            }
            else 
            {
                cursor_value.Minimum = Convert.ToInt32(graphPane.YAxis.Scale.Min)*1000;
                cursor_value.Maximum = Convert.ToInt32(graphPane.YAxis.Scale.Max)*1000;

                if (cursor_a_b.Text == "CursorA") cursor_ay_value = Convert.ToDouble(cursor_value.Value)/1000;
                else cursor_by_value = Convert.ToDouble(cursor_value.Value)/1000;
            }
        }

        private void Control_message() 
        {
            int cntrl = 0;

            byte[] cntrl_to_serial = new byte[3];

            if (rising == false) cntrl++;

            cntrl = cntrl << 1;

            if (timer1.Enabled) cntrl++;

            cntrl = cntrl << 4;

            switch (sampling_rate_div) 
            {
                case 1: 
                    cntrl = cntrl + 0b0000;
                    break;

                case 2:
                    cntrl = cntrl + 0b0001;
                    break;

                case 4:
                    cntrl = cntrl + 0b0010;
                    break;

                case 10:
                    cntrl = cntrl + 0b0011;
                    break;

                case 20:
                    cntrl = cntrl + 0b0100;
                    break;

                case 40:
                    cntrl = cntrl + 0b0101;
                    break;

                case 100:
                    cntrl = cntrl + 0b0110;
                    break;

                case 200:
                    cntrl = cntrl + 0b0111;
                    break;

                case 400:
                    cntrl = cntrl + 0b1000;
                    break;

                case 1000:
                    cntrl = cntrl + 0b1001;
                    break;

                case 2000:
                    cntrl = cntrl + 0b1010;
                    break;

                case 4000:
                    cntrl = cntrl + 0b1011;
                    break;
                case 10000:
                    cntrl = cntrl + 0b1100;
                    break;
            }
            

            cntrl = cntrl << 1;

            if (ac_dc == true) cntrl = cntrl + 0b01;
            else cntrl = cntrl + 0b00;

            cntrl_to_serial[0] = (byte)cntrl;

            //debug.Text = Convert.ToString(cntrl_to_serial[2], 2).PadLeft(8,'0') + "   " + Convert.ToString(cntrl_to_serial[2], 2).Length;
            //debug.Text = trackBar1.Value.ToString();
            cntrl = 0;
            double trigg;

            if (probe_div.Text == "1X") 
            {
                trigg = trackBar1.Value / 100.0;
                trigg = (trigg + 2.5) / 5.0;
                trigg = trigg * 4094;
                //debug.Text = trigg.ToString();
            }
            else 
            {
                trigg = trackBar1.Value / 100.0;
                trigg = (trigg + 25) / 50;
                trigg = trigg * 4094;
                //debug.Text = trigg.ToString();
            }

            cntrl = Convert.ToInt32(trigg);

            if (cntrl < 0) cntrl = 0;
            if (cntrl > 4095) cntrl = 4095;

            if (rising == false) cntrl = cntrl | 0b1111000000000000;
            //debug2.Text = buffer[buff_pointer].ToString();
            byte[] temp = BitConverter.GetBytes(cntrl);

            cntrl_to_serial[1] = temp[0];
            cntrl_to_serial[2] = temp[1];

            
            //debug.Text = buff_pointer.ToString();
            if (serialPort1.IsOpen) 
            {
                /*serialPort1.Write(cntrl_to_serial, 2, 1);
                serialPort1.DiscardOutBuffer();
                serialPort1.Write(cntrl_to_serial, 0, 1);
                serialPort1.DiscardOutBuffer();
                serialPort1.Write(cntrl_to_serial, 1, 1);
                */
                serialPort1.Write(cntrl_to_serial, 0, cntrl_to_serial.Length);
            }
       
        }
    }
}
