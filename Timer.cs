using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // Variabile per il tempo rimanente
    public float timeRemaining = 15;
    // Testo del timer
    public TextMeshProUGUI timerText;

    // Evento che viene attivato quando il timer finisce
    public event Action onTimerEnd;

    // Flag che indica se il timer e' in esecuzione
    private bool isTimerRunning = false;

    // Proprieta' che indica se il timer e' terminato
    public bool IsTimerEnded { get; private set; }

    // AudioClip per il suono di avvio del timer
    public AudioClip startSound;

    // AudioSource per riprodurre il suono di avvio del timer
    public AudioSource AST;

    void Update()
    {
        // Se il timer e' in esecuzione
        if (isTimerRunning)
        {
            // Se il tempo rimanente e' maggiore di zero, aggiorna il timer
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimer();
            }
            // Altrimenti, se il tempo e' scaduto, interrompi il timer
            else
            {
                timeRemaining = 0;
                isTimerRunning = false;
                IsTimerEnded = true;
                onTimerEnd?.Invoke();
            }
        }
    }

    // Metodo per aggiornare il testo del timer UI
    void UpdateTimer()
    {
        int seconds = Mathf.CeilToInt(timeRemaining);
        timerText.text = seconds.ToString();
    }

    // Metodo per avviare il timer
    public void StartTimer()
    {
        // Resetta il tempo rimanente, imposta il timer in esecuzione e avvia il suono di avvio
        timeRemaining = 15;
        isTimerRunning = true;
        IsTimerEnded = false;
        AST.clip = startSound;
        AST.Play();
    }

    // Metodo per terminare il timer e fermare il suono
    public void EndTimer()
    {
        AST.Stop();
    }
}
