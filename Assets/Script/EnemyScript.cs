using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyScript : MonoBehaviour
{
     public GameObject enemyBullet;
     public Transform []gunpoint;
     public GameObject enemyflash;
     public float bulletFireDelay = 0.8f;
     public float speed = 1f;

     public GameObject EnemyExplosionPrefab;
     public AudioSource audioSource;
     public AudioClip bulletSound;
     public AudioClip damageSound;
     public AudioClip explosionSound;



    // Enemy health
     public float health = 10f;
     float barSize = 1f;
     float damage = 0;
     public HealthBar healthbar;

    // Damage Effect 
    public GameObject damageEffect;  //after this we have to spawn this effect so we use Instantiate method

    //Spawn Coint 
    public GameObject cointPrefab;

    void Start()
    {
        enemyflash.SetActive(false);
        StartCoroutine(EShoot());

        damage = barSize / health;    // 1/10 = 0.1f  ||  so the damage will be  0.5f every time when bullet collide with enemy 

    }

    private void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);  // now enemy will go down in the game
    }

 
    void Fire()
    {
        for(int i = 0; i< gunpoint.Length; i++)
        {
            Instantiate(enemyBullet, gunpoint[i].position, Quaternion.identity);
        }

         //Instantiate(enemyBullet, gunpoint.position, Quaternion.identity);
         //Instantiate(enemyBullet, enmSpawn2.position, Quaternion.identity);
    }
    IEnumerator EShoot()
    {
          yield return new WaitForSeconds(bulletFireDelay);
          Fire();
          audioSource.PlayOneShot(bulletSound, 0.5f);
          enemyflash.SetActive(true);
         
          yield return new WaitForSeconds(0.04f);
          enemyflash.SetActive(false);
         
          StartCoroutine(EShoot());
    }

       // Enemy Damage
    void DamageHealthBAr()
    {
        if (health > 0)
        {
            health -= 1;
            barSize -= damage;   // 1 - .1 = .9 is barSize
            healthbar.SetSize(barSize);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerBullet")
        {
            audioSource.PlayOneShot(damageSound);

            DamageHealthBAr();
            Destroy(collision.gameObject);   // here i also destroy the bullet
            GameObject damageEffectCopy =   Instantiate(damageEffect, collision.transform.position, Quaternion.identity);
            Destroy(damageEffectCopy,0.05f);    // destroy the Damage effect copy

        if(health <= 0) 
        {
            AudioSource.PlayClipAtPoint(explosionSound, Camera.main.transform.position, 0.5f);  // with this method we use AudioSource

            Destroy(gameObject);
            GameObject CopyofEenemyExplosion =  Instantiate(EnemyExplosionPrefab, transform.position,Quaternion.identity);   // transform.position is Enemy position  
            Destroy(CopyofEenemyExplosion, 0.4f);  // here i am destroying the copy of the enemy Explosion that is why i create CopyofEenemyExplosion variable

                //Spawn Coint after enemy Destroy
                Instantiate(cointPrefab, transform.position, Quaternion.identity);
         }
      } 
   }
}
