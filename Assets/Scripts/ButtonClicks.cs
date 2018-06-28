using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClicks : MonoBehaviour {
    public GameObject setWindow;
    public GameObject audioSet;
    public GameObject keySet;
    public GameObject windowSet;
    public GameObject gameSet;
    public Animator anim;
 

	public void on_setButton_click()
    {
        Debug.Log("设置按钮点击");
        anim.Play("SWOpen");
        setWindow.SetActive(true);

    }
    public void on_quitButton_click()
    {
        Debug.Log("关闭窗口");
        setWindow.SetActive(false);

    }


    public void on_audioSet_Active()
    {
        audioSet.SetActive(true);
        keySet.SetActive(false);
        windowSet.SetActive(false);
        gameSet.SetActive(false);
    }
    public void on_keySet_Active()
    {
        audioSet.SetActive(false);
        keySet.SetActive(true);
        windowSet.SetActive(false);
        gameSet.SetActive(false);
    }
    public void on_interfaceSet_Active()
    {
        audioSet.SetActive(false);
        keySet.SetActive(false);
        windowSet.SetActive(true);
        gameSet.SetActive(false);
    }
    public void on_gameSet_Active()
    {
        audioSet.SetActive(false);
        keySet.SetActive(false);
        windowSet.SetActive(false);
        gameSet.SetActive(true);
    }
}
