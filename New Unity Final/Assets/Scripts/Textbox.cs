using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Textbox : MonoBehaviour
{
    public UnityEngine.UI.Text textbox;
    void Update()
    {
        // if player presses 'E' key this frame
        if (Input.GetKeyDown(KeyCode.E))
        {
            // if textbox reference exists
            if (textbox != null)
            {
                // toggle textbox (visible/hidden)
                bool wasActive = textbox.gameObject.activeSelf;
                textbox.gameObject.SetActive(!wasActive);
            }
        }
    }
}

