using Leap;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vegetable : MonoBehaviour
{
    public int maxHealth = 3;

    public HealthBar healthBar;
    public Canvas canvas;
    public GameObject sliced;
    private ParticleSystem cutParticles;
    private Rigidbody rb;

    private bool collided = false;
    private bool cut = false;
    private bool cuttable = false;

    private void Awake()
    {
        cutParticles = GetComponentInChildren<ParticleSystem>();
        rb = this.gameObject.GetComponent<Rigidbody>();
        healthBar.SetMaxHealth(maxHealth);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "knife" && collided == false && cuttable == true)
        {
            FindObjectOfType<AudioManager>().Play("cut");
            healthBar.DecreaseHealth();
            cutParticles.Play();
            collided = true;
        }

        if (other.gameObject.name == "CuttingBoard")
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            canvas.gameObject.SetActive(true);
            cuttable = true;
        }
        if (healthBar.slider.value == 0 && cut == false)
        {
            cut = true;
            SwitchObjects();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "knife")
        {
            collided = false;
        }
        if (collision.gameObject.name == "CuttingBoard")
        {
            cuttable = false;
        }
    }

    private void SwitchObjects()
    {
        FindObjectOfType<AudioManager>().Play("pop");
        Instantiate(sliced, transform.position, transform.rotation);
        Destroy(transform.gameObject);
    }

}
