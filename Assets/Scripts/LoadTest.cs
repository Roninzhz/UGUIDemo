using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// 加载进度条的测试脚本
/// 1、修改Slider 的Value 数值，实现进度条的加载过程
/// 2、当加载完成时跳转场景
/// 可实现文本跳转百分比
/// </summary>
public class LoadTest : MonoBehaviour {
	//声明用来接收
	Slider slider;
	public Text t;
	Text text;
	
	//组件获取
	void GetCom()
    {
		//获取Slider
		slider = GetComponent<Slider>();
		//获取text
		text = GetComponentInChildren<Text>();
	}

	//小细节 显示文本
	void LoadAppear()
    {
		text.enabled = true;
    }

	//跳转场景
	void LoadChange()
	{
		SceneManager.LoadScene(1);
	}

	//进度条进度设置和显示
	void SliderChange()
    {
		slider.value += 1;
		t.text = slider.value.ToString() + "%";
	}

	// Use this for initialization
	void Start()
	{
		//获取组件
		GetCom();
		//出现正在加载...
		//正在加载文本只需判断一次，所以放进Start方法判断
		//节省资源浪费
		Invoke("LoadAppear", 0.02f);
	}

	// Update is called once per frame
	void Update () {
		//0.02s固定刷新
		//进度条
		SliderChange();
		//跳转场景
		if (slider.value>=slider.maxValue)
        {
			text.text = "加载完毕,立即进入...";
			//延迟函数
			Invoke("LoadChange", 1f);
        }
	}
}
