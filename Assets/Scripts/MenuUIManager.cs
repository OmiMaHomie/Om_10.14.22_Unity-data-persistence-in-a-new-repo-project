using System;
using UnityEngine;
using TMPro;

// The canvas class for the menu scene.
public class MenuUIManager : MonoBehaviour
{
    /* Properties */
    [SerializeField] TMP_Text HighScoreText; // The Best Score Text textfield. Set in editor.
    [SerializeField] TMP_InputField NameInputField; // The Input Name inputfield. Set in editor.
    string CurrentName = "UNNAMED"; // The current name of the player.


    /* Methods */

    // Runs before any Update methods are called in.
    void Start()
    {
        DisplayHighScore();
    }

    // Is ran ever frame.
    void Update()
    {
       
    }

    // Transitions to the main scene.
    public void PlayGame() => ButtonUtilites.GoToGame();

    // Quits the game (in editor mode, quit play mode).
    public void Quit() => ButtonUtilites.Quit();

    // Sets the Best Score Text to be the HighScoreName & HighScorValue (from ScoreManager script).
    public void DisplayHighScore() => HighScoreText.text = ScoreManager.ScoreManagerInstance.HighScoreToString();

    // Sets CurrentName to be what's inNameInputField
    void SetName()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter) && String.IsNullOrWhiteSpace(NameInputField.text))
            CurrentName = NameInputField.text;
    }
}
