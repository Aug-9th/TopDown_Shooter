using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayManager : MonoBehaviour
{
    public static GamePlayManager instance;

    private int score;
    public int levelNumber;

    public Level[] Level;

    public Text scoreText;

    void Awake()
    {
        instance= this;
    }

    void Start()
    {
        levelNumber = 0;
    }
    void Update()
    {

        TextHolder();
        if(score >= Level[levelNumber].scoreMax) 
        {

            levelNumber++;
            Debug.Log("Level is: " + levelNumber);
            
        }

        
    }

    public void Addscore(int a)
    {
        score += a;
        Debug.Log("Score is: " + score);
    }
    
    void TextHolder()
    {
        scoreText.text = "Score: " + score;
    }
}
