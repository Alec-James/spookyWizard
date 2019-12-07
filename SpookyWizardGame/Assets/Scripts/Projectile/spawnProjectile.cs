using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnProjectile : MonoBehaviour
{
    public GameObject firePoint;
    public List<GameObject> vfx = new List<GameObject>();

    private GameObject effectToSpawn;
    public GameObject mainCam;
    // Start is called before the first frame update
    void Start()
    {

        effectToSpawn = vfx[0];
        mainCam = GameObject.Find("Camera_Holder");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            SpawnVFX();
        }
    }

    void SpawnVFX()
    {
        GameObject vfx;

        if (firePoint != null)
        {
            vfx = Instantiate(effectToSpawn, firePoint.transform.position, transform.rotation);

        }
        else
        {
            Debug.Log ("No Fire Point");
        }
    }
}
