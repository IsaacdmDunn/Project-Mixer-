using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddLiquid : MonoBehaviour
{
    public Liquid blue;
    public Liquid red;

    public Cup cup;
    public void AddRed()
    {
        if (cup.cupVolume < cup.cupSize)
        {
            if (cup.contents.Find(x => x.id == 1))
            {
                Debug.Log("red found");
            }
            else
            {
                Debug.Log("red not found");
                cup.contents.Add(red);
            }
            cup.contents.Find(x => x.id == 1).volume += 0.001f;
            //cup.contents.Find("red");
            //cup.red.volume += 0.001f;
            //cup.contentsSprite.color = (cup.contentsSprite.color + new Color(1f, 0f, 0f, 1f)) / 2f;
        }

    }
    public void AddBlue()
    {
        if (cup.cupVolume < cup.cupSize)
        {
            if (cup.contents.Find(x => x.id == 2))
            {
                Debug.Log("red found");
            }
            else
            {
                Debug.Log("red not found");
                cup.contents.Add(blue);
            }
            cup.contents.Find(x => x.id == 2).volume += 0.001f;
        }
    }

    public void Update()
    {
        if (Input.GetMouseButton(0))
        {
            AddBlue();
        }
        else if (Input.GetMouseButton(1))
        {
            AddRed();
        }
    }
}
