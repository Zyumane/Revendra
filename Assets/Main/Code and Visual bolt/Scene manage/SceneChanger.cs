using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void Scene1 ()
    {
        SceneManager.LoadScene("Map 1");
    }
    public void Scene2()
    {
        SceneManager.LoadScene("Map 2");
    }
    public void Scene3()
    {
        SceneManager.LoadScene("Map 3");
    }
}
