using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    public GameObject explosiveObject;
    public float explosionForce = 10.0f;
    public float explosionRadius = 5.0f;
    public float explosionUpwardForce = 1.0f;

    void FixedUpdate()
    {
        if (explosiveObject == enabled)
        {
            Invoke("TriggerExplosion", 5);
        }
    }

    void TriggerExplosion()
    {
        Vector3 explosionPosition = explosiveObject.transform.position;
        Collider[] affectedObjects = Physics.OverlapSphere(explosionPosition, explosionRadius);

        foreach (Collider hitObject in affectedObjects)
        {
            Rigidbody objectRigidbody = hitObject.GetComponent<Rigidbody>();
            if (objectRigidbody != null)
            {
                objectRigidbody.AddExplosionForce(explosionForce, explosionPosition, explosionRadius, explosionUpwardForce, ForceMode.Impulse);
            }
        }
    }
}
