using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boot : MonoBehaviour
{
    void Update()
    {
        if (Input.anyKeyDown) {
            LoadSceneAsync.Load("MainMenu", null);
        }

        LoadSceneAsync.UpdateManual();
    }
}
