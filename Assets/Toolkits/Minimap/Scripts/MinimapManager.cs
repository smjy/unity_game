using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinimapManager : MonoBehaviour
{
    public static MinimapManager _instance;
    public GameObject iconDisplayGO;
    public GameObject iconCircle;
    public static float scale;
    public static float defaultScale = 75f;
    public static float borderSize = 88f;
    public static float minScale = 40f;
    public static float maxScale = 150f;

    static public MinimapManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<MinimapManager>();
            }
            return _instance;
        }
    }
    static public void SetScale(float v, bool isAdd = false)
    {
        scale = Mathf.Clamp(isAdd ? (scale + v) : v, minScale, maxScale);
    }
    public void RegisterObj(Transform obj, GameObject iconPrefab)
    {
        GameObject icon = Instantiate(iconPrefab, iconDisplayGO.transform);
        icon.transform.parent = iconDisplayGO.transform;
        icon.GetComponent<MinimapIconController>().target = obj;
    }
    public void RegisterObj(Transform obj, GameObject iconPrefab,Color color)
    {
        GameObject icon = Instantiate(iconPrefab, iconDisplayGO.transform);
        icon.transform.parent = iconDisplayGO.transform;
        icon.GetComponent<Image>().color = color;
        icon.GetComponent<MinimapIconController>().target = obj;
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
        _instance = FindObjectOfType<MinimapManager>();
    }
    // Update is called once per frame
    void Update()
    {

    }
}
