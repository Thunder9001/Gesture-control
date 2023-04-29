using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity;
using Leap.Unity.Interaction;
using Leap;

public class GestureInteraction : MonoBehaviour
{
    // Create a list of game objects one for each interaction.
    public GameObject[] pullList;
    
    public float speed = 0.5f;

    //Controlled by Leap detectors
    bool push = false;
    bool pull = false;

    private void Awake()
    {
        pullList = GameObject.FindGameObjectsWithTag("Pullable");
    }
    //Get palm ui element

    public void Push()
    {
        if(CheckPalmUI())
        {
            push = false;
        }
        else
        {
            push = true;
        }
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
        if (CheckPalmUI())
        {
            pull = false;
        }
        else
        {
            pull = true;
        }
    }

    public bool CheckPalmUI()
    {
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        Hand _rightHand = Hands.Right;
        Vector3 rHandDirection = new Vector3(_rightHand.PalmNormal.x, _rightHand.PalmNormal.y, _rightHand.PalmNormal.z).normalized;
        Vector3 rIndexFingerDirection = _rightHand.GetIndex().Direction.normalized;
        if (push == true)
        {
            transform.Translate (rHandDirection * speed * Time.deltaTime, Space.World);
        }
        else if (pull == true)
        {
            transform.Translate(-rIndexFingerDirection * speed * Time.deltaTime, Space.World);
        }   

    }
}
