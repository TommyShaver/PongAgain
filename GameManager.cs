using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManagerInstance {get; private set;}
    public TextMeshProUGUI scoreText;
 
    private int playerOneScore = 0;
    private int playerTwoScore = 0;
    //Starting Logic ==================================================================
    private void Awake()
    {
        if (gameManagerInstance != null && gameManagerInstance != this)
        {
            Destroy(this);
        }
        else
        {
            gameManagerInstance = this;
        }

    }

    public void Start()
    {
        UpdateScore(0, 0);
    }

    //Score ===========================================================================
    public void UpdateScore(int scoreToAddPOne,int scoreToAddPTwo)
    {
        playerOneScore = playerOneScore + scoreToAddPOne;
        playerTwoScore = playerTwoScore + scoreToAddPTwo;
        scoreText.text = "Score:" + playerOneScore + "-" + playerTwoScore;
    }   
}
