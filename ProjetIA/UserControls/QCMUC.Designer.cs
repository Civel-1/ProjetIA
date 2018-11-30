namespace ProjetIA.UserControls {
    partial class QCMUC {
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
            this.checkBoxAnswer1 = new System.Windows.Forms.CheckBox();
            this.checkBoxAnswer2 = new System.Windows.Forms.CheckBox();
            this.checkBoxAnswer3 = new System.Windows.Forms.CheckBox();
            this.checkBoxAnswer4 = new System.Windows.Forms.CheckBox();
            this.buttonSubmitAnswer = new System.Windows.Forms.Button();
            this.textBoxQuestion = new System.Windows.Forms.TextBox();
            this.labelMissingAnswer = new System.Windows.Forms.Label();
            this.buttonNextQuestion = new System.Windows.Forms.Button();
            this.labelResultQuestion = new System.Windows.Forms.Label();
            this.labelMultipleAnswer = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBoxAnswer1
            // 
            this.checkBoxAnswer1.AutoSize = true;
            this.checkBoxAnswer1.Location = new System.Drawing.Point(354, 468);
            this.checkBoxAnswer1.Name = "checkBoxAnswer1";
            this.checkBoxAnswer1.Size = new System.Drawing.Size(18, 17);
            this.checkBoxAnswer1.TabIndex = 4;
            this.checkBoxAnswer1.UseVisualStyleBackColor = true;
            this.checkBoxAnswer1.CheckedChanged += new System.EventHandler(this.CheckBoxAnswer_CheckedChanged);
            // 
            // checkBoxAnswer2
            // 
            this.checkBoxAnswer2.AutoSize = true;
            this.checkBoxAnswer2.Location = new System.Drawing.Point(636, 468);
            this.checkBoxAnswer2.Name = "checkBoxAnswer2";
            this.checkBoxAnswer2.Size = new System.Drawing.Size(18, 17);
            this.checkBoxAnswer2.TabIndex = 5;
            this.checkBoxAnswer2.UseVisualStyleBackColor = true;
            this.checkBoxAnswer2.CheckedChanged += new System.EventHandler(this.CheckBoxAnswer_CheckedChanged);
            // 
            // checkBoxAnswer3
            // 
            this.checkBoxAnswer3.AutoSize = true;
            this.checkBoxAnswer3.Location = new System.Drawing.Point(354, 529);
            this.checkBoxAnswer3.Name = "checkBoxAnswer3";
            this.checkBoxAnswer3.Size = new System.Drawing.Size(18, 17);
            this.checkBoxAnswer3.TabIndex = 6;
            this.checkBoxAnswer3.UseVisualStyleBackColor = true;
            this.checkBoxAnswer3.CheckedChanged += new System.EventHandler(this.CheckBoxAnswer_CheckedChanged);
            // 
            // checkBoxAnswer4
            // 
            this.checkBoxAnswer4.AutoSize = true;
            this.checkBoxAnswer4.Location = new System.Drawing.Point(636, 529);
            this.checkBoxAnswer4.Name = "checkBoxAnswer4";
            this.checkBoxAnswer4.Size = new System.Drawing.Size(18, 17);
            this.checkBoxAnswer4.TabIndex = 7;
            this.checkBoxAnswer4.UseVisualStyleBackColor = true;
            this.checkBoxAnswer4.CheckedChanged += new System.EventHandler(this.CheckBoxAnswer_CheckedChanged);
            // 
            // buttonSubmitAnswer
            // 
            this.buttonSubmitAnswer.Location = new System.Drawing.Point(377, 572);
            this.buttonSubmitAnswer.Name = "buttonSubmitAnswer";
            this.buttonSubmitAnswer.Size = new System.Drawing.Size(148, 53);
            this.buttonSubmitAnswer.TabIndex = 8;
            this.buttonSubmitAnswer.Text = "Valider";
            this.buttonSubmitAnswer.UseVisualStyleBackColor = true;
            this.buttonSubmitAnswer.Click += new System.EventHandler(this.ButtonSubmitAnswer_Click);
            // 
            // textBoxQuestion
            // 
            this.textBoxQuestion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxQuestion.Location = new System.Drawing.Point(229, 230);
            this.textBoxQuestion.Multiline = true;
            this.textBoxQuestion.Name = "textBoxQuestion";
            this.textBoxQuestion.ReadOnly = true;
            this.textBoxQuestion.Size = new System.Drawing.Size(732, 175);
            this.textBoxQuestion.TabIndex = 9;
            // 
            // labelMissingAnswer
            // 
            this.labelMissingAnswer.AutoSize = true;
            this.labelMissingAnswer.ForeColor = System.Drawing.Color.Red;
            this.labelMissingAnswer.Location = new System.Drawing.Point(657, 428);
            this.labelMissingAnswer.Name = "labelMissingAnswer";
            this.labelMissingAnswer.Size = new System.Drawing.Size(213, 17);
            this.labelMissingAnswer.TabIndex = 11;
            this.labelMissingAnswer.Text = "Veuillez renseigner une réponse";
            this.labelMissingAnswer.Visible = false;
            // 
            // buttonNextQuestion
            // 
            this.buttonNextQuestion.Enabled = false;
            this.buttonNextQuestion.Location = new System.Drawing.Point(619, 572);
            this.buttonNextQuestion.Name = "buttonNextQuestion";
            this.buttonNextQuestion.Size = new System.Drawing.Size(148, 53);
            this.buttonNextQuestion.TabIndex = 12;
            this.buttonNextQuestion.Text = "Question Suivante";
            this.buttonNextQuestion.UseVisualStyleBackColor = true;
            this.buttonNextQuestion.Click += new System.EventHandler(this.ButtonNextQuestion_Click);
            // 
            // labelResultQuestion
            // 
            this.labelResultQuestion.AutoSize = true;
            this.labelResultQuestion.Location = new System.Drawing.Point(4, 362);
            this.labelResultQuestion.Name = "labelResultQuestion";
            this.labelResultQuestion.Size = new System.Drawing.Size(0, 17);
            this.labelResultQuestion.TabIndex = 13;
            // 
            // labelMultipleAnswer
            // 
            this.labelMultipleAnswer.AutoSize = true;
            this.labelMultipleAnswer.Location = new System.Drawing.Point(327, 428);
            this.labelMultipleAnswer.Name = "labelMultipleAnswer";
            this.labelMultipleAnswer.Size = new System.Drawing.Size(198, 17);
            this.labelMultipleAnswer.TabIndex = 14;
            this.labelMultipleAnswer.Text = "Plusieurs réponses acceptées";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::ProjetIA.Properties.Resources.header;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1194, 163);
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // QCMUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelMultipleAnswer);
            this.Controls.Add(this.labelResultQuestion);
            this.Controls.Add(this.buttonNextQuestion);
            this.Controls.Add(this.labelMissingAnswer);
            this.Controls.Add(this.textBoxQuestion);
            this.Controls.Add(this.buttonSubmitAnswer);
            this.Controls.Add(this.checkBoxAnswer4);
            this.Controls.Add(this.checkBoxAnswer3);
            this.Controls.Add(this.checkBoxAnswer2);
            this.Controls.Add(this.checkBoxAnswer1);
            this.MinimumSize = new System.Drawing.Size(1200, 700);
            this.Name = "QCMUC";
            this.Size = new System.Drawing.Size(1200, 700);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxAnswer1;
        private System.Windows.Forms.CheckBox checkBoxAnswer2;
        private System.Windows.Forms.CheckBox checkBoxAnswer3;
        private System.Windows.Forms.CheckBox checkBoxAnswer4;
        private System.Windows.Forms.Button buttonSubmitAnswer;
        private System.Windows.Forms.TextBox textBoxQuestion;
        private System.Windows.Forms.Label labelMissingAnswer;
        private System.Windows.Forms.Button buttonNextQuestion;
        private System.Windows.Forms.Label labelResultQuestion;
        private System.Windows.Forms.Label labelMultipleAnswer;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
