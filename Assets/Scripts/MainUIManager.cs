using UnityEngine;
using TMPro;

public class MainUIManager : MonoBehaviour
{
    // Properties
    public static TMP_Text ScoreText; // The ScoreText textfield. Is universal.


    // Methods

    // Is run whenever the script is loaded.
    void Awake()
    {
        // Property initalization.
        ScoreText = GameObject.Find("HighScoreText").GetComponent<TMP_Text>();
        SetScore();
    }

    // Sets the ScoreText to the high score info.
    public static void SetScore() => ScoreManager.Instance.GetHighScore(ScoreText);

}
