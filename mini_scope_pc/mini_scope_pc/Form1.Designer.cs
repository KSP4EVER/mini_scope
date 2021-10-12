
namespace mini_scope_pc
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.coupling = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.min_value = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.max_value = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.avg_value = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.trigger_lvl = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.probe_div = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.voltage_offset = new System.Windows.Forms.Label();
            this.voltage_offset_track = new System.Windows.Forms.TrackBar();
            this.label15 = new System.Windows.Forms.Label();
            this.volt_div_up = new System.Windows.Forms.Button();
            this.volt_div_down = new System.Windows.Forms.Button();
            this.time_div_down = new System.Windows.Forms.Button();
            this.time_div_up = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.time_div = new System.Windows.Forms.Label();
            this.voltage_div = new System.Windows.Forms.Label();
            this.cursor_enable = new System.Windows.Forms.CheckBox();
            this.cursor_value = new System.Windows.Forms.TrackBar();
            this.cursor_a_b = new System.Windows.Forms.Button();
            this.cursor_select_axix = new System.Windows.Forms.Button();
            this.x_diff = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cursor_bx = new System.Windows.Forms.Label();
            this.cursor_bx_text = new System.Windows.Forms.Label();
            this.cursor_ax = new System.Windows.Forms.Label();
            this.cursor_ax_text = new System.Windows.Forms.Label();
            this.cursor_by = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cursor_ay = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.y_diff = new System.Windows.Forms.Label();
            this.freq = new System.Windows.Forms.Label();
            this.cursor_panel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.com_conn = new System.Windows.Forms.Button();
            this.com_port_list = new System.Windows.Forms.ComboBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.voltage_offset_track)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cursor_value)).BeginInit();
            this.cursor_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.BackColor = System.Drawing.Color.Black;
            this.zedGraphControl1.Location = new System.Drawing.Point(0, 14);
            this.zedGraphControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(582, 360);
            this.zedGraphControl1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(588, 8);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(204, 47);
            this.button1.TabIndex = 1;
            this.button1.Text = "Run/Stop";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 30;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(588, 151);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ch1";
            // 
            // coupling
            // 
            this.coupling.FormattingEnabled = true;
            this.coupling.Items.AddRange(new object[] {
            "DC",
            "AC"});
            this.coupling.Location = new System.Drawing.Point(642, 202);
            this.coupling.Margin = new System.Windows.Forms.Padding(2);
            this.coupling.Name = "coupling";
            this.coupling.Size = new System.Drawing.Size(82, 21);
            this.coupling.TabIndex = 3;
            this.coupling.Text = "DC";
            this.coupling.SelectedIndexChanged += new System.EventHandler(this.coupling_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(588, 204);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Coupling:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 376);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Min:";
            // 
            // min_value
            // 
            this.min_value.AutoSize = true;
            this.min_value.Location = new System.Drawing.Point(54, 376);
            this.min_value.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.min_value.Name = "min_value";
            this.min_value.Size = new System.Drawing.Size(26, 13);
            this.min_value.TabIndex = 6;
            this.min_value.Text = "Ch1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(97, 376);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Max:";
            // 
            // max_value
            // 
            this.max_value.AutoSize = true;
            this.max_value.Location = new System.Drawing.Point(129, 376);
            this.max_value.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.max_value.Name = "max_value";
            this.max_value.Size = new System.Drawing.Size(26, 13);
            this.max_value.TabIndex = 8;
            this.max_value.Text = "Ch1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(162, 376);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Avg:";
            // 
            // avg_value
            // 
            this.avg_value.AutoSize = true;
            this.avg_value.Location = new System.Drawing.Point(195, 376);
            this.avg_value.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.avg_value.Name = "avg_value";
            this.avg_value.Size = new System.Drawing.Size(26, 13);
            this.avg_value.TabIndex = 10;
            this.avg_value.Text = "Ch1";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(588, 235);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Tigger:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Rising",
            "Falling"});
            this.comboBox1.Location = new System.Drawing.Point(642, 233);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(82, 21);
            this.comboBox1.TabIndex = 12;
            this.comboBox1.Text = "Rising";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(588, 272);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "Tigger level:";
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 10;
            this.trackBar1.Location = new System.Drawing.Point(591, 300);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(2);
            this.trackBar1.Maximum = 2500;
            this.trackBar1.Minimum = -2500;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(204, 45);
            this.trackBar1.TabIndex = 15;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // trigger_lvl
            // 
            this.trigger_lvl.AutoSize = true;
            this.trigger_lvl.Location = new System.Drawing.Point(653, 272);
            this.trigger_lvl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.trigger_lvl.Name = "trigger_lvl";
            this.trigger_lvl.Size = new System.Drawing.Size(23, 13);
            this.trigger_lvl.TabIndex = 16;
            this.trigger_lvl.Text = "0 V";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(588, 174);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 13);
            this.label11.TabIndex = 18;
            this.label11.Text = "Probe:";
            // 
            // probe_div
            // 
            this.probe_div.FormattingEnabled = true;
            this.probe_div.Items.AddRange(new object[] {
            "1X",
            "10X"});
            this.probe_div.Location = new System.Drawing.Point(642, 171);
            this.probe_div.Margin = new System.Windows.Forms.Padding(2);
            this.probe_div.Name = "probe_div";
            this.probe_div.Size = new System.Drawing.Size(82, 21);
            this.probe_div.TabIndex = 17;
            this.probe_div.Text = "1X";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(588, 72);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 13);
            this.label12.TabIndex = 19;
            this.label12.Text = "Time Div";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(588, 118);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(62, 13);
            this.label13.TabIndex = 20;
            this.label13.Text = "Voltage Div";
            // 
            // voltage_offset
            // 
            this.voltage_offset.AutoSize = true;
            this.voltage_offset.Location = new System.Drawing.Point(667, 336);
            this.voltage_offset.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.voltage_offset.Name = "voltage_offset";
            this.voltage_offset.Size = new System.Drawing.Size(23, 13);
            this.voltage_offset.TabIndex = 23;
            this.voltage_offset.Text = "0 V";
            // 
            // voltage_offset_track
            // 
            this.voltage_offset_track.LargeChange = 10;
            this.voltage_offset_track.Location = new System.Drawing.Point(591, 364);
            this.voltage_offset_track.Margin = new System.Windows.Forms.Padding(2);
            this.voltage_offset_track.Maximum = 2500;
            this.voltage_offset_track.Minimum = -2500;
            this.voltage_offset_track.Name = "voltage_offset_track";
            this.voltage_offset_track.Size = new System.Drawing.Size(204, 45);
            this.voltage_offset_track.TabIndex = 22;
            this.voltage_offset_track.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(588, 336);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(75, 13);
            this.label15.TabIndex = 21;
            this.label15.Text = "Voltage offset:";
            // 
            // volt_div_up
            // 
            this.volt_div_up.Location = new System.Drawing.Point(670, 108);
            this.volt_div_up.Name = "volt_div_up";
            this.volt_div_up.Size = new System.Drawing.Size(54, 33);
            this.volt_div_up.TabIndex = 24;
            this.volt_div_up.Text = "+";
            this.volt_div_up.UseVisualStyleBackColor = true;
            this.volt_div_up.Click += new System.EventHandler(this.volt_div_up_Click);
            // 
            // volt_div_down
            // 
            this.volt_div_down.Location = new System.Drawing.Point(730, 108);
            this.volt_div_down.Name = "volt_div_down";
            this.volt_div_down.Size = new System.Drawing.Size(54, 33);
            this.volt_div_down.TabIndex = 25;
            this.volt_div_down.Text = "-";
            this.volt_div_down.UseVisualStyleBackColor = true;
            this.volt_div_down.Click += new System.EventHandler(this.volt_div_down_Click);
            // 
            // time_div_down
            // 
            this.time_div_down.Location = new System.Drawing.Point(730, 62);
            this.time_div_down.Name = "time_div_down";
            this.time_div_down.Size = new System.Drawing.Size(54, 33);
            this.time_div_down.TabIndex = 27;
            this.time_div_down.Text = "-";
            this.time_div_down.UseVisualStyleBackColor = true;
            this.time_div_down.Click += new System.EventHandler(this.time_div_down_Click);
            // 
            // time_div_up
            // 
            this.time_div_up.Location = new System.Drawing.Point(670, 62);
            this.time_div_up.Name = "time_div_up";
            this.time_div_up.Size = new System.Drawing.Size(54, 33);
            this.time_div_up.TabIndex = 26;
            this.time_div_up.Text = "+";
            this.time_div_up.UseVisualStyleBackColor = true;
            this.time_div_up.Click += new System.EventHandler(this.time_div_up_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.time_div);
            this.panel1.Controls.Add(this.voltage_div);
            this.panel1.Location = new System.Drawing.Point(12, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(556, 18);
            this.panel1.TabIndex = 28;
            // 
            // time_div
            // 
            this.time_div.AutoSize = true;
            this.time_div.Location = new System.Drawing.Point(74, 0);
            this.time_div.Name = "time_div";
            this.time_div.Size = new System.Drawing.Size(41, 13);
            this.time_div.TabIndex = 1;
            this.time_div.Text = "label14";
            // 
            // voltage_div
            // 
            this.voltage_div.AutoSize = true;
            this.voltage_div.Location = new System.Drawing.Point(0, 0);
            this.voltage_div.Name = "voltage_div";
            this.voltage_div.Size = new System.Drawing.Size(41, 13);
            this.voltage_div.TabIndex = 0;
            this.voltage_div.Text = "label14";
            // 
            // cursor_enable
            // 
            this.cursor_enable.AutoSize = true;
            this.cursor_enable.Location = new System.Drawing.Point(591, 414);
            this.cursor_enable.Name = "cursor_enable";
            this.cursor_enable.Size = new System.Drawing.Size(56, 17);
            this.cursor_enable.TabIndex = 29;
            this.cursor_enable.Text = "Cursor";
            this.cursor_enable.UseVisualStyleBackColor = true;
            this.cursor_enable.CheckedChanged += new System.EventHandler(this.cursor_enable_CheckedChanged);
            // 
            // cursor_value
            // 
            this.cursor_value.LargeChange = 10;
            this.cursor_value.Location = new System.Drawing.Point(591, 450);
            this.cursor_value.Margin = new System.Windows.Forms.Padding(2);
            this.cursor_value.Maximum = 2500;
            this.cursor_value.Minimum = -2500;
            this.cursor_value.Name = "cursor_value";
            this.cursor_value.Size = new System.Drawing.Size(204, 45);
            this.cursor_value.TabIndex = 30;
            this.cursor_value.Scroll += new System.EventHandler(this.cursor_value_Scroll);
            // 
            // cursor_a_b
            // 
            this.cursor_a_b.Location = new System.Drawing.Point(649, 410);
            this.cursor_a_b.Name = "cursor_a_b";
            this.cursor_a_b.Size = new System.Drawing.Size(75, 23);
            this.cursor_a_b.TabIndex = 31;
            this.cursor_a_b.Text = "CursorA";
            this.cursor_a_b.UseVisualStyleBackColor = true;
            this.cursor_a_b.Click += new System.EventHandler(this.cursor_a_b_Click);
            // 
            // cursor_select_axix
            // 
            this.cursor_select_axix.Location = new System.Drawing.Point(730, 410);
            this.cursor_select_axix.Name = "cursor_select_axix";
            this.cursor_select_axix.Size = new System.Drawing.Size(75, 23);
            this.cursor_select_axix.TabIndex = 32;
            this.cursor_select_axix.Text = "| |";
            this.cursor_select_axix.UseVisualStyleBackColor = true;
            this.cursor_select_axix.Click += new System.EventHandler(this.cursor_select_axix_Click);
            // 
            // x_diff
            // 
            this.x_diff.AutoSize = true;
            this.x_diff.Location = new System.Drawing.Point(177, 2);
            this.x_diff.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.x_diff.Name = "x_diff";
            this.x_diff.Size = new System.Drawing.Size(26, 13);
            this.x_diff.TabIndex = 38;
            this.x_diff.Text = "Ch1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(132, 2);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 37;
            this.label6.Text = "BX-AX:";
            // 
            // cursor_bx
            // 
            this.cursor_bx.AutoSize = true;
            this.cursor_bx.Location = new System.Drawing.Point(28, 26);
            this.cursor_bx.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.cursor_bx.Name = "cursor_bx";
            this.cursor_bx.Size = new System.Drawing.Size(26, 13);
            this.cursor_bx.TabIndex = 36;
            this.cursor_bx.Text = "Ch1";
            // 
            // cursor_bx_text
            // 
            this.cursor_bx_text.AutoSize = true;
            this.cursor_bx_text.Location = new System.Drawing.Point(0, 26);
            this.cursor_bx_text.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.cursor_bx_text.Name = "cursor_bx_text";
            this.cursor_bx_text.Size = new System.Drawing.Size(24, 13);
            this.cursor_bx_text.TabIndex = 35;
            this.cursor_bx_text.Text = "BX:";
            // 
            // cursor_ax
            // 
            this.cursor_ax.AutoSize = true;
            this.cursor_ax.Location = new System.Drawing.Point(28, 2);
            this.cursor_ax.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.cursor_ax.Name = "cursor_ax";
            this.cursor_ax.Size = new System.Drawing.Size(26, 13);
            this.cursor_ax.TabIndex = 34;
            this.cursor_ax.Text = "Ch1";
            // 
            // cursor_ax_text
            // 
            this.cursor_ax_text.AutoSize = true;
            this.cursor_ax_text.Location = new System.Drawing.Point(0, 2);
            this.cursor_ax_text.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.cursor_ax_text.Name = "cursor_ax_text";
            this.cursor_ax_text.Size = new System.Drawing.Size(24, 13);
            this.cursor_ax_text.TabIndex = 33;
            this.cursor_ax_text.Text = "AX:";
            // 
            // cursor_by
            // 
            this.cursor_by.AutoSize = true;
            this.cursor_by.Location = new System.Drawing.Point(28, 76);
            this.cursor_by.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.cursor_by.Name = "cursor_by";
            this.cursor_by.Size = new System.Drawing.Size(26, 13);
            this.cursor_by.TabIndex = 42;
            this.cursor_by.Text = "Ch1";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(0, 76);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(24, 13);
            this.label14.TabIndex = 41;
            this.label14.Text = "BY:";
            // 
            // cursor_ay
            // 
            this.cursor_ay.AutoSize = true;
            this.cursor_ay.Location = new System.Drawing.Point(28, 52);
            this.cursor_ay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.cursor_ay.Name = "cursor_ay";
            this.cursor_ay.Size = new System.Drawing.Size(26, 13);
            this.cursor_ay.TabIndex = 40;
            this.cursor_ay.Text = "Ch1";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(0, 52);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(24, 13);
            this.label17.TabIndex = 39;
            this.label17.Text = "AY:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(132, 26);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 43;
            this.label8.Text = "BY-AY:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(132, 52);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(36, 13);
            this.label16.TabIndex = 44;
            this.label16.Text = "1/|dx|:";
            // 
            // y_diff
            // 
            this.y_diff.AutoSize = true;
            this.y_diff.Location = new System.Drawing.Point(177, 26);
            this.y_diff.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.y_diff.Name = "y_diff";
            this.y_diff.Size = new System.Drawing.Size(26, 13);
            this.y_diff.TabIndex = 45;
            this.y_diff.Text = "Ch1";
            // 
            // freq
            // 
            this.freq.AutoSize = true;
            this.freq.Location = new System.Drawing.Point(177, 52);
            this.freq.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.freq.Name = "freq";
            this.freq.Size = new System.Drawing.Size(26, 13);
            this.freq.TabIndex = 46;
            this.freq.Text = "Ch1";
            // 
            // cursor_panel
            // 
            this.cursor_panel.Controls.Add(this.freq);
            this.cursor_panel.Controls.Add(this.y_diff);
            this.cursor_panel.Controls.Add(this.label16);
            this.cursor_panel.Controls.Add(this.label8);
            this.cursor_panel.Controls.Add(this.cursor_by);
            this.cursor_panel.Controls.Add(this.label14);
            this.cursor_panel.Controls.Add(this.cursor_ay);
            this.cursor_panel.Controls.Add(this.label17);
            this.cursor_panel.Controls.Add(this.x_diff);
            this.cursor_panel.Controls.Add(this.label6);
            this.cursor_panel.Controls.Add(this.cursor_bx);
            this.cursor_panel.Controls.Add(this.cursor_bx_text);
            this.cursor_panel.Controls.Add(this.cursor_ax);
            this.cursor_panel.Controls.Add(this.cursor_ax_text);
            this.cursor_panel.Location = new System.Drawing.Point(314, 382);
            this.cursor_panel.Name = "cursor_panel";
            this.cursor_panel.Size = new System.Drawing.Size(239, 117);
            this.cursor_panel.TabIndex = 47;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 410);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 48;
            this.label4.Text = "COM Port:";
            // 
            // com_conn
            // 
            this.com_conn.Location = new System.Drawing.Point(132, 436);
            this.com_conn.Name = "com_conn";
            this.com_conn.Size = new System.Drawing.Size(75, 23);
            this.com_conn.TabIndex = 49;
            this.com_conn.Text = "Connect";
            this.com_conn.UseVisualStyleBackColor = true;
            this.com_conn.Click += new System.EventHandler(this.com_conn_Click);
            // 
            // com_port_list
            // 
            this.com_port_list.FormattingEnabled = true;
            this.com_port_list.Location = new System.Drawing.Point(28, 436);
            this.com_port_list.Margin = new System.Windows.Forms.Padding(2);
            this.com_port_list.Name = "com_port_list";
            this.com_port_list.Size = new System.Drawing.Size(82, 21);
            this.com_port_list.TabIndex = 50;
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 506);
            this.Controls.Add(this.com_port_list);
            this.Controls.Add(this.com_conn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cursor_panel);
            this.Controls.Add(this.cursor_select_axix);
            this.Controls.Add(this.cursor_a_b);
            this.Controls.Add(this.cursor_value);
            this.Controls.Add(this.cursor_enable);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.time_div_down);
            this.Controls.Add(this.time_div_up);
            this.Controls.Add(this.volt_div_down);
            this.Controls.Add(this.volt_div_up);
            this.Controls.Add(this.voltage_offset);
            this.Controls.Add(this.voltage_offset_track);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.probe_div);
            this.Controls.Add(this.trigger_lvl);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.avg_value);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.max_value);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.min_value);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.coupling);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.zedGraphControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "MiniScope";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.voltage_offset_track)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cursor_value)).EndInit();
            this.cursor_panel.ResumeLayout(false);
            this.cursor_panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox coupling;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label min_value;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label max_value;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label avg_value;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label trigger_lvl;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox probe_div;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label voltage_offset;
        private System.Windows.Forms.TrackBar voltage_offset_track;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button volt_div_up;
        private System.Windows.Forms.Button volt_div_down;
        private System.Windows.Forms.Button time_div_down;
        private System.Windows.Forms.Button time_div_up;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label time_div;
        private System.Windows.Forms.Label voltage_div;
        private System.Windows.Forms.CheckBox cursor_enable;
        private System.Windows.Forms.TrackBar cursor_value;
        private System.Windows.Forms.Button cursor_a_b;
        private System.Windows.Forms.Button cursor_select_axix;
        private System.Windows.Forms.Label x_diff;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label cursor_bx;
        private System.Windows.Forms.Label cursor_bx_text;
        private System.Windows.Forms.Label cursor_ax;
        private System.Windows.Forms.Label cursor_ax_text;
        private System.Windows.Forms.Label cursor_by;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label cursor_ay;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label y_diff;
        private System.Windows.Forms.Label freq;
        private System.Windows.Forms.Panel cursor_panel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button com_conn;
        private System.Windows.Forms.ComboBox com_port_list;
        private System.IO.Ports.SerialPort serialPort1;
    }
}

