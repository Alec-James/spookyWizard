using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStats : MonoBehaviour
{
    //public int playerHealth = 100;
    //public int playerMana = 100;
    bool torchOn;

    Mana manaUI;
    Health healthUI;
    bool isDepleted;

    public dungeonConstruction dC;
    public int collectedArtifacts = 0;




    // Start is called before the first frame update
    void Start()
    {
        torchOn = this.gameObject.GetComponent<playerAbilities>().flameOn;

        healthUI = GameObject.Find("Health").GetComponent<Health>();
        manaUI = GameObject.Find("Magic").GetComponent<Mana>();

        dC = GameObject.Find("dungeonMaster").GetComponent<dungeonConstruction>();

    }

    // Update is called once per frame
    void Update()
    {
        torchOn = this.gameObject.GetComponent<playerAbilities>().flameOn;


        //if the torch is on, drain mana
        if (torchOn)
        {
            TorchMana();
        }else if (!torchOn)
        {
           //regens mana if torch is off
            RegenMana();
        }

       


    }

    public void IgniteMana()
    {
        manaUI.consumeMana(10f);
        Debug.Log("IGNITE MANA DECREASE");
    }

    public void TorchMana()
    {
        manaUI.consumeMana(.05f);
    }

    public void RegenMana()
    {
        manaUI.consumeMana(-.03f);
    }

    public void FireboltMana()
    {
        
        manaUI.consumeMana(20f);
    }

    public void Death()
    {

    }

    public void BossDam()
    {

    }

    public void HealthPotion()
    {

    }

    public void ManaPotion()
    {

    }

    public void collectArtifact()
    {
        collectedArtifacts += 1;
        if (collectedArtifacts == 3)
        {
            Debug.Log("Opening Door Singleton");
            dC.moveDoor();
        }
    }


}
