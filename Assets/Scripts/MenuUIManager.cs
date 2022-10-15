using System;
using UnityEngine;
using TMPro;

// The canvas class for the menu scene.
public class MenuUIManager : MonoBehaviour
{
    /* Properties */
    [SerializeField] TMP_Text HighScoreText; // The Best Score Text textfield. Set in editor.

    /* Methods */

    // Runs before any Update methods are called in.
    void Start()
    {
        DisplayHighScore();
    }

    // Transitions to the main scene.
    public void PlayGame() => ButtonUtilites.GoToGame();

    // Quits the game (in editor mode, quit play mode).
    public void Quit() => ButtonUtilites.Quit();

    // Sets the Best Score Text to be the HighScoreName & HighScorValue (from ScoreManager script).
    public void DisplayHighScore() => HighScoreText.text = ScoreManager.ScoreManagerInstance.HighScoreToString();
}
