using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject fire;

    public GameObject fp;
    public float interval;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shoot",0,interval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Shoot()
    {
        Rigidbody clone = Instantiate(fire,fp.transform.position,fp.transform.rotation).GetComponent<Rigidbody>();
        clone.velocity = transform.TransformDirection(fp.transform.forward*speed);
    }
}
