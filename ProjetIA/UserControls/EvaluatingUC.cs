using System;
using System.Windows.Forms;

namespace ProjetIA.UserControls {
    public partial class EvaluatingUC : UserControl {
        //Cet UC permet de choisir les exercices. Il rend aussi compte de l'avancement grâce à l'objet EvaluationResult

        private IndexForm mainForm;
        public EvaluatingUC(IndexForm _mainForm) {
            InitializeComponent();
            mainForm = _mainForm;


            //Quelques vérifications quant à l'avancement de l'utilisateur dans l'examen 
            //afin d'afficher ou non ses résultats
            if (mainForm.evalResult.hasDoneDijkstra) {
                labelDijkstraScore.Text = "Note Dijkstra : "+ mainForm.evalResult.resultDijkstra+"/20";
                buttonDijkstra.Enabled = false;
            } else {
                labelDijkstraScore.Visible = false;
            }

            if (mainForm.evalResult.hasDoneQCM) {
                labelQCMScore.Text = "Note QCM : " + mainForm.evalResult.resultQCM + "/20";
                buttonQCM.Enabled = false;
            } else {
                labelQCMScore.Visible = false;
            }

            if(mainForm.evalResult.hasDoneDijkstra && mainForm.evalResult.hasDoneQCM) {
                float finalNote = (mainForm.evalResult.resultQCM + mainForm.evalResult.resultDijkstra) / 2;
                labelFinalResult.Text = "Note totale : " + finalNote + "/20";
            } else {
                labelFinalResult.Text = "";
            }
        }

        //Début de l'exercice QCM
        private void ButtonQCM_Click(object sender, EventArgs e) {
            mainForm.ChangeToQCM();
        }

        //Début de l'exercice Dijkstra
        private void ButtonDijkstra_Click(object sender, EventArgs e) {
            mainForm.ChangeToDijkstra();
        }
    }
}
