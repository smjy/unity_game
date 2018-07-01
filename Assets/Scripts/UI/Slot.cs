using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Slot : MonoBehaviour {

    Animator anim;
   	private void Awake() {
        anim = GetComponent<Animator>();
    }

    void Start() {
        anim.Play("SlotOpen",1);
    }
}
