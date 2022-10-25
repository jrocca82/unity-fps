using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackPlayer : MonoBehaviour
{
    public float radius = 3f;
    public Collider[] colliderSearch;
    public bool playerDetected = false;

    [SerializeField]
    private GameObject laser;

    public int timer = 0;
    public Transform laserSpawn;

    void Update()
    {
        timer += 1;
        playerDetected = false;
        colliderSearch = Physics.OverlapSphere(transform.position, radius);

        foreach(Collider collider in colliderSearch){
            if(collider.tag == "Player") {
                playerDetected = true;
                Transform playerPos = GameObject.Find("Player").transform;

                transform.LookAt(playerPos.position);

                if(timer >= 15) {
                    GameObject laserClone = Instantiate(laser, laserSpawn.transform.position, laserSpawn.transform.rotation);
                    laser.transform.rotation = Quaternion.Euler(100.01f, 57.34f, -56.90f);
                    laserClone.GetComponent<Rigidbody>().AddForce(laserSpawn.transform.forward * 1000);
                    timer = 0;
                    Destroy(laserClone, 0.5f);
                }
            }
        }
    }
}
