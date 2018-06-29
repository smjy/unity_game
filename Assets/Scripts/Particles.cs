using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Lib;

public class Particles : MonoBehaviour
{

    private float size;
    private float blur;
    private Color color;
    public float minSize = 0.03f;
    public float maxSize = 0.09f;
    public float boundSize = 500f;
    private SpriteRenderer sr;
    Camera guideCamera;
    float boundleft,boundright,boundup,bounddown;
    // Use this for initialization
    void Start()
    {

        foreach(Camera c in Camera.allCameras) {
            if (c.gameObject.name == "Guide Camera") {
                Debug.Log("Guide Camera Found");
                guideCamera = c;
                break;
            }
        }
        boundleft = -boundSize;
        boundright = Screen.width + boundSize;
        boundup = -boundSize;
        bounddown = Screen.height + boundSize;

        sr = GetComponent<SpriteRenderer>();
        size = Random.Range(minSize, maxSize);
        //if (Random.Range(1, 11) < 2)
        if (true)
        {

            color = DUlib.randMainColor();
            sr.material.color = color;
        }
        float x = Random.Range(0f, Screen.width);
        float y = Random.Range(0f, Screen.height);
        float z = Random.Range(100f, 250f);
        Vector3 pos = guideCamera.ScreenToWorldPoint(new Vector3(x, y, z));


        transform.position = pos;
        transform.localScale = new Vector3(size, size, 1f);
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 pos = guideCamera.WorldToScreenPoint(transform.position);

        if (pos.x >= boundleft && pos.y >= boundup && pos.x <= boundright && pos.y <= bounddown) return;

        if (pos.x < 0)
            pos.x = boundright;
        else if (pos.x > boundright)
            pos.x = boundleft;
        if (pos.y < boundup)
            pos.y = bounddown;
        else if (pos.y > bounddown)
            pos.y = boundup;
            
        transform.position = guideCamera.ScreenToWorldPoint(pos);
        
    }
}