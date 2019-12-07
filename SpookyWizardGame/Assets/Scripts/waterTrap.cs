using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterTrap : MonoBehaviour
{
    GameObject player;
    public GameObject waterParticles;
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
            player.GetComponent<playerAbilities>().anim.SetBool("waterTrap", true);
        }
    }
}
