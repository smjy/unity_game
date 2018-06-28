using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class try_1 : MonoBehaviour {
    public Button TRY_BUTTON;
    public Image TRY_IMAGE;
    public Text text;
	// Use this for initialization
	void Start () {
        TRY_IMAGE = GetComponent<Image>();
        TRY_BUTTON = GetComponent<Button>();
        text = transform.Find("Text").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
}
