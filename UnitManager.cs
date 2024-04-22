using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;  // For UI components like Buttons
using UnityEngine;
using TMPro;

public class UnitManager : MonoBehaviour
{
    public ResourceManager resourceManager;
    private Dictionary<Type, int> unitInventory = new Dictionary<Type, int>();

    public TextMeshProUGUI villagerCountText;  // For displaying the number of villagers
    public Button buyVillagerButton;           // Button to buy villagers
    public Button sellVillagerButton;          // Button to sell villagers
    
    void Start()
    {
        // Make sure your buttons are assigned either through the inspector or programmatically here
        if (buyVillagerButton != null)
            buyVillagerButton.onClick.AddListener(BuyVillager);

        if (sellVillagerButton != null)
            sellVillagerButton.onClick.AddListener(SellVillager);
        
        // Initialize villagers to 3 at the start of the game.
        unitInventory[typeof(Villager)] = 3;

        InitializeUnitUI();
    }

    private void InitializeUnitUI()
    {
        // Assume we start with 0 villagers, so update the UI accordingly.
        // If you start with a different number, make sure to set that before calling this method.
        if (villagerCountText != null)
            villagerCountText.text = $"Villagers: {GetUnitCount(typeof(Villager))}";
        
        // Call similar update logic for other unit types here if necessary.
    }

    private int GetUnitCount(Type unitType)
    {
        if (unitInventory.ContainsKey(unitType))
        {
            return unitInventory[unitType];
        }
        return 0; // Return 0 if the unit type isn't in the inventory yet
    }

    // Specific method for buying a Villager unit
    public void BuyVillager() {
        BuyUnit(typeof(Villager));
    }

    // Specific method for selling a Villager unit
    public void SellVillager() {
        SellUnit(typeof(Villager));
    }

    public void BuyUnit(Type unitType)  {
        Unit unit = UnitFactory.CreateUnit(unitType);
        if (resourceManager.CanAfford(unit.Cost))
        {
            resourceManager.SubtractResources(unit.Cost);
            unit.Purchase();
            AddUnitToInventory(unitType);
        }
    }

    public void SellUnit(Type unitType)
    {
        if (HasUnitsInInventory(unitType))
        {
            // Let's say you get back half the resources when you sell a unit
            Unit unit = UnitFactory.CreateUnit(unitType); // You still need an instance for the cost, but you won't "use" this unit
            ResourceCost sellCost = new ResourceCost(
                gold: unit.Cost.gold / 2,
                food: unit.Cost.food / 2,
                iron: unit.Cost.iron / 2,
                stone: unit.Cost.stone / 2
            );
            resourceManager.AddResources(sellCost);
            RemoveUnitFromInventory(unitType);
        }
    }


    private void AddUnitToInventory(Type unitType)
    {
        if (!unitInventory.ContainsKey(unitType)) {
            unitInventory[unitType] = 0;
        }
        unitInventory[unitType]++;
        UpdateUnitUI(unitType); // Corrected to non-generic call
    }

    private bool HasUnitsInInventory(Type unitType)
    {
        return unitInventory.ContainsKey(unitType) && unitInventory[unitType] > 0;
    }

    private void RemoveUnitFromInventory(Type unitType)
    {
        if (unitInventory.ContainsKey(unitType) && unitInventory[unitType] > 0)
        {
            unitInventory[unitType]--;
            UpdateUnitUI(unitType);
        }
    }

    void OnEnable() {
        Building.BuildingConstructed += OnBuildingConstructed;
        Building.BuildingDestroyed += OnBuildingDestroyed;
    }

    void OnDisable() {
        Building.BuildingConstructed -= OnBuildingConstructed;
        Building.BuildingDestroyed -= OnBuildingDestroyed;
    }

    private void OnBuildingConstructed(Building building)
    {
        if (building is TownCenter) {
            buyVillagerButton.interactable = true;
            sellVillagerButton.interactable = true;
        }
        // Add cases for other building types if needed
    }

    private void OnBuildingDestroyed(Building building)
    {
        if (building is TownCenter) {
            buyVillagerButton.interactable = false;
            sellVillagerButton.interactable = false;
        }
        // Add cases for other building types if needed
    }


    private void UpdateUnitUI(Type unitType)
    {
        if (unitType == typeof(Villager))
        {
            villagerCountText.text = $"Villagers: {unitInventory[unitType]}";
        }
        // Handle UI updates for other unit types...
    }

}
