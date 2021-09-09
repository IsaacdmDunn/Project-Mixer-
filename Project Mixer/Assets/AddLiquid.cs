using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddLiquid : MonoBehaviour
{
    public Cup cup;

    public Liquid blue;
    public Liquid red;
    public Liquid green;

    public void AddRed()
    {
        if (cup.cupVolume < cup.cupSize)
        {
            if (!cup.contents.Find(x => x.id == 1))
            {
                cup.contents.Add(red);
            }
            else
            {
                
            }
            cup.contents.Find(x => x.id == 1).volume += 0.001f;
            //cup.red.volume += 0.001f;
        }

    }
    public void AddBlue()
    {
        if (cup.cupVolume < cup.cupSize)
        {
            if (cup.contents.Find(x => x.id == 2))
            {
            }
            else
            {
                cup.contents.Add(blue);
            }
            cup.contents.Find(x => x.id == 2).volume += 0.001f;
        }
    }

    public void AddFluid(Liquid liquid)
    {
        if (cup.cupVolume < cup.cupSize)
        {
            if (cup.contents.Find(x => x.id == liquid.id))
            {
            }
            else
            {
                cup.contents.Add(liquid);
            }
            cup.contents.Find(x => x.id == liquid.id).volume += 0.001f;
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
        else if (Input.GetKey(KeyCode.W))
        {
            AddFluid(green);
        }
    }
}
