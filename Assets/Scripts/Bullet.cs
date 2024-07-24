using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Translate(Vector2.up *speed *Time.deltaTime);
    }
}
