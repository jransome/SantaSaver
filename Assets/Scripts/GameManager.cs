using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
  public Santa Santa;
  public ZombieSpawner ZombieSpawner;
  public Text InstructionText;
  public Text GameOverText;
  public AudioClip[] Songs;
  
  AudioSource audio;

  void Start()
  {
    audio = GetComponent<AudioSource>();
    Time.timeScale = 0f;
    PlaySong();
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

    if(!Santa.IsAlive)
    {
      if (audio.pitch > 0.3f) audio.pitch -= 0.003f;
      if (audio.pitch < 0.5f) audio.Stop();
      audio.loop = false;
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
    ZombieSpawner.SuperChance = 5f;
    
    PlaySong();
  }

  void PlaySong()
  {
    audio.clip = Songs[Random.Range(0, Songs.Length)];
    audio.pitch = 1;
    audio.loop = true;
    audio.Play();
  }
}
