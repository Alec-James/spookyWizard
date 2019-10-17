using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Magic : MonoBehaviour
{
    public float CurrentMagic { get; set; }
    public float MaxMagic { get; set; }
    public Slider Magicbar;
    // Start is called before the first frame update
    void Start()
    {
        MaxMagic = 20f;
        CurrentMagic = MaxMagic;
        Magicbar.value = CalcMagic();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
            DealDamage(6);
    }

    void DealDamage(float dmg)
    {
        CurrentMagic -= dmg;
        Magicbar.value = CalcMagic();
        if (CurrentMagic <= 0)
        {

        }
    }
    float CalcMagic()
    {
        return CurrentMagic / MaxMagic;

    }
}
