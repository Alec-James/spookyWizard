using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class artifactScript : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 3, Space.Self);
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Debug.Log("Collided with player");
            player.GetComponent<playerStats>().collectArtifact();
            Destroy(gameObject);
        }
    }
}
