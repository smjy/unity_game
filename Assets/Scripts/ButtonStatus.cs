using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonStatus : MonoBehaviour {

	
    public Material hoverMt;
    public Material normalMt;

    // Use this for initialization
    void Start()
    {
        Button btn = this.GetComponent<Button>();
        UIEventListener btnListener = btn.gameObject.AddComponent<UIEventListener>();

        btnListener.OnMouseEnter += delegate (GameObject gb) {
           
            gb.GetComponent<Image>().material = hoverMt;
        };

        btnListener.OnMouseExit += delegate (GameObject gb) {
            
            gb.GetComponent<Image>().material = normalMt;
        };
    }
}
