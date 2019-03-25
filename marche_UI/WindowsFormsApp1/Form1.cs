﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void panel1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (graphBool)
            {
                //pen0 for repere
                Pen pen0 = new Pen(Color.FromArgb(0, 0, 0));
                //pen1 for S
                Pen pen1 = new Pen(Color.FromArgb(255, 239, 0));
                //pen2 for C
                Pen pen2 = new Pen(Color.FromArgb(255, 119, 0));
                //pen3 for U
                Pen pen3 = new Pen(Color.FromArgb(0, 137, 255));

                //draw repere
                e.Graphics.DrawLine(pen0, 0, 350, 400, 350);
                e.Graphics.DrawLine(pen0, 50, 500, 50, -700);

                //S-marche
                walk.Type = 'S';
                for (int i = 0; i < 350; i++)
                {
                    walk.walk(generator);
                }
                e.Graphics.DrawLine(pen1,
                                    50,
                                    350,
                                    (walk.PrevPositions[0].X + walk.ActualPos.X) / 2,
                                    (walk.PrevPositions[0].X + walk.ActualPos.X) / 2
                                    );

                //C-marche
                walk.Type = 'C';
                for (int i = 0; i < 350; i++)
                {
                    walk.walk(generator);
                }
                e.Graphics.DrawLine(pen2,
                                    50,
                                    350,
                                    (walk.PrevPositions[0].X + walk.ActualPos.X) / 2,
                                    (walk.PrevPositions[0].X + walk.ActualPos.X) / 2
                                    );

                //U-marche
                walk.Type = 'U';
                for (int i = 0; i < 350; i++)
                {
                    walk.walk(generator);
                }
                e.Graphics.DrawLine(pen3,
                                    50,
                                    350,
                                    (walk.PrevPositions[0].X + walk.ActualPos.X) / 2,
                                    (walk.PrevPositions[0].X + walk.ActualPos.X) / 2);
            }
            else
            {
                Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));
                for (int i = 0; i < walk.NbrFoot - 1; i++)
                {
                    e.Graphics.DrawLine(pen, 
                                        400 + walk.PrevPositions[i].X * ((int)(400 / walk.NbrFoot)), 
                                        345 + walk.PrevPositions[i].Y * ((int)(400 / walk.NbrFoot)), 
                                        400 + walk.PrevPositions[i + 1].X * ((int)(400 / walk.NbrFoot)),
                                        345 + walk.PrevPositions[i + 1].Y * ((int)(400 / walk.NbrFoot)));
                }
                e.Graphics.DrawLine(pen, 400 + walk.PrevPositions[walk.NbrFoot - 1].X * ((int)(400 / walk.NbrFoot)), 345 + walk.PrevPositions[walk.NbrFoot - 1].Y * ((int)(400 / walk.NbrFoot)), 400 + walk.ActualPos.X * ((int)(400 / walk.NbrFoot)), 345 + walk.ActualPos.Y * ((int)(400 / walk.NbrFoot)));
            }
        }

        private void nbrFoot_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
