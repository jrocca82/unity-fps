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

    public Animation animClip;

    bool canShoot = true;

    void Update()
    {
        timer += 1;
        SpawnBullet();
    }

    void SpawnBullet()
    {
        if (Input.GetMouseButtonDown(0) && timer >= 20 && canShoot == true)
        {
            GameObject bulletClone =
                Instantiate(bullet, spawnArea.position, spawnArea.rotation);

            bulletClone
                .GetComponent<Rigidbody>()
                .AddForce(spawnArea.transform.forward * 800);
            canShoot = false;
            StartCoroutine("RecoilAnim");
            timer = 0;
            Destroy(bulletClone, 1f);
        }
    }

    IEnumerator RecoilAnim()
    {
        animClip.Play("Gun_Recoil");
        yield return new WaitForSeconds(animClip.clip.length);
        canShoot = true;
    }
}
