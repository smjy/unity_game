using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapManager : MonoBehaviour
{
    public static MinimapManager _instance;
    public GameObject iconDisplay;
	public static float scale;
	public static float defaultScale = 90f;

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
	static public void SetScale(float v,bool isAdd=false){
		scale = Mathf.Clamp(isAdd?(scale+v):v,60f,150f);
	}
    public void RegisterObj(Transform obj, GameObject iconPrefab)
    {
        GameObject icon = Instantiate(iconPrefab, iconDisplay.transform);
        icon.transform.parent = iconDisplay.transform;
        icon.GetComponent<MinimapIconController>().target = obj;
    }
    public void RemoveObj(Transform obj)
    {

    }
    // Use this for initialization
    void Start()
    {

    }

	void Awake(){
		scale = defaultScale;
	}
    // Update is called once per frame
    void Update()
    {

    }
}
