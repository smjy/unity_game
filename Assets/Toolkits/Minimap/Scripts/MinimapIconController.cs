using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapIconController : MonoBehaviour
{

    // Use this for initialization
    public Transform target;
    RectTransform rect;

    void Start()
    {

    }
    void Awake()
    {
        rect = GetComponent<RectTransform>();
    }
    // Update is called once per frame
    void Update()
    {
        float posScale = MinimapManager.scale;
        rect.transform.localScale = new Vector3(1, 1, 1) * (posScale / MinimapManager.defaultScale);
        Vector2 pos = Camera.main.WorldToViewportPoint(target.transform.position);
        transform.localPosition = new Vector2(Mathf.Clamp((pos.x - 0.5f) * posScale, -90, 90), Mathf.Clamp((pos.y - 0.5f) * posScale, -90, 90));
    }
}
