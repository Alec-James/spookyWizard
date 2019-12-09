using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuChange : MonoBehaviour
{
    public void GotoMainScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void GotoMenuScene()
    {
        SceneManager.LoadScene("SWMenu");
    }

    public void GotoOptionsScene()
    {
        SceneManager.LoadScene("OptionsMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void EasySelection()
    {
        difficultyOptions.xGrid = 5;
        difficultyOptions.zGrid = 5;
        SceneManager.LoadScene("SWMenu");
    }

    public void MediumSelection()
    {
        difficultyOptions.xGrid = 7;
        difficultyOptions.zGrid = 7;
        SceneManager.LoadScene("SWMenu");
    }

    public void HardSelection()
    {
        difficultyOptions.xGrid = 10;
        difficultyOptions.zGrid = 10;
        SceneManager.LoadScene("SWMenu");
    }
}
