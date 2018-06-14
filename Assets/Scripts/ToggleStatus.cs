using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleStatus : MonoBehaviour {

    public Sprite hoverMt;
    public Sprite normalMt;
    void Start()
    {
        Toggle btn = this.GetComponent<Toggle>();
        UIEventListener btnListener = btn.gameObject.AddComponent<UIEventListener>();

        btnListener.OnMouseEnter += delegate (GameObject gb) {

           
                Debug.Log("in");
                gb.GetComponentInChildren<Image>().sprite = hoverMt;
                gb.GetComponentInChildren<Text>().color = Color.white;
                       
        };

        btnListener.OnMouseExit += delegate (GameObject gb) {
           
                Debug.Log("out");
                gb.GetComponentInChildren<Image>().sprite = normalMt;
                Color32 color32 = new Color32(77, 50, 109, 255);
                gb.GetComponentInChildren<Text>().color = color32;
           
        };
       
    }

   
}
