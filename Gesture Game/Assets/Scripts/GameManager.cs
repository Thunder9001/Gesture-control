using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum GameState
{
    Start,
    Pause,
    GameOver
}


public class GameManager : MonoBehaviour
{
    public float moveSpeed;
    public static GameManager gameManager;

    public GameState State;

    public int score;
    public int combo;
    public int timeSecs;
    public TMP_Text scoreTxt;
    public TMP_Text comboTxt;
    public TMP_Text timeTxt;
    public TMP_Text GoScoreTxt;
    public TMP_Text GoTimeTxt;
    public TMP_Text GoMessage;
    public TMP_Text startMsg;


    private void Awake()
    {
        gameManager = this;
        startMsg.text = "Cut the fruit, avoid or push away the bombs";
    }

    

    public void IncreaseScore(int points)
    {
        score += points;
        scoreTxt.text = score.ToString();
    }

    // Update is called once per frame
    public void UpdateGameState(GameState newState)
    {
        State = newState;
        switch (newState)
        {
            case GameState.Start:

                break;
            case GameState.Pause:
                break;
            case GameState.GameOver:
                break;
        }
        
    }
}
