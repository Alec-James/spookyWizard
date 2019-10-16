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
    public GameObject player;
    //layer = Gam
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Random.Range(0, 100) > 75)
        {
            shootIce();
        }

    }

    private void shootIce()
    {
        GameObject tempBullet;
        Transform player;
        //player = playerPos;
        tempBullet = Instantiate(iceShot) as GameObject;
        tempBullet.transform.position = transform.position + LeftCast.position;
    }
}
