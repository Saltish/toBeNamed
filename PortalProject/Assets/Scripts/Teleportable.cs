using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportable : MonoBehaviour
{
    private bool canMove = true;
    private int exitCount = 0;

    private Treasure t;
    private Rigidbody rb;

    private void Start()
    {
        t = GetComponent<Treasure>();
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (canMove && other.gameObject.CompareTag("Portal"))
        {
            PortalObject nowPortal = other.GetComponent<PortalObject>();

            Transform nowTrans = other.transform;
            Transform newTrans = nowPortal.getPartner().transform;

            canMove = false;

            //q是 旧传送门位姿 到 新传送门位姿 的旋转四元数
            Quaternion q = Quaternion.FromToRotation(nowTrans.forward, -newTrans.forward);
            //offset是 “物体现位置 相对于 现传送门中心”的偏置经过旋转得到的“物体新位置 相对于 新传送门中心”的新偏置
            Vector3 offset = q * (transform.position - nowTrans.position);

            
            

            //对物体朝向也进行旋转
            transform.rotation *= q;

            

            if (t)
            {
                rb.velocity = q * rb.velocity;
                transform.position = newTrans.position + offset + Vector3.Normalize(rb.velocity) * transform.position.y * 0.5f;
                t.switchFlag();
            }
            else
            {
                //以新传送门中心出发，加上新偏置，加上新传送门正方向*（传送门厚度 + 物体厚度（目前主角为1.6） + 余量
                transform.position = newTrans.position + offset + newTrans.forward * transform.position.y * 0.5f;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
        if (other.gameObject.CompareTag("Portal"))
        {
            exitCount++;
            Debug.Log("exit "+exitCount);
            //TODO 当exit一个传送门（允许下次传送时）传送门外观发生变化以提示这一点
            if (exitCount == 2)
            {
                exitCount = 0;
                canMove = true;
                
            }
        }
    }
}
