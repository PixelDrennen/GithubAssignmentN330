using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunModule : MonoBehaviour
{
    public Transform bulletSpawn;
    public GameObject bulletPrefab;

    public float fireRate = 0.2f;
    private float next = 0f;

    // Update is called once per frame
    void Update()
    {
        if (InputManager.Instance.isFiring)
        {
            if (Time.time > next)
            {
                next = Time.time + fireRate;
                GameObject bullet = Instantiate(bulletPrefab);
                bullet.transform.position = bulletSpawn.position;
                bullet.transform.eulerAngles = bulletSpawn.eulerAngles;
            }
        }
    }
}
