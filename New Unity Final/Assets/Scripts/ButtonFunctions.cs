using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonFunctions : MonoBehaviour
{
    public void Play()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("WorldMap");
    }

    public void Continue()
    {
        LevelChange.SwitchLevel(false, "Worldmap");
    }

    public void Credits()
    {
        LevelChange.SwitchLevel(false, "Credits");
    }

    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;

#else
            Application.Quit();
#endif
    }

    public void cow(){

        LevelChange.SwitchLevel(false, "SecretCowLevel");

    }
}
