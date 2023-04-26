using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyContact : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        Destroy(other.gameObject);
    }
}
