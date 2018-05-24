using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class hotkey
{
    private bool use;
    private string keyName;

    public hotkey() { use = false; keyName = ""; }
    public hotkey(bool b, string name) { use = b; keyName = name; }
    public hotkey(string name) { use = false; keyName = name; }
    public void setUsed(bool b) { use = b; }
    public bool isused() { return use; }
    public string getName() { return keyName; }
    public void setName(string name) { keyName = name; }

}

public class keySet : MonoBehaviour {
  
    enum hotkeyNames{W,S,A,D,空格,鼠标左键,鼠标右键 };

    void fillkeys()
    {
        hotkey[] hotkeys = new hotkey[8];
        for(int i=0;i<hotkeys.Length;i++)
        {
            hotkeys[i].setName("");
        }
    }
    

	
}
