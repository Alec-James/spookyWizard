using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FbIceAttack : MonoBehaviour
{
    public Transform player;


    private float speed = 25f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Vector3 playerPos = new Vector3(player.position.x, player.position.y + 5, player.position.z);

        // Aim bullet in player's direction.
        transform.rotation = Quaternion.LookRotation(playerPos);



    }

    // Update is called once per frame
    void Update()
    {
        // Move the projectile forward towards the player's last known direction;

        
            if (speed != 0)
            {
                this.GetComponent<Rigidbody>().AddForce((player.position.x - this.transform.position.x),(player.position.y - this.transform.position.y + 1f), (player.position.z - this.transform.position.z) * 2f);
            }
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Destroy(collision.other.gameObject);
            Destroy(gameObject);

        }
        else if (collision.CompareTag("finalBoss"))
        {

            Debug.Log("Hit Boss");

        }
        else if (collision.CompareTag("Projectile") || (collision.CompareTag("Waypoint")))
        {

        }
        else
        {
            Debug.Log("Hit NOt player");
            Destroy(gameObject);
        }
    }
}