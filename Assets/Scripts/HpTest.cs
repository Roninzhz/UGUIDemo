using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 血量扣减：通过鼠标左键实现血量扣减
/// 扣减公式：当前血量 / 最大血量 * 血条的长度（最大值）
/// </summary>
public class HpTest : MonoBehaviour {

	//最大血量
	public float maxHP=100;
	//当前血量
	private float currentHP;

	//声明一块空间是Slider类型
	Slider slider;
	// Use this for initialization
	void Start () {

		//设置当前血量
		currentHP = maxHP;

		//当前挂载脚本身上的物体找组件
		//GetComponent

		//当前挂载脚本物体身上往下找组件
		//获取血条
		slider=GetComponentInChildren<Slider>();

		//打印一下，确认是否获取组件
		//print(slider.direction);

		//获取鼠标   0左键   2中间  3右键
		Input.GetMouseButtonDown(0);
	}
	
	// Update is called once per frame
	void Update () {

		//鼠标左键单击血条递减
        if (Input.GetMouseButtonDown(0))
        {
			currentHP -= 20;
			slider.value = currentHP / maxHP * slider.maxValue;
		}

		//
		if (Input.GetMouseButtonDown(1))
		{
			transform.Rotate(0, 1, 0);
		}

		if (Input.GetMouseButtonUp(2))
		{
			print("你能抬起滚轮");
		}
	}
}
