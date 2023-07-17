using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScemeMgr : MonoBehaviour
{
    public void MainScene()
    {
        SceneManager.LoadScene(1);
    }
    public void startScene()
    {
        SceneManager.LoadScene(0);
    }
}
