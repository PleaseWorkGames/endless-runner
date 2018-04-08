﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : TextAbstract
{
    [System.Serializable]
    public class Multiplier
    {
        public float leftBound;
        public float rightBound;
        public float multiplier = 1.0f;
    }

    public Multiplier[] Multipliers;
    
    private float time = 0.0f;

    private float score = 0;
    
    private float multiplier = 1.0f;
    
    public Player player;

    void Update()
    {
        time += (Time.deltaTime * multiplier);
        
        text.text = "Score: " + Mathf.Round(time);
    }
}