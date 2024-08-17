using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField nameField;
    public TMP_Text bestScoreText;

    public void Start()
    {
        MainDataManager.Instance.LoadBestScore();
        bestScoreText.text = $"Best score: {MainDataManager.BestScore} by {MainDataManager.BestPlayerName}"; 
    }
    public void StartGame()
    {
        MainDataManager.PlayerName = nameField.text;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
