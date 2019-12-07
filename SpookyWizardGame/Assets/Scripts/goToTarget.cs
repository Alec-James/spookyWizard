using UnityEngine;
using System.Collections;
using VHS;

public class goToTarget : MonoBehaviour
{
    public Transform[] targets; // list of potential targets
    private Transform target = null;
    public float chaseSpeed = 2f;
    public float wanderingSpeed = .75f;

    UnityEngine.AI.NavMeshAgent nav;
    public float headOffset = 1.5f; // the origin of this character is at the feet. we want to cast rays from the eyes
    public float FOV = 110f; // how wide the ooze's field of view is in degrees

    float lastStateChangeTime; //when was the last time we changed state
    public float stateChangeInterval = 30f; // how often to change state

    enum oozeState { chasing = 0, wandering = 1 }; // different states of the ooze
    oozeState state = oozeState.wandering;

    public static float normalPlayerWalkSpeed = 3f;
    public static float normalPlayerRunSpeed = 6f;
    public static float slowPlayerWalkSpeed = 1.5f;
    public static float slowPlayerRunSpeed = 2f;
    public static float timeOut = 8f;

    GameObject player; //this is the where the current player is stored

     
    

    // initialization
    void Start()
    {
        Random.seed = (int)System.DateTime.Now.Ticks;
        nav = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player"); // finds the player in current context
        targets[0] = player.transform;
        

    }

    // try to find a target. if no target is found, wander. if a target is found, chase it.
    void Update()
    {

            if (!Targeting())
                Wandering();


            if (state == oozeState.chasing && target)
                Chasing();

    }
    //gets a ranom point on a circle around the zombie to decide where to wander to. OR stays idle for a little while
    void Wandering()
    {
        if (Time.time > lastStateChangeTime + stateChangeInterval)
        {
            lastStateChangeTime = Time.time;
            if (Random.Range(0, 100) > 50)
            { // go to random destination
                Vector2 vec2 = GetRandomOnCircle(Random.Range(1.0f, 4.0f));

                nav.destination = new Vector3(transform.position.x + vec2.x, transform.position.y, transform.position.z + vec2.y);
                print("wandering change " + gameObject.name + " " + nav.destination);
                nav.speed = wanderingSpeed;

            }
            else
            { // play an idle animation
                nav.destination = transform.position;
                print("idle change " + gameObject.name);
                nav.speed = 0f;

            }
        }
    }

    //chase the target
    void Chasing()
    {

        nav.destination = target.position; //set the target
        nav.speed = chaseSpeed; // actual speed of movement
        print("chasing" + target.tag);

    }

    // Check to see if the monster can see a target. If so, return true. Else, return false.
    bool Targeting()
    {
        if (!target)
        {

                Vector3 dir = targets[0].position - transform.position;
                RaycastHit hit = new RaycastHit();
                Debug.DrawLine(transform.position + Vector3.up * headOffset, targets[0].position + Vector3.up * headOffset, Color.red);

                Debug.DrawLine(transform.position + Vector3.up * headOffset, (transform.position + Vector3.up * headOffset) + transform.forward);

                //logic for modeling the oozes's field of view and make sure the potential target is not another enemy
                if (Mathf.Acos(Vector3.Dot(transform.forward, Vector3.Normalize(dir))) < Mathf.Deg2Rad * (FOV / 2f)
                   && Physics.Raycast(transform.position + Vector3.up * headOffset, dir, out hit)
                       && hit.collider.gameObject.tag.Equals("Player")
                       )
                {

                    target = targets[0];
                    state = oozeState.chasing;
                    print(hit.collider.gameObject.tag);
                    return true;
                }

        
        }
        target = null;
        return false;

    }

    void OnTriggerEnter (Collider other)
    {
        // attack player and slow
        if (other.CompareTag("Player"))
        {
            //print("collision with " + target.tag);
            StartCoroutine(Slow(other));
            //print("end effect " + target.tag);

        }
    }


    IEnumerator Slow(Collider player)
    {
        //Debug.Log("ONE");

        FirstPersonController charScript = targets[0].GetComponent<FirstPersonController>();

        //apply player

        charScript.walkSpeed = slowPlayerWalkSpeed;
        charScript.runSpeed = slowPlayerRunSpeed;

        yield return new WaitForSeconds(timeOut);

        charScript.walkSpeed = normalPlayerWalkSpeed;
        charScript.runSpeed = normalPlayerRunSpeed;

    }

    Vector2 GetRandomOnCircle(float radius)
    {

        // initialize calculation variables
        float _x = 0;
        float _y = 0;
        Vector2 _returnVector;

        // convert degrees to radians
        float angleRadians = Random.Range(-1f, 1f);
        float angleRadians2 = Random.Range(-1f, 1f);

        // get the 2D dimensional coordinates
        _x = radius * Mathf.Cos(angleRadians);
        _y = radius * Mathf.Sin(angleRadians2);

        // derive the 2D vector
        _returnVector = new Vector2(_x, _y);

        // return the vector info
        return _returnVector;
    }
}
