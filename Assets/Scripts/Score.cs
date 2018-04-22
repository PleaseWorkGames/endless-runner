using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : TextAbstract
{
    [System.Serializable]
    public class Multiplier
    {
        public float fractionalPositionFromLeftOfScreen;
        public float multiplier = 1.0f;
    }

    public Multiplier[] Multipliers;
    
    private float time = 0.0f;

    private float score = 0;
    
    private float defaultMulutiplier = 1.0f;
    
    private float multiplier = 1.0f;
    
    public Player player;

    protected new void Start()
    {
        base.Start();
    }
    
    void FixedUpdate()
    {
        multiplier = defaultMulutiplier; 
        
        Vector3 playerPosition = Camera.main.WorldToScreenPoint(player.transform.position);
        float screenWidth = Screen.width;

        float currentFractionalPositionFromLeftOfScreen = playerPosition.x / screenWidth;        
        
        for (int i = 0; i < Multipliers.Length; i += 1) {
            var multiplierConfigInstance = Multipliers[i];
            bool isInMultiplierRange = ( // TODO - need to re-evaluate this to test currentFractionalPositionFromLeftOfScreen between previous multiplierConfigInstance.fractionalPositionFromLeftOfScreen and current multiplierConfigInstance.fractionalPositionFromLeftOfScreen 
                currentFractionalPositionFromLeftOfScreen >=
                multiplierConfigInstance.fractionalPositionFromLeftOfScreen
            );

            if (isInMultiplierRange) {
                multiplier = multiplierConfigInstance.multiplier;
            }
        }
        
        Debug.Log(multiplier);
        
        score += (Time.deltaTime * multiplier);
        text.text = "Score: " + Mathf.Round(score);
    }
}