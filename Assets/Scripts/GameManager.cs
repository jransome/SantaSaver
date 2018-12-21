using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
  public Santa Santa;
  public Text InstructionText;
  public Text GameOverText;

  void Start()
  {
    Time.timeScale = 0f;
  }

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Space))
    {
      Time.timeScale = Time.timeScale == 0f ? 1f : 0;
      InstructionText.enabled = !InstructionText.enabled;
    }

    if (Input.GetKeyDown(KeyCode.R))
    {
      ResetGame();
    }
  }

  public void EndGame()
  {
    GameOverText.enabled = true;
  }

  void ResetGame()
  {
    GameObject[] zombies = GameObject.FindGameObjectsWithTag("zombie");
    foreach (var z in zombies)
    {
      Destroy(z);
    }
    Santa.IsAlive = true;
    GameOverText.enabled = false;

  }
}
