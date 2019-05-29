using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportable : MonoBehaviour
{
    //能否进入新传送门
    private bool canMove = true;
    //离开传送门判定区的计数，1代表离开进入的门，2代表离开到达的门
    private int exitCount = 0;

    private Treasure treasure;

    private void Start()
    {
        //如果是玩家，这里会获取失败
        treasure = GetComponent<Treasure>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (canMove && other.gameObject.CompareTag("Portal"))
        {
            //获取当前与下个传送门
            PortalObject nowPortal = other.GetComponent<PortalObject>();
            Transform nowTrans = other.transform;
            Transform newTrans = nowPortal.getPartner().transform;

            canMove = false;

            //q是 旧传送门位姿 到 新传送门位姿 的旋转四元数
            Quaternion q = Quaternion.FromToRotation(nowTrans.forward, -newTrans.forward);
            
            
            if (treasure)
            {    
                //子弹的传送
                transform.position = new Vector3(newTrans.position.x, transform.position.y, newTrans.position.z);
                treasure.switchFlag();
            }
            else
            {
                //玩家的传送
                
                //以新传送门中心出发，加上新偏置，加上新传送门正方向*（传送门厚度 + 物体厚度（目前主角为1.6） + 余量
                transform.position = newTrans.position + newTrans.forward * transform.position.y * 0.5f;
            }
            //对物体朝向也进行旋转
            transform.rotation *= q;

            GetComponent<Rigidbody>().velocity = q * GetComponent<Rigidbody>().velocity;
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Portal"))
        {
            exitCount++;
            if (exitCount == 2)
            {
                Debug.Log("exiting portal");
                //离开传送门
                exitCount = 0;
                canMove = true;
                
            }
        }
    }
}
