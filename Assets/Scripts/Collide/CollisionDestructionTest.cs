using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#pragma warning disable 0219
[RequireComponent(typeof(Destructible))]
public class CollisionDestructionTest : MonoBehaviour {
    
    public int hittime = 7;

    int hp;
    void Start() {
        hp = hittime;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<BulletController>()!=null) {
            Destroy(collision.gameObject);
            ContactPoint cp = collision.contacts[0];
            Vector3 toDirection = cp.point - transform.position;
            Quaternion r = Quaternion.FromToRotation(Vector3.forward,toDirection);
            Instantiate(EffectManager.main.get_hit_effect(),cp.point,r,EffectManager.main.effect_parent);

            hp--;
            if (hp==0) {
                GetComponent<Destructible>().trigger();
            }
        }
    }
	
}
