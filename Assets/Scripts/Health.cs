using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;



    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        Debug.Log("Damage taken: " + damageAmount);
        currentHealth -= damageAmount;
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("Loading");
        }
    }
}
