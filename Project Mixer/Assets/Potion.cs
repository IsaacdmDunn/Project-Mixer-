using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Potion : MonoBehaviour
{
    public List<Liquid> contents;
    public float cupVolume = 0f;
    public Vector4 color;
    public Image contentsSprite;
    public Liquid primaryIngredient;
    public Liquid secondaryIngredient;

    // Start is called before the first frame update
    void Start()
    {
        // cupVolume = red.volume + blue.volume;
        foreach (Liquid liquid in contents)
        {
            contentsSprite.color = contentsSprite.color + (liquid.color * (liquid.volume * 1000));
            if (primaryIngredient.volume < liquid.volume)
            {
                secondaryIngredient = primaryIngredient;
                primaryIngredient = liquid;
            }
            else if(secondaryIngredient.volume < liquid.volume)
            {

            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
