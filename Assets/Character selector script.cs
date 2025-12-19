using UnityEngine;
using UnityEngine.UI;

public class CharacterSelector : MonoBehaviour
{
    [Header("Characters")]
    public GameObject[] characters;  // assign nvchinh, nvgirl, nvgau in order
    private int currentIndex = 0;

    [Header("UI Buttons")]
    public Button leftButton;
    public Button rightButton;
    public Button confirmButton;

    void Start()
    {
        // Read previously selected character index (if exists)
        currentIndex = managerdata.manager.GetSelectedCharacterIndex();
        
        // Ensure index is valid
        if (currentIndex < 0 || currentIndex >= characters.Length)
        {
            currentIndex = 0; // Default to first character if invalid
        }

        // Attach listeners
        leftButton.onClick.AddListener(PreviousCharacter);
        rightButton.onClick.AddListener(NextCharacter);
        confirmButton.onClick.AddListener(ConfirmSelection);

        // Initialize display
        UpdateCharacterDisplay();
    }

    public void NextCharacter()
    {
        currentIndex++;
        if (currentIndex >= characters.Length)
            currentIndex = 0;
        UpdateCharacterDisplay();
    }

    public void PreviousCharacter()
    {
        currentIndex--;
        if (currentIndex < 0)
            currentIndex = characters.Length - 1;
        UpdateCharacterDisplay();
    }

    void UpdateCharacterDisplay()
    {
        for (int i = 0; i < characters.Length; i++)
        {
            characters[i].SetActive(i == currentIndex);
        }
    }

    public void ConfirmSelection()
    {
        // Save selected character index to PlayerPrefs using managerdata
        managerdata.manager.SetSelectedCharacterIndex(currentIndex);
        
        // Also save character name for backward compatibility (if needed)
        string selectedCharacter = characters[currentIndex].name;
        managerdata.manager.Setnowcharacter(selectedCharacter);

        Debug.Log("✅ Character Selected: Index " + currentIndex + " (" + selectedCharacter + ")");

        // (Optional) Load next scene or show confirmation UI
        // UnityEngine.SceneManagement.SceneManager.LoadScene("Gameplay");
    }
}
