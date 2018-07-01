using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PictureQualitySet : MonoBehaviour {
    public Toggle level1, level2, level3;

    void Start()
    {
        int CurLevel = QualitySettings.GetQualityLevel();
        switch (CurLevel)
        {
            case 0: level1.isOn = true; GameSetting.main.pictureQuality = "Low";
                break;
            case 2: level2.isOn = true; GameSetting.main.pictureQuality = "Medium";
                break;
            case 4: level3.isOn = true; GameSetting.main.pictureQuality = "High";
                break;
            default: break;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setLow()
    {
        QualitySettings.SetQualityLevel(0, true);

        Debug.Log(QualitySettings.GetQualityLevel());
        GameSetting.main.pictureQuality = "Low";
    }
    public void setMedium()
    {
        QualitySettings.SetQualityLevel(2, true);

        Debug.Log(QualitySettings.GetQualityLevel());
        GameSetting.main.pictureQuality = "Medium";

    }
    public void setHigh()
    {
        QualitySettings.SetQualityLevel(4, true);
        GameSetting.main.pictureQuality = "High";
        Debug.Log(QualitySettings.GetQualityLevel());
    }
}
