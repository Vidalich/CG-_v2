using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.Windows.Media;

namespace CG__v2
{
    public partial class Form1 : Form
    {
        PointF P;
        Brush blackBrush = new SolidBrush(Color.Black);
        Pen RedPen = new Pen(Color.Red);


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }

        // эллиптический цилиндр
        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = CreateGraphics();
            g.Clear(Color.FromArgb(240, 240, 240));

            float a = Convert.ToSingle(textBox1.Text.Replace(',', '.'));
            float b = Convert.ToSingle(textBox2.Text.Replace(',', '.'));

            float x0 = P.X;
            float y0 = P.Y;
            float N = 200;

            float x, y; 
            float z = 1;
            for (int k = 0; k < 500; k++, z++)
            {
                for (x = x0 - a; x <= x0 + a; x++)
                {
                    y = b * Convert.ToSingle(Math.Sqrt(1 - (x - x0) * (x - x0) / a / a)) + y0;
                    float Y = y * N / z;
                    float X = x * N / z;
                    g.FillRectangle(blackBrush, X, Y, 1, 1);
                    y = 2 * y0 - y;
                    Y = y * N / z;
                    X = x * N / z;
                    g.FillRectangle(blackBrush, X, Y, 1, 1);
                }
            }
        }

        // гиперболический цилиндр
        private void button2_Click(object sender, EventArgs e)
        {
            Graphics g = CreateGraphics();
            g.Clear(Color.FromArgb(240, 240, 240));

            float a = Convert.ToSingle(textBox3.Text.Replace('.', ','));
            float b = Convert.ToSingle(textBox4.Text.Replace('.', ','));

            float x0 = P.X;
            float y0 = P.Y;
            float N = 500;

            float x, y;
            float z = 1;

            for (int k = 0; k < 500; k++, z++)
            {
                for (x = x0 + a; x < x0 + a + 200; x++)
                {
                    y = b * Convert.ToSingle(Math.Sqrt(((x - x0) / a) * ((x - x0) / a) - 1)) + y0;
                    float X = x * N / z;
                    float Y = y * N / z;
                    g.FillRectangle(blackBrush, X, Y, 1, 1);
                    
                    X = (2 * x0 - x) * N / z;
                    g.FillRectangle(blackBrush, X, Y, 1, 1);

                    y = 2 * y0 - y;
                    Y = y * N / z;
                    X = x * N / z;
                    g.FillRectangle(blackBrush, X, Y, 1, 1);

                    X = (2 * x0 - x) * N / z;
                    g.FillRectangle(blackBrush, X, Y, 1, 1);
                }
            }
        }

        // параболический цилиндр
        private void button3_Click(object sender, EventArgs e)
        {
            Graphics g = CreateGraphics();
            g.Clear(Color.FromArgb(240, 240, 240));

            float p = Convert.ToSingle(textBox5.Text.Replace(',', '.'));

            float x0 = P.X;
            float y0 = P.Y;
            float N = 500;

            float x, y;
            float z = 1;

            for (int k = 0; k < 500; k++, z++)
                for (x = x0; x < x0 + 200; x++)
                {
                    y = Convert.ToSingle(Math.Sqrt(2 * p * (x - x0))) + y0;
                    float X = x * N / z;
                    float Y = y * N / z;
                    g.FillRectangle(blackBrush, X, Y, 1, 1);

                    y = 2 * y0 - y;
                    Y = y * N / z;
                    g.FillRectangle(blackBrush, X, Y, 1, 1);
                }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Graphics g = CreateGraphics();
            P = e.Location;
            g.FillRectangle(blackBrush, P.X, P.Y, 2, 2);
        }

        
    }
}
