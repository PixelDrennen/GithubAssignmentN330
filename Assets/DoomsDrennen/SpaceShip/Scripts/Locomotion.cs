using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locomotion : MonoBehaviour
{
    private Rigidbody rb;
    public float moveSpeed = 5f;
    public float turnSpeed = 5f;

    private void Awake()
    {
        rb = transform.root.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
        Turn();
    }

    private void Move()
    {
        rb.velocity = transform.root.forward * moveSpeed * InputManager.Instance.moveValue;
    }

    private void Turn()
    {
        rb.angularVelocity = transform.root.up * turnSpeed * InputManager.Instance.turnValue;
    }
}
