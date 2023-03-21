using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity;
using Leap.Unity.Interaction;
using Leap;

public class GestureInteraction : MonoBehaviour
{
    public LeapProvider leapProvider;
    //Direction of Push and pull
    Vector3 rHandDirection;
    Vector3 rIndexFingerDirection;
    Hand _rightHand;


    // Create a list of game objects one for each interaction.
    public List<GameObject> pushList;
    public List<GameObject> pullList;
    
    public float speed = 0.5f;

    //Controlled by Leap detectors
    bool push = false;
    bool pull = false;
    public void Push()
    {
        push = true;
    }
    public void StopPush()
    {
        push = false;
    }
    public void StopPull()
    {
        pull = false;
    }
    public void Pull()
    {
        pull = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        pushList = new List<GameObject>();
        pullList = new List<GameObject>();
        _rightHand = Hands.Right;
    }

    // Update is called once per frame
    void Update()
    {
        _rightHand = Hands.Right;
        rHandDirection = new Vector3(_rightHand.PalmNormal.x, _rightHand.PalmNormal.y, _rightHand.PalmNormal.z).normalized;
        rIndexFingerDirection = _rightHand.GetIndex().Direction.normalized;
        if (push == true)
        {
            transform.Translate (rHandDirection * speed * Time.deltaTime, Space.World);
            print(rHandDirection);
        }
        else if (pull == true)
        {
            transform.Translate(-rIndexFingerDirection * speed * Time.deltaTime, Space.World);
            print(-rIndexFingerDirection);
        }   

    }
}
