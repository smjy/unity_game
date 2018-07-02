using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Slot : MonoBehaviour {

    Animator anim;
    protected string _slotname = "";
    public string slotname {
        get {
            return _slotname;
        }
        set {
            _slotname = value;
        }
    }
   	protected virtual void Awake() {
        anim = GetComponent<Animator>();
    }


    public void toggleUI() {
        if (anim.GetBool("close")) {
            anim.SetBool("close",false);
        }else {
            anim.SetBool("close",true);
        }
    }
}
