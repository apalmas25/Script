using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Learn : MonoBehaviour
{
    // Metodo chiamato per avviare la scena di apprendimento
    public void Learna()
    {
        // Carica la scena con l'indice 21 in modo asincrono
        SceneManager.LoadSceneAsync(21);
    }
}
