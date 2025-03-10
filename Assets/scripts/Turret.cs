using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 10f;
    private bool isFiring = false;
    private float nextFireTime = 0f;

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))  // Hold space for continuous fire
        {
            if (Time.time > nextFireTime)
            {
                FireBullet();
                nextFireTime = Time.time + fireRate;
            }
        }
        RotateTurret();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireBullet();
        }
    }

    void RotateTurret()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePos - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    void FireBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = firePoint.right * fireRate;
    }
}
