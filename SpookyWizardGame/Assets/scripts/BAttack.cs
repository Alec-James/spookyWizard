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
    //layer = Gam
    void Start()
    {

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
        tempBullet = Instantiate(iceShot) as GameObject;
        tempBullet.transform.position = LeftCast.position;
    }
}
