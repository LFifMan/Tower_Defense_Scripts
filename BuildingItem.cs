using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class BuildingItem : MonoBehaviour
{
    public TextMeshProUGUI buildingNameText;
    public TextMeshProUGUI buildingCostText;
    public Button purchaseButton;
    private BuildingData buildingData; // Keep a reference to the building data for this item

    // Call this method to set up the building item
    public void Setup(BuildingData data)
    {
        buildingData = data; // Store the reference
        buildingNameText.text = data.Name;
        buildingCostText.text = $"Wood: {data.WoodCost} Gold: {data.GoldCost} Food: {data.FoodCost} Iron: {data.IronCost}";
        purchaseButton.onClick.AddListener(OnPurchaseButtonClicked);
    }

    public void OnPurchaseButtonClicked()
    {
        BuildingManager.Instance.PurchaseBuilding(buildingData);
    }
}

