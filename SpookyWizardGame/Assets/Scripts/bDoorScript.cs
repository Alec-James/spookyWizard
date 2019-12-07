using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bDoorScript : MonoBehaviour
{
    bool moveDoor;
    bool closeDoor;
    private int continueMoving = 0;
    // Start is called before the first frame update
    void Start()
    {
        moveDoor = false;
        closeDoor = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(moveDoor);
        if (moveDoor == true)
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
        moveDoor = true;
        Debug.Log("After Move Set " + moveDoor);
    }

    public void stopDoor()
    {
        moveDoor = false;
        closeDoor = false;
        continueMoving = 0;
    }

    public void sealDoor()
    {
        closeDoor = true;
    }
}
