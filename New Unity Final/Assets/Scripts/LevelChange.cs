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
        save();
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

    public void save()
    {
        PlayerControls pc = FindObjectOfType<PlayerControls>();
        Player p = FindObjectOfType<Player>();
        PlayerPrefs.SetInt("Crystals", pc.getCrystals());
        PlayerPrefs.SetFloat("PlayerX", pc.gameObject.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", pc.gameObject.transform.position.y);
        PlayerPrefs.SetInt("hasLazer", 1);
       PlayerPrefs.Save();
    }
}
