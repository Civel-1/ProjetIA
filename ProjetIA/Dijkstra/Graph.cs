using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace ProjetIA.Dijkstra
{
    class Graph
    {
        const string localPath = "adjacent_matrix.xml";

        public int[,] AdjacentMatrix { get; set; }

        public Graph() { }
        

    }
}
