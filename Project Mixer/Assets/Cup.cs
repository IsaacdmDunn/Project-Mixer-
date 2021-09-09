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

    public Text liquidList;

    public List<Mixer> mixer;
    
    // Start is called before the first frame update
    void Start()
    {
        //contents = new List<Liquid>();
        contentsSprite.color = new Vector4(1f,1f,1f,1f);
    }

    // Update is called once per frame
    void Update()
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
        //contentsSprite.color = contentsSprite.color / (cupVolume * 1000);
        color = contentsSprite.color;
        //contentsSprite.color = ((red.color*(red.volume * 1000)) + (blue.color * (blue.volume * 1000)))/(cupVolume * 1000);
        contentsSprite.transform.localScale = new Vector3(1, cupVolume, cupVolume);

        if (Input.GetKey(KeyCode.Q) && gameObject.transform.rotation.z < 90f)
        {
           gameObject.transform.Rotate(new Vector3(0,0,.1f));
        }
        else if (Input.GetKey(KeyCode.E) && gameObject.transform.rotation.z > 0f)
        {
            gameObject.transform.Rotate(new Vector3(0, 0, -.1f));
        }
        dropRate = gameObject.transform.rotation.z * 0.01f;
        if (dropRate < 0.005f)// && gameObject.transform.rotation.z > 30f)
        {
            dropRate = 0;
        }

        
    }

    
}
