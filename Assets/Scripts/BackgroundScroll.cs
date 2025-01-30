using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    #region Background Scroll Logic

    private Renderer meshRenderer;
    public float speed = 0.5f;

    void Start()
    {
        meshRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        meshRenderer.material.mainTextureOffset += new Vector2(0, speed * Time.deltaTime);
    }
    #endregion
}
