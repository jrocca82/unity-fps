using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PatrolHealth : DroneHealth
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
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

    public override void DroneDeath() {
        base.DroneDeath();
    }

    public override void DestructionOccur() {
        base.DestructionOccur();
    }
}
