using UnityEngine;

// The canvas class for the menu scene.
public class MenuUIManager : MonoBehaviour
{
    /* Methods */

    // Transitions to the main scene.
    public void PlayGame() => ButtonUtilites.GoToGame();
    // Quits the game (in editor mode, quit play mode).
    public void Quit() => ButtonUtilites.Quit();
}
