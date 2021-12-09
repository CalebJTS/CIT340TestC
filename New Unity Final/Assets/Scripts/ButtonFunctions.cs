using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonFunctions : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("WorldMap");
    }

    public void Exit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = true;
        #else
            Application.Quit();
        #endif
    }
}
