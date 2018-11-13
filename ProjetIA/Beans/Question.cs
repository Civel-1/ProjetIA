using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetIA {
    public class Question {
        //Cette classe permet de créer des instances de Questions.
        //Elle possède les informations concernant l'intitulé, les réponses possibles et attendues

        public int id { get; set; }
        public string _question { get; set; }
        public string _answer1 { get; set; }
        public string _answer2 { get; set; }
        public string _answer3 { get; set; }
        public string _answer4 { get; set; }
        public bool _multipeAnswer { get; set; }
        public bool _isTrueOrFalse { get; set; }
        public List<int> _answer { get; set; }

        public Question() {
            _answer = new List<int>();
        }

        public Question(string question, string answer1, string answer2, string answer3, string answer4,
                    bool multipleAnswer, bool isTrueOrFalse, List<int> answer) {
            _question = question;
            _answer1 = answer1;
            _answer2 = answer2;
            _answer3 = answer3;
            _answer4 = answer4;
            _multipeAnswer = multipleAnswer;
            _isTrueOrFalse = isTrueOrFalse;
            _answer = answer;
        }
    }
}
