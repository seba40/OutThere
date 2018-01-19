using UnityEngine;
using System.Collections;

public class scroll : MonoBehaviour
{
    public float scrollSpeed;


    void Update()
    {
        Vector2 offset = new Vector2(0, Time.time * scrollSpeed);
        GetComponent<Renderer>().material.mainTextureOffset = offset;

    }
}
