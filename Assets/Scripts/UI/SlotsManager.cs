using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotsManager : MonoBehaviour {

    public static SlotsManager main;

    public RectTransform slot_parent;
    public Slot slot_mainproperty;
    public Slot slot_property;
    public Slot slot_method;

   	private void Awake() {
        if (main == null)
            main = this;
        else if (main != this)
            Destroy(gameObject);  
    }
}
