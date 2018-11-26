using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProjetIA
{
    /// <summary>
    /// Utilitaire de lecture de fichier XML, permettant de récupérer les données relatives à la conception et l'affichage
    /// d'un graphe.
    /// </summary>
    class XMLGraphReader
    {
        /// <summary>
        /// Renvoie l'ensemble des matrices d'adjacences définies dans le fichier XML spécifié.
        /// </summary>
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

            List<int[,]> matrixes = new List<int[,]>();

            //Remplissage des matrices d'adjacences.
            int noMatrix = 0;
            foreach (var graph in result)
            {
                int length = Convert.ToInt32(graph.length);
                matrixes.Add(new int[length, length]);

                int defValue = (int)graph.defvalue;

                for (int i = 0; i < length; i++)
                    for (int j = 0; j < length; j++)
                        matrixes[noMatrix][i, j] = defValue;

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

        /// <summary>
        /// Renvoie les chemins d'accès au immages des graphes.
        /// </summary>
        internal List<string> getPath(string pathXML)
        {
            var xml = XDocument.Load(pathXML);

            var result = from graph in xml.Descendants("graphs").Descendants("graph")
                         select new
                         {
                             imgpath = graph.Attribute("img")
                         };

            List<string> paths = new List<string>();

            foreach (var graph in result)
            {
                paths.Add((string)graph.imgpath);
            }

            return paths;
        }
    }
}
