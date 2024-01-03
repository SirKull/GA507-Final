using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Windows")]
    public GameObject mainMenu = null;
    public GameObject levelSelect = null;
    public GameObject settings = null;


    public void OnClick_Play()
    {
        SceneManager.LoadScene("Example");
    }

    public void OnClick_LevelSelect()
    {

    }

    public void OnClick_Settings()
    {

    }

    public void OnClick_Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif

        if(Application.isPlaying)
        {
            Application.Quit();
        }
    }
}
