using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class CommandOutput : MonoBehaviour {

    public static CommandOutput main;
    public bool active = false;

    Animator anim;
  
    private void Awake() {
        if (main == null)
            main = this;
        else if (main != this)
            Destroy(gameObject);  

        anim = GetComponent<Animator>();
     
    }

    void Update() {
        if (CommandInput.main != null && CommandInput.main.N()) {
            return;
        }  
        if (StoryChapter1.main.lockInput) {
            return;
        } 
        if (!active)
            return;

        if (Input.GetKeyDown(KeySetManager.keySetting["Command Output"])) {
            if (anim.GetBool("open")) {
                anim.SetBool("open",false);
            } else {
                anim.SetBool("open",true);
            }
        }
    }

}
