using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

// Progress bar update code sourced adapted from loading bar implementation from https://www.youtube.com/watch?v=YMj2qPq9CP8
// Credit goes to Brackeys
public class Meat : MonoBehaviour
{
    public Slider progressBar;
    public Canvas canvas;
    public GameObject cooked;
    public float duration = 20f;

    private ParticleSystem cookParticles;
    private Rigidbody rb;
    private Collider cd;

    private bool isCooked = false;

    private void Awake()
    {
        cookParticles = GetComponentInChildren<ParticleSystem>();
        rb = this.gameObject.GetComponent<Rigidbody>();
        cd = this.gameObject.GetComponent<Collider>();
        progressBar.value = 0;
        progressBar.maxValue = 1;
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Cooktop")
        {
            canvas.gameObject.SetActive(true);
            rb.constraints = RigidbodyConstraints.FreezeAll;
            cookParticles.Play();
            FindObjectOfType<AudioManager>().Play("sizzle");
            StartCoroutine(CookMeat());
        }
    }

    private void Update()
    {
        if (isCooked)
        {
            rb.constraints = RigidbodyConstraints.None;
            rb.isKinematic = true;
            cookParticles.Stop();
            SwitchObjects();
        }
    }

    private void SwitchObjects()
    {
        FindObjectOfType<AudioManager>().Play("pop");
        cd.enabled = false;
        Instantiate(cooked, transform.position, transform.rotation);
        Destroy(transform.gameObject);
    }
    IEnumerator CookMeat()
    {
        float elapsed = 0f;
        while(isCooked == false)
        {
            float progress = Mathf.Clamp01(elapsed / duration);
            progressBar.value = progress;
            elapsed += Time.deltaTime;
            if(elapsed >= duration)
            {
                isCooked = true;
            }
            yield return null;
        }
    }
}
