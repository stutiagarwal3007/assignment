using UnityEngine;

public class Aircraft : MonoBehaviour
{
    public float speed = 2f;
    private float direction;
    public GameObject paratrooperPrefab;
    public GameObject bombPrefab;
    public bool isJet = false;

    private int maxParatroopers = 3; // Limit to 3 paratroopers
    private int paratrooperCount = 0;

    void Start()
    {
        if (isJet && bombPrefab == null)
        {
            Debug.LogError("Bomb prefab is missing in Jet!");
        }
        if (!isJet && paratrooperPrefab == null)
        {
            Debug.LogError("Paratrooper prefab is missing in Helicopter!");
        }

        if (!isJet) // Helicopters drop paratroopers
        {
            InvokeRepeating("DropParatrooper", 2f, 10f); // 10s interval
        }
        if (isJet) // Jets drop bombs
        {
            InvokeRepeating("DropBomb", 3f, 5f);
        }
    }

    public void SetDirection(float dir)
    {
        direction = dir;
    }

    void Update()
    {
        transform.Translate(Vector2.right * direction * speed * Time.deltaTime);

        if (transform.position.x > 8f || transform.position.x < -8f)
            Destroy(gameObject);
    }

    void DropParatrooper()
    {
        if (paratrooperPrefab != null && paratrooperCount < maxParatroopers)
        {
            Instantiate(paratrooperPrefab, transform.position + new Vector3(0, -0.5f, 0), Quaternion.identity);
            paratrooperCount++;
        }
    }

    void DropBomb()
    {
        if (bombPrefab != null)
        {
            Instantiate(bombPrefab, transform.position + new Vector3(0, -0.5f, 0), Quaternion.identity);
        }
    }
}
