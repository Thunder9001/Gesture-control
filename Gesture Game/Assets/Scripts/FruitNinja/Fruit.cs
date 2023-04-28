using UnityEngine;

// Code adapted to work with Leap Controller and sourced from a tutorial
// Original source repo: https://github.com/zigurous/unity-fruit-ninja-tutorial
public class Fruit : MonoBehaviour
{
    public GameObject whole;
    public GameObject sliced;

    private Rigidbody fruitRigidbody;
    private Collider fruitCollider;
    private ParticleSystem juiceParticles;

    public int points = 1;
    public bool cut = false;

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
        if (other.CompareTag("Player") && cut == false)
        {
            cut = true;
            FindObjectOfType<AudioManager>().Play("cut");
            FindObjectOfType<AudioManager>().Play("splash");
            Blade blade = other.GetComponent<Blade>();
            Slice(blade.dir, blade.transform.position, blade.sliceForce);
        }
    }
}
