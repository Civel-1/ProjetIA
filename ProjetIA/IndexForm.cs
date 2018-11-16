using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjetIA.UserControls;

namespace ProjetIA {
    public partial class IndexForm : Form {


        /*Cette classe est le formulaire de départ, vide par défaut, il appelle les bons UserControls à mettre
         au bon moment. Elle permet donc de gérer la communication et le routing entre les UC.
         C'est également à cette classe qu'est rattaché l'objet EvaluationResult car elle persistera toujours contrairement aux UC.*/

        /*A mettre dans le rapport : 
        Un choix à été fait pendant la conception, celui d'avoir un seul usercontrol pour toutes les questions
        et de l'appeler avec les questions/réponses en paramètres. on aurait pu avoir un template WPF xml qui avait tous les 
        attributs d'un usercontrol ce qui aurait permis d'avoir une interface spécifique à chaque question. 
        Mais ça implique de créer à chaque fois un usercontrol sous visual studio et de le retranscrire en xml.
        ce qui est long et chiant surtout si on veut juste ajouter à la volée des questions.
        du coup le choix qui a été fait est d'avoir une interface fixe avec un xml très simple permettant d'jaouter 
        facilement des questions (très intuitivement).
        On prendra en charge dans le code les questions spécifiques (2 réponses au lieu de 4, réponses multiples)

            A REVOIR, pas sur sur le passage des templates
        */
        //Amélioration possible : un fichier qui sauvegarde l'avancement de l'utilisateur.

        
        public EvaluationResult evalResult;

        //List des userControls
        UserControl indexUC;
        

        public IndexForm() {
            InitializeComponent();
            Text = "Evaluation Intelligence Artificielle";
            //Initialisation du premier UC
            indexUC = new IndexUC(this);
            //Initialisation de l'objet qui nous servira a garder trace des résultats
            evalResult = new EvaluationResult();

            Controls.Add(indexUC);
        }
        

        // ------------  Routing ------------------
        public void ChangeToEvaluating() {
            Controls.Clear();
            Controls.Add(new EvaluatingUC(this));
        }

        public void ChangeToQCM(int questionLeft) {
            Controls.Clear();
            QCMUC qcmuc = new QCMUC(this, questionLeft);
            Controls.Add(qcmuc);
        }

        internal void ChangeToQCMResult() {
            Controls.Clear();
            QCMResultUC qcmruc = new QCMResultUC(this);
            Controls.Add(qcmruc);
        }

        public void ChangeToDijkstra()
        {
            Controls.Clear();
            DijkstraUC djuc = new DijkstraUC(this);
            Controls.Add(djuc);
        }

        public void LoadImage(string path, PictureBox box)
        {
            box.ImageLocation = path;
        }

    }
}
