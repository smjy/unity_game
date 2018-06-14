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

    //绑定按键与功能
    public static class KeySetManager
    {

        static Dictionary<string, KeyCode> keySetting;
        static string[] functionMaps = GameSetting.main.functions;

        static KeyCode[] defaults = GameSetting.main.keySetDefaults;

        static KeySetManager()
        {
            InitializeDictionary();
        }

        private static void InitializeDictionary()
        {

            keySetting = new Dictionary<string, KeyCode>();
            for (int i = 0; i < functionMaps.Length; i++)
            {
                keySetting.Add(functionMaps[i], defaults[i]);
            }

        }
        public static bool isUsed(KeyCode K)
        {
            if (keySetting.ContainsValue(K))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //获取对应功能
        public static string getConflictKey(KeyCode K)  //获取按键对应的名字
        {
            Debug.Log(Time.time);
            if (keySetting.ContainsValue(K))
            {
                //遍历map，找到对应的key
                foreach (KeyValuePair<string, KeyCode> kvp in keySetting)
                {
                    if (kvp.Value.Equals(K))
                    {
                        return kvp.Key;
                    }
                }
            }
            else
            {
                return "按键未设置";
            }
            return "发生错误";

        }
        //按键设置
        public static void setKey(string function, KeyCode K)
        {
            keySetting[function] = K;
        }

        public static bool GetKeyDown(string K)
        {
            return Input.GetKeyDown(keySetting[K]);
        }
        //获取dictionary
        public static Dictionary<string, KeyCode> getKeySetting()
        {
            return keySetting;
        }
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

   
 

