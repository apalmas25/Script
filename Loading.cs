using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    // Metodo chiamato per caricare la scena
    public void Load()
    {
        // Carica la scena con l'indice 19 in modo asincrono
        SceneManager.LoadSceneAsync(19);
    }

    // Metodo chiamato per uscire dal gioco
    public void QuitGame()
    {
        // Chiude l'applicazione
        Application.Quit();

        // Se l'applicazione è in esecuzione nell'editor Unity
#if UNITY_EDITOR
        // Ferma l'esecuzione nel gioco nell'editor
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
