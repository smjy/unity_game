﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapNormalIconController : MinimapIconController
{

    // Use this for initialization
    public Transform target;
    RectTransform rect;

    public bool isTop; 

    public float borderSize;

    protected override void Start()
    {
    }
    void Awake()
    {
        rect = GetComponent<RectTransform>();
        this.borderSize = MinimapManager.borderSize;
        
    }
    // Update is called once per frame
    protected override void Update()
    {
        if (isTop)
        {
            transform.SetAsLastSibling();
        }
        float posScale = MinimapManager.scale;
        Vector2 pos = Camera.main.WorldToViewportPoint(target.transform.position);
        float dis = Mathf.Max(Mathf.Abs((pos.x - 0.5f) * posScale), Mathf.Abs((pos.y - 0.5f) * posScale));
        if (dis > borderSize)
        {
            rect.transform.localScale = Vector3.one * (1.25f + Mathf.Max(-0.5f / 120 * dis, -0.75f)) * (posScale / MinimapManager.defaultScale);
        }
        else
        {
            rect.transform.localScale = Vector3.one * (posScale / MinimapManager.defaultScale);
        }
        transform.localPosition = new Vector2(Mathf.Clamp((pos.x - 0.5f) * posScale, -borderSize, borderSize),
                                              Mathf.Clamp((pos.y - 0.5f) * posScale, -borderSize, borderSize));
        transform.localRotation = Quaternion.Euler(0,0, target.rotation.eulerAngles.z);
    }

    public override void SetTarget(GameObject obj){
        target = obj.transform;
    }

}
