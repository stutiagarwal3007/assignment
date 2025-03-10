using UnityEngine;

public class HelicopterSpawner : MonoBehaviour
{
    public GameObject helicopterPrefab;
    public GameObject jetPrefab;

    public float spawnInterval = 3f; // Faster spawning
    private float screenLeft = -8f;
    private float screenRight = 8f;

    void Start()
    {
        InvokeRepeating("SpawnAircraft", 2f, spawnInterval);
    }

    void SpawnAircraft()
    {
        float spawnX = Random.Range(screenLeft, screenRight);
        Vector3 spawnPosition = new Vector3(spawnX, 5f, 0); // Spawning slightly above screen

        GameObject aircraft = Random.value > 0.5f ? helicopterPrefab : jetPrefab;
        GameObject spawnedAircraft = Instantiate(aircraft, spawnPosition, Quaternion.identity);

        Aircraft aircraftScript = spawnedAircraft.GetComponent<Aircraft>();
        if (aircraftScript != null)
        {
            float direction = Random.value > 0.5f ? 1f : -1f; // Move left or right
            aircraftScript.SetDirection(direction);
        }
    }
}
