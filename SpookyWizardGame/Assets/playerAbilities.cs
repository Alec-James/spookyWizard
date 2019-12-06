using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAbilities : MonoBehaviour
{
    bool attacking = false;
    Animator anim;
    public GameObject firePoint;
    public List<GameObject> vfx = new List<GameObject>();
    private GameObject effectToSpawn;
    public float fireRate = 1;
    private float nextFire = 0.0F;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        effectToSpawn = vfx[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Debug.Log("animation should play");
            anim.SetBool("attacking", true);
            //SpawnVFX();
        }
        else
        {
            anim.SetBool("attacking", false);
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
            Debug.Log("No Fire Point");
        }
    }
}
