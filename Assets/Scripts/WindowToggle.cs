using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowToggle : MonoBehaviour {

    public GameObject loginObj;

    public GameObject startObj;

    public void StartButton()
    {
        //打开LoginWindow窗口
        //SetActive方法代表设置激活状态的方法
        loginObj.SetActive(true);

        //startObj.SetActive(false);
    }

    public void ReturnButton()
    {
        loginObj.SetActive(false);

        startObj.SetActive(true);

    }
}
