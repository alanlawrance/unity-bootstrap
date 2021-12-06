using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boot : MonoBehaviour
{
    void Update()
    {
        if (Input.anyKeyDown) {
            LoadSceneAsync.Load("MainMenu", SceneLoadCompleteCallback);
        }

        LoadSceneAsync.UpdateManual();
    }

    private void SceneLoadCompleteCallback(bool success)
    {
        if (success) {
            GameStateManager.BashState(GameState.MAIN_MENU);
        }
    }
}
