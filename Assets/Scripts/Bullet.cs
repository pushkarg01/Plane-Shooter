using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    #region Bullet Travel Speed
    public float speed = 10f;

    void Update()
    {
        transform.Translate(Vector2.up *speed *Time.deltaTime);
    }
    #endregion
}
