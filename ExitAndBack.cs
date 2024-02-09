using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Importa il modulo necessario per gestire le scene in Unity

public class ExitAndBack : MonoBehaviour
{
    // Metodo per tornare alla scena con l'indice 18
    public void Back()
    {
        SceneManager.LoadSceneAsync(18); // Carica la scena con l'indice 18 in modo asincrono
    }

    // Metodo per uscire dal gioco
    public void QuitGame()
    {
        Application.Quit(); // Chiude l'applicazione

        // Nel caso l'applicazione sia in esecuzione nell'editor di Unity, interrompe la riproduzione
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
