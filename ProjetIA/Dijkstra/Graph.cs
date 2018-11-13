using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace ProjetIA
{
    public class Graph
    {
        const string xmlPath = "graph.xml";
        private static Random rnd = new Random();

        public int[,] AdjacentMatrix { get; set; }
        public int NbNodes { get; set; }
        public int InitNode { get; set; }
        public int EndNode { get; set; }
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
