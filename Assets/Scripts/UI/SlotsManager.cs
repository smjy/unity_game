using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotsManager : MonoBehaviour {

    public static SlotsManager main;

    public RectTransform slot_parent;

    public IntPropertySlot slot_int_property;
    public FloatPropertySlot slot_float_property;
    public StringPropertySlot slot_string_property;
    public MethodSlot slot_method;

    public IntPropertySlot code_blocks;
    
    private List<PropertySlot> PropertySlots = new List<PropertySlot>();
    private List<MethodSlot> MethodSlots = new List<MethodSlot>();
    
   	private void Awake() {
        if (main == null)
            main = this;
        else if (main != this)
            Destroy(gameObject);  
        
        code_blocks.slotname = "codeBlock";
        code_blocks.value = PlayerStat.main.code_blocks;

        createIntPropertySlot("UserProperty",10);
        createMethodSlot("UserMethod");
        setUISlots();
    }

    void addSlot(MethodSlot s) {
        Debug.Log("add1");
        MethodSlots.Add(s);
        setUISlots();
    }
    void addSlot(PropertySlot s) {
        Debug.Log("add2");
        PropertySlots.Add(s);
        setUISlots();
    }
    void addPropertySlot(PropertySlot s) {
        Debug.Log("add2"+(s == null));

        PropertySlots.Add(s);
        setUISlots();
    }
    public MethodSlot createMethodSlot(string name) {
        MethodSlot ms = Instantiate(slot_method,slot_parent);
        ms.slotname = name;
        addSlot(ms);
        return ms;
    }
    public IntPropertySlot createIntPropertySlot(string name,int value) {
        IntPropertySlot ips = Instantiate(slot_int_property,slot_parent);
        ips.slotname = name;
        ips.value = value;
        addPropertySlot(ips as PropertySlot);
        return ips;
    }
    public FloatPropertySlot createFloatPropertySlot(string name,float value) {
        FloatPropertySlot ips = Instantiate(slot_float_property,slot_parent);
        ips.slotname = name;
        ips.value = value;
        addPropertySlot(ips as PropertySlot);
        return ips;
    }
    public StringPropertySlot createStringPropertySlot(string name,string value) {
        StringPropertySlot ips = Instantiate(slot_string_property,slot_parent);
        ips.slotname = name;
        ips.value = value;
        addPropertySlot(ips as PropertySlot);
        return ips;
    }
    public string getPropertyToString(string name) {
        foreach (PropertySlot ps in PropertySlots) {
            if (ps.slotname == "name") {
                if (ps is IntPropertySlot) {
                    return (ps as IntPropertySlot).value.ToString();
                }
                else if (ps is IntPropertySlot) {
                    return (ps as IntPropertySlot).value.ToString();
                }
                else if (ps is FloatPropertySlot) {
                    return (ps as FloatPropertySlot).value.ToString();
                }
            }
        }
        return "";
    }

    public void updateCodeBlock() {
        code_blocks.value = PlayerStat.main.code_blocks;
        code_blocks.updateValue();
    }

    public int getIntProperty(string name) {
        foreach (PropertySlot ps in PropertySlots) {
            if (ps.slotname == "name" && ps is IntPropertySlot) {
                return (ps as IntPropertySlot).value;
            }
        }
        return -1;
    }
    public float getFloatProperty(string name) {
        foreach (PropertySlot ps in PropertySlots) {
            if (ps.slotname == "name" && ps is FloatPropertySlot) {
                return (ps as FloatPropertySlot).value;
            }
        }
        return -1f;
    }
    public string getStringProperty(string name) {
        foreach (PropertySlot ps in PropertySlots) {
            if (ps.slotname == "name" && ps is StringPropertySlot) {
                return (ps as StringPropertySlot).value;
            }
        }
        return "";
    }


    void setUISlots() {
        int start = 0;
        //系统Slots
        setUISlot(code_blocks,start);
        start++;

        //PropertySlots
        foreach (PropertySlot ps in PropertySlots) {
            setUISlot(ps,start);
            start++;
        }

        //MethodSlots
        foreach (MethodSlot ps in MethodSlots) {
            setUISlot(ps,start);
            start++;
        }
    }
    void setUISlot(Slot s,int i) {
        float y = -30f*i;
        Vector2 v = new Vector2(0f,y);
        s.gameObject.GetComponent<RectTransform>().anchoredPosition = v;
    }
}
