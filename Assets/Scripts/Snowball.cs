using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowball : MonoBehaviour
{
    public float force = 1f;
    
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 horizontalForce = Vector3.left * -Input.GetAxis("Horizontal");
        Vector3 verticalForce = Vector3.forward * Input.GetAxis("Vertical");

        Vector3 forceVector = horizontalForce + verticalForce;
        rb.AddForce(forceVector, ForceMode.VelocityChange);
    }
}
