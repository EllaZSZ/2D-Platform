// Programmed By Arija

using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    public float changeTime;
    public string sceneName;
    // Code from here: https://www.youtube.com/watch?v=Zb5GxSz5mSI
    void Update()
    {
        changeTime -= Time.deltaTime;
        if (changeTime <= 0)
        {
            SceneManager.LoadScene(sceneName);
        }
        
    }
}
