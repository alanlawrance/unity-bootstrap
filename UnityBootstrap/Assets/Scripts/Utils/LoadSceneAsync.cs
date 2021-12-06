using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneAsync
{
    private static AsyncOperation m_AsyncOperation;
    private static Action<bool> m_Callback;

    public static void Load(string sceneName, Action<bool> callback)
    {
        if (m_AsyncOperation != null) {
            Debug.LogWarningFormat($"Trying to load '{sceneName}' while scene load in progress");
            return;
        }

        m_Callback = callback;

        m_AsyncOperation = SceneManager.LoadSceneAsync(sceneName);
        if (m_AsyncOperation == null) {
            m_Callback?.Invoke(false);
        } else {
            m_AsyncOperation.allowSceneActivation = false;
        }
    }

    public static void UpdateManual()
    {
        if (m_AsyncOperation != null) {
            if (m_AsyncOperation.isDone || m_AsyncOperation.progress >= 0.9f) {
                m_AsyncOperation.allowSceneActivation = true;
                m_AsyncOperation = null;
                m_Callback?.Invoke(true);
            }
        }        
    }
}
