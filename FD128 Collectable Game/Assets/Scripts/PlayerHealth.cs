using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Slider healthBar;
    public int maxHealth;
    private int currentHealth;

    public GameObject gameOverScreen;
    
    // Start is called before the first frame update
    void Start()
    {
        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;
        currentHealth = maxHealth;
        gameOverScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Heal(int value)
    {
        currentHealth += value;
        if(currentHealth >= healthBar.maxValue)
        {
            currentHealth = maxHealth;
        }
        healthBar.value = currentHealth;
    }

    public void TakeDamage(int value)
    {
        currentHealth -= value;
        healthBar.value = currentHealth;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Time.timeScale = 0;
        gameOverScreen.SetActive(true);
    }
}
