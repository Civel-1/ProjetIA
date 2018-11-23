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
            this.textBoxOuverts = new System.Windows.Forms.TextBox();
            this.textBoxFermes = new System.Windows.Forms.TextBox();
            this.dataGridViewOuvertsFermes = new System.Windows.Forms.DataGridView();
            this.labelOuverts = new System.Windows.Forms.Label();
            this.labelFermes = new System.Windows.Forms.Label();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.buttonEnd = new System.Windows.Forms.Button();
            this.treeView = new System.Windows.Forms.TreeView();
            ((System.ComponentModel.ISupportInitialize)(this.imgGraph)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOuvertsFermes)).BeginInit();
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
            // textBoxOuverts
            // 
            this.textBoxOuverts.Location = new System.Drawing.Point(326, 435);
            this.textBoxOuverts.Name = "textBoxOuverts";
            this.textBoxOuverts.Size = new System.Drawing.Size(229, 22);
            this.textBoxOuverts.TabIndex = 2;
            // 
            // textBoxFermes
            // 
            this.textBoxFermes.Location = new System.Drawing.Point(598, 435);
            this.textBoxFermes.Name = "textBoxFermes";
            this.textBoxFermes.Size = new System.Drawing.Size(229, 22);
            this.textBoxFermes.TabIndex = 3;
            // 
            // dataGridViewOuvertsFermes
            // 
            this.dataGridViewOuvertsFermes.AllowUserToAddRows = false;
            this.dataGridViewOuvertsFermes.AllowUserToDeleteRows = false;
            this.dataGridViewOuvertsFermes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOuvertsFermes.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.dataGridViewOuvertsFermes.Location = new System.Drawing.Point(19, 423);
            this.dataGridViewOuvertsFermes.Name = "dataGridViewOuvertsFermes";
            this.dataGridViewOuvertsFermes.ReadOnly = true;
            this.dataGridViewOuvertsFermes.RowTemplate.Height = 24;
            this.dataGridViewOuvertsFermes.Size = new System.Drawing.Size(282, 363);
            this.dataGridViewOuvertsFermes.TabIndex = 4;
            // 
            // labelOuverts
            // 
            this.labelOuverts.AutoSize = true;
            this.labelOuverts.Location = new System.Drawing.Point(326, 410);
            this.labelOuverts.Name = "labelOuverts";
            this.labelOuverts.Size = new System.Drawing.Size(58, 17);
            this.labelOuverts.TabIndex = 5;
            this.labelOuverts.Text = "Ouverts";
            // 
            // labelFermes
            // 
            this.labelFermes.AutoSize = true;
            this.labelFermes.Location = new System.Drawing.Point(598, 412);
            this.labelFermes.Name = "labelFermes";
            this.labelFermes.Size = new System.Drawing.Size(55, 17);
            this.labelFermes.TabIndex = 6;
            this.labelFermes.Text = "Fermés";
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Location = new System.Drawing.Point(691, 475);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(136, 27);
            this.buttonSubmit.TabIndex = 7;
            this.buttonSubmit.Text = "Soumettre l\'étape";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // buttonEnd
            // 
            this.buttonEnd.Location = new System.Drawing.Point(691, 759);
            this.buttonEnd.Name = "buttonEnd";
            this.buttonEnd.Size = new System.Drawing.Size(136, 27);
            this.buttonEnd.TabIndex = 8;
            this.buttonEnd.Text = "Terminer";
            this.buttonEnd.UseVisualStyleBackColor = true;
            this.buttonEnd.Click += new System.EventHandler(this.buttonEnd_Click);
            // 
            // treeView
            // 
            this.treeView.Location = new System.Drawing.Point(329, 524);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(346, 262);
            this.treeView.TabIndex = 9;
            // 
            // DijkstraUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.buttonEnd);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.labelFermes);
            this.Controls.Add(this.labelOuverts);
            this.Controls.Add(this.dataGridViewOuvertsFermes);
            this.Controls.Add(this.textBoxFermes);
            this.Controls.Add(this.textBoxOuverts);
            this.Controls.Add(this.imgGraph);
            this.Name = "DijkstraUC";
            this.Size = new System.Drawing.Size(862, 804);
            this.Load += new System.EventHandler(this.DijkstraUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgGraph)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOuvertsFermes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imgGraph;
        private System.Windows.Forms.TextBox textBoxOuverts;
        private System.Windows.Forms.TextBox textBoxFermes;
        private System.Windows.Forms.DataGridView dataGridViewOuvertsFermes;
        private System.Windows.Forms.Label labelOuverts;
        private System.Windows.Forms.Label labelFermes;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.Button buttonEnd;
        private System.Windows.Forms.TreeView treeView;
    }
}
