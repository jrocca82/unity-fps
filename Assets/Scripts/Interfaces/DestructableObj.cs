using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableObj : MonoBehaviour, IDestructable
{
    [SerializeField]
    protected GameObject explodeObject;
    private int hitCounter = 0;
    
    public void DestructionOccur(){
        hitCounter += 1;
        if(hitCounter >=3){
            GameObject explodeClone = Instantiate(explodeObject, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(explodeClone, 0.5f);
            Destroy(gameObject);
        }
    }
}
