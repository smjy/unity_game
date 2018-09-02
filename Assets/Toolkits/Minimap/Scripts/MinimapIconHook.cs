using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapIconHook : MonoBehaviour
{
    [Header("选择小地图要显示的图标")]
    public GameObject icon;
    [Header("选择小地图图标的颜色")]
    public Color color = new Color(1, 1, 1, 1);
    GameObject myicon;
    // Use this for initialization
    void Start()
    {

    }
    void Awake()
    {
        if (icon == null)
        {
            icon = MinimapManager.instance.iconCircle;
        }
        myicon =MinimapManager.instance.RegisterIcon(gameObject, icon, color);
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void iconDestroy() {
        Destroy(myicon);
    }
    void OnDestroy() {
        Destroy(myicon);
    }
}
