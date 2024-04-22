using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public static BuildingManager Instance { get; private set; }
    private List<Building> builtBuildings; // Tracks built buildings

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            builtBuildings = new List<Building>();
        }
    }

    public bool CanBuild(BuildingData buildingData)
    {
        // Check if prerequisites are met and if resources are available
        return ResourceManager.instance.CanAfford(new ResourceCost(buildingData.WoodCost, buildingData.GoldCost, buildingData.IronCost, buildingData.FoodCost));
    }

    public void PurchaseBuilding(BuildingData buildingData)
    {
        Debug.Log($"Attempting to purchase {buildingData.Name} for " +
            $"{buildingData.WoodCost} wood, " +
            $"{buildingData.GoldCost} gold, " +
            $"{buildingData.IronCost} iron, and " +
            $"{buildingData.FoodCost} food.");
                  
        if (CanBuild(buildingData)) {
            Debug.Log($"Building purchased: {buildingData.Name}");
            ResourceManager.instance.SubtractResources(new ResourceCost(buildingData.WoodCost, buildingData.GoldCost, buildingData.IronCost, buildingData.FoodCost));
            // Instantiate building prefab and update builtBuildings list
        } else {
            Debug.Log("Not enough resources to build: " + buildingData.Name);
        }
    }
}

