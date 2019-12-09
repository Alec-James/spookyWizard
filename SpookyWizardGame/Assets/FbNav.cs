using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class FbNav : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    NavMeshAgent bossAI;
    public float chaseSpeed = 8f;
    public float stalkSpeed = 2f;
    public GameObject[] waypoints;
    public bool isChashing;
    public bool isStalking;
    int currWaypoint;
    public float FOV = 110f; // how wide the zombie's field of view is in degrees
    int bossHealth = 100;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        bossAI = GetComponent<NavMeshAgent>();
        waypoints = GameObject.Find("dungeonMaster").GetComponent<dungeonConstruction>().nodeLayout;
        currWaypoint = 0;
        bossAI.speed = 6f;
        bossAI.destination = waypoints[currWaypoint].transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        bossAI.destination = waypoints[currWaypoint].transform.position;
        if(Random.Range(0,100) >= 90)
        {
            currWaypoint = Random.Range(0, 18);

        }
        transform.LookAt(player.position);

        if(bossHealth <= 0)
        {
            SceneManager.LoadScene("End");
        }
    }

    private void onTriggerEnter(Collider other)
    {
        Debug.Log("Collided with:");
        Debug.Log(other);
        if (other.gameObject.tag.Equals("Waypoint"))
        {
            Debug.Log("Inside waypoint");
            currWaypoint = Random.Range(0, 18);
            Debug.Log(currWaypoint);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("firebolt"))
        {
            Debug.Log("Ouch!");
            bossHealth -= 25;
        }
    }
}
