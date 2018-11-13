using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProjetIA
{
    class XMLGraphReader
    {
        internal List<int[,]> getMatrixes(string pathXML)
        {
            var xml = XDocument.Load(pathXML);

            //On récupère tous les coefficients de la matrice d'adjacence, ainsi que sa taille
            var result = from graph in xml.Descendants("graphs").Descendants("graph")
                         select new
                         {
                             id = graph.Attribute("id"),
                             defvalue = graph.Attribute("default"),
                             imgpath = graph.Descendants("img"),
                             length = graph.Descendants("nbnodes").Single().Value,
                             rel = graph.Descendants("rel")
                         };

            //On crée un tableau de la taille du résultat de la requête
            List<int[,]> matrixes = new List<int[,]> (result.Count());

            //On boucle sur les résultats pour créer des objets Questions que l'on ajoute à notre tableau
            int noMatrix = 0;
            foreach (var graph in result)
            {
                int length = Convert.ToInt32(graph.length);
                matrixes[noMatrix] = new int[length, length];

                int defValue = Convert.ToInt32(graph.defvalue);

                for (int i = 0; i < length; i++)
                    for (int j = 0; j < length; j++)
                        matrixes[noMatrix][i, j] = defValue;

                //On ajoute chaque réponse à notre objet
                foreach (var rel in graph.rel)
                {
                    string relation = (string)rel;

                    string[] relations = relation.Split(',');

                    int x = Convert.ToInt32(relations[0]);
                    int y = Convert.ToInt32(relations[1]);
                    int arcCost = Convert.ToInt32(relations[2]);

                    matrixes[noMatrix][x, y] = arcCost;
                }

                noMatrix++;
            }

            return matrixes;
        }

        internal List<string> getPath(string pathXML)
        {
            var xml = XDocument.Load(pathXML);

            //On récupère tous les coefficients de la matrice d'adjacence, ainsi que sa taille
            var result = from graph in xml.Descendants("graphs").Descendants("graph")
                         select new
                         {
                             imgpath = graph.Descendants("img"),
                         };

            List<string> paths = new List<string>(result.Count());

            foreach (var graph in result)
            {
                paths.Add(graph.imgpath.ToString());
            }

            return paths;
        }
    }
}
