using System.IO;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    // Properties

    public static ScoreManager Instance { get; set; } // Universal ScoreManager instance field.

    string CurrentNameField = "UNNAMED"; // Current user's name field.
    public string CurrentName // Current user's name property.
    {
        get { return CurrentNameField; } // Returns CurrentNameField if called.
        set
        {
            if (string.IsNullOrEmpty(value.Trim())) // If value is empty, set CurrentNameField as "UNNAMED".
                CurrentNameField = "UNNAMED";
            else // Else, set CurrentNameField as value.
                CurrentNameField = value;
        }
    }

    string HighScoreName { get; set; } = "UNNAMED"; // Highscore user's name field.
    int HighScoreScore { get; set; } = 0; // Highscore user's score field.


    // Methods

    // Runs whenever the script is loaded.
    void Awake()
    {
        // If Instance isn't initalized, set it to be the ScoreManager gameObject, and set this ScoreManager gameObject to be saved between scene transitions.
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        // Else, destroy the duplicate ScoreManager instance.
        else
            Destroy(gameObject);
    }

    // Returns HighScoreName & HighScoreScore as a string.
    public string GetHighScore(TMP_Text textfield) => textfield.text = $"Best Score: {HighScoreName}, {HighScoreScore}";

    // Checks to see if the current user's score is higher than the high score's score. Updates the properties if so.
    public bool CheckForNewHighScore(int currentScore)
    {
        if (currentScore > HighScoreScore)
        {
            HighScoreName = CurrentNameField;
            HighScoreScore = currentScore;
            return true;
        }
        else return false;
    }

    //
    // This section will contain methods relating to having data persistence between game sessions (so JSON file writing/reading).
    //

    // A protected HighScoreData class, which'll be used to write/read data of the HighScoreName & HighScoreScore into/from JSON files.
    [System.Serializable]
    public class HighScoreData
    {
        //Properties

        public string HighScoreName;
        public int HighScoreScore;
    }

    // Will save data into a JSON file, and put it into the system.
    public void SetHighScoreData()
    {
        Debug.Log($"HighScoreName: {HighScoreName} HighScoreScore: {HighScoreScore}");

        HighScoreData data = new HighScoreData();
        data.HighScoreName = HighScoreName;
        data.HighScoreScore = HighScoreScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/highScoreData.json", json);

        Debug.Log($"Data saved!\n Saved HighScoreName: {data.HighScoreName}\n Saved HighScoreScore: {data.HighScoreScore}");
        Debug.Log(json);
        Debug.Log($"{Application.persistentDataPath}/highScoreData.json");
    }

    // Will get data from JSON file, and put it into the ScoreManager's fields.
    public void GetHighScoreData()
    {
        string path = Application.persistentDataPath + "/highScoreData.json"; // Gets the string literal of the path the JSON file should be at.

        if (File.Exists(path)) // If path contains a file, run the following.
        {
            // Turns the JSON file into a string, and then converts the string to a HighScoreData class.
            string json = File.ReadAllText(path);
            HighScoreData data = JsonUtility.FromJson<HighScoreData>(json);

            // Sets HighScorename and HighScoreScore to data's values.
            HighScoreName = data.HighScoreName;
            HighScoreScore = data.HighScoreScore;
        }
    }
}
