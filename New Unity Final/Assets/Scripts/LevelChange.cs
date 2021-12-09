using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class LevelChange : MonoBehaviour
{
    public string targetLevel;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SwitchLevel(false, targetLevel);
    }

    // Update is called once per frame
    static public void SwitchLevel(bool restartCurrent, string level = "")
    {
        if (restartCurrent)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        else
            SceneManager.LoadScene(level);
    }
}
