using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public Vector3 moveLerp;
    public float time;
    Vector3 fromLocation;
    Vector3 toLocation;
    public ParticleSystem explosion;
    public void Destroy(){
        Instantiate(explosion.gameObject, gameObject.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

    void Awake(){
        fromLocation = gameObject.transform.position - moveLerp;
        toLocation = gameObject.transform.position + moveLerp;
    }
    void Update(){
        gameObject.transform.position = Vector3.Lerp(fromLocation, toLocation, Mathf.Sin(Time.time * time));
    }
}
