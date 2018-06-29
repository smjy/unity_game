using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapIconHook : MonoBehaviour
{
    public GameObject icon = MinimapManager.instance.iconCircle;
    public Color color = new Color(1, 1, 1, 1);

    // Use this for initialization
    void Start()
    {

    }
    void Awake()
    {
		print(color.ToString());
        MinimapManager.instance.RegisterObj(transform, icon, color);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
