﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetIA.UserControls
{
    public partial class DijkstraUC : UserControl
    {
        private IndexForm mainForm;
        private Graph currentGraph;
        private SearchTree DijSolver;

        public DijkstraUC(IndexForm _mainForm)
        {
            InitializeComponent();
            mainForm = _mainForm;

            currentGraph = new Graph();
            DijSolver = new SearchTree();
            imgGraph.ImageLocation = currentGraph.imgPath;

            StartEvaluating();
        }

        public void StartEvaluating()
        {
            
        }
    }
}
