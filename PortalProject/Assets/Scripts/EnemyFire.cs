﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    
    //本脚本暂时没用
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Wall")) {
            Destroy(gameObject);
        }else if(other.gameObject.CompareTag("Player")) {
            ResetStage();
        }else if(other.gameObject.CompareTag("Enemy")) {
            //KillEnemy(other.gameObject);
        }
    }

    private void KillEnemy(GameObject enemy) {
        //  TODO
        Destroy(enemy);
    }

    private void ResetStage() {
        //  TODO
        return;
    }
    
    

}
