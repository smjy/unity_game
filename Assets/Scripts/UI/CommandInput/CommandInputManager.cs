using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class CommandInputManager : MonoBehaviour {

    public static CommandInputManager main;
    public Text command_text;
    private void Awake() {
        if (main == null)
            main = this;
        else if (main != this)
            Destroy(gameObject);  
    }


    public void handle(string str) {

        if (str.Trim().Length == 0) return;

        str = str.Trim();

        if (StoryChapter1.main.in_story) {
            MainPlayer_Single.me.say(str);
            StoryChapter1.main.saySomething(str);
        }
        appendLine(str);

    }

    public void appendText(string str) {
        command_text.text += str;
    }
    
    public void appendLine(string str) {
        //appendText(bold(str)+"\n");
        appendText(str+"\n");
    }

    string bold(string str) {
        return "<b>"+str+"</b>";
    }
    
}
