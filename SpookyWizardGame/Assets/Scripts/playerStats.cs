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
    float regenRate = -0.03f;


    public dungeonConstruction dC;
    public int collectedArtifacts = 0;
    public AudioClip pickupSound;




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
        }
        else if (!torchOn)
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
        manaUI.consumeMana(regenRate);
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
            manaUI.MaxMana += 50;
            healthUI.MaxHealth += 25;
            regenRate += -0.07f;
            Debug.Log("Opening Door Singleton");
            dC.moveDoor();
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Projectile"))
        {
            healthUI.DealDamage(25);
        }
        if (collision.CompareTag("potion"))
        {
            collision.GetComponent<AudioSource>().PlayOneShot(pickupSound, 50f);
            healthUI.DealDamage(-100);
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("manaPotion"))
        {
            collision.GetComponent<AudioSource>().PlayOneShot(pickupSound, 50f);
            manaUI.consumeMana(-50);
            Destroy(collision.gameObject);
        }
    }
}
