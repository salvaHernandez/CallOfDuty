using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControlMenu : MonoBehaviour
{
    public Text txtGameOVer;

    private void Start()
    {
        txtGameOVer.enabled = false;
    }

    public void gameOver ()
    {
        txtGameOVer.enabled = true;
    }

    public void BotonStart() 
    {
        SceneManager.LoadScene(1);
    }
}
