using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuChange : MonoBehaviour
{
    public void GotoMainScene()
    {
        SceneManager.LoadScene("HUD");
    }

    public void GotoMenuScene()
    {
        SceneManager.LoadScene("SWMenu");
    }
}
