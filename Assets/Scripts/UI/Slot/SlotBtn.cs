using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider2D))]
public class SlotBtn : MonoBehaviour {

 
   	void OnMouseDown()
    {
        if (GetComponentInParent<Slot>()!=null) {
            Slot s = GetComponentInParent<Slot>();
            s.toggleUI();
        }
    }

    void Start() {
        
    }
}
