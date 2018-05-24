using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClicks : MonoBehaviour {
    public GameObject setWindow;
    public GameObject audioSetWindow;
    public GameObject keySetWindow;
    public GameObject interfaceSetWindow;
    public GameObject gameSetWindow;

	public void on_setButton_click()
    {
        Debug.Log("设置按钮点击");
        setWindow.SetActive(true);

    }
    public void on_quitButton_click()
    {
        Debug.Log("关闭窗口");
        setWindow.SetActive(false);

    }

    public void on_keyChoose_click()
    {
        if(Input.anyKeyDown)
        {
            //keyInput.GetComponent<Text>().text = Event.current.keyCode.ToString();
        }
    }

    public void on_audioSet_click()
    {
        audioSetWindow.SetActive(true);
        keySetWindow.SetActive(false);
        interfaceSetWindow.SetActive(false);
        gameSetWindow.SetActive(false);
    }
    public void on_keySet_click()
    {
        audioSetWindow.SetActive(false);
        keySetWindow.SetActive(true);
        interfaceSetWindow.SetActive(false);
        gameSetWindow.SetActive(false);
    }
    public void on_interfaceSet_click()
    {
        audioSetWindow.SetActive(false);
        keySetWindow.SetActive(false);
        interfaceSetWindow.SetActive(true);
        gameSetWindow.SetActive(false);
    }
    public void on_gameSet_click()
    {
        audioSetWindow.SetActive(false);
        keySetWindow.SetActive(false);
        interfaceSetWindow.SetActive(false);
        gameSetWindow.SetActive(true);
    }
}
