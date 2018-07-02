using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class commandinfo_panel : MonoBehaviour {

    public List<CommandInfo> commands;
    public List<Button> buttons;
    public List<GameObject> COMMANDS;
    Animator anim;
    Text dispaly;
    //Transform content;
    int command_num = 0;
    public GameObject cmd;
	// Use this for initialization
	void Start () {
        commands = new List<CommandInfo>();
        buttons = new List<Button>();
        anim = GetComponent<Animator>();
        COMMANDS = new List<GameObject>();
        //content = transform.Find("ScrollView").Find("Viewport").Find("Content").GetComponent<Transform>();
        dispaly = transform.Find("Text_descripiton").GetComponent<Text>();
        dispaly.text = "";
        findchild();//23
       //Instantiate(cmd, content);
        
	}
    void findchild()
    {
       
        for(int i=0;i<10;i++)
        {
            COMMANDS.Add(GameObject.Find("command" + i));
          
            buttons.Add(COMMANDS[i].GetComponent<Button>());
            commands.Add(COMMANDS[i].GetComponent<CommandInfo>());
            commands[i].initial();////35
           
           
           /* COMMANDS[i].GetComponent<Button>().onClick.AddListener(delegate ()
            {
                this.OnClick(commands[command_num]);
            });*/
            command_num++;
        }
    }
    //45
  // Update is called once per frame
	void Update () {
		
	}
    public void close()
    {
        Debug.Log("close");
        anim.SetBool("isout", true);
    }
    public void  OnClick(CommandInfo btn)
    {
        Debug.Log("clicked");
        //CommandInfo temp_commands = btn.GetComponent<CommandInfo>();
        // Text temp_btn = btn.GetComponent<Transform>().Find("Text").GetComponent<Text>();
        dispaly.text = btn.command_info;
    }
    public void add_command(GameObject cmd)
    {
        COMMANDS.Add(cmd);
        buttons.Add(cmd.GetComponent<Button>());
        commands.Add(cmd.GetComponent<CommandInfo>());
        /*buttons[command_num].onClick.AddListener(delegate ()
        {
            this.OnClick(commands[command_num]);
        });*/
        command_num++;
    }
}
