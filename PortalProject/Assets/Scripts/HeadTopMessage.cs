using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeadTopMessage : MonoBehaviour
{
    //此脚本用于使某一UI图片跟随场景内某一物体
    //此脚本应该挂在画布下的含Image组件的对象上

    public Transform targetTrans;//本UI跟随哪个物体
    public Vector3 UIoffset;//本UI相对于该物体的偏置
    private Image _image;
    public Sprite[] localSprite;

    private void Start()
    {
        _image = GetComponent<Image>();
    }

    private void Update()
    {
        transform.position = Camera.main.WorldToScreenPoint(targetTrans.position) + UIoffset;
    }

    public void SetImage(bool on, int num=0)
    {
        if (!on)
        {
            _image.enabled = false;
            return;
        }

        _image.enabled = true;
        _image.sprite = localSprite[num];
    }
    
}
