using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameHUD : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI killsText;
    [SerializeField] private TextMeshProUGUI levelText;

    public float elapsedTime = 0f;
    public int currentLevel = 1;

    void Update()
    {
        elapsedTime += Time.deltaTime;

        
        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);
        timerText.text = $"Tiempo: {minutes:00}:{seconds:00}";

        
        killsText.text = $"Eliminados: {EnemyManager.Instance.EnemiesKilled}";

        
        int newLevel = Mathf.FloorToInt(elapsedTime / 40f) + 1;
        if (newLevel != currentLevel)
        {
            currentLevel = newLevel;
        }
        levelText.text = $"Nivel: {currentLevel}";
    }
}
