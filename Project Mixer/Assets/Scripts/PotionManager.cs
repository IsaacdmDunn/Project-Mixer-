using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionManager : MonoBehaviour
{
    public List<Potion> potions;
    public int potionCount = 0;
    public int liquidsToAdd = 0;

    public Text potionInfo;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    public void PotionUpdate()
    {
        potionInfo.text = "Contents:  \n";

        foreach (Transform child in this.transform)
        {
            potionInfo.text += "Liquids: " + "Potion ID: " + potionCount + "\n";
            potionInfo.text += child.GetComponent<Potion>().primaryIngredient.name + " : " + child.GetComponent<Potion>().primaryIngredientVolume.ToString() + "\n";
            if (child.GetComponent<Potion>().secondaryIngredient != null)
            {
                potionInfo.text += child.GetComponent<Potion>().secondaryIngredient.name + " : " + child.GetComponent<Potion>().secondaryIngredient.ToString() + "\n";
            }

            potionCount++;
        }
        potionCount = 0;
    }
}
