using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
	INVALID,
    MAIN_MENU,
	GAMEPLAY
}

public class GameStateManager
{
	private static GameState m_PrevGameState;
	private static GameState m_GameState;
	private static GameState m_PendingGameState;

	public static void AwakeManual()
	{
		m_PendingGameState = GameState.INVALID;
		m_PrevGameState = GameState.INVALID;
		m_GameState = GameState.INVALID;
	}

    // Be very careful using BashState. It doesn't call any Enter/Exit functions.
    public static void BashState(GameState state)
    {
        m_GameState = state;
    }

	// State is actually switched next Update, so we don't have game-state changing
	// in the middle of game code.
	public static void SwitchToState(GameState state)
	{
		m_PendingGameState = state;
	}

	public static void SwitchToStateImmediate(GameState state)
	{
        m_PendingGameState = GameState.INVALID;
		ChangeState(state);
	}

	public static GameState GetState()
	{
		return m_GameState;
	}

	public static GameState GetPendingState()
	{
		return m_PendingGameState;
	}

	public static GameState GetPrevState()
	{
		return m_PrevGameState;
	}

	public static void UpdateManual()
	{
		if (m_PendingGameState != GameState.INVALID) {
			ChangeState(m_PendingGameState);
			m_PendingGameState = GameState.INVALID;
		}

		switch (m_GameState) {
            case GameState.MAIN_MENU:
                MainMenuStateManager.UpdateManual();
                break;
			case GameState.GAMEPLAY:
				GamePlayStateManager.UpdateManual();
				break;
			default:
				Debug.LogErrorFormat("Unsupported game state: {0}", m_GameState.ToString());
				break;
		}
	}

	public static void LateUpdateManual()
	{
		switch (m_GameState) {
			case GameState.MAIN_MENU:
				break;
			case GameState.GAMEPLAY:
                GamePlayStateManager.LateUpdateManual();
				break;
			default:
				Debug.LogErrorFormat("Unsupported game state: {0}", m_GameState.ToString());
				break;
		}
	}

	public static void FixedUpdateManual()
	{
		switch (m_GameState) {
			case GameState.MAIN_MENU:
				break;
			case GameState.GAMEPLAY:
				GamePlayStateManager.UpdateManual();
				break;
			default:
				Debug.LogErrorFormat("Unsupported game state: {0}", m_GameState.ToString());
				break;
		}
	}

	private static void ChangeState(GameState state)
	{
        if (m_GameState == state) {
            return;
        }

		ExitState(m_GameState, state);
		m_PrevGameState = m_GameState;
		m_GameState = state;
		EnterState(m_GameState, m_PrevGameState);
	}

	private static void EnterState(GameState newState, GameState prevState)
	{
		switch (newState) {
			case GameState.MAIN_MENU:
				MainMenuStateManager.Enter(prevState);
				break;
			case GameState.GAMEPLAY:
				GamePlayStateManager.Enter(prevState);
				break;
			default:
				Debug.LogErrorFormat("Unsupported game state: {0}", m_GameState.ToString());
				break;
		}
	}

	private static void ExitState(GameState currentState, GameState nextState)
	{
		switch (currentState) {
			case GameState.MAIN_MENU:
				MainMenuStateManager.Exit(nextState);
				break;
			case GameState.GAMEPLAY:
				GamePlayStateManager.Exit(nextState);
				break;
			default:
				Debug.LogErrorFormat("Unsupported game state: {0}", m_GameState.ToString());
				break;
		}
	}
}