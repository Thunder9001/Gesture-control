using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity;
using Leap.Unity.Interaction;
using Leap;

public class GestureInteraction : MonoBehaviour
{
    public LeapProvider leapProvider;
    public Vector3 rHandDirection;

    // Create a list of game objects one for each interaction.
    List<GameObject> pushList;
    List<GameObject> pullList;
    
    public float speed = 1;

    public bool push = false;
    public bool pull = false;
    
    private void OnEnable()
    {
        leapProvider.OnUpdateFrame += OnUpdateFrame;
    }
    private void OnDisable()
    {
        leapProvider.OnUpdateFrame -= OnUpdateFrame;
    }

    void OnUpdateFrame(Frame frame)
    {
        //Use a helpul utility function to get the first hand that matches the Chirality
        Hand _leftHand = frame.GetHand(Chirality.Left);
        Hand _rightHand = frame.GetHand(Chirality.Right);
    }

    public void Push()
    {
        Debug.Log("X: " + rHandDirection.x + ", Y: " + rHandDirection.y + ", Z: " + rHandDirection.z);
        push = true;
    }
    
    public void StopInteraction()
    {
        push = false;
        pull = false;
    }

    //TODO
    public void Pull()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        pushList = new List<GameObject>();
        pullList = new List<GameObject>();

        rHandDirection = new Vector3(0.0f, 1.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        Hand _rightHand = Hands.Right;
        rHandDirection.x = _rightHand.PalmNormal.x;
        rHandDirection.y = _rightHand.PalmNormal.y;
        rHandDirection.z = _rightHand.PalmNormal.z;
        if (push == true)
        {
            transform.Translate (rHandDirection * speed * Time.deltaTime);
        }
        //TODO PULL

    }
}
