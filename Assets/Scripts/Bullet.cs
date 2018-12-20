using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Force;

    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * Force, ForceMode.VelocityChange);
    }
}
