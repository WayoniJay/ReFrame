using UnityEngine;

public class SpawningOrb : MonoBehaviour
{
    public GameObject[] orbPrefabs;

    public float spawnRange = 5f;

    public float spawnInterval = 2f;

    private void Start()
    {
        InvokeRepeating("SpawnOrb", 1f, spawnInterval);
    }

    void SpawnOrb()
    {

        Vector3 pos = new Vector3(

            Random.Range(-spawnRange, spawnRange),

            Random.Range(1f, 3f),

            Random.Range(-spawnRange, spawnRange)

        );

        int index = Random.Range(0, orbPrefabs.Length);

        Instantiate(orbPrefabs[index], pos, Quaternion.identity);
    }

}
