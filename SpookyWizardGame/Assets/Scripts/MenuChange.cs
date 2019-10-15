using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuChange : MonoBehaviour
{
    public void GotoMainScene()
    {
        SceneManager.LoadScene("In-Class Anim");
    }

    public void GotoMenuScene()
    {
        SceneManager.LoadScene("menu");
    }
}
