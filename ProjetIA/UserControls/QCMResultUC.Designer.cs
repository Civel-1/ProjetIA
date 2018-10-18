namespace ProjetIA.UserControls {
    partial class QCMResultUC {
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
            this.labelResultText = new System.Windows.Forms.Label();
            this.labelUserResult = new System.Windows.Forms.Label();
            this.buttonReturnToEval = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelResultText
            // 
            this.labelResultText.AutoSize = true;
            this.labelResultText.Location = new System.Drawing.Point(61, 93);
            this.labelResultText.Name = "labelResultText";
            this.labelResultText.Size = new System.Drawing.Size(333, 34);
            this.labelResultText.TabIndex = 0;
            this.labelResultText.Text = "Vous avez terminé l\'évaluation des connaissances. \r\nVoici votre score :\r\n";
            // 
            // labelUserResult
            // 
            this.labelUserResult.AutoSize = true;
            this.labelUserResult.Location = new System.Drawing.Point(121, 193);
            this.labelUserResult.Name = "labelUserResult";
            this.labelUserResult.Size = new System.Drawing.Size(0, 17);
            this.labelUserResult.TabIndex = 1;
            // 
            // buttonReturnToEval
            // 
            this.buttonReturnToEval.Location = new System.Drawing.Point(133, 355);
            this.buttonReturnToEval.Name = "buttonReturnToEval";
            this.buttonReturnToEval.Size = new System.Drawing.Size(177, 76);
            this.buttonReturnToEval.TabIndex = 2;
            this.buttonReturnToEval.Text = "Retourner à l\'évaluation";
            this.buttonReturnToEval.UseVisualStyleBackColor = true;
            this.buttonReturnToEval.Click += new System.EventHandler(this.ButtonReturnToEval_Click);
            // 
            // QCMResultUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonReturnToEval);
            this.Controls.Add(this.labelUserResult);
            this.Controls.Add(this.labelResultText);
            this.Name = "QCMResultUC";
            this.Size = new System.Drawing.Size(464, 488);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelResultText;
        private System.Windows.Forms.Label labelUserResult;
        private System.Windows.Forms.Button buttonReturnToEval;
    }
}
