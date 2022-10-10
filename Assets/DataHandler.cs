using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHandler : MonoBehaviour
{   

    private GameObject units;
    [SerializeField]
    private ButtonManager buttonPrefab;
    [SerializeField]
    private GameObject buttonCotainer;
    [SerializeField]
    private List<Item> items;

    private int currentId = 0;

    private static DataHandler instance;
    public static DataHandler Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<DataHandler>();
            }
            return instance;
        }
    }
    private void Start()
    {
        LoadItems();
        CreateButton();

    }
    void LoadItems()
    {
        var itemsObj = Resources.LoadAll("Items",typeof(Item));
        foreach(Item item in itemsObj)
        {
            items.Add(item as Item);
        }
    }
    void CreateButton()
    {
        foreach (Item i in items)
        {
            ButtonManager b = Instantiate(buttonPrefab, buttonCotainer.transform);
            b.ItemId = currentId;
            b.ButtonTexture = i.unitImage;
            currentId++;
        }
    }

    public void setUnit(int id)
    {
        units = items[id].unitPrefab;
    }

    public GameObject getUnit()
    {
        return units;
    }
}
