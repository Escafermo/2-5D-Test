using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour {

    private bool isPaused = false;
    private float originalFixedDeltaTime;

    public bool isRecording = true;

    void Start()
    {
        originalFixedDeltaTime = Time.fixedDeltaTime;
        print(originalFixedDeltaTime);

        PlayerPrefsManager.UnlockLevel(2);

        print("Is level 1 unlocked: " + PlayerPrefsManager.IsLevelUnlocked(1));
        print("Is level 2 unlocked: " + PlayerPrefsManager.IsLevelUnlocked(2));
    }

    void Update() {

        if (CrossPlatformInputManager.GetButton("Fire1"))
        {
            isRecording = false;
        }
        else
        {
            isRecording = true;
        }

        //print(isRecording);

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                UnPauseGame();
                isPaused = false;
            } else
            {
                PauseGame();
                isPaused = true;
            }
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0;
        Time.fixedDeltaTime = 0;
    }

    void UnPauseGame()
    {
        Time.timeScale = 1;
        Time.fixedDeltaTime = originalFixedDeltaTime; // This value is 0.02 (check it on Edit->Project Settings->Time->Fixed Timestep
    }

    /// <summary>
    /// If the System pauses the game, consider GameManager bool "isPaused" as true
    /// </summary>
    /// <param name="pause"></param>
    void OnApplicationPause(bool pause)
    {
        isPaused = pause;
        
    }


}
