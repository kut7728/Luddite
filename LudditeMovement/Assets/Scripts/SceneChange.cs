using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public string userInput;
    public void GameScenesCtrl()
    {
        SceneManager.LoadScene(userInput);
    }
}
