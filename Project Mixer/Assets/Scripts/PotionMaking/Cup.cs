using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cup : MonoBehaviour
{
    public List<Liquid> contents;
    public RawImage contentsMeter;
    public RawImage contentsSprite;
    public float cupSize = 10f;
    public float cupVolume = 0f;
    public float dropRate = 0f;
    public Vector4 color;
    public bool cupUpdated = true;

    public Text liquidList;

    public List<Mixer> mixer;
    public List<Boiler> boiler;
    public Potion potion;
    public GameObject potionParent;

    public bool isCooking = false;
    public float temp = 0f;
    public float coolingRate = 0f;
    public float heatingRate = 0f;
    public RawImage TempMeter;
    public GameObject steam;

    //creates potion
    public void FinishPotion()
    {
        //sets up potion
        potion.cupVolume = cupVolume;
        potion.contents = contents;
        potion.color = color;

        //Instantiate potion and update potion list
        Potion newPotion = Instantiate(potion, new Vector3(),new Quaternion(),potionParent.transform);
        potionParent.GetComponent<PotionManager>().PotionUpdate();

        //empties cup and resets it
        foreach (Liquid liquid in contents)
        {
            liquid.volume = 0f;
        }
        contents.Clear();
        cupVolume = 0f;
        cupUpdated = false;

    }

    //updates cup
    public void CupUpdate()
    {
        //resets color and volume
        cupVolume = 0;
        contentsMeter.color = new Vector4(1f, 1f, 1f, 1f);
        contentsSprite.color = new Vector4(1f, 1f, 1f, 1f);

        liquidList.text = "Contents \n";

        //set attributes of potion from liquids contained in it
        foreach (Liquid liquid in contents)
        {
            liquid.volume -= dropRate * liquid.volume;
            contentsMeter.color = contentsMeter.color + (liquid.color * (liquid.volume * 1000));
            contentsSprite.color = contentsSprite.color + (liquid.color * (liquid.volume * 1000));
            cupVolume += liquid.volume;

            liquidList.text += liquid.name + " : " + liquid.volume * 100 + "% \n";


        }

        //removes liquid when volume gets too low
        for (int i = 0; i < contents.Count; i++)
        {
            if (contents[i].volume < 0.01f)
            {
                contents.RemoveAt(i);
            }

        }

        //checks for any available mixes 
        foreach (Mixer mix in mixer)
        {
            mix.CheckMix();
        }

        //calculates final potion attributes
        contentsMeter.color = contentsMeter.color / (cupVolume * 1000);
        contentsSprite.color = contentsSprite.color / (cupVolume * 1000);
        color = contentsMeter.color;
        color = contentsSprite.color;
        contentsMeter.transform.localScale = new Vector3(.1f, cupVolume, cupVolume);
        contentsSprite.transform.localScale = new Vector3(cupVolume, cupVolume, cupVolume);

        //calculates liquid drop rate depending on how tilted the cup is
        dropRate = gameObject.transform.rotation.z * 0.003f;
        if (dropRate < 0.0012f)
        {
            dropRate = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //tilts cup so liquids can be poured out
        if (Input.GetKey(KeyCode.Q) && gameObject.transform.rotation.z < 90f)
        {
           gameObject.transform.Rotate(new Vector3(0,0,.1f));
           cupUpdated = false;
        }
        else if (Input.GetKey(KeyCode.E) && gameObject.transform.rotation.z > 0f)
        {
            gameObject.transform.Rotate(new Vector3(0, 0, -.1f));
            cupUpdated = false;
        }
        
        //checks if cup can be updated
        if (!cupUpdated)
        {
            CupUpdate();
        }
        cupUpdated = true;

        if (isCooking && temp<100f)
        {
            temp += heatingRate;
        }
        else if (temp > 20f)
        {
            temp -= coolingRate;
        }
        if (temp >50f && cupVolume > 0)
        {
            steam.SetActive(true);
        }
        else
        {
            steam.SetActive(false);
        }

        TempMeter.transform.localScale = new Vector3(.1f, temp/100, 0);

        foreach (Boiler boilMix in boiler)
        {
            boilMix.CheckBoil();
        }
    }

    
}
