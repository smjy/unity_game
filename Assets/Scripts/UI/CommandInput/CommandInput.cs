using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class CommandInput : MonoBehaviour {

    public static CommandInput main;
    

    Animator anim;
    bool input_opened = false;
    CommandInputManager cim;
    InputField ipf;
    private void Awake() {
        if (main == null)
            main = this;
        else if (main != this)
            Destroy(gameObject);  

        anim = GetComponent<Animator>();
        ipf = GetComponentInChildren<InputField>();
    }

    public bool N() {
        return input_opened;
    }
    public bool Y() {
        return !input_opened;
    }
    void Start() {
        cim = CommandInputManager.main;
    }
    void Update() {
        if (Input.GetKeyDown(KeyCode.Return)) {
            if (!input_opened){
                input_opened = true;
                ipf.text = "";
                anim.SetBool("open",true);
                ipf.ActivateInputField();
                
            } else {
                input_opened = false;
                anim.SetBool("open",false);
                ipf.DeactivateInputField();
                string text = ipf.text;
                cim.handle(text);
                
            }
        }
    }

}
