using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    private bool typeFlag = true;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.CompareTag("Type1") && !typeFlag) || (other.CompareTag("Type2") && typeFlag))
        {
            rb.velocity = getNewVelocity(other.transform);
        }
    }

    private Vector3 getNewVelocity(Transform blockTrans)
    {
        Vector3 a = -rb.velocity;
        Vector3 f = Vector3.Normalize(blockTrans.forward);
        Vector3 b = Vector3.Dot(a, f) * f * 2 - a;
        return Vector3.Normalize(b) * 5.0f;
    }

    public void switchFlag()
    {
        typeFlag = !typeFlag;
    }
}
