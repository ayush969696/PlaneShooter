using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private float speed = 10f;
  
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
}
