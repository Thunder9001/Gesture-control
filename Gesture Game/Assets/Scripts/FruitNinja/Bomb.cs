using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Code adapted to work with Leap Controller and sourced from a tutorial
// Original source repo: https://github.com/zigurous/unity-fruit-ninja-tutorial

public class Bomb : MonoBehaviour
{
    public GameObject whole;
    public GameObject sliced;

    private Rigidbody bombRigidbody;
    private Collider bombCollider;
    private ParticleSystem explosionParticles;

    public bool cut = false;

    private void Awake()
    {
        bombRigidbody = GetComponent<Rigidbody>();
        bombCollider = GetComponent<Collider>();
        explosionParticles = GetComponentInChildren<ParticleSystem>();
    }

    private void Slice(Vector3 dir, Vector3 pos, float force)
    {
        FindObjectOfType<GameManager>().DecreaseLives();
        whole.SetActive(false);
        sliced.SetActive(true);
        bombCollider.enabled = true;
        explosionParticles.Play();

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        sliced.transform.rotation = Quaternion.Euler(0f, 0f, angle);

        Rigidbody[] slices = sliced.GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody s in slices)
        {
            s.velocity = bombRigidbody.velocity;
            s.AddForceAtPosition(dir * force, pos, ForceMode.Impulse);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.CompareTag("Player") && cut == false)
       {
            cut = true;
            FindObjectOfType<AudioManager>().Play("explosion");
            Blade blade = other.GetComponent<Blade>();
            Slice(blade.dir, blade.transform.position, blade.sliceForce);
       }
    }
}
