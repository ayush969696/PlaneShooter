using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Player Movement and Clamp Player Movement using ViewportWorldPoint

    public float speed = 10f;
    private float minX;
    private float maxX;
    private float minY;
    private float maxY;
    public float padding = 0.8f;
    public AudioSource audioSource;
    public AudioClip damageSound;
    public AudioClip explosionSound;
    public AudioClip cointSound;

    public GameObject explosion;             // now i have to spawn this explosion prefabs, so how we spawn it... we use Instantiate

    // player health
    public float health = 20f;
    private float barfillAmount = 1f;     //this variable will represent the  Bar Fill amount component
    private float damage = 0f;

    public PlayerHealth playerHealth;

    //Damage Effect on player Plane
    public GameObject damageEffect;  //after this we have to spawn this effect so we use Instantiate method

    public CoinCount coincount;
    public GameController gameOverPanel;

    void Start()
    {
        findBoundries();
        damage = barfillAmount / health;
    }
    void findBoundries()
    {
        Camera gameCamera = Camera.main;  // it means that now this camera now come to this gameCamera variable
        minX = gameCamera.ViewportToWorldPoint(new Vector3(0, 0,0)).x + padding;  // here ViewportToWorldPoint() convert Viewport position  To WorldPoint position
        maxX = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;

        minY = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        maxY = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }
    void Update()
    {
        //float deltaX = Input.GetAxis("Horizontal") * Time.deltaTime*speed;    //time.deltatime.....  make the player frame rate independent   
        //float deltaY = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        //
        // float newXpos = Mathf.Clamp(transform.position.x + deltaX, minX, maxX);  // Clamp the player position, means player can not go out of this position
        // float newYpos = Mathf.Clamp(transform.position.y + deltaY, minY, maxY);
        //
        // transform.position = new Vector2(newXpos, newYpos);

        //Android support Input System
        if (Input.GetMouseButton(0))
        {
           Vector2 newPosition = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));    // here simply i take user input position on
                                                                                                                                // screen
            transform.position = Vector2.Lerp(transform.position, newPosition, 10 * Time.deltaTime);     // and here i assign the user input position to the Player Plane
                                      // Lerp() help us to move the player Smoothly on the screen
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyBullet")
        {
             audioSource.PlayOneShot(damageSound, 0.5f);  // PlayOneShot() help us to use only one Audio Source in unity but use multiple Sounds

             DamagePlayerHealthBar();
             Destroy(collision.gameObject);      // here we also destrou enemy bullet when bullet collide with player

             GameObject damageEffectCopy =  Instantiate(damageEffect, collision.transform.position, Quaternion.identity);
             Destroy(damageEffectCopy, 0.05f); // destroy the Damage effect copy

            if (health <= 0)
            {
              AudioSource.PlayClipAtPoint(explosionSound, Camera.main.transform.position,.5f);      // we are using this method cause if we use PlayOneshot() then when player Destroy then this 
                                                                              // Playoneshot() also destroy  but PlayClipPoint() will not destroy 
              Destroy(gameObject);
              GameObject copyOfExplosion = Instantiate(explosion, transform.position, Quaternion.identity);
              Destroy(copyOfExplosion, 2f);    // we also give some delay to it
              gameOverPanel.GameOver();
             }
        }

        if(collision.gameObject.tag == "Coin")   // here we destroy the Coin or we can say we collect Coin as like
        {
            audioSource.PlayOneShot(cointSound);
            Destroy(collision.gameObject);
            coincount.AddCount();

        }
    }

    void DamagePlayerHealthBar()
    {
        if(health > 0)
        {
            health -= 1;
            barfillAmount -= damage;
            playerHealth.SetAmount(barfillAmount);
        }
    }

}
//Note : ViewportWorldPoint : Viewport and WorldPoint are different in the unity.