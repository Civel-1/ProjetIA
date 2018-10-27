using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProjetIA.UtilityClasses {
    class SaveFileUtility {

        private static SaveFileUtility instance;
        private string pathfile = @"progression.xml";
        private XDocument saveFile;


        private SaveFileUtility() {
            saveFile = getSaveFile();
        }

        public static SaveFileUtility Instance {
            get {
                if (instance == null) {
                    instance = new SaveFileUtility();
                }
                return instance;
            }
        }

        //instancie l'évaluation en cours selon ce qui est trouvé dans le fichier de sauvegarde
        internal EvaluationResult GetCurrentProgression() {
            EvaluationResult evalResult = EvaluationResult.Instance;

            List<int> questionsAnswered = GetQCMAnsweredQuestion();

            if (questionsAnswered.Count == 20) {
                evalResult.QCMStatus = EvaluationResult.Status.Done;
                evalResult.resultQCM = GetQCMResult();
            } else if(!(questionsAnswered.Count == 20)) {
                evalResult.answeredQuestions = questionsAnswered;
                evalResult.QCMStatus = EvaluationResult.Status.In_Progress;
                evalResult.questionLeft = 20 - questionsAnswered.Count;
                evalResult.currentScoreQCM = GetQCMResult();
            }

            return evalResult;
        }

        //Retourne le fichier de sauvegarde, si il n'existe pas, le crée
        public XDocument getSaveFile() {

            XDocument file = null ;

            //On regarde si le fichier existe déjà.
            if (File.Exists(pathfile)) {
                file = XDocument.Load(pathfile);

            }
            if (!File.Exists(pathfile)) {

                //Creation du fichier xml de sauvegarde de progression.
                //Trois status pour chaque exercice : Done, In Progress
                new XDocument(
                    new XElement("Evaluation")).Save(pathfile);

                file = XDocument.Load(pathfile);
            }
            return file;

            }


        //On récupère la liste des questions auxquelles l'utilisateur a déjà répondu
        internal List<int> GetQCMAnsweredQuestion() {
            List<int> listQuestion = new List<int>();

            var result = from question in saveFile.Descendants("QCM").Descendants("Question")
                         select new {
                             id = question.Attribute("id")
                         };
            foreach (var item in result) {
                listQuestion.Add((int)item.id);

            }
            return listQuestion;
        }

        //On récupère le résultat de l'utilisateur au QCM
        internal int GetQCMResult() {
            int finalResult = 0;

            var result = from question in saveFile.Descendants("QCM").Descendants("Question")
                         select new {
                             answer = question.Value
                         };
            foreach (var item in result) {
                if (item.answer.Equals("true")) {
                    finalResult++;
                }

            }
            return finalResult;
        }


        //Méthode qui ajoute au xml la réponse, appelée lorsque l'utilisateur valide sa réponse
        public void QCMAddAnswer(int questionNumber, bool result) {

            //On vérifie si c'est la première fois que l'utilisateur répond à une question du QCM
            if (saveFile.Root.Element("QCM") == null) {
                saveFile.Root.Add(new XElement("QCM"));
                saveFile.Save(pathfile);
            }

            //On ajoute un nouvel élément, la réponse.
            saveFile
                .Root
                .Element("QCM")
                .Add(new XElement("Question", new XAttribute("id", questionNumber), result));
            saveFile.Save(pathfile);
        }
        }
    }

