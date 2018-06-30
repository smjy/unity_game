using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapBorderIconController : MinimapIconController
{

    // Use this for initialization
    public MapBoundsController mapData;
	public RectTransform rect;
    protected override void Start()
    {

    }
    // Update is called once per frame
    protected override void Update()
    {
        float posScale = MinimapManager.scale;
        Vector2 pos = MinimapManager.instance.guideCamera.WorldToViewportPoint(new Vector3(
            (mapData.left + mapData.right) / 2,
            (mapData.top + mapData.bottom) / 2,
            100
        ));
        transform.localPosition = new Vector2(
			(pos.x - 0.5f) * posScale,
        	(pos.y - 0.5f) * posScale
		);

        Vector2 lt = MinimapManager.instance.guideCamera.WorldToViewportPoint(new Vector3(
            mapData.left,
            mapData.top,
            100
        )) * MinimapManager.scale;

        Vector2 rb = MinimapManager.instance.guideCamera.WorldToViewportPoint(new Vector3(
            mapData.right,
            mapData.bottom,
            100
        )) * MinimapManager.scale;

        // print(width);
        // print(length2);
        rect.sizeDelta = new Vector2(rb.x-lt.x, lt.y - rb.y);
    }

    public override void SetTarget(GameObject obj)
    {
        mapData = obj.GetComponent<MapBoundsController>();
        rect = GetComponent<RectTransform>();
		
    }
}
