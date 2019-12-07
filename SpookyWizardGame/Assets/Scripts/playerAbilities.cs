using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAbilities : MonoBehaviour
{
    bool attacking = false;
    public Animator anim;
    public GameObject firePoint;
    public List<GameObject> vfx = new List<GameObject>();
    private GameObject effectToSpawn;
    public float fireRate = 1;
    private float nextFire = 0.0F;
    public bool flameOn = true;
    public GameObject torchFire;
    public GameObject torchLight;
    public Mana manaUI;
    public AudioClip bolt;
    public AudioClip lightClick;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        effectToSpawn = vfx[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Debug.Log("animation should play");
            anim.SetBool("attacking", true);
            //SpawnVFX();
        }
        else
        {
            anim.SetBool("attacking", false);
        }

        if (Input.GetKeyDown(KeyCode.R) && (flameOn == false))
        {
            Debug.Log("IGNITE in UP");
            anim.SetBool("igniteMan", true);
            //Ignite();
        }
        else if (Input.GetKeyDown(KeyCode.R) && (flameOn == true))
        {
            Debug.Log("DOUSE in UP");
            anim.SetBool("douseMan", true);
            //Douse();
        }
    }

    void SpawnVFX()
    {
        GameObject vfx;

        if (firePoint != null)
        {
            if (manaUI.CurrentMana >= 20)
            {
                gameObject.GetComponent<AudioSource>().PlayOneShot(bolt, 3.8f);
                this.gameObject.GetComponent<playerStats>().FireboltMana();
                vfx = Instantiate(effectToSpawn, firePoint.transform.position, firePoint.transform.rotation);
            }
        }
        else
        {
            Debug.Log("No Fire Point");
        }
    }

    public void Ignite()
    {
        //turn on particles
        Debug.Log("IGNITE");
        gameObject.GetComponent<AudioSource>().PlayOneShot(lightClick, 3.8f);
        torchFire.GetComponent<ParticleSystem>().Play();
        flameOn = true;

        //turn on light
        torchLight.GetComponent<Light>().enabled = true;

        this.gameObject.GetComponent<playerStats>().IgniteMana();


        anim.SetBool("igniteMan", false);
    }

    public void Douse()
    {
        //turns off particles
        Debug.Log("DOUSE");
        gameObject.GetComponent<AudioSource>().PlayOneShot(lightClick, 3.8f);
        torchFire.GetComponent<ParticleSystem>().Stop();
        flameOn = false;

        // turns off light 
        torchLight.GetComponent<Light>().enabled=false;



        anim.SetBool("douseMan", false);

        anim.SetBool("waterTrap", false);

    }
}
