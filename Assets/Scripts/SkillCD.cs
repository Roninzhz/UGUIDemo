using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
/// <summary>
/// 技能冷却实现：
/// 当点击按钮将冷却图标的值调节为1，开始进行冷却
/// 在Update中每帧进行扣减，扣减比例根据冷却时间走
/// 当前冷却时间扣减
/// 显示冷却时间文本
/// 设定当前冷却开关 以及解决需求bug
/// </summary>
public class SkillCD : MonoBehaviour {

	//冷却时间
	float skillCDTime = 3;

	//当前冷却时间
	float skillCDCurrent;

	//声明image类型的变量
	Image image;

	//设置开关
	bool isCD;

	//文本
	public Text t;
	// Use this for initialization
	void Start () {

		//获取image类型的组件
		image= GetComponent<Image>();

		//text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		//判断当前是否冷却
        if (isCD)
        {
			//每帧扣减对应冷却时间的比例
			image.fillAmount -= 1 / skillCDTime * Time.deltaTime;
			skillCDCurrent -= Time.deltaTime;
			t.text = skillCDCurrent.ToString("0.0");
			if(skillCDCurrent<=0.01)
            {
				isCD = false;
				t.text = "";
            }
		}

	}

	public void SkillButton()
    {
		//当上一次冷却结束，点击才会进行下一次冷却
        if (image.fillAmount <= 0.01)
        {
			// 冷却图标      显示
			image.fillAmount = 1;

			//每次按下重置冷却时间
			skillCDCurrent = skillCDTime;

			//开启冷却
			isCD = true;
		}
    }
}
