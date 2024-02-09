using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadTimer : MonoBehaviour
{
    // Metodo chiamato per avviare la scena del quiz
    public void StartQuizScene()
    {
        // Carica la scena chiamata "QuizScene" in modo asincrono
        SceneManager.LoadSceneAsync("QuizScene");
    }
}
