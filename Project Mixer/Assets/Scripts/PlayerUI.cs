using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public float cash;
    public Text cashTxt;

    public void Update()
    {
        cashTxt.text = "Money: " + Mathf.Round(cash).ToString();
    }

}
