using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Z轴过远或过近会渐变消失的物体
[RequireComponent(typeof(MeshRenderer))]
public class FadeInZ : MonoBehaviour
{


    MeshRenderer mr;
    float z_para = 30f;
    void Start()
    {
        if (GetComponent<MeshRenderer>() != null)
        {
            mr = GetComponent<MeshRenderer>();
        }
    }
    void FixedUpdate()
    {

        float z = transform.position.z;
        float alpha = 1f;
        if (z > GameManager.z_max - z_para)
        {
            alpha = Mathf.Max(0f, 1f - (z + z_para - GameManager.z_max) / z_para);
        }
        else if (z < GameManager.z_min + z_para)
        {
            alpha = Mathf.Max(0f, (z - GameManager.z_min) / z_para);
        }

        // GameManager.z_min 0 GameManager.z_min + 10 1
        Color c = mr.material.color;
        //可以同步操作alpha
        if (c.a > alpha) c.a = alpha;
        mr.material.color = c;



    }
}
