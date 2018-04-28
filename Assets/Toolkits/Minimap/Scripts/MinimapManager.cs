using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapManager : MonoBehaviour {
	public static MinimapManager _instance;
	public GameObject iconDisplay;
    public GameObject iconPrefab;
	static public MinimapManager instance{
		get{
			if(_instance == null){
				_instance = FindObjectOfType<MinimapManager>();
			}
			return _instance;
		}
	}
	public void RegisterObj(Transform obj){
		GameObject icon = Instantiate(iconPrefab,iconDisplay.transform);
		icon.transform.parent = iconDisplay.transform;
		icon.GetComponent<MinimapIconController>().target = obj;
	}
	public void RemoveObj(Transform obj){

	}
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
