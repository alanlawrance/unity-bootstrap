using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The purpose of the GameManger class is to control the order that systems invoke Awake/Start/Update
// In general this means Monobehaviors should not use the built-in Awake/Start/Update but instead have 
// manual versions that are invoked in a specific order from GameManager.
//
public class GameManager
{
    public static void AwakeManual()
    {
        GameStateManager.AwakeManual();
    }

    public static void StartManual()
    {
    }

    public static void UpdateManual()
    {
        GameStateManager.UpdateManual();
        LoadSceneAsync.UpdateManual();
    }

    public static void FixedUpdateManual()
    {
    }
}
