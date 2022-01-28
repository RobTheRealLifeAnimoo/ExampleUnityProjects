using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawn : MonoBehaviour
{
    void OnTriggerEnter(Collider other){
        if(other.tag == "Cube"){
            GameObject.Destroy(other.gameObject);
        }
    }
}
