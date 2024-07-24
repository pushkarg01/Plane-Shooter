using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinCount : MonoBehaviour
{
    public TextMeshProUGUI coinCountText;
    public TextMeshProUGUI coinText;
    int count = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coinCountText.text = count.ToString();
        coinText.text = "COINS: " +count.ToString();
    }

    public void AddCount()
    {
        count++;
    }
}
