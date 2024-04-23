using UnityEngine;
using TMPro;

public class ResourceManager : MonoBehaviour
{
    public TextMeshProUGUI goldText;
    public TextMeshProUGUI woodText;
    public TextMeshProUGUI ironText;
    public TextMeshProUGUI foodText;

    public int gold = 100;
    public int wood = 100;
    public int iron = 100;
    public int food = 100;

    public static ResourceManager instance;

    public TextMeshProUGUI unassignedVillagersText; // UI text for unassigned villagers
    public int unassignedVillagers = 5; // Starting number of unassigned villagers

    void Awake()
    {
        // Ensure there's only one ResourceManager instance (singleton pattern)
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // Optional: makes it persist across scenes
        }
        else
        {
            Destroy(gameObject);
        }
        UpdateResourceUI();
    }

    // Getters
    public int GetGold() { return gold; }
    public int GetFood() { return food; }
    public int GetIron() { return iron; }
    public int GetWood() { return wood; }

    public bool CanAfford(ResourceCost cost)
    {
        return gold >= cost.gold && food >= cost.food &&
               iron >= cost.iron && stone >= cost.wood;
    }

    public void AddResources(ResourceCost cost)
    {
        gold += cost.gold;
        food += cost.food;
        iron += cost.iron;
        wood += cost.wood;
        UpdateResourceUI();
    }

    public void SubtractResources(ResourceCost cost)
    {
        gold -= cost.gold;
        food -= cost.food;
        iron -= cost.iron;
        wood -= cost.wood;
        UpdateResourceUI();
    }

    private void UpdateResourceUI()
    {
        // Update UI elements here
        if(goldText != null) goldText.text = "Gold: " + gold;
        if(woodText != null) woodText.text = "Wood: " + wood;
        if(ironText != null) ironText.text = "Iron: " + iron;
        if(foodText != null) foodText.text = "Food: " + food;
        // For now, just logging to console
        Debug.Log($"Updated Resources - Gold: {gold}, Wood: {wood}, Iron: {iron}, Food: {food}");
    }
}
