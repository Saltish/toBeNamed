using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    //单例模式
    public static WorldManager WM;
    
    private Light light;
    private Color _color1=new Color(1f, 0.56f, 0.53f);
    private Color _color2=new Color(0.67f, 0.69f, 1f);

    public MeshRenderer[] block1MR;
    public MeshRenderer[] block2MR;
    private MeshRenderer treasureMR;

    
    private bool realWorldOn=true;

        // Start is called before the first frame update
    void Start()
    {
        WM = this;
        light = FindObjectOfType<Light>();//现在先找全场唯一的光组件，这个之后改光照了的话要改的
        light.color = _color1;
        
        treasureMR = GameObject.FindGameObjectWithTag("Treasure").GetComponentInChildren<MeshRenderer>();
        
        foreach (var sr in block1MR)
            sr.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            SwitchWorld();

    }

    public void SwitchTreasure(bool typeFlag)
    {
        treasureMR.enabled = typeFlag == realWorldOn;//与当前世界一致则可显示
    }

    public void SwitchWorld()
    {
        realWorldOn = !realWorldOn;
        
        light.color = realWorldOn ? _color1 : _color2;

        treasureMR.enabled = !treasureMR.enabled;
            
        foreach (var mr in block1MR)
        {
            mr.enabled = !realWorldOn;
            //主人公不会与layer15相碰
            mr.gameObject.layer = realWorldOn ? 15 : 0; //我默认sr和碰撞体在一个物体下咯
        }
        foreach (var mr in block2MR)
        {
            mr.enabled = realWorldOn;
            mr.gameObject.layer = realWorldOn ? 0 : 15;
        }
    }
    
}
