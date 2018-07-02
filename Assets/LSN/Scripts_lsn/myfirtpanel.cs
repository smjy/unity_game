using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class myfirtpanel : MonoBehaviour {

    public int max_item = 30;
    public List<item> items;

    public Event button;
    private Rect windowrect;
    public Image line;
    public GUIStyle bu_1;
    public GUIStyle la_1;
    public int width1=800, height1,width2,height2;
    public GUIStyle la_2,la_3;
    int CLICKED = 0;
    //private Texture clicked=null;
    //public GUISkin t;
    List<GameObject> buttons;
    List<int> weapons_num,clothes_num;
    public int All_weapons = 10;
    public int All_clothes = 5;
    public List<Texture> WEAPON;
    public GUIStyle w_1;
    public GUIStyle w_2;
    private int window_clicked = 0;
    //int changebuttons_id = 0;
    public int items_inline = 5;
    public bool show = false;
    List<bool> WhichWeapon;

    void Start () {
        windowrect = new Rect(100, 100, 500,50);
        //initial();
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    public void addItem(item i)
    {
        //满了
        //弹出背包满了 社么也不做 return;
        //判断可堆叠
        //如果可以
        //操作某一个itemBlock
        //itemBLock.loadImage (item.image)
    }

    public void useItem(item i)
    {
        //i.use();
    }
    public void deleteItem(item i)
    {

    }
    public void setWeaponsNum(int index,int num)
    {
        weapons_num[index - 1] = num;
    }
    public void setClothesNum(int index, int num)
    {
        clothes_num[index - 1] = num;
    }
    void myWindow(int windowID)

    {
        /*GUILayout.BeginArea(new Rect(0,0,500, 350));
        //GUILayout.Button("things", bu_1);
        GUILayout.Label("BEAM LAYSER",la_1);
        GUILayout.Label("BUY&SWAP COST", la_2);
        GUILayout.EndArea();*/
        GUILayout.BeginArea(new Rect(0, 0, 150, 50));
     
        GUILayout.BeginHorizontal("changebuttons");
      if( GUILayout.Button("clothes", bu_1, GUILayout.Width(75), GUILayout.Height(20)))
        {
            window_clicked = 1;
        }
        if(GUILayout.Button("weapons", bu_1,GUILayout.Width(75), GUILayout.Height(20)))
        {
            window_clicked = 0;
        }
        GUILayout.EndHorizontal();
        GUILayout.EndArea();
        //GUI.Window(0, new Rect(100, 200, 500, 250),changebutton,"",w_2)
       /* GUILayout.BeginArea(new Rect(0, 30, 500, 350),w_2);

        int line = 0;
        if (All_weapons % items_inline == 0)
        {
            line = All_weapons / items_inline;
        }
        else
        {
            line = (All_weapons / items_inline) + 1;
           
        }
   
        for (int i = 0; i < line; i++)
        {
            
            GUILayout.BeginArea(new Rect(20, 70 + i * 50, 500, 250 + i * 50));
            GUILayout.BeginHorizontal("line"+ i);
           for (int j = 0; j < items_inline&&j+(i*items_inline)<weapons_num; j++)
            {
                GUILayout.Label(WEAPON[i * items_inline + j], la_1, GUILayout.Width(50), GUILayout.Height(50));
            }
            GUILayout.EndHorizontal();
            GUILayout.EndArea();
        }
        GUILayout.EndArea();*/



    }
    void changebutton(int changebuttons_id)
    {
       
        GUILayout.BeginArea(new Rect(0, 0, 500, 250));

        int line = 0;
        if (All_weapons % items_inline == 0)
        {
            line = All_weapons / items_inline;
        }
        else
        {
            line = (All_weapons / items_inline) + 1;

        }

        for (int i = 0; i < line; i++)
        {

            GUILayout.BeginArea(new Rect(20, 10 + i * 40, 700, 250+i*40));
            GUILayout.BeginHorizontal("line" + i);
            for (int j = 0; j < items_inline && j + (i * items_inline) < All_weapons; j++)
            {
                if (GUILayout.Button(WEAPON[i * items_inline + j], la_1, GUILayout.Width(40), GUILayout.Height(40)))
                {
                    Debug.Log("iji");

                    /* GUILayout.BeginArea(new Rect(400, 10, 280, 280));
                     GUILayout.Label(WEAPON[i * items_inline + j], GUILayout.Width(50), GUILayout.Height(50));
                     GUILayout.EndArea();*/
                    CLICKED = i * items_inline + j;
                }

            }
            GUILayout.EndHorizontal();
            GUILayout.EndArea();
        }
        GUILayout.EndArea();

        GUILayout.BeginArea(new Rect(400, 100, 280, 280));
        GUILayout.Label(WEAPON[CLICKED], la_3,GUILayout.Width(200), GUILayout.Height(200));
        GUILayout.EndArea();

    }

    void clothes_window(int clothes_winodw)
    {
        
    }
    public void getweapons(List<Texture> w)
    {
        WEAPON = w;
    }
    public void setshow()
    {
        show = !show;
    }
    void OnGUI()
    {
        //GUI.skin = t;
    if(show)
        {
            GUI.Window(0, windowrect, myWindow, "", w_1);
            GUI.Window(1, new Rect(100, 130, width1, 450), changebutton, "", w_2);
          
            switch (window_clicked)
            {
                case 0:
                    GUI.Window(1, new Rect(100, 130, 800, 450), changebutton, "", w_2);
                    break;
                case 1:
                    width1 = 0;
                    GUI.Window(2, new Rect(100, 130, 800, 450), clothes_window, "", w_2);
                    break;
            }
     
        }


    }
}
