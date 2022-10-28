using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StationaryHealth : MonoBehaviour
{
    public Image enemyHealth;

    public GameObject explosion;

    public Animation animClip;

    void Start()
    {
        animClip = GetComponent<Animation>();
    }

    void Update()
    {
        if (enemyHealth.fillAmount <= 0)
        {
            StartCoroutine("DeathAnim");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            enemyHealth.fillAmount -= 0.09f;
        }
    }

    IEnumerator DeathAnim()
    {
        animClip.Play("DroneDeath");
        yield return new WaitForSeconds(animClip.clip.length);
        GameObject explosionClone =
            Instantiate(explosion,
            gameObject.transform.position,
            gameObject.transform.rotation);
        Destroy(explosionClone, 0.5f);
        Destroy(gameObject, 0.2f);
    }
}
