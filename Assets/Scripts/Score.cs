using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : TextAbstract
{
    public Player player;

    void FixedUpdate()
    {
        text.text = "Score: 0";
    }
}