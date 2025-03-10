using UnityEngine;

public class Jet : MonoBehaviour
{
    public float speed = 2f;
    private float direction = -1f; // Default direction (left)

    void Start()
    {
        // Ensure a direction is assigned before moving
        if (direction == 0)
        {
            direction = Random.value > 0.5f ? 1f : -1f; // Randomize direction if not set
        }
    }

    void Update()
    {
        transform.Translate(Vector2.right * direction * speed * Time.deltaTime);

        // Destroy jet if it moves out of screen bounds
        if (transform.position.x > 9f || transform.position.x < -9f)
        {
            Destroy(gameObject);
        }
    }

    public void SetDirection(float dir)
    {
        direction = dir;
    }
}
