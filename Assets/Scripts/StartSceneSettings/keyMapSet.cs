using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class keyMapSet : MonoBehaviour
{

    public ToggleGroup keyGroup;
    Toggle toggle = null;
   

    void Start()
    {
        foreach (KeyValuePair<string, KeyCode> kvp in KeySetManager.getKeySetting())
        {
            GameObject text = GameObject.Find(kvp.Key+"Text");
            text.GetComponent<Text>().text = kvp.Value.ToString();
        }

    }
    void Update()
    {
        toggle = GetActive();      
    }

    //获取当前选中按钮
    public Toggle GetActive()
    {
        IEnumerator<Toggle> toggleEnum = keyGroup.ActiveToggles().GetEnumerator();
        toggleEnum.MoveNext();
        Toggle toggle = toggleEnum.Current;
        return toggle;
    }

    



    void OnGUI()
    {
        if (toggle!=null) //当前已经选中按钮
        {
            string FunctionNow = toggle.name.ToString();
            if (Input.anyKeyDown)
            {
                Event e = Event.current;
                if (e.isKey && e.keyCode != KeyCode.None)
                {                  
                    GameObject btnText = GameObject.Find(FunctionNow+"Text");
                    if (!KeySetManager.isUsed(e.keyCode)) //当前按键未使用
                    {
                        KeySetManager.setKey(FunctionNow, e.keyCode);

                        btnText.GetComponent<Text>().text = e.keyCode.ToString();
                    }
                    else //冲突
                    {
                        //hintWindow.SetActive(true);
                        //GameObject hintText = GameObject.Find("HintText");
                        string ConflictFunction = KeySetManager.getConflictKey(e.keyCode);
                        Debug.Log(ConflictFunction);
                        GameObject ConflictBtnText = GameObject.Find(ConflictFunction+"Text");
                        // hintText.GetComponent<Text>().text = "与功能" + ConflictFunction + "冲突，是否继续？";
                        KeySetManager.setKey(ConflictFunction, KeyCode.None);
                        ConflictBtnText.GetComponent<Text>().text = "未设置";
                        KeySetManager.setKey(FunctionNow, e.keyCode);
                        btnText.GetComponent<Text>().text = e.keyCode.ToString();

                    }


                }
            }
        }

    }
}

   
 

