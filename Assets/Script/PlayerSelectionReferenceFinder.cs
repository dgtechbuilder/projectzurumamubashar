using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Utility script for storing vantranform references for each player.
/// This script uses the Allplayer list to store vantranform references.
/// </summary>
public class PlayerSelectionReferenceFinder : MonoBehaviour
{
    [Header("Player Vantranform List")]
    [Tooltip("Assign vantranform references for each player here in order (index 0-5). This list stores vantranform references for each player.")]
    public List<GameObject> Allplayer = new List<GameObject>();
    
    [ContextMenu("Find All Vantranform References")]
    public void FindAllVantranformReferences()
    {
        Debug.Log("=== VANTRANSFORM REFERENCES ===");
        Debug.Log("Current Selected Character Index: " + managerdata.manager.GetSelectedCharacterIndex());
        Debug.Log("");
        
        Debug.Log("Vantranform List (Allplayer) - " + Allplayer.Count + " entries:");
        for (int i = 0; i < Allplayer.Count; i++)
        {
            if (Allplayer[i] != null)
            {
                string status = (i == managerdata.manager.GetSelectedCharacterIndex()) ? " [SELECTED]" : "";
                Debug.Log($"  [{i}] {Allplayer[i].name}{status}");
            }
            else
            {
                Debug.LogWarning($"  [{i}] NULL - Assign a vantranform reference here");
            }
        }
        Debug.Log("");
        
        Debug.Log("Player Selection Methods:");
        Debug.Log("  - managerdata.manager.GetSelectedCharacterIndex() - Returns selected index (0-5)");
        Debug.Log("  - managerdata.manager.SetSelectedCharacterIndex(int index) - Sets selected index");
        Debug.Log("");
        
        Debug.Log("This list (Allplayer) stores vantranform references for each player.");
        Debug.Log("Support: Up to 6 players (indices 0-5)");
        Debug.Log("=========================================");
        
        // Validation
        Debug.Log("\n=== VALIDATION ===");
        if (Allplayer.Count == 0)
        {
            Debug.LogWarning("⚠️ Allplayer list is empty! Assign vantranform references in Inspector.");
        }
        else
        {
            Debug.Log($"✓ Found {Allplayer.Count} vantranform references");
        }
        
        int nullCount = 0;
        for (int i = 0; i < Allplayer.Count; i++)
        {
            if (Allplayer[i] == null)
            {
                nullCount++;
                Debug.LogWarning($"⚠️ Vantranform at index [{i}] is null!");
            }
        }
        if (nullCount == 0 && Allplayer.Count > 0)
        {
            Debug.Log("✓ All vantranform references are assigned");
        }
    }
    
    [ContextMenu("Test Player Selection")]
    public void TestPlayerSelection()
    {
        if (Allplayer.Count == 0)
        {
            Debug.LogWarning("Allplayer list is empty!");
            return;
        }
        
        int currentIndex = managerdata.manager.GetSelectedCharacterIndex();
        Debug.Log($"Testing player selection with index {currentIndex}");
        
        if (currentIndex >= 0 && currentIndex < Allplayer.Count)
        {
            if (Allplayer[currentIndex] != null)
            {
                Debug.Log($"Selected vantranform: {Allplayer[currentIndex].name} at index {currentIndex}");
            }
            else
            {
                Debug.LogWarning($"Vantranform at index {currentIndex} is null!");
            }
        }
        else
        {
            Debug.LogWarning($"Invalid index {currentIndex}! Valid range is 0-{Allplayer.Count - 1}");
        }
    }
    
    [ContextMenu("List All Vantranform References")]
    public void ListAllVantranformReferences()
    {
        Debug.Log("=== VANTRANSFORM REFERENCES ===");
        Debug.Log($"Total Vantranforms: {Allplayer.Count}");
        Debug.Log("");
        
        Debug.Log("Vantranform List (Allplayer):");
        for (int i = 0; i < Allplayer.Count; i++)
        {
            if (Allplayer[i] != null)
            {
                string status = (i == managerdata.manager.GetSelectedCharacterIndex()) ? " [SELECTED]" : "";
                Debug.Log($"  [{i}] {Allplayer[i].name}{status}");
            }
            else
            {
                Debug.LogWarning($"  [{i}] NULL - Assign a vantranform reference here");
            }
        }
        
        Debug.Log("\nCurrent Selected Index: " + managerdata.manager.GetSelectedCharacterIndex());
        Debug.Log("This list stores vantranform references for each player.");
        Debug.Log("=================================");
    }
}
