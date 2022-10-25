using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private Transform spawnArea;

    public int timer = 0;

    void Update()
    {
        timer += 1;
        SpawnBullet();
    }

    void SpawnBullet()
    {
        if (Input.GetMouseButtonDown(0) && timer >= 20)
        {
            GameObject bulletClone =
                Instantiate(bullet, spawnArea.position, spawnArea.rotation);

            bulletClone
                .GetComponent<Rigidbody>()
                .AddForce(spawnArea.transform.forward * 800);
            timer = 0;
            Destroy(bulletClone, 1f);
        }
    }
}
