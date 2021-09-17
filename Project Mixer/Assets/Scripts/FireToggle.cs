using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireToggle : MonoBehaviour
{
    public Sprite fireOn;
    public Sprite fireOff;

    public bool isFireOn;
    // Start is called before the first frame update
    public void Toggle()
    {
        isFireOn = !isFireOn;
        if (isFireOn)
        {
            gameObject.GetComponent<Image>().sprite = fireOn;
        }
        else
        {
            gameObject.GetComponent<Image>().sprite = fireOff;
        }
    }

   
}
