using ProjetIA.UtilityClasses;
using System;
using System.Windows.Forms;

namespace ProjetIA.UserControls {
    public partial class EvaluatingUC : UserControl {

        //Cet UC permet de choisir les exercices. Il rend aussi compte de l'avancement grâce à l'objet EvaluationResult

        private IndexForm mainForm;
        private EvaluationResult evalResult;


        public EvaluatingUC(IndexForm _mainForm) {
            InitializeComponent();
            mainForm = _mainForm;
            evalResult = EvaluationResult.Instance;

            //Quelques vérifications quant à l'avancement de l'utilisateur dans l'examen 
            //afin d'afficher ou non ses résultats
            if (evalResult.DijkstraStatus == EvaluationResult.Status.Done ) {
                labelDijkstraScore.Text = "Note Dijkstra : "+ evalResult.resultDijkstra+"/20";
                buttonDijkstra.Enabled = false;
            } else {
                labelDijkstraScore.Visible = false;
            }

            if (evalResult.QCMStatus == EvaluationResult.Status.Done) {
                labelQCMScore.Text = "Note QCM : " + evalResult.resultQCM + "/20";
                buttonQCM.Enabled = false;
            } else {
                labelQCMScore.Visible = false;
            }

            if(evalResult.DijkstraStatus == EvaluationResult.Status.Done  && evalResult.QCMStatus == EvaluationResult.Status.Done ) {
                float finalNote = (mainForm.evalResult.resultQCM + evalResult.resultDijkstra) / 2;
                labelFinalResult.Text = "Note totale : " + finalNote + "/20";
            } else {
                labelFinalResult.Text = "";
            }
        }

        //Début de l'exercice QCM 
        private void ButtonQCM_Click(object sender, EventArgs e) {
            int questionLeft = evalResult.totalQuestion - evalResult.answeredQuestions.Count;
            mainForm.ChangeToQCM(questionLeft);
        }

        //Début de l'exercice Dijkstra
        private void ButtonDijkstra_Click(object sender, EventArgs e) {

        }
    }
}
