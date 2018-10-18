﻿using System;
using System.Windows.Forms;

namespace ProjetIA.UserControls {
    public partial class QCMResultUC : UserControl {

        //Cet UC permet juste d'afficher le résultat à l'exercice du QCM puis renvoit au menu de choix des exos
        private IndexForm mainForm;
        public QCMResultUC(IndexForm _mainForm) {
            mainForm = _mainForm;
            InitializeComponent();
            Init();
        }
        
        private void Init() {
            labelUserResult.Text = mainForm.evalResult.resultQCM + "/20";
        }

        private void ButtonReturnToEval_Click(object sender, EventArgs e) {
            mainForm.ChangeToEvaluating();
        }
    }
}
