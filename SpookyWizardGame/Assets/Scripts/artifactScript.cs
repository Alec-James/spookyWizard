using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class artifactScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 3, Space.Self);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            singletonController.collectArtifact();
            Destroy(gameObject);
        }
    }
}
