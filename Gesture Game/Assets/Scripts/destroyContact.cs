using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyContact : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent("Fruit") != null)
        {
            Fruit f = other.GetComponent<Fruit>();
            if (f.cut == false)
            {
                FindObjectOfType<GameManager>().ResetCombo();
            }
        }
        Destroy(other.gameObject);
    }
}
