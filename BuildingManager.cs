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
        return true; // Replace with actual checks
    }

    public void PurchaseBuilding(BuildingData buildingData)
    {
        Debug.Log($"Attempting to purchase {buildingData.Name} for " +
            $"{buildingData.WoodCost} wood, " +
            $"{buildingData.GoldCost} gold, " +
            $"{buildingData.IronCost} iron, and " +
            $"{buildingData.FoodCost} food.");
                  
        if (CanBuild(buildingData))
        {
            Debug.logs("Building can be built");
            // Deduct resources and instantiate the building prefab in the scene
            // Add the building to builtBuildings list
            // Invoke the OnBuilt method of the building instance
        }
        else
        {
            Debug.logs("Building cannot be built");
            // Inform the player they can't build the building
        }
    }
}

