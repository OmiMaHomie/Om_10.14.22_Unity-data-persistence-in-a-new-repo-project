using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIManager : MonoBehaviour
{
    // Properties
    public static TMP_Text HighScoreText; // The HighScoreText's textfield. Is universal.
    TMP_InputField NameInputField; // The InputNameField InputField gameObject.


    // Methods

    // Is run the first time the script's loaded.
    void Start()
    {
        ScoreManager.Instance.GetHighScoreData();
        SetScore();
    }

    // Runs whenever the script is loaded.
    void Awake()
    {
        // Property initalizaiton.
        HighScoreText = GameObject.Find("HighScoreText").GetComponent<TMP_Text>();
        NameInputField = GameObject.Find("InputNameField").GetComponent<TMP_InputField>();

        SetScore();
    }

    // Sets HighScoreText to be high score info.
    public static void SetScore() => ScoreManager.Instance.GetHighScore(HighScoreText);

    // Sets CurrentName & loads into the main scene.
    public void PlayGame() => SceneManager.LoadScene(1);

    // Going to be NameInputField's On Value Changed method. Will set ScoreManager.Instance.CurrentName to NameInputField whenever the value is changed.
    public void SetCurrentName() => ScoreManager.Instance.CurrentName = NameInputField.text;

    // Quits the application.
    public void QuitApplication()
    {
        ScoreManager.Instance.SetHighScoreData();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
