using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class bNav : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    NavMeshAgent bossAI;
    public float chaseSpeed = 2f;
    public bool isChasing = false;
    public float FOV = 110f; // how wide the zombie's field of view is in degrees
    void Start()
    {
        bossAI = GetComponent<NavMeshAgent>();
        bossAI.destination = player.position;

    }
    // Update is called once per frame
    void Update()
    {
        
        if (Vector3.Distance(transform.position, player.position) < 15f)
        {
            Chasing();
        }
        else
        {
            bossAI.destination = player.position;
        }
    }
    
    void Chasing()
    {
        bossAI.speed = chaseSpeed; // actual speed of movement
        bossAI.destination = player.position; //set the target
        

    }
    /*
    bool Targeting()
    {
        if (!target)
        {
            for (int i = 0; i < targets.Length; i++)
            {


                Vector3 dir = targets[i].position - transform.position;
                RaycastHit hit = new RaycastHit();
                Debug.DrawLine(transform.position + Vector3.up, player.position + Vector3.up, Color.red);

                Debug.DrawLine(transform.position + Vector3.up, (transform.position + Vector3.up) + transform.forward);

                if (Mathf.Acos(Vector3.Dot(transform.forward, Vector3.Normalize(dir))) < Mathf.Deg2Rad * (FOV / 2f)
                   && Physics.Raycast(transform.position + Vector3.up, dir, out hit)
                       && hit.collider.gameObject.tag.Equals("Player")
                       )
                {

                    target = targets[i];
                    state = bossState.chasing;
                    print(hit.collider.gameObject.tag);
                    isChasing = true;
                    return true;
                }

            }
        }
        return false;

    }*/
}
