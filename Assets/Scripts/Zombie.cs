using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
  public float Speed = 1f;

  public Transform Santa { get; set; }
  public bool IsSuper { get; set; } = false;
  public bool IsAlive { get; set; }

  private Rigidbody rb;
  Animator animator;

  void Start()
  {
    IsAlive = true;
    rb = GetComponent<Rigidbody>();
    animator = GetComponent<Animator>();
    if (IsSuper)
    {
      animator.speed = 20;
      Speed = 3f;
    }
  }

  void Update()
  {
    if (!IsAlive)
    {
      animator.Play("fallingback");
      return;
    }

    rb.MovePosition(transform.position + (transform.forward) * Speed / 100);
    Vector3 direction = Santa.position - transform.position;
    transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
  }

  Vector3 GetSantaPosition()
  {
    return Santa == null ? Vector3.zero : Santa.position;
  }

  void OnCollisionEnter(Collision other)
  {
    if (other.collider.CompareTag("bullet"))
    {
      IsAlive = false;
    }
  }

}
