using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lib;
public class MainPlayer_Single : MonoBehaviour
{
    // Use this for initialization
    public static MainPlayer_Single me;
    public float forcePower = .5f;
    public float maxSpeed = 500f;
    //public float friction_extra = 20f;
    //float friction;
    public TextMesh say_text;

    [HideInInspector]
    public Rigidbody rb;
    void Awake() {
        if (me == null)
            me = this;
        else if (me != this)
            Destroy(gameObject);  
    }

    public void say(string str) {
        Vector3 init_pos = transform.position;
        init_pos.x += 7f;
        init_pos.y += 10f;
        TextMesh tm = Instantiate(say_text,init_pos,new Quaternion(),transform.parent);
        tm.text = str;
    }

    void Start()
    {
        transform.position = new Vector3(0, 0, 100);
        rb = GetComponent<Rigidbody>();
    }

    float easeInput(float input) {
        if (input == 0) return 0f;
        if (input > 0) return Mathf.Pow(input,forcePower);
        return -Mathf.Pow(-input,forcePower);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 mv;
        if (CommandInput.main != null && CommandInput.main.N()) {
            mv = new Vector3(0,0,0);
        } else if (StoryChapter1.main.lockInput) {
            mv = new Vector3(0,0,0);
        } else {
            mv = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        }
     
        mv *= maxSpeed;

        rb.velocity = mv;
    }
}
