using System;
using System.Collections;
using System.Collections.Generic;
using TetrisLike.Utility;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckSplashScreen : MonoBehaviour
{
    private void Awake()
    {
        CheckSplashScreenLoad();
    }
    
    protected void CheckSplashScreenLoad()
    {
        if (SceneManager.GetActiveScene().name == EnvScene.SplashScreen)
        {
            SceneManager.LoadScene(EnvScene.SplashScreen, LoadSceneMode.Additive);
        }
    }
}
