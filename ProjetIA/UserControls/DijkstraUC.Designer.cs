namespace ProjetIA.UserControls
{
    partial class DijkstraUC
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

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.imgGraph = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // imgGraph
            // 
            this.imgGraph.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.imgGraph.Location = new System.Drawing.Point(6, 3);
            this.imgGraph.MaximumSize = new System.Drawing.Size(850, 400);
            this.imgGraph.Name = "imgGraph";
            this.imgGraph.Size = new System.Drawing.Size(850, 400);
            this.imgGraph.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imgGraph.TabIndex = 1;
            this.imgGraph.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(50, 434);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(229, 22);
            this.textBox1.TabIndex = 2;
            // 
            // DijkstraUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.imgGraph);
            this.Name = "DijkstraUC";
            this.Size = new System.Drawing.Size(862, 791);
            this.Load += new System.EventHandler(this.DijkstraUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgGraph)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imgGraph;
        private System.Windows.Forms.TextBox textBox1;
    }
}
