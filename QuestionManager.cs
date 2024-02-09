using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestionManager : MonoBehaviour
{
    // Dichiarazione delle variabili pubbliche
    public TextMeshProUGUI questionText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI timerText;
    public Button[] replyButtons;
    public Button next;
    public bool finish = false;
    public QuestionData questionData;
    public GameObject right;
    public GameObject wrong;
    public GameObject gameFinished;
    public Button playAgain;
    public AudioSource audioSourceCorrect;
    public AudioSource audioSourceIncorrect;
    public AudioClip correctAudio;
    public AudioClip incorrectAudio;
    private Timer timer;
    private int currentQuestion = 0;
    private static int score = 0;
    private bool questionAnswered = false;
    private int selectedReplyIndex = -1; // -1 indica che nessuna risposta è stata selezionata

    void Start()
    {
        // Inizializzazione delle variabili e associazione dei metodi agli eventi dei pulsanti
        questionData.RandomizeQuestions();
        right.SetActive(false);
        wrong.SetActive(false);
        gameFinished.SetActive(false);

        timer = GetComponent<Timer>();
        timer.StartTimer();
        timer.onTimerEnd += HandleTimerEnd;

        SetQuestion(currentQuestion);

        next.onClick.AddListener(NextQuestion);
        playAgain.onClick.AddListener(RestartGame);
    }

    // Metodo per riavviare il gioco
    void RestartGame()
    {
        // Resetta tutte le variabili di stato del gioco
        questionData.RandomizeQuestions();
        score = 0;
        currentQuestion = 0;
        questionAnswered = false;
        selectedReplyIndex = -1;
        gameFinished.SetActive(false); // Nascondi il pannello finale

        // Resetta il testo del punteggio
        scoreText.text = "SCORE: " + score;

        // Nascondi eventuali feedback visivi rimanenti
        right.SetActive(false);
        wrong.SetActive(false);

        // Avvia nuovamente il gioco
        SetQuestion(currentQuestion);
        timer.StartTimer();
    }

    // Metodo per impostare la domanda corrente
    void SetQuestion(int questionIndex)
    {
        // Imposta il testo della domanda
        questionText.text = questionData.newQuestions[questionIndex].questionText;

        // Ciclo attraverso i bottoni delle risposte e imposto il testo delle risposte e gli eventi onClick
        foreach (Button r in replyButtons)
        {
            r.onClick.RemoveAllListeners();
            r.GetComponent<Image>().color = Color.white; // Resetta lo stile del bottone
        }

        for (int i = 0; i < replyButtons.Length; i++)
        {
            int replyIndex = i; // Utilizza una variabile locale per catturare correttamente l'indice
            replyButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = questionData.newQuestions[questionIndex].replies[i];
            replyButtons[i].onClick.AddListener(() =>
            {
                SelectReply(replyIndex);
            });
        }
    }

    // Metodo per selezionare una risposta
    void SelectReply(int replyIndex)
    {
        if (!questionAnswered)
        {
            // Ripristina lo stile di tutti i bottoni delle risposte
            foreach (Button r in replyButtons)
            {
                r.GetComponent<Image>().color = Color.white;
            }

            // Imposta lo stile del bottone selezionato
            replyButtons[replyIndex].GetComponent<Image>().color = new Color(244f / 255f, 153f / 255f, 50f / 255f);

            selectedReplyIndex = replyIndex;
        }
    }

    // Metodo per controllare la risposta selezionata
    void CheckReply()
    {
        if (!questionAnswered && selectedReplyIndex != -1)
        {
            questionAnswered = true;

            if (selectedReplyIndex == questionData.newQuestions[currentQuestion].correctReplyIndex)
            {
                score += 10;
                scoreText.text = "SCORE: " + score;

                right.SetActive(true);
                audioSourceCorrect.clip = correctAudio;
                audioSourceCorrect.Play();
            }
            else
            {
                wrong.SetActive(true);
                audioSourceIncorrect.clip = incorrectAudio;
                audioSourceIncorrect.Play();
            }
        }
        else if (finish == true)
        {
            return;
        }
        else
        {
            audioSourceIncorrect.clip = incorrectAudio;
            audioSourceIncorrect.Play();
            wrong.SetActive(true);
        }
    }

    // Metodo per passare alla prossima domanda
    void NextQuestion()
    {
        CheckReply();
        float hideDelay = 1f;

        questionAnswered = false;
        selectedReplyIndex = -1; // Resetta l'indice della risposta selezionata

        currentQuestion++;

        if (currentQuestion < questionData.newQuestions.Length)
        {
            Invoke("Reset", hideDelay);
            SetQuestion(currentQuestion);
            timer.StartTimer(); // Avvia il timer per la nuova domanda
        }
        else
        {
            timer.EndTimer();
            gameFinished.SetActive(true);
            finish = true;

            float scorePercentage = (float)score / questionData.newQuestions.Length * 10;
            finalScoreText.text = "You scored " + scorePercentage.ToString("f0") + "%";

            if (scorePercentage < 50)
            {
                finalScoreText.text += "\nMaybe next time!";
            }
            else if (scorePercentage < 60)
            {
                finalScoreText.text += "\nKeep trying";
            }
            else if (scorePercentage < 70)
            {
                finalScoreText.text += "\nGood job";
            }
            else if (scorePercentage < 80)
            {
                finalScoreText.text += "\nWell done!";
            }
            else
            {
                finalScoreText.text += "\nYou are a genius!";
            }
        }
    }

    // Metodo per ripristinare lo stato dei pulsanti delle risposte
    void Reset()
    {
        right.SetActive(false);
        wrong.SetActive(false);

        foreach (Button r in replyButtons)
        {
            r.interactable = true;
        }
    }

    // Metodo per gestire la fine del timer
    void HandleTimerEnd()
    {
        NextQuestion();
    }
}
