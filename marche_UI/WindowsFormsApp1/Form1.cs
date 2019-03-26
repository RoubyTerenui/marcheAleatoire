using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        MarcheAleatoire walk;
        RandomGenerator generator;
        bool graphBool;
        public Form1()
        {
            generator = new RandomGenerator(13, 1073, 43215, 4294967087, 1403580, 810728);
            InitializeComponent();
            walk = new MarcheAleatoire((int)nbrFoot.Value, comboBox1.Text[0]);
            walk.walk(generator);
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.graphBool = false;
        }
        private void graph(object sender, EventArgs e)
        {
            this.graphBool = true;
            panel1.Refresh();

        }

        private void launch(object sender, EventArgs e)
        {
            walk = new MarcheAleatoire((int)nbrFoot.Value, comboBox1.Text[0]);
            this.graphBool = false;
            walk.walk(generator);
            panel1.Refresh();
        }
        private void Form1_Load(object sender, EventArgs e){}

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e){}

        private void panel1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (graphBool)
            {
                //pen0 for repere
                Pen pen0 = new Pen(Color.FromArgb(0, 0, 0));
                //pen1 for U
                Pen pen1 = new Pen(Color.FromArgb(255, 239, 0));
                //pen2 for S
                Pen pen2 = new Pen(Color.FromArgb(255, 119, 0));
                //pen3 for C
                Pen pen3 = new Pen(Color.FromArgb(0, 137, 255));

                //draw repere
                e.Graphics.DrawLine(pen0, 0, 500, 600, 500);
                e.Graphics.DrawLine(pen0, 60, 700, 60, 0);
                //echelles Y
                e.Graphics.DrawLine(pen0, 55, 400, 65, 400);
                e.Graphics.DrawLine(pen0, 55, 300, 65, 300);
                e.Graphics.DrawLine(pen0, 55, 200, 65, 200);
                e.Graphics.DrawLine(pen0, 55, 100, 65, 100);
                //echelle X
                for(int i=150; i < 700; i+=90)
                {
                    e.Graphics.DrawLine(pen0, i, 495, i, 505);
                }


                //U-marche
                double[] meanDistancetab = new double[60];
                double meanDistance = 0;
                for (int i = 1; i < 60; i++)
                {
                    walk = new MarcheAleatoire(i, 'U');
                    for (int j = 0; j < 1000; j++)
                    {
                        walk.walk(generator);
                        meanDistance += walk.PrevPositions[0].distance(walk.ActualPos);
                    }
                    meanDistancetab[i] = meanDistance/1000;
                }
                for(int i = 1; i < meanDistancetab.Length; i++)
                {
                    e.Graphics.DrawLine(pen1,
                                   60 + (i - 1) * (540 / 60),
                                   500 - Convert.ToInt64(meanDistancetab[i - 1]),
                                   60 + i * (540 / 60),
                                   500 - Convert.ToInt64(meanDistancetab[i]));
                }

                //S-marche
                double[] meanDistancetab2= new double[60];
                double meanDistance2 = 0;
                for (int i = 1; i < 60; i++)
                {
                    walk = new MarcheAleatoire(i, 'S');
                    for (int j = 0; j < 1000; j++)
                    {
                        walk.walk(generator);
                        meanDistance2 += walk.PrevPositions[0].distance(walk.ActualPos);
                    }
                    meanDistancetab2[i] = meanDistance2/1000;
                }
                for (int i = 1; i < meanDistancetab2.Length; i++)
                {
                    e.Graphics.DrawLine(pen2,
                                    60 + (i - 1) * (540 / 60),
                                    500 - Convert.ToInt64(meanDistancetab2[i - 1]) ,
                                    60 + i * (540 / 60),
                                    500 - Convert.ToInt64(meanDistancetab2[i]));
                }
                //C-marche
                double[] meanDistancetab3 = new double[60];
                double meanDistance3 = 0;
                for (int i = 1; i < 60; i++)
                {
                    walk = new MarcheAleatoire(i, 'S');
                    for (int j = 0; j < 1000; j++)
                    {
                        walk.walk(generator);
                        meanDistance3 += walk.PrevPositions[0].distance(walk.ActualPos);
                    }
                    meanDistancetab3[i] = meanDistance3/1000;
                }
                for (int i = 1; i < meanDistancetab3.Length; i++)
                {
                    e.Graphics.DrawLine(pen3,
                                    60 + (i - 1) * (540 / 60),
                                    500 - Convert.ToInt64(meanDistancetab3[i - 1]),
                                    60 + i * (540 / 60),
                                    500 - Convert.ToInt64(meanDistancetab3[i]));
                }
            }
            else
            {
                Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));
                for (int i = 0; i < walk.NbrFoot - 1; i++)
                {
                    e.Graphics.DrawLine(pen, 
                                        panel1.Height/2 + walk.PrevPositions[i].X * ((int)(40 / walk.PositionMax)), 
                                        panel1.Width/2 + walk.PrevPositions[i].Y * ((int)(40 / walk.PositionMax)),
                                        panel1.Height/2 + walk.PrevPositions[i + 1].X * ((int)(40 / walk.PositionMax)),
                                        panel1.Width/2 + walk.PrevPositions[i + 1].Y * ((int)(40 / walk.PositionMax)));
                }
                e.Graphics.DrawLine(pen,
                                    panel1.Height/2 + walk.PrevPositions[walk.NbrFoot - 1].X * ((int)(40 / walk.PositionMax)),
                                    panel1.Width/2 + walk.PrevPositions[walk.NbrFoot - 1].Y * ((int)(40 / walk.PositionMax)),
                                    panel1.Height/2 + walk.ActualPos.X * ((int)(40 / walk.PositionMax)),
                                    panel1.Width/2 + walk.ActualPos.Y * ((int)(40 / walk.PositionMax)));
            }
        }

        private void nbrFoot_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
