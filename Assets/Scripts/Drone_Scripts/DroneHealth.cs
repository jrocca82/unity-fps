using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DroneHealth : MonoBehaviour, IDestructable
{
    [SerializeField]
    protected Image enemyHealth;

    [SerializeField]
    protected GameObject explosion;

    [SerializeField]
    protected Animation animClip;

    protected virtual void Start()
    {
        animClip = GetComponent<Animation>();
    }

    protected virtual void Update()
    {
        if (enemyHealth.fillAmount <= 0)
        {
            DroneDeath();
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

    public virtual void DroneDeath()
    {
        StartCoroutine("DeathAnim");
    }

    public virtual void DestructionOccur() {
        enemyHealth.fillAmount -= 0.09f;
        if(enemyHealth.fillAmount <= 0) {
            DroneDeath();
        }
    }
}
