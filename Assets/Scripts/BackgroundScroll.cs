using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    private Renderer meshRenderer;
    public float speed = 0.5f;
    void Start()
    {
        meshRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        Vector2 offset = meshRenderer.material.mainTextureOffset;
        offset = offset + new Vector2(0,speed * Time.deltaTime);
        meshRenderer.material.mainTextureOffset = offset;
        */

        meshRenderer.material.mainTextureOffset += new Vector2(0, speed * Time.deltaTime);
    }
}
