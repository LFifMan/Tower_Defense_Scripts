using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RightPanelManager : MonoBehaviour
{
    public GameObject buildingItemPrefab; // Assign in Inspector
    // public GameObject upgradeItemPrefab; // Assign in Inspector
    public Transform contentArea; // Assign in Inspector

    // Call this method to update the right panel with available buildings
    public void ShowAvailableBuildings(Building[] availableBuildings)
    {
        ClearPanel();

        // Instantiate a BuildingItem for each available building
        foreach (Building building in availableBuildings)
        {
            GameObject itemGO = Instantiate(buildingItemPrefab, contentArea);
            BuildingItem itemScript = itemGO.GetComponent<BuildingItem>();
            itemScript.Setup(building);
            // Optionally set up button listeners or other interactions here
        }
    }

    private void ClearPanel()
    {
        foreach (Transform child in contentArea)
        {
            Destroy(child.gameObject);
        }
    }
}

