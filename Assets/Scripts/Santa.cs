using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Santa : MonoBehaviour
{
  public GameObject DeathExplosion;
  public GameObject SantaModel;

  public bool isAlive { get; set; } = true;

  void Update()
  {
    if (isAlive)
    {
      transform.Rotate(new Vector3(0, 1f, 0));
    }
  }

  void OnCollisionEnter(Collision other)
  {
    if (other.collider.CompareTag("zombie"))
    {
      SantaModel.SetActive(false);
      isAlive = false;
      DeathExplosion.SetActive(true);

      GameObject[] Zombies = GameObject.FindGameObjectsWithTag("zombie");
      foreach (var Zombie in Zombies)
      {
        Zombie.GetComponent<Zombie>().IsAlive = false;
        Zombie.GetComponent<Rigidbody>().AddExplosionForce(200f, transform.position, 200f, 2f, ForceMode.Impulse);
      }
    }

    if (other.collider.CompareTag("bullet"))
    {

    }
  }
}
