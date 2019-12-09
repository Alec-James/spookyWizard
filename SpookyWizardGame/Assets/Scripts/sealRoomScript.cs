using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sealRoomScript : MonoBehaviour
{
    dungeonConstruction dc;

    // Start is called before the first frame update
    void Start()
    {
        dc = GameObject.Find("dungeonMaster").GetComponent<dungeonConstruction>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //To Do: Detect if player entered the trigger.
        if (other.gameObject.tag.Equals("Player"))
        {
            dc.closeDoor();
            GameObject.Find("AudioController").GetComponent<musicController>().playBossMusic();

        }
        
    }
}
