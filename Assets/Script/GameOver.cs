using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void ReLoad()
    {
        SceneManager.LoadScene("Level1");
        Time.timeScale = 1f;
    }
    public void Quit()  
    {
        Application.Quit();
    }
}
