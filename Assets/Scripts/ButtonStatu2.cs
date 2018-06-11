using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonStatu2 : MonoBehaviour {
    public Sprite hoverMt;
    public Sprite normalMt;

    // Use this for initialization
    void Start()
    {
        Image btn = this.GetComponent<Image>();
        UIEventListener btnListener = btn.gameObject.AddComponent<UIEventListener>();

        btnListener.OnMouseEnter += delegate (GameObject gb) {

            Debug.Log("in");
            gb.GetComponent<Image>().sprite = hoverMt;
           
        };

        btnListener.OnClick += delegate (GameObject gb) {
            Debug.Log("click");
            gb.GetComponent<Image>().sprite = hoverMt;

        };
    }
}
