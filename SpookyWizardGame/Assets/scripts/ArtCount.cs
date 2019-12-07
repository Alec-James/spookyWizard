using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArtCount : MonoBehaviour
{
    public Text text,unlocked;
    public int count=0;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (text != null)
        {
            text.text = player.GetComponent<playerStats>().collectedArtifacts.ToString()+" of 3";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<playerStats>().collectedArtifacts == 3)
        {
            unlocked.text = "The Seal Has Been Broken!";
            
        }
        if (player.GetComponent<playerStats>().collectedArtifacts <= 3)
        {
            text.text = player.GetComponent<playerStats>().collectedArtifacts.ToString() + " of 3";
        }
    }
}
