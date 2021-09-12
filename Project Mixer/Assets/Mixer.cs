using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mixer : MonoBehaviour
{
    public Cup cup;
    public Liquid mix;
    public float ID1;
    public float ID2;
    public float _ratio;
    
    // Start is called before the first frame update
    void Start()
    {
        mix.volume = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void mixLiquid(Liquid liquid1, Liquid liquid2, float ratio, Liquid mix)
    {
        if (liquid1.volume > 0.01f && liquid2.volume > ratio)
        {
            liquid1.volume -= 0.01f;
            liquid2.volume -= ratio;
            mix.volume += (0.01f + ratio);
            if (!cup.contents.Find(x => x.id == mix.id))
            {
                cup.contents.Add(mix);
            }
        }
        
    }

    public void CheckMix()
    {
        if (cup.contents.Find(x => x.id == ID1) && cup.contents.Find(x => x.id == ID2))
        {
            mixLiquid(cup.contents.Find(x => x.id == ID1), cup.contents.Find(x => x.id == ID2), _ratio, mix); 
        }
    }
}
