using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class singletonController : MonoBehaviour
{
    public static dungeonConstruction dC;
    public static int collectedArtifacts = 0;

    // Start is called before the first frame update
    void Start()
    {
        dC = GameObject.Find("dungeonMaster").GetComponent<dungeonConstruction>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void collectArtifact()
    {
        collectedArtifacts += 1;
        if (collectedArtifacts == 3)
        {
            Debug.Log("Opening Door Singleton");
            dC.moveDoor();
        }
    }
}
