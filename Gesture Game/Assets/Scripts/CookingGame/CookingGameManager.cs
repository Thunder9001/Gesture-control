using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CookingGameManager : MonoBehaviour
{
    public int state = 0;
    public static CookingGameManager gameManager;
    public TMP_Text Instruction1Txt;
    public TMP_Text Instruction2Txt;
    public TMP_Text Instruction3Txt;
    public TMP_Text Instruction4Txt;
    public TMP_Text Instruction5Txt;
    public TMP_Text Instruction6Txt;

    private void Awake()
    {
        NewGame();
    }

    private void NewGame()
    {
        Instruction1Txt.gameObject.SetActive(true);
        Instruction2Txt.gameObject.SetActive(false);
        Instruction3Txt.gameObject.SetActive(false);
        Instruction4Txt.gameObject.SetActive(false);
        Instruction5Txt.gameObject.SetActive(false);
    }

    public void NextState()
    {
        state++;
    }
    public int getState()
    {
        return state;
    }

    private void Update()
    {
        switch(state)
        {
            case 0: Instruction1Txt.gameObject.SetActive(true); break;
            case 1: Instruction1Txt.gameObject.SetActive(false); Instruction2Txt.gameObject.SetActive(true); break;
            case 2: Instruction2Txt.gameObject.SetActive(false); Instruction3Txt.gameObject.SetActive(true); break;
            case 3: Instruction3Txt.gameObject.SetActive(false); Instruction4Txt.gameObject.SetActive(true); break;
            case 4: Instruction4Txt.gameObject.SetActive(false); Instruction5Txt.gameObject.SetActive(true); break;
            case 5: Instruction5Txt.gameObject.SetActive(false); Instruction6Txt.gameObject.SetActive(true); break;
            case 6: Instruction6Txt.gameObject.SetActive(false); Debug.Log(state); break;
        }
    }

}
