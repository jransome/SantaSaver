using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
  public float SpawnInterval = 1f;
  public float SpawnRadius = 20f;
  public float SuperChanceIncrement = 1f;
  public GameObject ZombiePrefab;
  public Transform Santa;

  public float SuperChance { get; set; } = 5f;

  void Start()
  {
    StartCoroutine(Spawn());
  }

  Vector3 GetRandomPointOnUnitCircle()
  {
    float randomAngle = Random.Range(0f, Mathf.PI * 2f);
    return new Vector3(Mathf.Sin(randomAngle), 0f, Mathf.Cos(randomAngle));
  }

  IEnumerator Spawn()
  {
    while (true)
    {
      Zombie z = Instantiate(ZombiePrefab, transform.position + GetRandomPointOnUnitCircle() * SpawnRadius, Quaternion.identity).GetComponent<Zombie>();
      z.Santa = Santa;
      if (Random.Range(0f, 100f) < SuperChance) z.IsSuper = true;
      SuperChance += SuperChanceIncrement;
      yield return new WaitForSeconds(SpawnInterval);
    }
  }
}
