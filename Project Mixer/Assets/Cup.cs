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
    public Vector4 color;
    
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

        // cupVolume = red.volume + blue.volume;
        foreach (Liquid liquid in contents)
        {
            contentsSprite.color += (liquid.color * (liquid.volume * 100));
            cupVolume += liquid.volume;
            
        }
        contentsSprite.color = contentsSprite.color / (cupVolume * 100);
        
        color = contentsSprite.color;
        //contentsSprite.color = ((red.color*(red.volume * 10)) + (blue.color * (blue.volume * 10)))/(cupVolume * 10);
        //contentsSprite.color = Color.Lerp(contentsSprite.color, color, .5f);
        contentsSprite.transform.localScale = new Vector3(1, cupVolume, cupVolume);

        if (Input.GetKey(KeyCode.Q))
        {
            gameObject.transform.Rotate(new Vector3(0,0,-.1f));
        }
        else if (Input.GetKey(KeyCode.E))
        {
            gameObject.transform.Rotate(new Vector3(0, 0, .1f));
        }
    }
}
