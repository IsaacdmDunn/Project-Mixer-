using UnityEngine;

public class AddLiquid : MonoBehaviour
{
    public Cup cup;
    public LiquidManager lm;
    public LiquidManager liquids;

    public Liquid blue;
    public Liquid red;
    public Liquid green;

    public void Start()
    {
        blue.volume = 0;
        red.volume = 0;
        green.volume = 0;
        
    }


    public void AddFluid(Liquid liquid)
    {
        if (cup.cupVolume < cup.cupSize)
        {
            if (cup.contents.Find(x => x.id == liquid.id))
            {
            }
            else
            {
                cup.contents.Add(liquid);
            }
            cup.contents.Find(x => x.id == liquid.id).volume += 0.001f;
            cup.cupUpdated = false;
        }
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            AddFluid(liquids.liquidsPrefab[0]);
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            AddFluid(liquids.liquidsPrefab[1]);
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            AddFluid(liquids.liquidsPrefab[2]);
        }
    }
}
