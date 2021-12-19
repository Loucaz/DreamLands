using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{


    public int coinsCount;
    public static Inventory instance;

    private List<Item> items;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de Inventory dans la scène");
            return;
        }
        instance = this;

        items = new List<Item>();
        AddItem("items/carrot");
        AddItem("items/egg");
        AddItem("items/fish");
        AddItem("items/milk");
        AddItem("items/wheat");
        AddItem("items/wood");
        
    }


    public void AddItem(int count)
    {
        coinsCount += count;
    }

    private void AddItem(string name)
    {
        items.Add(new Item(items.Count(), name));
    }

    public string FindItem(string nameItem)
    {
        var s = items.Find(x => x.name == nameItem);
        return s.name;
    }

    public string GetRandomItem()
    {
        int random = Random.Range(0, items.Count());
        return items.Find(x => x.id == random).name;
    }

}

