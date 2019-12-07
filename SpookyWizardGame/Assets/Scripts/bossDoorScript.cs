using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossDoorScript : MonoBehaviour
{
    public bool moveDoor = false;
    public bool closeDoor = false;
    private int continueMoving = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.moveDoor == true)
        {
            transform.Translate(Vector2.right * 1.2f * Time.deltaTime);
            continueMoving += 1;
        }

        if (continueMoving >= 500)
            stopDoor();

        if (this.closeDoor == true)
        {
            transform.Translate(Vector2.left * 1.2f * Time.deltaTime);
            continueMoving += 1;
        }

    }

    public void openDoor()
    {
        this.moveDoor = true;
    }

    public void stopDoor()
    {
        this.moveDoor = false;
        this.closeDoor = false;
        continueMoving = 0;
    }

    public void sealDoor()
    {
        this.closeDoor = true;
    }
}
