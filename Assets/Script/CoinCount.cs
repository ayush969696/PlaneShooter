using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class CoinCount : MonoBehaviour
{
    public Text coinCountText;
    private int count = 0;
    public Text finalcoinCount;

    void Start()
    {
        
    }

    void Update()
    {
        coinCountText.text = ":" + count.ToString();
        finalcoinCount.text = "Coins : " + count.ToString();
    }

    public void AddCount()    // we are calling this method in PlayerMovement Script
    {
        count++;
    }

}
