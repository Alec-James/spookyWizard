using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Health : MonoBehaviour
{
    public float CurrentHealth { get; set; }
    public float MaxHealth { get; set; }
    public Slider healthbar;
    // Start is called before the first frame update
    void Start()
    {
        MaxHealth = 100f;
        CurrentHealth = MaxHealth;
        if(healthbar!=null)
            healthbar.value = CalcHealth();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.X))
            //DealDamage(1);
    }

    public void DealDamage(float dmg)
    {
        CurrentHealth -= dmg;
        if(healthbar!=null)
            healthbar.value = CalcHealth();
        if (CurrentHealth <= 0)
        {
            Die();
        }
        if(CurrentHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;
            healthbar.value = MaxHealth;
        }
    }
    float CalcHealth()
    {
        return CurrentHealth / MaxHealth;

    }
    void Die()
    {
        CurrentHealth = 0;
        SceneManager.LoadScene("Death");
    }
}
