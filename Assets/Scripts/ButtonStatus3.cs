using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonStatus3 : MonoBehaviour {
    public Sprite hoverMt;
    public Sprite normalMt;

    // Use this for initialization
    void Start()
    {
        Button btn = this.GetComponent<Button>();
        UIEventListener btnListener = btn.gameObject.AddComponent<UIEventListener>();

        btnListener.OnMouseEnter += delegate (GameObject gb) {

            Debug.Log("in");
            gb.GetComponent<Image>().sprite = hoverMt;
            
        };

        btnListener.OnMouseExit += delegate (GameObject gb) {
            Debug.Log("out");
            gb.GetComponent<Image>().sprite = normalMt;
            
        };

       
    }
}
