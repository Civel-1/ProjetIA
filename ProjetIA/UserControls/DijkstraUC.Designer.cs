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
            ((System.ComponentModel.ISupportInitialize)(this.imgGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // imgGraph
            // 
            this.imgGraph.Location = new System.Drawing.Point(3, 3);
            this.imgGraph.Name = "imgGraph";
            this.imgGraph.Size = new System.Drawing.Size(832, 354);
            this.imgGraph.TabIndex = 1;
            this.imgGraph.TabStop = false;
            // 
            // DijkstraUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.imgGraph);
            this.Name = "DijkstraUC";
            this.Size = new System.Drawing.Size(838, 653);
            this.Load += new System.EventHandler(this.DijkstraUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgGraph)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox imgGraph;
    }
}
