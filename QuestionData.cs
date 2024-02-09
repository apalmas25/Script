using UnityEngine;
using System.Linq;
using System.Collections.Generic;

// leggo le domande da inspector
[CreateAssetMenu(fileName = "New QuestionData", menuName = "QuestionData")]


// classe che contiene la lista di domande
public class QuestionData : ScriptableObject
{
    [System.Serializable]

    // una domanda e' una struttura dati che possiede il testo della domanda, una lista di risposte possibili e l'indice della risposta corretta
    public struct Question
    {

        public string questionText;

        public string[] replies;

        public int correctReplyIndex;
    }

    public Question[] questions;

    public Question[] newQuestions;

    // metodo che serve per randomizzare la lista di domande (ne sceglie 10 su 30)
    public void RandomizeQuestions()
    {
        List<Question> remainingQuestions = questions.ToList();
        newQuestions = new Question[10];

        for (int i = 0; i < 10; i++)
        {
            // Se non ci sono piu domande disponibili, interrompi il ciclo
            if (remainingQuestions.Count == 0)
                break;

            // Seleziona casualmente una domanda tra quelle rimanenti
            int randomIndex = Random.Range(0, remainingQuestions.Count);
            newQuestions[i] = remainingQuestions[randomIndex];

            // Rimuovi la domanda selezionata dall'elenco delle domande rimanenti
            remainingQuestions.RemoveAt(randomIndex);
        }
    }
}