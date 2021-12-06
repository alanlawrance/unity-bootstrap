using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boot : MonoBehaviour
{
    [Tooltip("Filename (without extension) of scene that boot will load")]
    public string m_FirstSceneName;

    private void Start()
    {
        if (string.IsNullOrEmpty(m_FirstSceneName)) {
            Debug.LogWarning("Specify the name of the first scene to load in the inspector for the Boot script");
        }
    }

    void Update()
    {
        if (Input.anyKeyDown && !string.IsNullOrEmpty(m_FirstSceneName)) {
            LoadSceneAsync.Load(m_FirstSceneName, null);
        }

        LoadSceneAsync.UpdateManual();
    }
}
