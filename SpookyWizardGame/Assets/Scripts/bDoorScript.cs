using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bDoorScript : MonoBehaviour
{
    private bool newMoveDoor = false;
    private bool closeDoor = false;
    private int continueMoving = 0;
    private Transform doorCurrent;
    private int endPoint;

    public AudioClip doorClose;

    private bool doorSet = true;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("START BOIIIII");
        //newMoveDoor = false;
        //openDoor();
        endPoint = 500;
        //doorCurrent = gameObject.transform;

    }

    // Update is called once per frame
    void Update()
    {
        /**if (doorSet == true)
        {
            doorCurrent = gameObject.transform;
            doorSet = false;
        }**/

        //Debug.Log(newMoveDoor);
        if (newMoveDoor == true)
        {
           
            transform.Translate(Vector2.right * 1.2f * Time.deltaTime);
            continueMoving += 1;
        }

        if (continueMoving >= endPoint)
        {
            
            stopDoor();
        }

        if (closeDoor == true)
        {
            transform.Translate(Vector2.left * 1.2f * Time.deltaTime);
            //transform.position = Vector3.MoveTowards(transform.position, doorCurrent.position, 5);
            continueMoving += 1;
        }

    }

    public void openDoor()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(doorClose, 4f);
        Debug.Log("MOVE DOOR");
        newMoveDoor = true;
        Debug.Log("After Move Set " + newMoveDoor);
    }

    public void stopDoor()
    {
        Debug.Log("DOOR STOP");
        newMoveDoor = false;
        closeDoor = false;
        endPoint = continueMoving;
        continueMoving = 0;

    }

    public void sealDoor()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(doorClose, 4f);
        Debug.Log("DoorSEAL");
        closeDoor = true;
    }
}
