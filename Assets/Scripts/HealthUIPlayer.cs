using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUIPlayer : MonoBehaviour
{
    public Image bar;
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }

    public void SetAmount(float amount)
    {
        bar.fillAmount = amount;
    }
}
