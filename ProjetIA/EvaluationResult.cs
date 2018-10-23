using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetIA
{
    public class EvaluationResult
    {

        //Cet objet permet de suivre l'évolution et les résultats de l'utilisateur durant 
        //son examen. Il est initialisé dans IndexForm et est public, chaque UC peut donc le lire
        //et ajouter les résultats à la fin des exercices

        public bool hasDoneQCM;
        public bool hasDoneDijkstra;
        public int resultQCM;
        public int resultDijkstra;

        public EvaluationResult() {
            hasDoneDijkstra = false;
            hasDoneQCM = false;
            resultDijkstra = -1;
            resultQCM = -1;
        }
    }
}
