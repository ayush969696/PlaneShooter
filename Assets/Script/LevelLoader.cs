using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    private int curretnIndex;
    void Start()
    {
        curretnIndex = SceneManager.GetActiveScene().buildIndex;  // with the help of this line now we have our current Game Level / Scene
                                                          // here we are taking our current Game Level / Scene 
    }

    void Update()
    {

    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void ReLoad()
    {
        SceneManager.LoadScene(curretnIndex);
        Time.timeScale = 1f;
    }
    public void MainManu()   // when user click on the Main Manu button then user will go to the Start Manu Scene
    {
        SceneManager.LoadScene("StartManu");
    }

    public void Quit()   // this is for our StartManu Quit Button
    {
        Application.Quit();
    }
}
