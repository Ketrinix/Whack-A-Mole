using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerBar : MonoBehaviour
{
    [Header("Datos del Temporizador")]
    public TextMeshProUGUI timerText; // Texto que muestra el tiempo restante
    public Slider timerBar;           // Barra de progreso (baja con el tiempo)
    public float timeRemaining; // Tiempo total en segundos

    private bool timerEnded = false;

    private void Start()
    {
        timerBar.maxValue = timeRemaining; // Configurar el valor máximo del slider
        timerBar.value = timeRemaining;    // Inicializar el slider con el tiempo total
    }

    private void Update()
    {
        if (!timerEnded && timeRemaining > 0f)
        {
            timeRemaining -= Time.deltaTime; // Restar tiempo
            timerBar.value = timeRemaining;  // Actualizar el slider

            UpdateTimerText();
        }
        else if (!timerEnded)
        {
            timeRemaining = 0f;
            timerEnded = true;
            timerText.text = "00:00"; // Mostrar que el tiempo terminó
        }
    }

    private void UpdateTimerText()
    {
        timerText.text = $"00:{Mathf.Ceil(timeRemaining):00}"; // Formato de minutos:segundos
    }
}