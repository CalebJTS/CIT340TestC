using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int maxHealth = 110;
    public Text HeathScore;
    public Slider healthbar;
    public GameObject player;
    //static Enemy foe;
   
    
 
    int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    //returns whether or not the object died.
    public bool ChangeHealth(int changeInHealth)
    {
        //currentHealth += changeInHealth;
        //if (currentHealth > maxHealth)
        //    currentHealth = maxHealth;

        currentHealth = Mathf.Min(maxHealth, currentHealth + changeInHealth);
        //HeathScore.text = "Health: " + currentHealth;
        //healthbar.value = (float)currentHealth / maxHealth;

        if (currentHealth <= 0)
        {
            Die();
            return true;
        }
        return false;
    }

    public bool ChangePlayerHealth(int healthChange)
    {
        {
            //currentHealth += changeInHealth;
            //if (currentHealth > maxHealth)
            //    currentHealth = maxHealth;

            currentHealth = Mathf.Min(maxHealth, currentHealth + healthChange);
            healthbar.value = (float)currentHealth / maxHealth;

            if (currentHealth <= 0)
            {
                //GameOver();
                return true;
            }
            return false;
        }

    }

    public int checkCurrentHealth()
    {
        return currentHealth;
    }

    public bool WillKill(int changeInHealth)
    {
        return currentHealth + changeInHealth <= 0;
    }

    public void Die()
    {

        //Play timed visual death effect here before calling Destroy()
         Destroy(gameObject);
        
    }

    public bool GameOver()
    {

        return true;
        
//#if UNITY_EDITOR
        //UnityEditor.EditorApplication.isPlaying = false;
//#else
//Application.Quit();
//#endif
    }

    public void heal()
    {
        currentHealth = maxHealth;
        healthbar.value = (float)currentHealth / maxHealth;
        //HeathScore.text = "Health: " + currentHealth.ToString();
        
    }
}
