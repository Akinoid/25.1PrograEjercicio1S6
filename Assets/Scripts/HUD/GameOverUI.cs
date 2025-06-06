using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class GameOverUI : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private TMP_Text timeText;
    [SerializeField] private TMP_Text killsText;
    [SerializeField] private TMP_Text levelText;
    [SerializeField] private Button mainMenuButton;
    public GameHUD game;
    public GameObject g;
    private void Start()
    {
        panel.SetActive(false); 
        mainMenuButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Start");
        });
    }

    public void ShowGameOver()
    {
        float time = game.elapsedTime;
        int kills = EnemyManager.Instance.EnemiesKilled;
        int level = game.currentLevel;

        timeText.text = $"Tiempo sobrevivido: {time:F1} s";
        killsText.text = $"Enemigos eliminados: {kills}";
        levelText.text = $"Nivel alcanzado: {level}";

        panel.SetActive(true);

        g.SetActive(false);
    }
}
