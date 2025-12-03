using UnityEngine;
#if UNITY_EDITOR
using UnityEditor; // This allows us to control the Editor
#endif

public class QuitGameHandler : MonoBehaviour
{
    public void QuitTheGame()
    {
        // Logic for the Unity Editor (so you can see it work now)
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
            // Logic for the actual Android/iOS phone
            Application.Quit();
#endif

        Debug.Log("Game is quitting...");
    }
}