using ProjetIA.UtilityClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetIA {
    class QuestionHandler {

        //Cette classe est un singleton, nous ne voulons pas plus d'une instance de cette classe.
        //Elle permet de gérer les questions, elle appelle le XMLReader qui s'occupe du mapping puis distribue les questions aléatoirement
        private static QuestionHandler instance;
        private Question[] questions;
        private List<int> answeredQuestions;
        private Random rnd;
        private EvaluationResult evalResult;

       
        private QuestionHandler() {

            //On récupère 
            evalResult = EvaluationResult.Instance;

            //On récupère la liste des questions depuis le XML
            XMLReader xmlReader = new XMLReader();
            questions = xmlReader.getQuestions();


            //Lors de la première question, on initialise le random qui nous servira tout du long de l'exercice
            rnd = new Random();

            //Si le joueur a déjà commencé le test, on récupère les questions auxquelles il a déjà répondu
            answeredQuestions = evalResult.answeredQuestions;
        }

        public static QuestionHandler Instance {
            get {
                if (instance == null) {
                    instance = new QuestionHandler();
                }
                return instance;
            }
        }

        //Retourne aléatoirement une nouvelle question parmi celles qui n'ont pas encore été posé
        internal Question GetNextQuestion() {
            

            //On boucle jusqu'à trouver une question qui n'a pas encore été posé
            //TODO REVOIR CA
            int questionNumber = -1;
            bool newQuestion = false;
            while (newQuestion == false) {
                newQuestion = true;
                questionNumber = rnd.Next(1, questions.Length + 1);

                //On vérifie que la question n'a pas déjà été posée
                foreach( int answeredQuestion in answeredQuestions) {
                    if(answeredQuestion == questions[questionNumber - 1].id) {
                        newQuestion = false;
                    }
                }
            }
            answeredQuestions.Add(questions[questionNumber - 1].id);
            return questions[questionNumber-1];
        }
    }
}
