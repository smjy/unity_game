using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TestUiEvent : MonoBehaviour
{
    public Material hoverMt;
    public Material normalMt;


    // Use this for initialization
    void Start()
    {
        Button btn = this.GetComponent<Button>();
        UIEventListener btnListener = btn.gameObject.AddComponent<UIEventListener>();

        btnListener.OnMouseEnter += delegate (GameObject gb) {
            Debug.Log(gb.name + " OnMouseEnter");
            gb.GetComponent<Image>().material = hoverMt;
        };

        btnListener.OnMouseExit += delegate (GameObject gb) {
            Debug.Log(gb.name + " OnMOuseExit");
            gb.GetComponent<Image>().material = normalMt;
        };

    }

    // Update is called once per frame
    void Update()
    {

    }
}
