using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void ButtonStart()
    {
        SceneManager.LoadScene(1);
    }

    public void ButtonExit()
    {
        Debug.Log("Salir");
        Application.Quit();
    }
    public void ButtonTry() {
        SceneManager.LoadScene(1);
    }
    public void ButtonMenu() {
        SceneManager.LoadScene(0);
    }
    public void LostScene() {
        SceneManager.LoadScene(2);
    }
}
