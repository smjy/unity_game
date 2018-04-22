using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordController : MonoBehaviour {

    public float follow_time = 3f; //字符飞向UI所需时间
    public float wait_time = .8f; //字符初始漂浮的时间
    public Text target_text;
    Vector3 startSpeed;
    Vector3 torqueSpeed;
    float torqueForce = 12f;
    float speedDecrease;
    bool startFollow = false;
    RectTransform following;
    Color c;
    int time;

    // Use this for initialization
    public void Init(char c, Vector3 ss, float sd,Text tt) {
        GetComponent<TextMesh>().text = c.ToString();
        target_text = tt;
        startSpeed = ss;
        speedDecrease = sd;
    }

	void Start () {
        time = 0;
        torqueSpeed = Random.onUnitSphere * torqueForce * Random.Range(0.5f,2f);
        following = target_text.GetComponent<RectTransform>();
        
	}

  
    void FixedUpdate() {
        if (startSpeed.magnitude < speedDecrease) startSpeed = new Vector3(0, 0, 0);
        else startSpeed = (startSpeed.normalized * (startSpeed.magnitude - speedDecrease));
        transform.Translate(startSpeed, Space.World);
        transform.Rotate(torqueSpeed);
        torqueSpeed *= 0.99f;

        
        time++;
        if (!startFollow && time > wait_time * 50) {
            startFollow = true;
            time = 0;
        } 

        if (startFollow) { 

            float alpha = 1f - time/(50f * follow_time);
            
            c = GetComponent<TextMesh>().color;
            c.a = alpha;
            GetComponent<TextMesh>().color = c;

            Vector3 ap = following.anchoredPosition;
            ap.z = 100;
            Vector3 target = Camera.main.ScreenToWorldPoint(ap);

            Vector3 direction = (target - transform.position).normalized;
            float distance = (target - transform.position).magnitude;
            float frac = time / (50f * follow_time);
            frac = frac*frac;
            transform.position = Vector3.Lerp(transform.position, target, frac);
            if ((transform.position - target).magnitude < 10f || time >= 50f * follow_time) {
                //加钱
                string t = target_text.GetComponent<Text>().text;
                target_text.GetComponent<Text>().text = (int.Parse(t) + 1).ToString();
                Destroy(gameObject);
            }
        }
        
        
	}

}
