using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // public bool GameIsPaused = true;
    public Text InstructionText;

    void Start() {
        Time.timeScale = 0f;    
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = Time.timeScale == 0f ? 1f : 0;
            InstructionText.enabled = !InstructionText.enabled;
        }
    }
}
