using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cup : MonoBehaviour
{
    public List<Liquid> contents;
    public RawImage contentsSprite;
    public float cupSize = 10f;
    public float cupVolume = 0f;
    public float dropRate = 0f;
    public Vector4 color;
    public bool cupUpdated = true;

    public Text liquidList;

    public List<Mixer> mixer;
    public Potion potion;
    public GameObject potionParent;

    //public PotionList potionList;

    // Start is called before the first frame update
    void Start()
    {
        //contents = new List<Liquid>();
        contentsSprite.color = new Vector4(1f,1f,1f,1f);
    }

    public void FinishPotion()
    {
        potion.cupVolume = cupVolume;
        potion.contents = contents;
        potion.color = color;
        //foreach (Liquid liquid in contents)
        //{
        //    potion.contents.Add(liquid);
        //}

        //potionList.potions.Add(potion);
        Potion newPotion = Instantiate(potion, new Vector3(),new Quaternion(),potionParent.transform);

        potionParent.GetComponent<PotionManager>().PotionUpdate();

        //potionList.UpdateUI();
        foreach (Liquid liquid in contents)
        {
            liquid.volume = 0f;
        }
        //dropRate = 100f;
        contents.Clear();
        cupVolume = 0f;
        cupUpdated = false;

    }

    public void CupUpdate()
    {
        cupVolume = 0;
        contentsSprite.color = new Vector4(1f, 1f, 1f, 1f);
        liquidList.text = "Contents \n";

        // cupVolume = red.volume + blue.volume;
        foreach (Liquid liquid in contents)
        {
            liquid.volume -= dropRate * liquid.volume;
            contentsSprite.color = contentsSprite.color + (liquid.color * (liquid.volume * 1000));
            cupVolume += liquid.volume;
            liquidList.text += liquid.name + " : " + liquid.volume * 100 + "% \n";


        }
        for (int i = 0; i < contents.Count; i++)
        {
            if (contents[i].volume < 0.01f)
            {
                contents.RemoveAt(i);
            }

        }

        foreach (Mixer mix in mixer)
        {
            mix.CheckMix();
        }

        contentsSprite.color = contentsSprite.color / (cupVolume * 1000);
        color = contentsSprite.color;
        contentsSprite.transform.localScale = new Vector3(1, cupVolume, cupVolume);

        dropRate = gameObject.transform.rotation.z * 0.003f;
        if (dropRate < 0.0012f)// && gameObject.transform.rotation.z > 30f)
        {
            dropRate = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
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
        //cupUpdated = false;
        if (!cupUpdated)
        {
            CupUpdate();
        }
        cupUpdated = true;
    }

    
}
