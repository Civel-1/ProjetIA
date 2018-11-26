using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetIA
{
    // Classe abstraite, il est donc impératif de créer une classe qui en hérite
    // pour résoudre un problème particulier en y ajoutant des infos liées au contexte du problème
    abstract public class GenericNode
    {
        public int Num { get; protected set; }
        protected double gCost;
        /// <summary>
        /// Estimation heuristique du coût pour atteindre le noeud final (méthode A* non implémentée ici).
        /// </summary>
        protected double hCost;
        /// <summary>
        /// Coût total (gCost+hCost).
        /// </summary>
        public double TotCost { get; protected set; }
        protected GenericNode parentNode; 
        /// <summary>
        /// Liste des noeuds enfants.
        /// </summary>
        public List<GenericNode> Children { get; }            
        /// <summary>
        /// Lien vers le graphe contenant le noeud. 
        /// </summary>
        public Graph graph { get; set; } 

        public GenericNode(int num, Graph graph)
        {
            ParentNode = null;
            Children = new List<GenericNode>();
            this.graph = graph;
            Num = num;
        }

        /// <summary>
        /// Coût du chemin du noeud initial jusqu'à ce noeud.
        /// </summary>
        public double GCost
        {
            get { return gCost; }
            set
            {
                gCost = value;
                CalculateTotCost();
            }
        }

        /// <summary>
        /// Noeud parent.
        /// </summary>
        public GenericNode ParentNode
        {
            get { return parentNode; }
            set
            {
                parentNode = value;
                if(parentNode != null)
                    parentNode.Children.Add(this);
            }
        }

        /// <summary>
        /// Supprime le lien vers le noeud parent du noeud courant.
        /// </summary>
        public void FlushParent()
        {
            if (parentNode == null)
                return;
            parentNode.Children.Remove(this);
            parentNode = null;
        }

        public void CalculateTotCost()
        {
            this.TotCost = GCost + hCost;
        }

        public abstract bool IsEqual(GenericNode gn);
        /// <summary>
        /// Détermine le coût de l'arc entre le noeud et un noeud gn, en fonction de la matrice d'adjacence définie dans 
        /// le graphe des noeuds.
        /// </summary>
        public abstract double GetArcCost(GenericNode gn);
        /// <summary>
        /// Obtient les successeurs du noeud courant dans le graphe.
        /// </summary>
        public abstract List<GenericNode> GetSuccessors();
        /// <summary>
        /// Renvoie le coût heuristique estimé entre deux noeuds. Non implémenté ici.
        /// </summary>
        public abstract double CalculateHCost();
        /// <summary>
        /// Renvoie si le noeud est le noeud de destination du problème de plus court chemin.
        /// </summary>
        public abstract bool GetEndState();
    }
}
