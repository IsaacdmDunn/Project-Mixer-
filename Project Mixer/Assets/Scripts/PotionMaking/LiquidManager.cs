using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class LiquidManager : MonoBehaviour
{
    public List<Liquid> liquids;
    public List<Liquid> liquidsPrefab;
    Liquid data;
    List<Liquid> data1;
    public void Start()
    {

        foreach (Liquid liquid in liquidsPrefab)
        {
            liquid.volume = 0;
        }
    }

    public void SaveToJson()
    {
        //data = new Liquid[2];
        data = liquids[0];
        data = liquids[1];
        foreach (Liquid liquids in liquids)
        {
            
        }

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(Application.dataPath + "/Liquids.json", json);
    }

    public void LoadFromJson()
    {
        string json = File.ReadAllText(Application.dataPath + "/Liquids.json");
        Liquid data = JsonUtility.FromJson<Liquid>(json);

        //liquid.id = data.id + 10;
        //liquid.name = data.name;
        //liquid.color.r = data.color.r;
        //liquid.color.g = data.color.g;
        //liquid.color.b = data.color.b;
        //liquid.color.a = data.color.a;
    }
}