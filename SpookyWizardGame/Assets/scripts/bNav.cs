using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class bNav : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform goal;
    NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
    }
    // Update is called once per frame
    void Update()
    {
        agent.destination = goal.position;
    }
}
