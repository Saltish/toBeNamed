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

    private MeshRenderer treasureMR;
    
    private GameObject[] block1Model;
    private GameObject[] block2Model;


    private GameObject[] block1Colld;
    private GameObject[] block2Colld;
    
    private bool realWorldOn=true;

        // Start is called before the first frame update
    void Start()
    {
        WM = this;
        light = FindObjectOfType<Light>();//现在先找全场唯一的光组件，这个之后改光照了的话要改的
        light.color = _color1;
        
        treasureMR = GameObject.FindGameObjectWithTag("Treasure").GetComponentInChildren<MeshRenderer>();

        block1Model = GameObject.FindGameObjectsWithTag("ReflectWall1");
        block2Model = GameObject.FindGameObjectsWithTag("ReflectWall2");
        block1Colld = GameObject.FindGameObjectsWithTag("Type1");
        block2Colld = GameObject.FindGameObjectsWithTag("Type2");

        foreach (var model in block1Model)
            model.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)||Input.GetKeyUp(KeyCode.R))
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
            
        foreach (var model in block1Model)
            model.SetActive(!realWorldOn);
        foreach (var model in block2Model)
            model.SetActive(realWorldOn);
        
        
        //主人公不会与layer15相碰
        foreach (var item in block1Colld)
            item.layer= realWorldOn ? 15 : 0;
        foreach (var item in block2Colld)
            item.layer= realWorldOn ? 0 : 15;
        
    }
    
}
