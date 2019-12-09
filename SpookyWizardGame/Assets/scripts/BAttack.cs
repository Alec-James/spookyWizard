using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BAttack : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject iceShot;
    public Transform LeftCast;
    public Transform player;
    public AudioClip iceAttack;
    //layer = Gam
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            if (GetComponent<bNav>().isStalking == true)
            {
                if (Random.Range(0, 100) > 97)
                {
                    shootIce();
                }
            }
        }
    }

    private void shootIce()
    {
        GameObject tempBullet;
        //player = playerPos;
        gameObject.GetComponent<AudioSource>().PlayOneShot(iceAttack, 1f);
        tempBullet = Instantiate(iceShot,LeftCast.position , gameObject.transform.rotation) as GameObject;
        tempBullet.transform.position = LeftCast.position;
    }
}
