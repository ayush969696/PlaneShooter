using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject []enemies;
    public float respTime = 2f;
    public int enemySpawnCount = 10;
    public GameController gameControllerScript;

    private bool lastEnemySpawn = false;           // this means that yet the last enmy did not spawn so we do not need to show level completed Panel
    void Start()
    {
        StartCoroutine(Enemyspawner());
    }

    void Update()
    {
      if (lastEnemySpawn && FindObjectOfType<EnemyScript>() == null)  //IMP* FindObjectOfType<>(): this method tells us that we have any oject in scence which hase EnemyScript
       {
         StartCoroutine(gameControllerScript.levelCompelted());        // calling the levelcomplete() then levelcomplete panel will show in the Game;
       }
    }
    IEnumerator Enemyspawner()
    {
       for(int i = 0; i < enemySpawnCount; i++) { 
          yield return new WaitForSeconds(respTime);
          SpawnEnemy();
        }
          lastEnemySpawn = true;
    }
    private void SpawnEnemy()
    { 
        int randomValues = Random.Range(0, enemies.Length);    // i use this method cause i want to spawn enemies randomly.  we have to pass to values in it and then it will spawn the enemy according the values  
        int randomXpos = Random.Range(-2, 2);              // with the help of this i can spawn the enemy in X position between -3 to 3

        Instantiate(enemies[randomValues], new Vector2(randomXpos, transform.position.y), Quaternion.identity);
    }
  
}
