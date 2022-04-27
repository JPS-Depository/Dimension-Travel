using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Image healthBar;
    public float currentHealth;
    private float maxHealth= 100f;
    public Car2DController car;

    private void Start()
    {
        healthBar = GetComponent<Image>();
        //car = FindObjectOfType<Car2DController>();
    }

    private void Update()
    {
        currentHealth = car.carHealth;
        healthBar.fillAmount = currentHealth / maxHealth;
    }
}
