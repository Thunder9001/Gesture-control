using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTutorial : MonoBehaviour
{
    public GameObject lettuce;
    public GameObject tomato;
    public GameObject meat;

    public GameObject cheese;
    public GameObject buns;

    public int maxItems = 1;
    private int lCount;
    private int tCount;
    private int mCount;
    private int cCount;
    private int bCount;

    public void SpawnMeat()
    {
        if (mCount < maxItems)
        {
            FindObjectOfType<AudioManager>().Play("pop");
            Instantiate(meat, transform.position, transform.rotation);
            mCount++;
        }

    }

    public void SpawnTomato()
    {
        if (tCount < maxItems)
        {
            FindObjectOfType<AudioManager>().Play("pop");
            Instantiate(tomato, transform.position, Quaternion.Euler(-90f, 0f, 0f));
            tCount++;
        }
    }
    public void SpawnLettuce()
    {
        if (lCount < maxItems)
        {
            FindObjectOfType<AudioManager>().Play("pop");
            Instantiate(lettuce, transform.position, transform.rotation);
            lCount++;
        }
    }
    public void SpawnCheese()
    {
        if (cCount < maxItems)
        {
            FindObjectOfType<AudioManager>().Play("pop");
            Instantiate(cheese, transform.position, transform.rotation);
            cCount++;
        }
    }
    public void SpawnBuns()
    {
        if (bCount < maxItems)
        {
            FindObjectOfType<AudioManager>().Play("pop");
            Instantiate(buns, transform.position, transform.rotation);
            bCount++;
        }
    }
}
