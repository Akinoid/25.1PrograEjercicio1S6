using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class StartO : MonoBehaviour
{
    [SerializeField] private Button mainMenuButton;
    void Start()
    {
        mainMenuButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Game");
        });
    }

}

    
