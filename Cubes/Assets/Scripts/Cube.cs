using UnityEngine;

public class Cube : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddTorque(new Vector3(25,25,25), ForceMode.Force);
    }
}
