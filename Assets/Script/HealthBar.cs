using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Transform bar;

    private void Start()
    {
        SetSize(1f);
    }

    public void SetSize(float size)
    {
        bar.localScale = new Vector2(size, 1f);
    }
}
