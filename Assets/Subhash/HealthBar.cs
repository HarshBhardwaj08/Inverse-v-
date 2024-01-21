using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Slider healthSlider;
    [SerializeField] Image healthSliderImage;
    [SerializeField] Gradient gradientColor;

    int currentHealth ;
    int maxHealth = 100;
    bool isDead = false;
    bool end = false;

    public static event Action OnDead;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        healthSliderImage.color = gradientColor.Evaluate(currentHealth);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(end) return;


        if(currentHealth <= 0)
        {
            OnDead?.Invoke();
            Debug.Log("end");
            end = true;
        }
    }


    public void Damage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth < 0) 
        {
            healthSlider.value = 0;

            return;
        }
        
        float healthvalue = (float)currentHealth / maxHealth;
        healthSlider.value = healthvalue;
        healthSliderImage.color = gradientColor.Evaluate(healthvalue);
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

        public void SetIsDeadTrue()
    {
        isDead = true;
    }

    public bool GetIsDead()
    {
        return isDead;
    }
}
