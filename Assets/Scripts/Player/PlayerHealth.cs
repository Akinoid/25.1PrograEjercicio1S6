using UnityEngine;


public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    [SerializeField]private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log("Player hit! Current HP: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        FindObjectOfType<GameOverUI>().ShowGameOver();
        Time.timeScale = 0f;
        Debug.Log("Player died!");

    }
}
