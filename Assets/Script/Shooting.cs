using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject playerBullet;     // in this i will get the bullet in the unity
    public Transform spawnPoint1;     // this is the positon form where the bullet will shoot 
    public Transform spawnPoint2;     // this is second place from where the bullet will shoot
    public float bulletFireDelay = 1f;
    public GameObject muzzleFlash;   // here i only take one muzzleFlash cause i make the second muzzleFash child of first muzzleFlash
    public AudioSource audioSource;


    void Start()
    {
        muzzleFlash.SetActive(false);
        StartCoroutine(Shoot());  // with the help to Coroutine we can fire automatically
    }
    void Fire()
    {
        Instantiate(playerBullet, spawnPoint1.position, Quaternion.identity);  // with the help of this i can fire the bullet from plane right side 
        Instantiate(playerBullet, spawnPoint2.position, Quaternion.identity);  // fire bullet from left side
    }
    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(bulletFireDelay);
        Fire();
        audioSource.Play();
        muzzleFlash.SetActive(true);

        yield return new WaitForSeconds(0.04f);
        muzzleFlash.SetActive(false);

        StartCoroutine(Shoot());  // if i call this method then bullet will fire infinitly
    }

   
}
