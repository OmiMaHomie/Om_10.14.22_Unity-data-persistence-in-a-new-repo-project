using UnityEngine.SceneManagement;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class ButtonManager : MonoBehaviour
{
    /* Properties */

    [SerializeField] GameObject ButtonManagerInstance; // The ButtonManager gameObject. Set in editor.


    /* Methods */

    // Runs when the application first opens.
    void Start()
    {
        DontDestroyOnLoad(ButtonManagerInstance); // Keeps the ButtonManager gameObject in memory when scenes change in the game.
    }

    // Loads the menu scene.
    public void GoToMenu() => SceneManager.LoadScene(0);

    // Loads the game scene.
    public void GoToGame() => SceneManager.LoadScene(1);

    // Quits the application in a build version, and exits play mode in the editor.
    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Exit();
#endif
    }
}
