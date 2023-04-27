using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FruitThrower : MonoBehaviour
{
    private Collider spawnArea;

    public GameObject[] fruits;
    public GameObject bomb;

    [Range(0f, 1f)]
    public float bombChance = 0.05f;
    public float minSpawnDelay = 0.2f;
    public float maxSpawnDelay = 1f;

    public float minAngle = -15f;
    public float maxAngle = 15f;

    public float minForce = 15f;
    public float maxForce = 25f;

    public float maxLifetime = 5f;

    private void Awake()
    {
        spawnArea = GetComponent<Collider>();
    }
    // Start is called before the first frame update
    private void OnEnable()
    {
        StartCoroutine(Spawn());
    }

    public void OnDisable()
    {
        StopAllCoroutines();
    }


    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(2f);
        while (enabled)
        {
            Vector3 pos = new Vector3()
            {
                x = Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x),
                y = Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y),
                z = Random.Range(spawnArea.bounds.min.z, spawnArea.bounds.max.z)
            };



            Quaternion rot = Quaternion.Euler(0f, 0f, Random.Range(minAngle, maxAngle));
            GameObject fruit;
            if (Random.value > bombChance)
            {
                int rand = Random.Range(0, fruits.Length);
                if (rand == 4)
                {
                    fruit = Instantiate(fruits[rand], pos, Quaternion.Euler(0f, 90f, 0f));
                }
                else
                {
                    fruit = Instantiate(fruits[rand], pos, rot);
                }
            }
            else
            {
                fruit = Instantiate(bomb, pos, rot);
            }
            Destroy(fruit, maxLifetime);
            float force = Random.Range(minForce, maxForce);
            fruit.GetComponent<Rigidbody>().AddForce(fruit.transform.up * force, ForceMode.Impulse);
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
        }
    }
}
