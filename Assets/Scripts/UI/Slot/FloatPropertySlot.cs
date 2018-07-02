using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatPropertySlot : PropertySlot {
    public float value;

    public override void updateValue() {
        value_text.text = value.ToString("#0.00");
    }
    
}
