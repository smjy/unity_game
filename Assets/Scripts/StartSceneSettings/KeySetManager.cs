using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;//绑定按键与功能

public static class KeySetManager {

    static Dictionary<string, KeyCode> keySetting;
    static string[] functionMaps = GameSetting.main.functions;

    static KeyCode[] defaults = GameSetting.main.keySetDefaults;

    // static KeySetManager()
    // {
    //     InitializeDictionary();
    // }

    public static void InitializeDictionary()
    {

        keySetting = new Dictionary<string, KeyCode>();
        Debug.Log("init Keysetmanager");
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
