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
        double[] buff = new double[1024];

        public Form1()
        {
            InitializeComponent();

            graphPane = zedGraphControl1.GraphPane;
            DrawsinCurve();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void DrawsinCurve() 
        {
            PointPairList pointPairs = new PointPairList();
            Random rnd = new Random();

            for (int i = 0; i < buff.Length; i++) 
            {
                buff[i] = rnd.NextDouble();
                double x = i;
                double y = buff[i];
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
            Random rnd = new Random();

            for (int i = 0; i < buff.Length; i++)
            {
                buff[i] = Math.Sin(i * Math.PI / 180);
                double x = i - 1024/2;
                double y = buff[i];
                PointPair pointPair = new PointPair(x, y);

                pointPairs.Add(pointPair);
            }
            zedGraphControl1.Invalidate();
            zedGraphControl1.GraphPane.CurveList.Clear();
            LineItem lineItem = graphPane.AddCurve("Sin Curve", pointPairs, Color.Red, SymbolType.None);
            zedGraphControl1.AxisChange();
            zedGraphControl1.GraphPane.YAxis.Scale.Min = -1;
            zedGraphControl1.GraphPane.YAxis.Scale.Max =  1;
            zedGraphControl1.GraphPane.XAxis.Scale.Min = -512;
            zedGraphControl1.GraphPane.XAxis.Scale.Max = 512;
        }
    }
}
