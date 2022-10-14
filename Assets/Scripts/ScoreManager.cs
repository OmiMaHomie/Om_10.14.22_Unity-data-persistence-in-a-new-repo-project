using System.IO;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    /* Properties */

    public static ScoreManager ScoreManagerInstance; // The ScoreManager object instance. Is set in the Awake() method.
    string HighScoreName = "UNNAMED"; // Will hold data on the high score's name. 
    int HighScoreValue = 0; // Will hold data on the high score's score.


    /* Methods */

    // Runs this code whenever this script is loaded into a scene.
    private void Awake()
    {
        // If ScoreManagerInstance isn't initalized, initalize it as ScoreManager gameObject (this) and set it to be saved in memory during scene switches.
        if (ScoreManagerInstance == null)
        {
            ScoreManagerInstance = this;
            DontDestroyOnLoad(ScoreManagerInstance);
        }

        // TO-DO: MAKE SURE THAT ONLY 1 INSTANCE OF THE ScoreManager OBJECT SHOULD BE INSTANTIATED DURING THE RUNTIME>
    }

    // Returns HighScoreName & HighScoreValue as a string.
    public string HighScoreToString() => $"{HighScoreName}, {HighScoreValue}";

    // Is a protected sub-class of ScoreManager, meant to be a placeholder to write/read JSON files. Contains the HighScoreName & HighScoreValue properties as string.
    [System.Serializable]
    protected class HighScoreData
    {
        public string HighScoreName;
        public int HighScoreValue;
    }

    // Saves HighScoreName & HighScoreData into a JSON file.
    void WriteHighScoreData()
    {
        // Initalizes a new HighScoreData class, and sets the HighScoreName & HighScoreValue to the superclass's value.
        HighScoreData data = new();
        data.HighScoreName = HighScoreName;
        data.HighScoreValue = HighScoreValue;

        // Creates a json string of data, and saves it into a json file in a file.
        string jsonFile = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/highscorefile.json", jsonFile);
    }

    // Reads highscorefile.json, takes the data and applies it to HighScoreName & HighScoreValue.
    void ReadHighScoreData()
    {
        // Gets the string path for the json file.
        string jsonFilePath = Application.persistentDataPath + "/highscorefile.json";

        // If highscorefile.json exists, run the following.
        if(File.Exists(jsonFilePath))
        {
            // Convert the json code into a string, and turn the json data into C# data by putting it back into a new HighScoreData class.
            string json = File.ReadAllText(jsonFilePath);
            HighScoreData data = JsonUtility.FromJson<HighScoreData>(jsonFilePath);

            // Set data's HighScoreName & HighScoreValue to superclass's HighScoreName & HighScoreValue.
            HighScoreName = data.HighScoreName;
            HighScoreValue = data.HighScoreValue;
        }
    }
}
