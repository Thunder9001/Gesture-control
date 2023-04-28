using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Code adapted to work with Leap Controller and sourced from a tutorial
//Original code can be found here https://github.com/zigurous/unity-fruit-ninja-tutorial  
public class Blade : MonoBehaviour
{

    public GameObject rightHand;
    public GameObject index;
    public GameObject planeCollider;


    private Collider bladeCollider;
    private TrailRenderer bladeTrail;

    private bool isSlicing;
    public Vector3 dir { get; private set; }
    public float minSliceVelocity = 0.2f;
    public float sliceForce = 0.5f;

    private void Awake()
    {
        bladeCollider = GetComponent<Collider>();
        bladeTrail = GetComponentInChildren<TrailRenderer>();
    }

    private void OnEnable()
    {
        StopSlicing();
    }

    private void OnDisable()
    {
        StopSlicing();
    }

    // Update is called once per frame
    private void Update()
    {
        if (rightHand.activeSelf && !isSlicing)
        {
            StartSlicing();
        }
        else if(!rightHand.activeSelf)
        {

            StopSlicing();
        } 
        else if(isSlicing)
        {
            ContinueSlicing();
        }
    }


    private void StartSlicing()
    {
        RaycastHit pointPos;
        if (Physics.Raycast(index.transform.position, index.transform.forward, out pointPos, 20f))
        {
            transform.position = new Vector3(pointPos.point.x, pointPos.point.y, 0f);
        }

        isSlicing = true;
        bladeCollider.enabled = true;
        bladeTrail.enabled = true;
        bladeTrail.Clear();
    }
    private void StopSlicing()
    {
        isSlicing = false;
        bladeCollider.enabled = false;
        bladeTrail.enabled = false;
    }
    
    private void ContinueSlicing()
    {
        Vector3 newPos = new Vector3();
        RaycastHit pointPos;
        if (Physics.Raycast(index.transform.position, index.transform.forward, out pointPos, 20f))
        {
            newPos = pointPos.point;
        }
        newPos.z = 0f;

        dir = newPos - transform.position;

        float velocity = dir.magnitude / Time.deltaTime;
        bladeCollider.enabled = velocity > minSliceVelocity;

        transform.position = newPos;
    }



}
