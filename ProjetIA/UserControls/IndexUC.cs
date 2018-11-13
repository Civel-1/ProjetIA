using ProjetIA.UtilityClasses;
using System;
using System.Windows.Forms;

namespace ProjetIA.UserControls {
    public partial class IndexUC : UserControl {
        //Cet UC est "l'écran d'accueil" contenant un message de bienvenue et un bouton pour démarrer l'évaluation
        private IndexForm mainForm;
        private EvaluationResult evalResult;
        private SaveFileUtility saveFile;


        public IndexUC(IndexForm _mainForm) {
            InitializeComponent();
            mainForm = _mainForm;


            //Ici, on gère la récupération de l'avancement possible de l'utilisateur
            evalResult = EvaluationResult.Instance;
            saveFile = SaveFileUtility.Instance;
            evalResult = saveFile.GetCurrentProgression();
        }

        private void ButtonStartTest_Click(object sender, EventArgs e) {
            mainForm.ChangeToEvaluating();
        }
    }
}
