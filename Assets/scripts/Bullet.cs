using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletControl : MonoBehaviour
{

    // Use this for initialization
    //public Transform Weapon;

    public float speed = 6f;
    void Start()
    {
        //speedY = 6f;
        //transform.rotation = Weapon.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;

        // Destroy bullet when it leaves the screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        if (transform.position.y > max.y)
        {
            Destroy(gameObject);
        }
    }
}