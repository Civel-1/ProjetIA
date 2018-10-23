using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetIA
{
    // classe abstraite, il est donc impératif de créer une classe qui en hérite
    // pour résoudre un problème particulier en y ajoutant des infos liées au contexte du problème
    abstract public class GenericNode
    {
        protected double gCost;           //coût du chemin du noeud initial jusqu'à ce noeud
        protected double hCost;               //estimation heuristique du coût pour atteindre le noeud final
        public double TotCost { get; protected set; }           //coût total (g+h)
        protected GenericNode parentNode;     // noeud parent
        public List<GenericNode> Children { get; }  // noeuds enfants
        public bool EndState { get; set; }

        public GenericNode()
        {
            ParentNode = null;
            Children = new List<GenericNode>();
        }

        public double GCost
        {
            get { return gCost; }
            set
            {
                gCost = value;
                CalculateTotCost();
            }
        }

        public GenericNode ParentNode
        {
            get { return parentNode; }
            set
            {
                parentNode = value;
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
            hCost = CalculateHCost();
            this.TotCost = GCost + hCost;
        }

        public void RecalculeCoutTotal()
        {
            TotCost = GCost + hCost;
        }

        // Méthodes abstrates, donc à surcharger obligatoirement avec override dans une classe fille
        public abstract bool IsEqual(GenericNode N2);
        public abstract double GetArcCost(GenericNode N2);
        public abstract List<GenericNode> GetListSucc();
        public abstract double CalculateHCost();
        // On peut aussi penser à surcharger ToString() pour afficher correctement un état
        // c'est utile pour l'affichage du treenode
    }
}
