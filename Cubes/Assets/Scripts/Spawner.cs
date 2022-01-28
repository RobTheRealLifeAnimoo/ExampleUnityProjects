using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Collider start;
    public Collider end;
    public GameObject cube;
    public float frequency = 1;
    Vector2 size;
    float timePassed;
    // Start is called before the first frame update
    void Start()
    {
        size.x = start.bounds.size.x / 2;
        size.y = start.bounds.size.z / 2;
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        if(timePassed > frequency){
            float x = Random.Range(-size.x, size.x);
            float y = Random.Range(-size.y, size.y);
            GameObject.Instantiate(cube, new Vector3(start.transform.position.x + x, start.transform.position.y, start.transform.position.z + y), Quaternion.identity);
            timePassed = 0;
        }
    }
}
