using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public Renderer meshrenderer;
    public float speed = 0.1f;

 
    void Update()
    {
        //Vector2 offset = meshrenderer.material.mainTextureOffset;
        //  offset = offset + new Vector2(0, speed * Time.deltaTime);
        //  meshrenderer.material.mainTextureOffset = offset;

        // short cut code
        meshrenderer.material.mainTextureOffset += new Vector2(0, speed * Time.deltaTime);
    }
}
