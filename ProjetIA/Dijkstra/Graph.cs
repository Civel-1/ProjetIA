using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace ProjetIA
{
    /// <summary>
    /// Classe permettant de récupérer depuis un fichier XML l'ensemble des informations nécessaires à
    /// la construction d'une matrice d'adjacence pour le problème posé.
    /// Les Graphs s'occupent également de choisir au hasard une modélisation dans le fichier XML, un noeud
    /// initial, et un noeud final.
    /// </summary>
    public class Graph
    {

        const string xmlPath = "../../Dijkstra/graph.xml"; //le fichier est défini en tant que ressource incorporée.
        private static Random rnd = new Random();

        /// <summary>
        /// Matrice d'adjacence du graphe.
        /// </summary>
        public int[,] AdjacentMatrix { get; set; }
        /// <summary>
        /// Nombre de noeuds contenus dans le graphe.
        /// </summary>
        public int NbNodes { get; set; }
        /// <summary>
        /// Identifiant numérique du noeud initial.
        /// </summary>
        public int InitNode { get; set; }
        /// <summary>
        /// Identifiant numérique du noeud final.
        /// </summary>
        public int EndNode { get; set; }
        /// <summary>
        /// Chemin d'accès à l'image représentant le graphe.
        /// </summary>
        public string imgPath { get; set; }

        public Graph()
        {
            XMLGraphReader graphReader = new XMLGraphReader();
            List<int[,]> adjacentMatrixes = graphReader.getMatrixes(xmlPath);
            int alea = rnd.Next(0, adjacentMatrixes.Count);

            AdjacentMatrix = adjacentMatrixes[alea];
            NbNodes = AdjacentMatrix.GetLength(0);
            imgPath = graphReader.getPath(xmlPath)[alea];

            InitNode = rnd.Next(0, 2); //On part toujours d'un des premiers noeuds par défaut
            EndNode = NbNodes - 1; //On se rend toujours au dernier noeud pas défaut
        }
    }
}
