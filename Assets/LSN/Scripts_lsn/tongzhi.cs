using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class tongzhi : MonoBehaviour {
    public GUISkin t;
    public GUIStyle la_1;
    public GUIStyle la_2;
    public GUIStyle Img_1;
    private Rect windowrect;
    public string content, title;
    public Texture line;
    // Use this for initialization
    void Start () {
        la_1.padding.top = 10;
        la_1.padding.left = 20;
        windowrect = new Rect(1250, 280, 280,400 );
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void myWindow(int windowID)

    {
        GUILayout.BeginArea(new Rect(0, 0, 280, 30));
        //GUILayout.Button("things", bu_1);
        GUILayout.Label(title,la_1);
        
        GUILayout.EndArea();

        GUILayout.BeginArea(new Rect(30, 70, 250, 80));
        //GUILayout.Button("things", bu_1);
        GUILayout.Label(line, Img_1);

        GUILayout.EndArea();

        GUILayout.BeginArea(new Rect(20, 50, 240, 200));
        //GUILayout.Button("things", bu_1);
        GUILayout.Label(content, la_2);

        GUILayout.EndArea();
        
    }
    void OnGUI()
    {
        GUI.skin = t;
        GUI.Window(0, windowrect, myWindow, "");

    }
    public void setcontent(string c)
    {
        content = c;
    }
    public void settitle(string t)
    {
        title = t;
    }
}
