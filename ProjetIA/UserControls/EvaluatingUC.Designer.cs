namespace ProjetIA.UserControls {
    partial class EvaluatingUC {
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
            this.buttonDijkstra = new System.Windows.Forms.Button();
            this.buttonQCM = new System.Windows.Forms.Button();
            this.labelDijkstraScore = new System.Windows.Forms.Label();
            this.labelQCMScore = new System.Windows.Forms.Label();
            this.labelFinalResult = new System.Windows.Forms.Label();
            this.labelEvaluatingText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonDijkstra
            // 
            this.buttonDijkstra.Location = new System.Drawing.Point(143, 172);
            this.buttonDijkstra.Name = "buttonDijkstra";
            this.buttonDijkstra.Size = new System.Drawing.Size(133, 55);
            this.buttonDijkstra.TabIndex = 0;
            this.buttonDijkstra.Text = "Dijkstra";
            this.buttonDijkstra.UseVisualStyleBackColor = true;
            this.buttonDijkstra.Click += new System.EventHandler(this.ButtonDijkstra_Click);
            // 
            // buttonQCM
            // 
            this.buttonQCM.Location = new System.Drawing.Point(400, 172);
            this.buttonQCM.Name = "buttonQCM";
            this.buttonQCM.Size = new System.Drawing.Size(133, 55);
            this.buttonQCM.TabIndex = 1;
            this.buttonQCM.Text = "QCM";
            this.buttonQCM.UseVisualStyleBackColor = true;
            this.buttonQCM.Click += new System.EventHandler(this.ButtonQCM_Click);
            // 
            // labelDijkstraScore
            // 
            this.labelDijkstraScore.AutoSize = true;
            this.labelDijkstraScore.Location = new System.Drawing.Point(143, 303);
            this.labelDijkstraScore.Name = "labelDijkstraScore";
            this.labelDijkstraScore.Size = new System.Drawing.Size(97, 17);
            this.labelDijkstraScore.TabIndex = 3;
            this.labelDijkstraScore.Text = "Note Dijkstra :";
            // 
            // labelQCMScore
            // 
            this.labelQCMScore.AutoSize = true;
            this.labelQCMScore.Location = new System.Drawing.Point(143, 358);
            this.labelQCMScore.Name = "labelQCMScore";
            this.labelQCMScore.Size = new System.Drawing.Size(85, 17);
            this.labelQCMScore.TabIndex = 4;
            this.labelQCMScore.Text = "Note QCM : ";
            // 
            // labelFinalResult
            // 
            this.labelFinalResult.AutoSize = true;
            this.labelFinalResult.Location = new System.Drawing.Point(146, 418);
            this.labelFinalResult.Name = "labelFinalResult";
            this.labelFinalResult.Size = new System.Drawing.Size(98, 17);
            this.labelFinalResult.TabIndex = 5;
            this.labelFinalResult.Text = "Résultat final :";
            // 
            // labelEvaluatingText
            // 
            this.labelEvaluatingText.AutoSize = true;
            this.labelEvaluatingText.Location = new System.Drawing.Point(183, 93);
            this.labelEvaluatingText.Name = "labelEvaluatingText";
            this.labelEvaluatingText.Size = new System.Drawing.Size(300, 34);
            this.labelEvaluatingText.TabIndex = 6;
            this.labelEvaluatingText.Text = "Vous avez démarré une nouvelle évaluation. \r\nVeuillez effectuer les deux exercice" +
    "s suivants :\r\n";
            // 
            // EvaluatingUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Controls.Add(this.labelEvaluatingText);
            this.Controls.Add(this.labelFinalResult);
            this.Controls.Add(this.labelQCMScore);
            this.Controls.Add(this.labelDijkstraScore);
            this.Controls.Add(this.buttonQCM);
            this.Controls.Add(this.buttonDijkstra);
            this.Name = "EvaluatingUC";
            this.Size = new System.Drawing.Size(700, 500);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonDijkstra;
        private System.Windows.Forms.Button buttonQCM;
        private System.Windows.Forms.Label labelDijkstraScore;
        private System.Windows.Forms.Label labelQCMScore;
        private System.Windows.Forms.Label labelFinalResult;
        private System.Windows.Forms.Label labelEvaluatingText;
    }
}
