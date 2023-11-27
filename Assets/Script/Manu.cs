using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Manu : MonoBehaviour
{
    public void OnPlayerButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    public void Mapmanu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
    public void toturial1()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(5);
    }
    public void Map1()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(2);
    }
    public void Map2()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(3);
    }
    public void credit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(4);
    }
    public void OnQuit1Button()
    {
        Application.Quit();
    }
}
