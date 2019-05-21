using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
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
            GameObject.Destroy(this.gameObject);
        }else if(other.gameObject.CompareTag("Player")) {
            ResetStage();
        }else if(other.gameObject.CompareTag("Enemy")) {
            //KillEnemy(other.gameObject);
        }
    }

    private void KillEnemy(GameObject enemy) {
        //  TODO
        GameObject.Destroy(enemy);
        return;
    }

    private void ResetStage() {
        //  TODO
        return;
    }

}
