using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Metodo chiamato per avviare la scena principale
    public void StartMainScene()
    {
        // Carica la scena chiamata "MainScene" in modo asincrono
        SceneManager.LoadSceneAsync("MainScene");
    }
}
