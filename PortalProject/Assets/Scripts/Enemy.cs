using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    
    //本脚本暂时没用
    public GameObject fire;

    public GameObject fp;
    
    public GameObject player;
    public float interval;
    public float speed;

    NavMeshAgent mr;
    // Start is called before the first frame update
    void Start()
    {

        InvokeRepeating("Shoot",0,interval);
        mr = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //mr.destination = player.transform.position;
    }

    void Shoot()
    {
        
        Rigidbody clone = Instantiate(fire,fp.transform.position,fp.transform.rotation).GetComponent<Rigidbody>();
        //clone.velocity = transform.TransformDirection(this.gameObject.transform.forward*speed);
        clone.velocity = this.gameObject.transform.forward * speed;
    }
}
