using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CanvasManager : MonoBehaviour
{

    public Canvas canvas;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause")) //Escape
        {
            canvas.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void UnPause()
    {
        canvas.gameObject.SetActive(false); 
        Time.timeScale = 1;
    }
}
