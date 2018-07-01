using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntPropertySlot : PropertySlot {
    public int value;

    public override void updateValue() {
        value_text.text = value.ToString();
    }
}
