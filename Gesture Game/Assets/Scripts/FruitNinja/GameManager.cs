using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Code adapted to work with Leap Controller and sourced from Fruit Ninja tutorial below
// Original source repo: https://github.com/zigurous/unity-fruit-ninja-tutorial

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    public int score;
    public int lives;
    public int combo;
    public TMP_Text scoreTxt;
    public TMP_Text livesTxt;
    public TMP_Text comboTxt;
    public TMP_Text goScoreTxt;
    public TMP_Text goMessage;
    public Image explodeFade;
    public Canvas gameUI;
    public Canvas gameOver;

    public Blade blade;
    public FruitThrower fruitThrower;


    private void Awake()
    {
        NewGame();
        blade = FindObjectOfType<Blade>();
        fruitThrower = FindObjectOfType<FruitThrower>();
        gameOver.enabled = false;
        gameUI.enabled = true;

    }
    
    private void NewGame()
    {
        blade.enabled = true;
        fruitThrower.enabled = true;

        score = 0;
        combo = 0;
        scoreTxt.text = "Score: " + score.ToString();
        comboTxt.text = "Combo: " + combo.ToString();
        livesTxt.text = "Lives: " + lives.ToString();
        Debug.Log(lives);
        Time.timeScale = 1f;

        Clear();
    }

    private void EndGame()
    {
        blade.enabled = false;
        fruitThrower.enabled = false;
        gameOver.enabled = true;
        gameUI.enabled = false;

        goMessage.text = "Good job!\n Your final score was:\n";
        goScoreTxt.text = score.ToString();

        
    }
    private void Clear()
    {
        Fruit[] fruits = FindObjectsOfType<Fruit>();
        foreach (Fruit f in fruits)
        {
            Destroy(f.gameObject);
        }

        Bomb[] bombs = FindObjectsOfType<Bomb>();
        foreach (Bomb b in bombs)
        {
            Destroy(b.gameObject);
        }
    }

    public void ResetCombo()
    {
        combo = 0;
        comboTxt.text = "Combo: " + combo.ToString();
    }
    public void DecreaseLives()
    {
        lives -= 1;
        livesTxt.text = "Lives: " + lives.ToString();
        ResetCombo();
        if(lives <= 0)
        {
            Explode();
        }
    }

    public void IncreaseScore(int points)
    {
        combo += 1;
        score += points + combo;
        scoreTxt.text = "Score: " + score.ToString();
        comboTxt.text = "Combo: " + combo.ToString();
    }

    public void Explode()
    {
        blade.enabled = false;
        fruitThrower.enabled = false;

        StartCoroutine(ExplodeSequence());
    }

    private IEnumerator ExplodeSequence()
    {
        float elapsed = 0;
        float duration = 0.5f;
        while(elapsed < duration)
        {
            float pct = Mathf.Clamp01(elapsed / duration);
            explodeFade.color = Color.Lerp(Color.clear, Color.white, pct);
            Time.timeScale = 1f - pct;
            elapsed += Time.unscaledDeltaTime;
            yield return null;
        }
        yield return new WaitForSecondsRealtime(0.5f);
        elapsed = 0;
        while (elapsed < duration)
        {
            float pct = Mathf.Clamp01(elapsed / duration);
            explodeFade.color = Color.Lerp(Color.white, Color.clear, pct);
            Time.timeScale = 1f - pct;
            elapsed += Time.unscaledDeltaTime;
            yield return null;
        }
        EndGame();

        Time.timeScale = 1f;
    }
}
