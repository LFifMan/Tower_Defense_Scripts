using UnityEngine;
using TMPro;

public class ResourceManager : MonoBehaviour
{
    public TextMeshProUGUI goldText;  // Drag the appropriate Text element to this field in the Inspector
    public TextMeshProUGUI stoneText;
    public TextMeshProUGUI ironText;
    public TextMeshProUGUI foodText;

    public int gold = 100;
    public int stone = 100;
    public int iron = 100;
    public int food = 100;

    public static ResourceManager instance;

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
        UpdateUI();
    }

    // Getters
    public int GetGold() { return gold; }
    public int GetFood() { return food; }
    public int GetIron() { return iron; }
    public int GetStone() { return stone; }

    public bool CanAfford(ResourceCost cost)
    {
        return gold >= cost.gold && food >= cost.food &&
               iron >= cost.iron && stone >= cost.stone;
    }

    public void AddResources(ResourceCost cost)
    {
        gold += cost.gold;
        food += cost.food;
        iron += cost.iron;
        stone += cost.stone;
        UpdateUI();
    }

    public void SubtractResources(ResourceCost cost)
    {
        gold -= cost.gold;
        food -= cost.food;
        iron -= cost.iron;
        stone -= cost.stone;
        UpdateUI();
    }

    private void UpdateUI()
    {
        // Update UI elements here
        if(goldText != null) goldText.text = "Gold: " + gold.ToString();
        if(stoneText != null) stoneText.text = "Stone: " + stone.ToString();
        if(ironText != null) ironText.text = "Iron: " + iron.ToString();
        if(foodText != null) foodText.text = "Food: " + food.ToString();
        // For now, just logging to console
        Debug.Log($"Updated Resources - Gold: {gold}, Stone: {stone}, Iron: {iron}, Food: {food}");
    }
}
