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
    public float primaryIngredientVolume;
    public Liquid secondaryIngredient;
    public float secondaryIngredientVolume;
    public float sellValue;

    // Start is called before the first frame update
    void Awake()
    {
        // cupVolume = red.volume + blue.volume;
        foreach (Liquid liquid in contents)
        {

            contentsSprite.color = color;
            
            if (secondaryIngredient == null && primaryIngredient != null)
            {
                secondaryIngredient = primaryIngredient;
                primaryIngredient = liquid;
                secondaryIngredientVolume = primaryIngredientVolume;
                primaryIngredientVolume = liquid.volume;
            }
            if (primaryIngredient == null)
            {
                primaryIngredientVolume = liquid.volume;
                primaryIngredient = liquid;
            }
            else if(secondaryIngredient == null)
            {

                secondaryIngredient = liquid;
                secondaryIngredientVolume = liquid.volume;
            }
        }

        sellValue = primaryIngredientVolume * primaryIngredient.value;
        sellValue += secondaryIngredientVolume * secondaryIngredient.value;
    }

    public void SellPotion()
    {
        GameObject.Find("PlayerUI").GetComponent<PlayerUI>().cash += sellValue;
        Destroy(this.gameObject);
    }
}
