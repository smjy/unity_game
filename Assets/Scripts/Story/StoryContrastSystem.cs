using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class StoryContrastSystem : MonoBehaviour {

    public GameObject effect1;
    public GameObject effect2;

	
	void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<MainPlayer_Single>()!=null) {

            //Destroy(collision.gameObject);
            float imp = collision.impulse.magnitude;
            imp -= 7000f;
            ContactPoint cp = collision.contacts[0];
            Vector3 toDirection = cp.point - transform.position;
            Quaternion r = Quaternion.FromToRotation(Vector3.forward,toDirection);
            Instantiate(EffectManager.main.get_hit_effect(),cp.point,r,EffectManager.main.effect_parent);
            
            if (imp > 0) {
                Instantiate(effect1,transform);

                
                StoryChapter1.main.contrastResolve += imp/550000f;
                StoryChapter1.main.setContrast(Mathf.Max(1f,3f-imp/2000f));

                if (StoryChapter1.main.contrastResolve > StoryChapter1.main.contrastMax) {
                    DestroyAfter da = gameObject.AddComponent<DestroyAfter>();
                    
                    da.destroy_after = 3f;
                    foreach (ParticleSystem ps in gameObject.GetComponentsInChildren<ParticleSystem>()) {
                        ps.Stop();
                    }
                    gameObject.GetComponent<SphereCollider>().enabled = false;
                    gameObject.GetComponent<MeshRenderer>().enabled = false;
                    Instantiate(effect2,transform);

                }
            }
            
        }
    }
}
