using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayStateManager
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
           LoadSceneAsync.Load("MainMenu", LoadMainMenuCallback);
        }        
    }

    public static void LateUpdateManual()
    {
    }

    public static void Enter(GameState prevState)
    {
    }

    public static void Exit(GameState nextState)
    {
    }

    private static void LoadMainMenuCallback(bool success)
    {
        if (success) {
            GameStateManager.SwitchToState(GameState.MAIN_MENU);
        }
    }
}
