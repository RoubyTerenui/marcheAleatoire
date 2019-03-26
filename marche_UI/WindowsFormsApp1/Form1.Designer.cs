namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.nbrFoot = new System.Windows.Forms.NumericUpDown();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.Launch = new System.Windows.Forms.Button();
            this.Graph = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbrFoot)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(0, 55);
            this.panel1.MaximumSize = new System.Drawing.Size(800, 800);
            this.panel1.MinimumSize = new System.Drawing.Size(800, 800);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 800);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.nbrFoot);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.Launch);
            this.panel2.Controls.Add(this.Graph);
            this.panel2.Location = new System.Drawing.Point(1, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(799, 57);
            this.panel2.TabIndex = 1;
            // 
            // nbrFoot
            // 
            this.nbrFoot.Location = new System.Drawing.Point(523, 18);
            this.nbrFoot.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.nbrFoot.Name = "nbrFoot";
            this.nbrFoot.Size = new System.Drawing.Size(120, 22);
            this.nbrFoot.TabIndex = 3;
            this.nbrFoot.TabStop = false;
            this.nbrFoot.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nbrFoot.ValueChanged += new System.EventHandler(this.nbrFoot_ValueChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "C",
            "S",
            "U"});
            this.comboBox1.Location = new System.Drawing.Point(334, 18);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.Text = "C";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Launch
            // 
            this.Launch.Location = new System.Drawing.Point(170, 12);
            this.Launch.Name = "Launch";
            this.Launch.Size = new System.Drawing.Size(101, 34);
            this.Launch.TabIndex = 0;
            this.Launch.Text = "Launch";
            this.Launch.UseVisualStyleBackColor = true;
            this.Launch.Click += new System.EventHandler(this.launch);
            // 
            // Graph
            // 
            this.Graph.Location = new System.Drawing.Point(15, 12);
            this.Graph.Name = "Graph";
            this.Graph.Size = new System.Drawing.Size(101, 34);
            this.Graph.TabIndex = 0;
            this.Graph.Text = "Graph";
            this.Graph.UseVisualStyleBackColor = true;
            this.Graph.Click += new System.EventHandler(this.graph);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 855);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nbrFoot)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button Launch;
        private System.Windows.Forms.Button Graph;
        private System.Windows.Forms.NumericUpDown nbrFoot;
    }
}

