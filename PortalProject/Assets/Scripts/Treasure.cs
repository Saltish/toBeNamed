using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    public static float speed=2.0f;
    private bool typeFlag = true;
    public Rigidbody rb;
    public Material type1;
    public Material type2;
    public MeshRenderer mr;
    private Vector3 startPos;

    private void Start()
    {
        mr.material = type1;
        startPos = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.CompareTag("Type1") && !typeFlag) || (other.CompareTag("Type2") && typeFlag))
        {
            //撞到反弹墙
            Vector3 pos = other.transform.position;
            transform.position = new Vector3(pos.x, transform.position.y, pos.z);
            rb.velocity = GetNewVelocity(other.transform.forward);
        }
        else if (other.CompareTag("Wall"))
        {
            //撞墙
            transform.position = startPos;
            transform.rotation = new Quaternion();
            rb.velocity = Vector3.zero;
            mr.material = type1;
            typeFlag = true;
        }
        else if (other.CompareTag("Destination"))
        {
            Destroy(gameObject);
        }
    }

    private Vector3 GetNewVelocity(Vector3 forward)
    {
        Vector3 a = -rb.velocity;
        Vector3 f = Vector3.Normalize(forward);
        Vector3 b = Vector3.Dot(a, f) * 2 * f - a;
        return Vector3.Normalize(b) * 5.0f;
    }

    public void switchType()
    {
        //改变子弹种类
        if (typeFlag) mr.material = type2;
        else mr.material = type1;
        typeFlag = !typeFlag;
    }
}
