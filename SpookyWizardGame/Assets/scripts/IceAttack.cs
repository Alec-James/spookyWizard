using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceAttack : MonoBehaviour
{
    public Transform player;
    
    public float speed = 4f;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
        Vector3 playerPos = new Vector3(player.position.x, player.position.y, player.position.z);

        // Aim bullet in player's direction.
        transform.rotation = Quaternion.LookRotation(playerPos);
    }

    // Update is called once per frame
    void Update()
    {
        // Move the projectile forward towards the player's last known direction;
        if (player)
        {
            this.GetComponent<Rigidbody>().AddForce((player.position - this.transform.position).normalized * 2f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Destroy(collision.other.gameObject);
            Destroy(gameObject);

        }
        else if (collision.collider.CompareTag("Boss") || (collision.collider.CompareTag("Projectile")))
        {

        }
        else
        {
            Destroy(gameObject);
        }
    }
}
