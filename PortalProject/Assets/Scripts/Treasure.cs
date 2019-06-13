using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    public static float speed=5.0f;
    private bool typeFlag = true;
    public Rigidbody rb;
    public Material type1;
    public Material type2;
    public MeshRenderer mr;
    private Vector3 startPos;
    private Quaternion startRot;

    private void Start()
    {
        mr.material = type1;
        startPos = transform.position;
        startRot = transform.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.CompareTag("Type1") && !typeFlag) || (other.CompareTag("Type2") && typeFlag))
        {
            //撞到反弹墙
            Debug.Log("反弹");
            //位置移动到反弹墙的中心
            Vector3 pos = other.transform.position;
            transform.position = new Vector3(pos.x, transform.position.y, pos.z);
            //改变面朝的方向和速度方向
            transform.forward=GetNewForward(other.transform.forward);
            rb.velocity = speed * transform.forward;
        }
        else if (other.CompareTag("Wall"))
        {
            //撞墙
            transform.position = startPos;
            transform.rotation = startRot;
            rb.velocity = Vector3.zero;
            mr.material = type1;
            typeFlag = true;
            WorldManager.WM.SwitchTreasure(typeFlag);
        }
        else if (other.CompareTag("Destination"))
        {
            LevelSceneManager.GetInstance().finishLevel();
        }
    }

    //返回反弹后应面朝的方向
    private Vector3 GetNewForward(Vector3 boardForward)//参数为反弹墙的forward
    {
        Vector3 a = -rb.velocity;
        Vector3 f = Vector3.Normalize(boardForward);
        Vector3 b = Vector3.Dot(a, f) * 2 * f - a;
        return Vector3.Normalize(b);
    }

    public void switchType()
    {
        //改变子弹种类
        typeFlag = !typeFlag;
        
        WorldManager.WM.SwitchTreasure(typeFlag);

        mr.material = typeFlag ? type1 : type2;


    }
}
