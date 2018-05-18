using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapUI : MonoBehaviour
{

    private float clock;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Time.deltaTime);
        if (Time.time - clock > 3f)
        {
            MinimapManager.scale = Mathf.Lerp(MinimapManager.scale, MinimapManager.defaultScale, Time.deltaTime*3f);
        }
    }
    void OnMouseOver()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            MinimapManager.SetScale(+5, true);
            clock = Time.time;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            MinimapManager.SetScale(-5, true);
            clock = Time.time;

        }
    }
}
