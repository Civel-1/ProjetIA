using System.Collections.Generic;

namespace ProjetIA {
    public class EvaluationResult {

        //Cet objet permet de suivre l'évolution et les résultats de l'utilisateur durant 
        //son examen. Il est initialisé dans IndexForm et est public, chaque UC peut donc le lire
        //et ajouter les résultats à la fin des exercices

        private static EvaluationResult instance;

        //QCM
        public Status QCMStatus;
        public int questionLeft = 20;
        public int totalQuestion = 20;
        public List<int> answeredQuestions;
        public int currentScoreQCM;
        public int resultQCM;

        //Dijkstra
        public Status DijkstraStatus;
        public int resultDijkstra;


        //On crée une énumérateur pour le statut de progression du test
        public enum Status {
            Done,
            In_Progress,
            Not_Started
        }

        public EvaluationResult() {
            QCMStatus = Status.Not_Started;
            DijkstraStatus = Status.Not_Started;
            answeredQuestions = new List<int>();
            resultDijkstra = -1;
            resultQCM = -1;
        }

        public static EvaluationResult Instance {
            get {
                if (instance == null) {
                    instance = new EvaluationResult();
                }
                return instance;
            }
        }
    }
}
