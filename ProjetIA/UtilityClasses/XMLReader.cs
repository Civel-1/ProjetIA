using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProjetIA {
    class XMLReader {
        //Cette class s'occupe de lire le XML et de faire le mapping et de renvoyer un tableau de Questions

        private String pathFile = @"questions.xml";

        internal Question[] getQuestions() {
            

            var xml = XDocument.Load(pathFile);

            //On récupère toutes les questions
            var result = from question in xml.Descendants("questions").Descendants("question")
                       select new {
                           id = question.Attribute("id"),
                           intitule = question.Descendants("intitule").Single().Value,
                           reponsesPossibles = question.Descendants("reponses").Descendants("reponse"),
                           reponsesAttendues = question.Descendants("reponsesAttendues").Descendants("reponseAttendue")
                           };

            //On crée un tableau de la taille du résultat de la requête
            Question[] questions = new Question[result.Count()];

            //On boucle sur les résultats pour créer des objets Questions que l'on ajoute à notre tableau
            int compteurQuestion = 0;
            foreach (var question in result) {

                Question currentQuestion = new Question();
                currentQuestion._question = question.intitule;
                currentQuestion.id = (int)question.id;
                

                //On ajoute chaque réponse à notre objet
                foreach (var reponsePossible in question.reponsesPossibles) {
                    if(reponsePossible.Attribute("number").Value.Equals("1")) {
                        currentQuestion._answer1 = reponsePossible.Value;
                    }else if (reponsePossible.Attribute("number").Value.Equals("2")) {
                        currentQuestion._answer2 = reponsePossible.Value;
                    } else if (reponsePossible.Attribute("number").Value.Equals("3")) {
                        currentQuestion._answer3 = reponsePossible.Value;
                    } else if (reponsePossible.Attribute("number").Value.Equals("4")) {
                        currentQuestion._answer4 = reponsePossible.Value;
                    }
                }

                //Ici on ajoute la liste des réponses attendues.
                foreach (var reponseAttendue in question.reponsesAttendues) {
                    currentQuestion._answer.Add((int)reponseAttendue);
                }

                //Finalement, on renseigne les bool réponses multiples et vrai/faux
                if(question.reponsesPossibles.Count() == 2) {
                    currentQuestion._isTrueOrFalse = true;
                } else {
                    currentQuestion._isTrueOrFalse = false;
                }

                if (question.reponsesAttendues.Count() != 1) {
                    currentQuestion._multipeAnswer = true;
                } else {
                    currentQuestion._multipeAnswer = false;
                }

                //on ajoute finalement la question à notre tableau maintenant que l'objet est completement renseigné
                questions[compteurQuestion] = currentQuestion;
                compteurQuestion++;
            }

            return questions;
        }
    }
}
