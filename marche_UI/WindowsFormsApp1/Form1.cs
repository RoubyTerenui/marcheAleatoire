using System;
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
        public Form1()
        {
            generator = new RandomGenerator(13, 1073, 43215, 4294967087, 1403580, 810728);
            InitializeComponent();
            walk = new MarcheAleatoire((int)nbrFoot.Value, comboBox1.Text[0]);
            walk.walk(generator);
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
        }
        private void launch(object sender, EventArgs e)
        {
            walk = new MarcheAleatoire((int)nbrFoot.Value, comboBox1.Text[0]);
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
            Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));
            for (int i = 0; i < walk.NbrFoot - 1; i++)
            {
                e.Graphics.DrawLine(pen, 400 + walk.PrevPositions[i].X * ((int)(400/ walk.NbrFoot )), 345 + walk.PrevPositions[i].Y * ((int)(400/ walk.NbrFoot)), 400 + walk.PrevPositions[i + 1].X * ((int)(400/ walk.NbrFoot)), 345 + walk.PrevPositions[i + 1].Y * ((int)(400/ walk.NbrFoot)));
            }
            e.Graphics.DrawLine(pen, 400 + walk.PrevPositions[walk.NbrFoot - 1].X * ((int)(400/ walk.NbrFoot)), 345 + walk.PrevPositions[walk.NbrFoot-1].Y * ((int)(400/ walk.NbrFoot)), 400 + walk.ActualPos.X * ((int)(400/ walk.NbrFoot)), 345 + walk.ActualPos.Y * ((int)(400/ walk.NbrFoot)));

        }

        private void nbrFoot_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
