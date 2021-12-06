using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Serves as the entry point into the game.  This should be the only place where a Monobehavior uses
// Awake/Start/Update
//
// This monobehavior should be added to an object in every scene except Boot, so the scene can be loaded
// to play the game.
//
public class Main : MonoBehaviour
{
    public static Main m_Instance = null;
    public GameState m_DefaultGameState;

    private void Awake()
    {
        // If Main already exists, then destroy this version as it isn't needed
        if (m_Instance) {
            gameObject.SetActive(false);
            Object.Destroy(gameObject);
        } else {
            m_Instance = this;

            GameManager.AwakeManual();
            GameStateManager.BashState(m_DefaultGameState);

            Object.DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        GameManager.StartManual();
    }

    void Update()
    {
        GameManager.UpdateManual();
    }
}
