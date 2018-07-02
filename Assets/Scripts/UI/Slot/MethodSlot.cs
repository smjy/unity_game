using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MethodSlot : Slot {
    protected Text name_text;
    protected virtual void Start() {
        foreach(Text t in GetComponentsInChildren<Text>()) {
            if (t.gameObject.name == "Text_MethodName") {
                //Debug.Log("find name text");
                name_text = t;
            }
        }

        updateName();
    }
    public virtual void updateName() {
        name_text.text = _slotname+"()";
    }

}
