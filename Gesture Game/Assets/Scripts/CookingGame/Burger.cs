using Leap.Unity;
using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;

public class Burger : MonoBehaviour
{
    public GameObject burger;
    private int state = 0;

    private GameObject instance;
    private void Awake()
    {
        foreach (Transform c in burger.transform.GetChildren())
        {
            c.gameObject.SetActive(false);
        }
        Vector3 pos = new Vector3(transform.position.x, transform.position.y + 0.03f, transform.position.z);
        instance = Instantiate(burger, pos, transform.rotation);
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name.Contains("BunBase") && state == 0)
        {
            NextState();
            FindObjectOfType<CookingGameManager>().NextState();
            Destroy(collider.gameObject);
            Debug.Log(state);
        }

        if (collider.gameObject.name.Contains("Patty") && state == 1)
        {
            NextState();
            FindObjectOfType<CookingGameManager>().NextState();
            Destroy(collider.gameObject);
            Debug.Log(state);
        }
        if (collider.gameObject.name.Contains("Cheese") && state == 2)
        {
            NextState();
            FindObjectOfType<CookingGameManager>().NextState();
            Destroy(collider.gameObject);
            Debug.Log(state);
        }
        if (collider.gameObject.name.Contains("CutTomatoes") && state == 3)
        {
            NextState();
            FindObjectOfType<CookingGameManager>().NextState();
            Destroy(collider.gameObject);
            Debug.Log(state);
        }
        if (collider.gameObject.name.Contains("CutSalad") && state == 4)
        {
            NextState();
            Debug.Log(state);
            Destroy(collider.gameObject);
            NextState();
            FindObjectOfType<CookingGameManager>().NextState();
            Debug.Log(state);
        }
    }

    private void NextState()
    {
        FindObjectOfType<AudioManager>().Play("pop");
        instance.transform.GetChild(state).gameObject.SetActive(true);
        state++;
    }
}
