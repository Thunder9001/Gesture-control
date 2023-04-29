using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullObject : MonoBehaviour
{
    public GameObject puller;
    private bool IsPulling = false;
    public float pullSpeed = 0.5f;


    public void pull()
    {
        IsPulling = true;
    }
    public void stopPull()
    {
        IsPulling=false;
    }
    // Update is called once per frame
    void Update()
    {
        if (IsPulling)
        {
            Vector3 dir = (puller.transform.position - transform.position).normalized;
            transform.Translate(dir * pullSpeed * Time.deltaTime, Space.World);
        }
    }
}
