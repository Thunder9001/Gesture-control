using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public GameObject whole;
    public GameObject sliced;

    private Rigidbody fruitRigidbody;
    private Collider fruitCollider;
    private ParticleSystem juiceParticles;

    public int points = 1;

    private void Awake()
    {
        fruitRigidbody = GetComponent<Rigidbody>();
        fruitCollider = GetComponent<Collider>();
        juiceParticles = GetComponentInChildren<ParticleSystem>();
    }

    private void Slice(Vector3 dir, Vector3 pos, float force)
    {
        FindObjectOfType<GameManager>().IncreaseScore(points);
        whole.SetActive(false);
        sliced.SetActive(true);
        fruitCollider.enabled = true;
        juiceParticles.Play();

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        sliced.transform.rotation = Quaternion.Euler(0f, 0f, angle);

        Rigidbody[] slices = sliced.GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody s in slices)
        {
            s.velocity = fruitRigidbody.velocity;
            s.AddForceAtPosition(dir * force, pos, ForceMode.Impulse);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Blade blade = other.GetComponent<Blade>();
            Slice(blade.dir, blade.transform.position, blade.sliceForce);
        }
    }
}
