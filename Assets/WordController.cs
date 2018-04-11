using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordController : MonoBehaviour {

    public float follow_force = 70f;
    public Text target_text;
    float force_update = 1.05f;
    float force;
    Rigidbody r;
    bool startFollow = false;
    RectTransform following;
    float waitTime = .8f;
    Color c;
    int time;

	// Use this for initialization
	void Start () {
        time = 0;
        following = target_text.GetComponent<RectTransform>();
        force = follow_force;
        r = GetComponent<Rigidbody>();
        StartCoroutine(followAfter());
        c = GetComponent<TextMesh>().color;
	}
	
    IEnumerator followAfter() {
        yield return new WaitForSeconds(waitTime);
        startFollow = true;
    }
    // Update is called once per frame
    void Update() {
        if (startFollow) {
            time++;
            float alpha = Mathf.Max(0f,1f-(Mathf.Max(0f,time*Time.deltaTime*0.5f)));
            c = GetComponent<TextMesh>().color;
            c.a = alpha;
            GetComponent<TextMesh>().color = c;
            Vector3 ap = following.anchoredPosition;
            ap.z = 100;
            Vector3 target = Camera.main.ScreenToWorldPoint(ap);

            Vector3 direction = (target - transform.position).normalized;
            r.AddForce(direction * force);
            force *= force_update;
            if ((transform.position - target).magnitude < 10f || time > 2/Time.deltaTime) {
                //加钱
                string t = target_text.GetComponent<Text>().text;
                target_text.GetComponent<Text>().text = (int.Parse(t) + 1).ToString();
                Destroy(gameObject);
            }
        }
        
	}

}
