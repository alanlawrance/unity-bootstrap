using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuState
{
    public static void AwakeManual()
    {
    }

    public static void StartManual()
    {
    }

    public static void UpdateManual()
    {
        if (Input.anyKeyDown) {
            LoadSceneAsync.Load("Level", LoadLevelCallback);
        }        
    }

    public static void Enter(GameState prevState)
    {
    }

    public static void Exit(GameState nextState)
    {
    }

    private static void LoadLevelCallback(bool success)
    {
        if (success) {
            GameStateManager.SwitchToState(GameState.GAMEPLAY);
        }
    }
}
