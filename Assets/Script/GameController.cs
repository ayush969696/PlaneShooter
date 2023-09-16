using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject pauseManu;
    public GameObject pauseBtnDisable;
    public GameObject levelCompletePanel;
    public GameObject endDilog;

    // GameOver Panel
    public GameObject gameOverPanel;

    void Start()
    {
        Time.timeScale = 1f;
        pauseBtnDisable.SetActive(true);
        pauseManu.SetActive(false);
        gameOverPanel.SetActive(false);
        levelCompletePanel.SetActive(false);
        endDilog.SetActive(false);
    }

    void Update()
    {
        
    }
    public void PauseGame()
    {
        pauseManu.SetActive(true);
        Time.timeScale = 0f;      // with the Time will be 0 and then every thing in game will pause
        pauseBtnDisable.SetActive(false);
    }
    public void ResumeGame()
    {  // As you can see i just do opposite of the PauseGame() code 
        pauseManu.SetActive(false);
        Time.timeScale = 1f;     
        pauseBtnDisable.SetActive(true);
    }
    public void GameOver()     // now we have to call this method in PlayerMovement Script cause when player Dies then this Panel will show 
    {
        gameOverPanel.SetActive(true);
        pauseBtnDisable.SetActive(false);
    }
   
    public IEnumerator levelCompelted()      // now we have to call the StartCorotine() in EnemySpawner Script in Update()
    {
        yield return new WaitForSeconds(2f);
        endDilog.SetActive(true);

        yield return new WaitForSeconds(3f);
        levelCompletePanel.SetActive(true);
        Time.timeScale = 0f;  //pause the game 

        pauseBtnDisable.SetActive(false); // we also have to disable the pause button
    }

    public void Quit()
    {
        Application.Quit();
    }
   
}
