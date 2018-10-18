using System;
using System.Windows.Forms;

namespace ProjetIA.UserControls {
    public partial class IndexUC : UserControl {
        //Cet UC est "l'écran d'accueil" contenant un message de bienvenue et un bouton pour démarrer l'évaluation
        private IndexForm mainForm;
        public IndexUC(IndexForm _mainForm) {
            InitializeComponent();
            mainForm = _mainForm;
        }

        private void ButtonStartTest_Click(object sender, EventArgs e) {
            mainForm.ChangeToEvaluating();
        }
    }
}
