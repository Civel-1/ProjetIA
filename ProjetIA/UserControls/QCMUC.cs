using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ProjetIA.UtilityClasses;

namespace ProjetIA.UserControls {
    public partial class QCMUC : UserControl {
        IndexForm mainForm;
        Question currentQuestion;
        private QuestionHandler questionHandler;
        private bool ignoreEvents = false;
        private int result;
        private int questionLeft;
        private SaveFileUtility saveFile;
        private EvaluationResult evalResult;
       
        
        public QCMUC(IndexForm _mainForm, int _questionLeft) {
            InitializeComponent();

            mainForm = _mainForm;
            questionHandler = QuestionHandler.Instance;

            questionLeft = _questionLeft;
            evalResult = EvaluationResult.Instance;
            result = evalResult.currentScoreQCM;

            //Utilisé pour écrire les résultats
            saveFile = SaveFileUtility.Instance;

            StartEvaluating();
            
        }


        private void StartEvaluating() {

            //Récupère la première question
            currentQuestion = questionHandler.GetNextQuestion();
            //init de la première question
            InitQuestion();
        }

        //On initialise la questions et les réponses.
        private void InitQuestion() {
            //On réinitialise les champs spécifiques
            ClearQuestion();

            textBoxQuestion.Text = currentQuestion._question;
            checkBoxAnswer1.Text = currentQuestion._answer1;
            checkBoxAnswer2.Text = currentQuestion._answer2;


            //On vérifie si c'est une question avec 4 réponses.
            if (currentQuestion._isTrueOrFalse) {
                checkBoxAnswer3.Visible = false;
                checkBoxAnswer4.Visible = false;
            } else {
                checkBoxAnswer3.Text = currentQuestion._answer3;
                checkBoxAnswer4.Text = currentQuestion._answer4;
            }

            //On regarde si la question accepte plusieurs réponses, si non, on disable le commentaire
            if (!currentQuestion._multipeAnswer) {
                labelMultipleAnswer.Visible = false;
            }

            //On regarde si c'est la dernière question de l'examen
            if (questionLeft == 1) {
                buttonNextQuestion.Text = "Terminer";
            }
        }

        //Avant de charger la nouvelle question, on réinitialise les champs
        private void ClearQuestion() {
            labelResultQuestion.Visible = false;
            labelMultipleAnswer.Visible = true;
            labelMissingAnswer.Visible = false;
            checkBoxAnswer1.Checked = false;
            checkBoxAnswer2.Checked = false;
            checkBoxAnswer3.Checked = false;
            checkBoxAnswer4.Checked = false;
            checkBoxAnswer1.Text = "";
            checkBoxAnswer2.Text = "";
            checkBoxAnswer3.Text = "";
            checkBoxAnswer4.Text = "";
            checkBoxAnswer1.ForeColor = Color.Black;
            checkBoxAnswer2.ForeColor = Color.Black;
            checkBoxAnswer3.ForeColor = Color.Black;
            checkBoxAnswer4.ForeColor = Color.Black;
            checkBoxAnswer3.Visible = true;
            checkBoxAnswer4.Visible = true;

            buttonSubmitAnswer.Enabled = true;
            buttonNextQuestion.Enabled = false;
        }

        //Vérifie si la/les réponse/s de l'utilisateur est/sont correcte/s
        private bool CheckUserAnswer(List<int> userAnswers) {
            bool rightAnswer = true;//par défaut l'utilisateur a bon, si il manque des réponses ou qu'il en a une de fausse, ce boolean passe à faux

            //on check si les réponses attendues correspondent à celles de l'utilisateur, si oui -> vert, sinon -> rouge
            foreach (int expectedAnswer in currentQuestion._answer) {
                if (userAnswers.Contains(expectedAnswer)) {
                    ChangeAnswerColor(expectedAnswer, true);
                } else {
                    ChangeAnswerColor(expectedAnswer, false);
                    rightAnswer = false; //Il manque une réponse -> l'utilisateur a raté la question.
                }
            }

            //On vérifie maintenant si l'utilisateur n'a pas coché une réponse qui n'était pas attendu
            foreach (int userAnswer in userAnswers) {
                if (!(currentQuestion._answer.Contains(userAnswer))) {
                    ChangeAnswerColor(userAnswer, false);
                    rightAnswer = false;
                }
            }

            //On vérifie que l'utilisateur n'a pas oublié de réponse.
            if (!(userAnswers.Count == currentQuestion._answer.Count)) {
                rightAnswer = false;
            }

            return rightAnswer;
        }

        //Change la couleur de la réponse selon si la réponse est bonne ou fausse
        private void ChangeAnswerColor(int expectedAnswer, bool isRight) {
            switch (expectedAnswer) {
                case 1:
                    if (isRight)
                        checkBoxAnswer1.ForeColor = Color.Green;
                    else
                        checkBoxAnswer1.ForeColor = Color.Red;
                    break;
                case 2:
                    if (isRight)
                        checkBoxAnswer2.ForeColor = Color.Green;
                    else
                        checkBoxAnswer2.ForeColor = Color.Red;
                    break;
                case 3:
                    if (isRight)
                        checkBoxAnswer3.ForeColor = Color.Green;
                    else
                        checkBoxAnswer3.ForeColor = Color.Red;
                    break;
                case 4:
                    if (isRight)
                        checkBoxAnswer4.ForeColor = Color.Green;
                    else
                        checkBoxAnswer4.ForeColor = Color.Red;
                    break;
            }
        }

        //Récupère la liste des réponses de l'utilisateur. 
        private List<int> GetUserAnswer() {
            List<int> res = new List<int>();

            //On ajoute à une liste de int les réponses choisies par l'utilisateur.
            //Dans le cas ou une seule réponse est possible, la liste sera de longueur 1.
            // Elle ne pourra pas être plus longue, ceci est géré au niveau des clics sur les checkboxs
            if (checkBoxAnswer1.Checked) {
                res.Add(1);
            }
            if (checkBoxAnswer2.Checked) {
                res.Add(2);
            }
            if (checkBoxAnswer3.Checked) {
                res.Add(3);
            }
            if (checkBoxAnswer4.Checked) {
                res.Add(4);
            }
            if (res.Count != 0)
                return res;
            else//Si aucune réponse sélectionné, on renvoit null afin de gérer l'exception par nous même.
                return null;
        }

        //On cloture l'exercice, on met à jour le EvaluationResult puis on lance l'UC QCMResult
        private void EndEvaluation() {
            evalResult.QCMStatus = EvaluationResult.Status.Done;
            evalResult.resultQCM = result;
            mainForm.ChangeToQCMResult();
        }
       

        //--------- IHM controlleurs ----------
        //L'utilisateur valide sa réponse
        private void ButtonSubmitAnswer_Click(object sender, EventArgs e) {

            List<int> userAnswer = GetUserAnswer();
            if(userAnswer == null) {
                labelMissingAnswer.Visible = true;
            } else {
                bool isRight = CheckUserAnswer(userAnswer);
                labelMissingAnswer.Visible = false;
                buttonSubmitAnswer.Enabled = false;
                buttonNextQuestion.Enabled = true;
                if(isRight) { //Réponse juste
                    labelResultQuestion.Text = "Bravo !";
                    labelResultQuestion.ForeColor = Color.Green;
                    labelResultQuestion.Visible = true;
                    result++;
                    questionLeft--;
                } else {                        //Réponse fausse
                    labelResultQuestion.Text = "C'est faux";
                    labelResultQuestion.ForeColor = Color.Red;
                    labelResultQuestion.Visible = true;
                    questionLeft--;
                }

                //Ecrire dans l'avancement dans le fichier de sauvegarde
                saveFile.QCMAddAnswer(currentQuestion.id, isRight);
            }
        }

        //Bouton question suivante
        private void ButtonNextQuestion_Click(object sender, EventArgs e) {
            if (questionLeft == 0) {
                EndEvaluation();
            }
            else {
                currentQuestion = questionHandler.GetNextQuestion();
                InitQuestion();
            }
        }

        //Méthode commune à tous les boutons radios.
        private void CheckBoxAnswer_CheckedChanged(object sender, EventArgs e) {
            CheckBox current = sender as CheckBox;
            if (!ignoreEvents) { //permet d'éviter que les autres checkboxes réagissent quand on les set ci dessous
                ignoreEvents = true;
                if (!currentQuestion._multipeAnswer) { //Si une seule réponse attendue, on met toutes les autres checkbo à unchecked
                    if (current == checkBoxAnswer1) {
                        checkBoxAnswer2.Checked = false;
                        checkBoxAnswer3.Checked = false;
                        checkBoxAnswer4.Checked = false;
                    } else if (current == checkBoxAnswer2) {
                        checkBoxAnswer1.Checked = false;
                        checkBoxAnswer3.Checked = false;
                        checkBoxAnswer4.Checked = false;
                    } else if (current == checkBoxAnswer3) {
                        checkBoxAnswer1.Checked = false;
                        checkBoxAnswer2.Checked = false;
                        checkBoxAnswer4.Checked = false;
                    } else {
                        checkBoxAnswer1.Checked = false;
                        checkBoxAnswer2.Checked = false;
                        checkBoxAnswer3.Checked = false;
                    }
                }
            }
            ignoreEvents = false;
        }
    }
}
