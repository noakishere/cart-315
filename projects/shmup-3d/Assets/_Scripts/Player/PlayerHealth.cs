using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : SingletonMonoBehaviour<PlayerHealth>
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private int health;

    void Start()
    {
        healthSlider.enabled = true;
        healthSlider.maxValue = health;
        healthSlider.minValue = 0;

        healthSlider.value = health;
    }

    public void UpdateHealth(int healthDifference)
    {
        if(health - healthDifference > 0)
        {
            health += healthDifference;
            healthSlider.value = health;
        }
        else
        {
            SceneManager.LoadScene(0);
            Debug.Log("YOU DIE!");
        }

        if(health <= 0)
        {
            SceneManager.LoadScene(0);

        }
    }
}
