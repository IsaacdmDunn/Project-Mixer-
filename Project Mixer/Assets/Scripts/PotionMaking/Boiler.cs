using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boiler : MonoBehaviour
{
    public Cup cup;
    public Liquid mix;
    public float ID;
    public float changeRate;
    
    // Start is called before the first frame update
    void Start()
    {
        mix.volume = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void boilLiquid(Liquid liquid1, float changeRate, Liquid mix)
    {
        if (cup.temp > liquid1.boilingPoint)
        {
            //Debug.Log("dawujhwidh");
            if (!cup.contents.Find(x => x.id == mix.id))
            {
                Debug.Log("dawujhwidh");
                cup.contents.Add(mix);
                
            }
            cup.cupUpdated = false;
            liquid1.volume -= changeRate;
            mix.volume += changeRate;
        }
        
    }

    public void CheckBoil()
    {
        if (cup.contents.Find(x => x.id == ID))
        {
            boilLiquid(cup.contents.Find(x => x.id == ID), changeRate, mix); 
        }
    }
}
