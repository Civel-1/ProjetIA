namespace ProjetIA.UserControls {
    partial class IndexUC {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IndexUC));
            this.labelWelcome = new System.Windows.Forms.Label();
            this.buttonStartTest = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelWelcome
            // 
            this.labelWelcome.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelWelcome.AutoSize = true;
            this.labelWelcome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.labelWelcome.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWelcome.Location = new System.Drawing.Point(593, 301);
            this.labelWelcome.Name = "labelWelcome";
            this.labelWelcome.Size = new System.Drawing.Size(463, 154);
            this.labelWelcome.TabIndex = 1;
            this.labelWelcome.Text = resources.GetString("labelWelcome.Text");
            this.labelWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonStartTest
            // 
            this.buttonStartTest.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStartTest.BackColor = System.Drawing.Color.Silver;
            this.buttonStartTest.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonStartTest.FlatAppearance.BorderColor = System.Drawing.Color.SeaShell;
            this.buttonStartTest.FlatAppearance.BorderSize = 0;
            this.buttonStartTest.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SeaShell;
            this.buttonStartTest.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SeaShell;
            this.buttonStartTest.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStartTest.Location = new System.Drawing.Point(597, 488);
            this.buttonStartTest.Name = "buttonStartTest";
            this.buttonStartTest.Size = new System.Drawing.Size(274, 71);
            this.buttonStartTest.TabIndex = 0;
            this.buttonStartTest.Text = "DEMARRER";
            this.buttonStartTest.UseVisualStyleBackColor = false;
            this.buttonStartTest.Click += new System.EventHandler(this.ButtonStartTest_Click);
            // 
            // IndexUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.BackgroundImage = global::ProjetIA.Properties.Resources.indexBackGround;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.labelWelcome);
            this.Controls.Add(this.buttonStartTest);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(1200, 700);
            this.Name = "IndexUC";
            this.Size = new System.Drawing.Size(1200, 700);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelWelcome;
        private System.Windows.Forms.Button buttonStartTest;
    }
}
