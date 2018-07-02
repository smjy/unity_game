using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PropertySlot : Slot {
    
    protected Text name_text;
    protected Text value_text;

    protected virtual void Start() {
        foreach(Text t in GetComponentsInChildren<Text>()) {
            if (t.gameObject.name == "Text_PropertyName") {
                //Debug.Log("find name text");
                name_text = t;
            }
            if (t.gameObject.name == "Text_PropertyValue") {
                //Debug.Log("find value text");
                value_text = t;
            }
        }

        updateName();
        updateValue();
    }
    
    public virtual void updateValue() {

    }
    public virtual void updateName() {
        name_text.text = _slotname;
    }
}
