using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClicks : MonoBehaviour {
    public GameObject setWindow;

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
}
