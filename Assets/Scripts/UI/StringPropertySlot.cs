using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringPropertySlot : PropertySlot {
    public string value;

    public override void updateValue() {
        value_text.text = value;
    }
}
