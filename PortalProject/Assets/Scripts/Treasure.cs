using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    private bool typeFlag = true;
    private Rigidbody rb;
    public Material type1;
    public Material type2;
    private Renderer renderer;
    private Vector3 startPos;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        renderer = GetComponent<Renderer>();
        renderer.material = type1;
        startPos = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.CompareTag("Type1") && !typeFlag) || (other.CompareTag("Type2") && typeFlag))
        {
            Vector3 pos = other.transform.position;
            transform.position = new Vector3(pos.x, transform.position.y, pos.z);
            rb.velocity = getNewVelocity(other.transform.forward);
        }
        else if (other.CompareTag("Wall"))
        {
            transform.position = startPos;
            transform.rotation = new Quaternion();
            rb.velocity = Vector3.zero;
            renderer.material = type1;
            typeFlag = true;
        }
        else if (other.CompareTag("Destination"))
        {
            Destroy(gameObject);
        }
    }

    private Vector3 getNewVelocity(Vector3 forward)
    {
        Vector3 a = -rb.velocity;
        Vector3 f = Vector3.Normalize(forward);
        Vector3 b = Vector3.Dot(a, f) * f * 2 - a;
        return Vector3.Normalize(b) * 5.0f;
    }

    public void switchFlag()
    {
        if (typeFlag) renderer.material = type2;
        else renderer.material = type1;
        typeFlag = !typeFlag;
    }
}
