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
        GraphPane graphPane;
        double[] buffer;
        
        //volt divs in [V]
        double[] volt_divs = new double[9] { 0.01, 0.02, 0.05, 0.1, 0.2, 0.5, 1, 2, 5 };
        int volt_divs_pointer = 6;

        //time divs in [ms]
        double[] time_divs = new double[15] {0.01, 0.02, 0.05, 0.10, 0.20, 0.50, 1,2,5,10,20,5,100,200,500 };
        int time_divs_pointer = 7;

        //sampling rate div
        int sampling_rate_div = 1;

        bool rising = true;

        public Form1()
        {
            InitializeComponent();


            graphPane = zedGraphControl1.GraphPane;
            graphPane.Title.IsVisible = true;
            graphPane.Chart.Fill = new Fill(Color.Black);
            graphPane.XAxis.Color = Color.White;
            graphPane.XAxis.MajorGrid.IsVisible = true;
            graphPane.XAxis.MajorGrid.Color = Color.White;
            graphPane.XAxis.Scale.IsVisible = false;
            graphPane.XAxis.Title.IsVisible = false;
            graphPane.YAxis.MajorGrid.IsVisible = true;
            graphPane.YAxis.MajorGrid.Color = Color.White;
            graphPane.YAxis.Color = Color.White;
            graphPane.YAxis.Scale.IsVisible = false;
            graphPane.YAxis.Title.IsVisible = false;


            //Voltage dim set for startup (1V/div)
            if (volt_divs[volt_divs_pointer] < 1) voltage_div.Text = (volt_divs[volt_divs_pointer] * 1000).ToString() + " mV/div";
            else voltage_div.Text = volt_divs[volt_divs_pointer].ToString() + " V/div";
            zedGraphControl1.GraphPane.YAxis.Scale.Min = -4 * volt_divs[volt_divs_pointer];
            zedGraphControl1.GraphPane.YAxis.Scale.Max = 4 * volt_divs[volt_divs_pointer];
            graphPane.YAxis.Scale.MajorStep = volt_divs[volt_divs_pointer];

            //time div set 1ms/divs
            buffer = new double[12000];
            zedGraphControl1.GraphPane.XAxis.Scale.Min = -1 * (buffer.Length / 2);
            zedGraphControl1.GraphPane.XAxis.Scale.Max =  1 * (buffer.Length / 2);
            graphPane.XAxis.Scale.MajorStep = buffer.Length / 12;

            graphPane.Legend.IsVisible = false;

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
                buffer[i] = rnd.NextDouble();
                double x = i;
                double y = buffer[i];
                PointPair pointPair = new PointPair(x, y);

                pointPairs.Add(pointPair);
            }

            
            LineItem lineItem = graphPane.AddCurve("Sin Curve", pointPairs, Color.Red, SymbolType.None);
            zedGraphControl1.AxisChange();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            timer1.Enabled = !timer1.Enabled;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            PointPairList pointPairs = new PointPairList();
            

            for (int i = 0; i < buffer.Length; i++)
            {
                if(i % sampling_rate_div == 0) buffer[i] = Math.Sin(i * Math.PI / 180);
                
                double x = i - buffer.Length/2;
                double y;

                //add voltage offset and probe control
                if (probe_div.Text == "1X") y = buffer[i] + (Convert.ToDouble(voltage_offset_track.Value) / 100.0);
                else y = 10 * buffer[i] + (Convert.ToDouble(voltage_offset_track.Value) / 100.0);
                //PointPair pointPair = new PointPair(x, y);

                pointPairs.Add(x,y);
            
            }

            zedGraphControl1.GraphPane.CurveList.Clear();

            LineItem lineItem = graphPane.AddCurve("Sin Curve", pointPairs, Color.Yellow, SymbolType.None);
            zedGraphControl1.AxisChange();

            zedGraphControl1.Refresh();
        }

        private void coupling_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (coupling.Text == "Rising") rising = true;
            else rising = false;
        }



        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            trigger_lvl.Text = (Convert.ToDouble(trackBar1.Value)/100.0).ToString() + " V";


        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            voltage_offset.Text = (Convert.ToDouble(voltage_offset_track.Value) / 100.0).ToString() + " V";
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        //set higher  voltage divison
        private void volt_div_up_Click(object sender, EventArgs e)
        {
            if (volt_divs_pointer < 8) volt_divs_pointer++;
            if (volt_divs[volt_divs_pointer] < 1) voltage_div.Text = (volt_divs[volt_divs_pointer] * 1000).ToString() + " mV/div";
            else voltage_div.Text = volt_divs[volt_divs_pointer].ToString() + " V/div";
            zedGraphControl1.GraphPane.YAxis.Scale.Min = -4 * volt_divs[volt_divs_pointer];
            zedGraphControl1.GraphPane.YAxis.Scale.Max =  4 * volt_divs[volt_divs_pointer];
            graphPane.YAxis.Scale.MajorStep = volt_divs[volt_divs_pointer];
            zedGraphControl1.Refresh();

        }

        //set lower  voltage divison
        private void volt_div_down_Click(object sender, EventArgs e)
        {
            if (volt_divs_pointer > 0) volt_divs_pointer--;
            if (volt_divs[volt_divs_pointer] < 1) voltage_div.Text = (volt_divs[volt_divs_pointer] * 1000).ToString() + " mV/div";
            else voltage_div.Text = volt_divs[volt_divs_pointer].ToString() + " V/div";
            zedGraphControl1.GraphPane.YAxis.Scale.Min = -4 * volt_divs[volt_divs_pointer];
            zedGraphControl1.GraphPane.YAxis.Scale.Max = 4 * volt_divs[volt_divs_pointer];
            graphPane.YAxis.Scale.MajorStep = volt_divs[volt_divs_pointer];
            zedGraphControl1.Refresh();

        }

        private void time_div_up_Click(object sender, EventArgs e)
        {
            if (time_divs_pointer < 14) time_divs_pointer++;
            if (time_divs[time_divs_pointer] < 1.0) time_div.Text = (time_divs[time_divs_pointer] * 1000).ToString() + " us/div";
            else time_div.Text = (time_divs[time_divs_pointer]).ToString() + " ms/div";

            switch (time_divs[time_divs_pointer]) 
            {
                case 0.01:  buffer = new double[120];
                    break;
                case 0.02:
                    buffer = new double[240];
                    sampling_rate_div = 1;
                    break;
                case 0.05:
                    buffer = new double[600];
                    sampling_rate_div = 1;
                    break;
                case 0.10:
                    buffer = new double[1200];
                    sampling_rate_div = 1;
                    break;
                case 0.20:
                    buffer = new double[2400];
                    sampling_rate_div = 1;
                    break;
                case 0.50:
                    buffer = new double[6000];
                    sampling_rate_div = 1;
                    break;
                case 1.00:
                    buffer = new double[12000];
                    sampling_rate_div = 1;
                    break;
                case 2.00:
                    buffer = new double[12000];
                    sampling_rate_div = 2;
                    break;
                case 5.00:
                    buffer = new double[12000];
                    sampling_rate_div = 5;
                    break;
                case 10.0:
                    buffer = new double[12000];
                    sampling_rate_div = 10;
                    break;
                case 20.0:
                    buffer = new double[12000];
                    sampling_rate_div = 20;
                    break;
                case 50.0:
                    buffer = new double[12000];
                    sampling_rate_div = 50;
                    break;
                case 100.0:
                    buffer = new double[12000];
                    sampling_rate_div = 100;
                    break;
                case 200.0:
                    buffer = new double[12000];
                    sampling_rate_div = 200;
                    break;
                case 500.0:
                    buffer = new double[12000];
                    sampling_rate_div = 500;
                    break;
            }

            zedGraphControl1.GraphPane.XAxis.Scale.Min = -1 * (buffer.Length / 2);
            zedGraphControl1.GraphPane.XAxis.Scale.Max = 1 * (buffer.Length / 2);
            graphPane.XAxis.Scale.MajorStep = buffer.Length / 12;
        }

        private void time_div_down_Click(object sender, EventArgs e)
        {
            if (time_divs_pointer > 0) time_divs_pointer--;
            if (time_divs[time_divs_pointer] < 1.0) time_div.Text = (time_divs[time_divs_pointer] * 1000).ToString() + " us/div";
            else time_div.Text = (time_divs[time_divs_pointer]).ToString() + " ms/div";

            switch (time_divs[time_divs_pointer])
            {
                case 0.01:
                    buffer = new double[120];
                    break;
                case 0.02:
                    buffer = new double[240];
                    sampling_rate_div = 1;
                    break;
                case 0.05:
                    buffer = new double[600];
                    sampling_rate_div = 1;
                    break;
                case 0.10:
                    buffer = new double[1200];
                    sampling_rate_div = 1;
                    break;
                case 0.20:
                    buffer = new double[2400];
                    sampling_rate_div = 1;
                    break;
                case 0.50:
                    buffer = new double[6000];
                    sampling_rate_div = 1;
                    break;
                case 1.00:
                    buffer = new double[12000];
                    sampling_rate_div = 1;
                    break;
                case 2.00:
                    buffer = new double[12000];
                    sampling_rate_div = 2;
                    break;
                case 5.00:
                    buffer = new double[12000];
                    sampling_rate_div = 5;
                    break;
                case 10.0:
                    buffer = new double[12000];
                    sampling_rate_div = 10;
                    break;
                case 20.0:
                    buffer = new double[12000];
                    sampling_rate_div = 20;
                    break;
                case 50.0:
                    buffer = new double[12000];
                    sampling_rate_div = 50;
                    break;
                case 100.0:
                    buffer = new double[12000];
                    sampling_rate_div = 100;
                    break;
                case 200.0:
                    buffer = new double[12000];
                    sampling_rate_div = 200;
                    break;
                case 500.0:
                    buffer = new double[12000];
                    sampling_rate_div = 500;
                    break;
            }

            zedGraphControl1.GraphPane.XAxis.Scale.Min = -1 * (buffer.Length / 2);
            zedGraphControl1.GraphPane.XAxis.Scale.Max = 1 * (buffer.Length / 2);
            graphPane.XAxis.Scale.MajorStep = buffer.Length / 12;
        }
    }
}
