using UnityEngine.SceneManagement;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

// A universal class that holds methods to transition between scenes. Will hold data that'll also need to be passed between scenes too.
public class ButtonUtilites : MonoBehaviour
{
    /* Methods */

    // Loads the menu scene.
    public static void GoToMenu() => SceneManager.LoadScene(0);

    // Loads the game scene.
    public static void GoToGame()
    {
        ScoreManager.ScoreManagerInstance.SetCurrentName();
        SceneManager.LoadScene(1);
    }

    // Quits the application in a build version, and exits play mode in the editor.
    public static void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Exit();
#endif
    }
}
