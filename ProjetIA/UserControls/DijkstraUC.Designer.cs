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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DijkstraUC));
            this.textBoxOuverts = new System.Windows.Forms.TextBox();
            this.textBoxFermes = new System.Windows.Forms.TextBox();
            this.dataGridViewOuvertsFermes = new System.Windows.Forms.DataGridView();
            this.labelOuverts = new System.Windows.Forms.Label();
            this.labelFermes = new System.Windows.Forms.Label();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.buttonEnd = new System.Windows.Forms.Button();
            this.treeViewDijkstra = new System.Windows.Forms.TreeView();
            this.textBoxNode = new System.Windows.Forms.TextBox();
            this.submitNode = new System.Windows.Forms.Button();
            this.labelEndNode = new System.Windows.Forms.Label();
            this.labelEndNodeText = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonReInit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.labelInitNode = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.imgGraph = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOuvertsFermes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxOuverts
            // 
            this.textBoxOuverts.Location = new System.Drawing.Point(384, 512);
            this.textBoxOuverts.Name = "textBoxOuverts";
            this.textBoxOuverts.Size = new System.Drawing.Size(173, 22);
            this.textBoxOuverts.TabIndex = 2;
            // 
            // textBoxFermes
            // 
            this.textBoxFermes.Location = new System.Drawing.Point(384, 569);
            this.textBoxFermes.Name = "textBoxFermes";
            this.textBoxFermes.Size = new System.Drawing.Size(173, 22);
            this.textBoxFermes.TabIndex = 3;
            // 
            // dataGridViewOuvertsFermes
            // 
            this.dataGridViewOuvertsFermes.AllowUserToAddRows = false;
            this.dataGridViewOuvertsFermes.AllowUserToDeleteRows = false;
            this.dataGridViewOuvertsFermes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOuvertsFermes.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.dataGridViewOuvertsFermes.Location = new System.Drawing.Point(27, 421);
            this.dataGridViewOuvertsFermes.Name = "dataGridViewOuvertsFermes";
            this.dataGridViewOuvertsFermes.ReadOnly = true;
            this.dataGridViewOuvertsFermes.RowTemplate.Height = 24;
            this.dataGridViewOuvertsFermes.Size = new System.Drawing.Size(348, 351);
            this.dataGridViewOuvertsFermes.TabIndex = 4;
            // 
            // labelOuverts
            // 
            this.labelOuverts.AutoSize = true;
            this.labelOuverts.Location = new System.Drawing.Point(381, 492);
            this.labelOuverts.Name = "labelOuverts";
            this.labelOuverts.Size = new System.Drawing.Size(58, 17);
            this.labelOuverts.TabIndex = 5;
            this.labelOuverts.Text = "Ouverts";
            // 
            // labelFermes
            // 
            this.labelFermes.AutoSize = true;
            this.labelFermes.Location = new System.Drawing.Point(384, 549);
            this.labelFermes.Name = "labelFermes";
            this.labelFermes.Size = new System.Drawing.Size(55, 17);
            this.labelFermes.TabIndex = 6;
            this.labelFermes.Text = "Fermés";
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Location = new System.Drawing.Point(384, 614);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(136, 27);
            this.buttonSubmit.TabIndex = 7;
            this.buttonSubmit.Text = "Soumettre l\'étape";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // buttonEnd
            // 
            this.buttonEnd.Location = new System.Drawing.Point(650, 705);
            this.buttonEnd.Name = "buttonEnd";
            this.buttonEnd.Size = new System.Drawing.Size(176, 43);
            this.buttonEnd.TabIndex = 8;
            this.buttonEnd.Text = "Terminer";
            this.buttonEnd.UseVisualStyleBackColor = true;
            this.buttonEnd.Click += new System.EventHandler(this.buttonEnd_Click);
            // 
            // treeViewDijkstra
            // 
            this.treeViewDijkstra.Location = new System.Drawing.Point(889, 421);
            this.treeViewDijkstra.Name = "treeViewDijkstra";
            this.treeViewDijkstra.Size = new System.Drawing.Size(333, 351);
            this.treeViewDijkstra.TabIndex = 9;
            this.treeViewDijkstra.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewDijkstra_AfterSelect);
            // 
            // textBoxNode
            // 
            this.textBoxNode.Location = new System.Drawing.Point(784, 521);
            this.textBoxNode.Name = "textBoxNode";
            this.textBoxNode.Size = new System.Drawing.Size(52, 22);
            this.textBoxNode.TabIndex = 10;
            // 
            // submitNode
            // 
            this.submitNode.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitNode.Location = new System.Drawing.Point(842, 512);
            this.submitNode.Name = "submitNode";
            this.submitNode.Size = new System.Drawing.Size(32, 34);
            this.submitNode.TabIndex = 11;
            this.submitNode.Text = ">";
            this.submitNode.UseVisualStyleBackColor = true;
            this.submitNode.Click += new System.EventHandler(this.submitNode_Click);
            // 
            // labelEndNode
            // 
            this.labelEndNode.AutoSize = true;
            this.labelEndNode.Location = new System.Drawing.Point(198, 363);
            this.labelEndNode.Name = "labelEndNode";
            this.labelEndNode.Size = new System.Drawing.Size(46, 17);
            this.labelEndNode.TabIndex = 12;
            this.labelEndNode.Text = "label1";
            // 
            // labelEndNodeText
            // 
            this.labelEndNodeText.AutoSize = true;
            this.labelEndNodeText.Location = new System.Drawing.Point(185, 336);
            this.labelEndNodeText.Name = "labelEndNodeText";
            this.labelEndNodeText.Size = new System.Drawing.Size(88, 17);
            this.labelEndNodeText.TabIndex = 13;
            this.labelEndNodeText.Text = "Noeud final :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(657, 524);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 17);
            this.label1.TabIndex = 14;
            this.label1.Text = "Entrez un noeud :";
            // 
            // buttonReInit
            // 
            this.buttonReInit.Location = new System.Drawing.Point(483, 715);
            this.buttonReInit.Name = "buttonReInit";
            this.buttonReInit.Size = new System.Drawing.Size(120, 23);
            this.buttonReInit.TabIndex = 15;
            this.buttonReInit.Text = "Recommencer";
            this.buttonReInit.UseVisualStyleBackColor = true;
            this.buttonReInit.Click += new System.EventHandler(this.buttonReInit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 336);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 17);
            this.label2.TabIndex = 16;
            this.label2.Text = "Noeud initial :";
            // 
            // labelInitNode
            // 
            this.labelInitNode.AutoSize = true;
            this.labelInitNode.Location = new System.Drawing.Point(63, 363);
            this.labelInitNode.Name = "labelInitNode";
            this.labelInitNode.Size = new System.Drawing.Size(46, 17);
            this.labelInitNode.TabIndex = 17;
            this.labelInitNode.Text = "label3";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(245, 136);
            this.label3.TabIndex = 18;
            this.label3.Text = resources.GetString("label3.Text");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(381, 421);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(212, 51);
            this.label4.TabIndex = 19;
            this.label4.Text = "Entrez les ensembles dans \r\nles champs correspondants,\r\nà chaque étape de la réso" +
    "lution.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(688, 421);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(186, 68);
            this.label5.TabIndex = 20;
            this.label5.Text = "Pour remplir un noeud, \r\nsélectionnez-le dans l\'arbre\r\npuis entrez son nom dans l" +
    "e\r\nchamp correspondant.";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::ProjetIA.Properties.Resources.headerDijkstra;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(27, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(287, 157);
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // imgGraph
            // 
            this.imgGraph.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.imgGraph.Location = new System.Drawing.Point(372, 3);
            this.imgGraph.MaximumSize = new System.Drawing.Size(850, 400);
            this.imgGraph.Name = "imgGraph";
            this.imgGraph.Size = new System.Drawing.Size(850, 400);
            this.imgGraph.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgGraph.TabIndex = 1;
            this.imgGraph.TabStop = false;
            // 
            // DijkstraUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelInitNode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonReInit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelEndNodeText);
            this.Controls.Add(this.labelEndNode);
            this.Controls.Add(this.submitNode);
            this.Controls.Add(this.textBoxNode);
            this.Controls.Add(this.treeViewDijkstra);
            this.Controls.Add(this.buttonEnd);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.labelFermes);
            this.Controls.Add(this.labelOuverts);
            this.Controls.Add(this.dataGridViewOuvertsFermes);
            this.Controls.Add(this.textBoxFermes);
            this.Controls.Add(this.textBoxOuverts);
            this.Controls.Add(this.imgGraph);
            this.MinimumSize = new System.Drawing.Size(1250, 850);
            this.Name = "DijkstraUC";
            this.Size = new System.Drawing.Size(1250, 850);
            this.Load += new System.EventHandler(this.DijkstraUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOuvertsFermes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgGraph)).EndInit();
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
        private System.Windows.Forms.TreeView treeViewDijkstra;
        private System.Windows.Forms.TextBox textBoxNode;
        private System.Windows.Forms.Button submitNode;
        private System.Windows.Forms.Label labelEndNode;
        private System.Windows.Forms.Label labelEndNodeText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonReInit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelInitNode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
