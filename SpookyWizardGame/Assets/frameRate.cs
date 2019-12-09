using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frameRate : MonoBehaviour
{
    // Lock framerate
    void Awake()
    {
        Application.targetFrameRate = 30;
    }


}
