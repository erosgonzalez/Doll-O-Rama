using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    // Start is called before the first frame update
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}

    public void NewButton()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadButton()
    {
        SceneManager.LoadScene(2);
    }

    public void SettingsButton()
    {
        SceneManager.LoadScene(3);
    }

    public void BackButton()
    {
        SceneManager.LoadScene(0);
    }
}
