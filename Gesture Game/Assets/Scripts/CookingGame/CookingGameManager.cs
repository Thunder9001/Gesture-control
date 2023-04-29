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

    private void Awake()
    {
        NewGame();
    }

    private void NewGame()
    {
        Instruction1Txt.enabled = true;
        Instruction2Txt.enabled = false;
        Instruction3Txt.enabled = false;
        Instruction4Txt.enabled = false;
        Instruction5Txt.enabled = false;
    }
    
}
