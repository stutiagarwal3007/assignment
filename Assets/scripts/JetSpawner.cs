using UnityEngine;

public class JetSpawner : MonoBehaviour
{
    public GameObject jetPrefab;
    public float spawnRate = 1f;

    void Start()
    {
        InvokeRepeating("SpawnJet", 5f, spawnRate);
    }

    void SpawnJet()
    {
        Instantiate(jetPrefab, new Vector3(10, Random.Range(2, 5), 0), Quaternion.identity);
    }
}
