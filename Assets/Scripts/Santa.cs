using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Santa : MonoBehaviour
{
  public GameObject DeathExplosion;
  public GameObject SantaModel;
  public GameManager GameManager;

  private bool isAlive = true;
  public bool IsAlive
  {
    get { return isAlive; }
    set
    {
      isAlive = value;
      SantaModel.SetActive(value);
      DeathExplosion.SetActive(!value);
      if(value == false) GameManager.EndGame();
    }
  }

  public AudioSource audio;

  void Update()
  {
    if (IsAlive)
    {
      transform.Rotate(new Vector3(0, 1f, 0));
    }
    else
    {
      if (audio.pitch > 0.3f) audio.pitch -= 0.003f;
      if (audio.pitch < 0.5f) audio.Stop();
      audio.loop = false;
    }
  }

  void OnCollisionEnter(Collision other)
  {
    if (other.collider.CompareTag("zombie"))
    {
      IsAlive = false;

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
