using UnityEngine;

public class AddLiquid : MonoBehaviour
{
    public Cup cup;
    public LiquidManager liquids;

    //checks if liquid exists, if not add new liquid to cup then adds liquid
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

    //check for liquids to be added to cup
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
