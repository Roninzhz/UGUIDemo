using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Itween插件测试脚本
/// </summary>
public class ItweenTest : MonoBehaviour {

	public GameObject moneyObject;

	public Transform pos;
	// Use this for initialization
	void Start () {

		//元宝移动位置
		iTween.MoveTo(moneyObject, pos.position, 100 * Time.deltaTime);

		iTween.ColorTo(moneyObject, Color.white, 100);


	}

}
