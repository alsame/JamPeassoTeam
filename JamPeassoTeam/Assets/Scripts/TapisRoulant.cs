﻿using UnityEngine;
using System.Collections;

public class TapisRoulant : MonoBehaviour {
    public float scrollSpeed = 0.5F;
    public Renderer rend;
    void Start()
    {
        rend = GetComponent<Renderer>();
    }
    void FixedUpdate()
    {
        float offset = Time.time * scrollSpeed;
        rend.material.SetTextureOffset("_MainTex", new Vector2(-offset, 0));
    }
}
