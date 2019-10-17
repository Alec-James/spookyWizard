using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArtCount : MonoBehaviour
{
    public Text text,unlocked;
    public int count=0;
    public bool found=false;
    // Start is called before the first frame update
    void Start()
    {
        if (text != null)
        {
            text.text = count.ToString()+" of 3";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (count == 3)
        {
            unlocked.text = "All artifacts found. Door Unlocked!";
            this.enabled = false;
        }
        if (found)
        {
            count++;
            found = false;
            text.text = count.ToString() + " of 3";
        }
    }
}
