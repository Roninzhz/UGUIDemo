using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EventTest : MonoBehaviour, IPointerClickHandler,IDragHandler,IBeginDragHandler{
	///声明一个Button类型的变量
	Button button;

	//画布矩形变换组件
	RectTransform rectParent;

	//用来存储转换后的3D坐标
	Vector3 worldPos;

	//偏移量
	Vector3 offset;
	// Use this for initialization

	/// <summary>
	/// 
	/// </summary>
	void Start () {
		//print("张贺召张臭臭臭臭臭臭臭臭臭臭臭臭臭臭子");
		//在脚本对象身上找Button组件
		button=GetComponent<Button>();
		//通过代码的方式为当前的按钮绑定一个方法
		//button.onClick.AddListener(Fun);

		//获取画布
		rectParent = transform.parent as RectTransform;
	}

  //  public void Fun()
  //  {
		//print("通过代码的方式为按钮绑定了一个方法");
  //  }

    // Update is called once per frame
    void Update () {
		
	}

	/// <summary>
	/// 按钮的测试方法
	/// </summary>
	public void ButtonTest()
    {
		SceneManager.LoadScene(0);

	}

	/// <summary>
	/// 开关的测试方法
	/// </summary>
	public void ToggleTest()
	{
		print("Toggle");
	}

	/// <summary>
	/// Slider的测试方法
	/// </summary>
	public void SliderTest()
	{
		print("Slider");
	}

	public void OnPointerClick(PointerEventData eventData)
    {
		print("臭子");
		if(eventData.clickCount==2)
        {
			print("臭子臭子");
        }
	}

	public void OnDrag(PointerEventData eventData)
    {

        //覆盖模式下的拖拽方式
        //因为当前模式下坐标系与3D坐标系重合
        //所以不需要转换
        //将鼠标位置实时赋值给ui
        //transform.position = eventData.position;

        //其他模式
        //将屏幕坐标系转换为世界坐标系在矩形视窗内
        //参数1：代表当前画布的矩形变换组件
        //    2：需要转换的2D坐标（鼠标）
        //    3：一个事件摄像机
        //	  4：将2D鼠标坐标转换为3D坐标并返回出去

        RectTransformUtility.ScreenPointToWorldPointInRectangle(rectParent, eventData.position, eventData.pressEventCamera, out worldPos);
        transform.position = worldPos-offset;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
		//将鼠标转换为3D坐标
		RectTransformUtility.ScreenPointToWorldPointInRectangle(rectParent, eventData.position, eventData.pressEventCamera, out worldPos);

		//扣减计算偏移量
		//拿点击的点-图片的中心点
		offset = worldPos - transform.position;

    }
}