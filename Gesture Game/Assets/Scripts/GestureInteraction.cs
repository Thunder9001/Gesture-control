using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity;
using Leap.Unity.Interaction;
using Leap;

public class GestureInteraction : MonoBehaviour
{
    public Vector3 rHandDirection;
    public float speed = 2;
    public bool push = false;
    void Push()
    {
        Debug.Log("X: " + rHandDirection.x + ", Y: " + rHandDirection.y + ", Z: " + rHandDirection.z);
        push = true;
    }

    public void Pull()
    {
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Hand _rightHand = Hands.Right;
        rHandDirection = _rightHand.PalmNormal;
        if (push == true)
        {
            transform.Translate (rHandDirection * speed * Time.deltaTime);
        }

    }
}
