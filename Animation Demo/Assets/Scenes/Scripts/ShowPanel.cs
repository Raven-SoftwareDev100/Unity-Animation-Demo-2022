using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPanel : MonoBehaviour
{
    public GameObject panel;
    public bool isVisible = true;

    public void DisplayPanel()
    {
        if(isVisible == false)
        {
            panel.SetActive(true);
            isVisible = true;
        }
        else if(isVisible == true)
        {
            panel.SetActive(false);
            isVisible = false;
        }
    }
}
