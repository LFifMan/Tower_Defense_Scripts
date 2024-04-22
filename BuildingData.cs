using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingData
{
    public string Name { get; private set; }
    public int WoodCost { get; private set; }
    public int GoldCost { get; private set; }
    public int IronCost { get; private set; }
    public int FoodCost { get; private set; }

    // Constructor for the BuildingData
    public BuildingData(string name, int woodCost, int goldCost, int ironCost, int foodCost)
    {
        Name = name;
        WoodCost = woodCost;
        GoldCost = goldCost;
        IronCost = ironCost;
        FoodCost = foodCost;
    }

    // Method to handle the purchase, called from BuildingItem UI
    public void Purchase()
    {
        GameManager.Instance.PurchaseBuilding(this);
    }
}

