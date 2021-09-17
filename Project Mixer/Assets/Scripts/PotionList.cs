using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PotionList : MonoBehaviour
{
    public List<Potion> potions;
    public Text potionList;

    public void UpdateUI()
    {
        potionList.text = "Potions \n\n";
        potionList.text += potions.Count.ToString();

        foreach (Potion potion in potions)
        {
            potionList.text += "Liquids:  \n";
            //potionList.text += potion.primaryIngredient.name;

            foreach (Liquid liquid in potion.contents)
            {

                //Debug.Log(potions.Count);
                potionList.text += liquid.name + " : " + liquid.volume * 100f + "% \n";
            }
            potionList.text += "\n";
        }
    }

    public void FindPotions()
    {

    }
}
