using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bDoorScript : MonoBehaviour
{
    private bool newMoveDoor = false;
    private bool closeDoor = false;
    private int continueMoving = 0;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("START BOIIIII");
        //newMoveDoor = false;
        //openDoor();
    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log(newMoveDoor);
        if (newMoveDoor == true)
        {
            Debug.Log("Opening Boss Door...");
            transform.Translate(Vector2.right * 1.2f * Time.deltaTime);
            continueMoving += 1;
        }

        if (continueMoving >= 500)
        {
            Debug.Log("Stopping Boss Door...");
            stopDoor();
        }

        if (closeDoor == true)
        {
            Debug.Log("Closing Boss Door...");
            transform.Translate(Vector2.left * 1.2f * Time.deltaTime);
            continueMoving += 1;
        }

    }

    public void openDoor()
    {
        Debug.Log("OPen door being called");
        newMoveDoor = true;
        Debug.Log("After Move Set " + newMoveDoor);
    }

    public void stopDoor()
    {
        Debug.Log("Stop door being called");
        newMoveDoor = false;
        closeDoor = false;
        continueMoving = 0;
    }

    public void sealDoor()
    {
        Debug.Log("Seal door being called");
        closeDoor = true;
    }
}
