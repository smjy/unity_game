using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinimapManager : MonoBehaviour
{
    public static MinimapManager _instance;
    public GameObject iconDisplayGO;
    public GameObject iconCircle;
    public GameObject iconRect;
    public GameObject iconRectBorder;
    public GameObject iconRectRound;
    public Camera guideCamera;
    public static float scale;
    public static float defaultScale = 75f;
    public static float borderSize = 88f;
    public static float minScale = 40f;
    public static float maxScale = 150f;

    static public MinimapManager instance
    {
        get
        {
            return _instance;
        }
    }
    static public void SetScale(float v, bool isAdd = false)
    {
        scale = Mathf.Clamp(isAdd ? (scale + v) : v, minScale, maxScale);
    }
    public GameObject RegisterIcon(GameObject obj, GameObject iconPrefab)
    {
        GameObject icon = Instantiate(iconPrefab, iconDisplayGO.transform);
        icon.transform.parent = iconDisplayGO.transform;
        icon.GetComponent<MinimapIconController>().SetTarget(obj);
        return icon;
    }
    public void RegisterIcon(GameObject obj, GameObject iconPrefab,Color color)
    {
        GameObject icon = RegisterIcon(obj, iconPrefab);
        icon.GetComponent<Image>().color = color;
    }


    public void RemoveObj(Transform obj)
    {

    }
    // Use this for initialization
    void Start()
    {

    }

    void Awake()
    {
        scale = defaultScale;
        if(_instance==null){
            _instance = FindObjectOfType<MinimapManager>();
        }
        guideCamera = GameObject.Find("Guide Camera").GetComponent<Camera>();
    }
    // Update is called once per frame
    void Update()
    {

    }
}
