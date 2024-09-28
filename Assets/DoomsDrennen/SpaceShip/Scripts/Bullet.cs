using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 50f;
    private Rigidbody rb;
    public float lifetime = 3f;
    private float currentLifetime = 0f;

    public float damage = 20f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        currentLifetime += Time.deltaTime;

        if (currentLifetime >= lifetime)
            Destroy(gameObject);

        rb.velocity = transform.forward * bulletSpeed;
    }

    //? detect if anything is touching this gameobject
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Health>().health -= damage;
        }
        Destroy(gameObject);
    }
}
