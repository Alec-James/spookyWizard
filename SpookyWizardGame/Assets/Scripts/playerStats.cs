using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStats : MonoBehaviour
{
    public int playerHealth = 100;
    public int playerMana = 100;
    bool torchOn;
    // Start is called before the first frame update
    void Start()
    {
        torchOn = this.gameObject.GetComponent<playerAbilities>().flameOn;

    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth == 0)
        {
            //DIE
        }

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
        Debug.Log("IGNITE MANA DECREASE");
    }

    public void TorchMana()
    {

    }

    public void RegenMana()
    {

    }

    public void FireboltMana()
    {

    }

    public void Death()
    {

    }

    public void BossDam()
    {

    }


}
