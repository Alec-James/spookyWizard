using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterTrap : MonoBehaviour
{
    GameObject player;
    public ParticleSystem waterParticles;
    ParticleSystem pS;
    private Vector3 vertPos = new Vector3(0f, 4f, 0f);
    public AudioClip splash;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //To Do: When player collides with trap, spawn water and deactivate flame.
        if (other.CompareTag("Player"))
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(splash, 1f);
            pS = Instantiate(waterParticles, gameObject.transform.position + vertPos, waterParticles.transform.rotation);
            pS.Play();
            player.GetComponent<playerAbilities>().anim.SetBool("waterTrap", true);
        }
    }
}
