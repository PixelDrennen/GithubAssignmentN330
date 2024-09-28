using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locomotion : MonoBehaviour
{
    private Rigidbody rb;
    public float acceleration = 5f;
    public float deceleration = 5f;
    public float turnSpeed = 5f;

    public float currentSpeed = 0f;

    public float maxSpeed = 10f;


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
        currentSpeed += Time.deltaTime * InputManager.Instance.moveValue * acceleration;
        currentSpeed = Mathf.Clamp(currentSpeed, 0f, maxSpeed);

        rb.velocity = transform.root.forward * currentSpeed;

        if (InputManager.Instance.moveValue <= 0)
        {
            currentSpeed -= Time.deltaTime * deceleration;
        }
    }

    private void Turn()
    {
        rb.angularVelocity = transform.root.up * turnSpeed * InputManager.Instance.turnValue;
    }
}
