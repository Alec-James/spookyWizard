using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Mana : MonoBehaviour
{
    public float CurrentMana { get; set; }
    public float MaxMana { get; set; }
    public Slider manahbar;

    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        MaxMana = 100f;
        CurrentMana = MaxMana;
        if (manahbar != null)
            manahbar.value = CalcMana();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.X))
        //consumeMana(0.1f);
    }

    public void consumeMana(float dmg)
    {
        CurrentMana -= dmg;
        if (manahbar != null)
            manahbar.value = CalcMana();

        if (CurrentMana <= 0)
        {
            player.GetComponent<playerAbilities>().Douse();
        }

    }
    float CalcMana()
    {
        return CurrentMana / MaxMana;

    }
   
}
