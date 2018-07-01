using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonStatus : MonoBehaviour {

	
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
            gb.GetComponentInChildren<Text>().color = Color.white;
        };

        btnListener.OnMouseExit += delegate (GameObject gb) {
            Debug.Log("out");
            gb.GetComponent<Image>().sprite = normalMt;
            Color32 color32 = new Color32(77, 50, 109, 255);
            gb.GetComponentInChildren<Text>().color = color32;
        };

        btnListener.OnClick += delegate (GameObject gb) {
            Debug.Log("out");
            gb.GetComponent<Image>().sprite = normalMt;
            Color32 color32 = new Color32(77, 50, 109, 255);
            gb.GetComponentInChildren<Text>().color = color32;
            gb.GetComponentInChildren<AudioSource>().Play();
        };
    }
}
