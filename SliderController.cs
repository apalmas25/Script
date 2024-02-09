using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SliderController : MonoBehaviour
{
    // Riferimento al componente TextMeshProUGUI associato al testo dello slider
    [SerializeField] private TextMeshProUGUI sliderText = null;

    // Valore massimo dello slider
    [SerializeField] private float maxSliderAmount = 100.0f;

    // Metodo chiamato quando il valore dello slider cambia
    public void SliderChange(float value)
    {
        // Calcola il valore effettivo dello slider moltiplicando il valore passato per il valore massimo
        float localValue = value * maxSliderAmount;

        // Aggiorna il testo dello slider con il valore calcolato, formattandolo in modo che mostri solo un intero
        sliderText.text = localValue.ToString("0");
    }
}
