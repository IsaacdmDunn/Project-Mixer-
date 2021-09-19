using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionManager : MonoBehaviour
{
    public List<Potion> potions;
    public int potionCount = 0;

    public Text potionInfo;


    //Updates the potion list when a new potion is made
    public void PotionUpdate()
    {
        potionInfo.text = "Contents:  \n";

        //for each potion made update text and move potion
        foreach (Transform child in this.transform)
        {
            potionInfo.text += "Liquids: " + "Potion ID: " + potionCount + "\n";
            potionInfo.text += child.GetComponent<Potion>().primaryIngredient.name + " : " + child.GetComponent<Potion>().primaryIngredientVolume.ToString() + " : " +
                 Mathf.Round(child.GetComponent<Potion>().primaryIngredient.value * child.GetComponent<Potion>().primaryIngredientVolume).ToString() + "\n";
            if (child.GetComponent<Potion>().secondaryIngredient != null)
            {
                potionInfo.text += child.GetComponent<Potion>().secondaryIngredient.name + " : " + child.GetComponent<Potion>().secondaryIngredientVolume.ToString() + " : " +
                    Mathf.Round(child.GetComponent<Potion>().secondaryIngredient.value * child.GetComponent<Potion>().secondaryIngredientVolume).ToString() + "\n";
            }
            child.transform.position = new Vector3(100 * potionCount + 50, 50, 0);
            potionCount++;
        }
        potionCount = 0;
    }
}
