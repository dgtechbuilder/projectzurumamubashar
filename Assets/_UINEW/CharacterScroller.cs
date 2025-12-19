using JetBrains.Annotations;
using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
// If you're using TextMeshPro, uncomment this:
// using TMPro;

public class CharacterScroller : MonoBehaviour
{
    [System.Serializable]
    public class CharacterData
    {
        //public int characterId;
        public string characterName;   // e.g. "Warrior"
        [TextArea]
        public string description;     // e.g. "A strong melee fighter."
        public Sprite portrait;        // Character image
        public string Information;
        public string MoreInfo;
        public Sprite Flag;
    }

    [Header("Character List")]
    public CharacterData[] characters;

    [Header("UI References")]
    [Header("Character Main Icon")]
    public Image characterImage;      // UI Image to show portrait
    [Header("Character Name Text")]
    public TMP_Text nameText;             // UI Text for character name
    [Header("Character FlagMain Text")]
    public TMP_Text descriptionText;      // UI Text for description
    [Header("Flag Main")]
    public Image MainFlag;
    [Header("Inside Box Description")]
    public TextMeshProUGUI DiscriptionInSideBox;
    [Header("Inside Box More Info ")]
    public TextMeshProUGUI MoreInfoInSideBox;
    [Header("Inside Box Flag")]
    public Image InsideBoxFlag;

    private int currentIndex = 0;

    public List<GameObject> SelectionImages;

    void Start()
    {
        if (characters == null || characters.Length == 0)
        {
            Debug.LogWarning("No characters assigned to CharacterScroller.");
            return;
        }
        int current = managerdata.manager.GetSelectedCharacterIndex();
        HideAllImages();
        ActiveSelectionImage(current);
        UpdateUI();
    }

    public void NextCharacter()
    {
        if (characters == null || characters.Length == 0) return;

        currentIndex++;
       
        if (currentIndex >= characters.Length)
            currentIndex = 0;

        managerdata.manager.SetSelectedCharacterIndex(currentIndex);
        HideAllImages();
        ActiveSelectionImage(currentIndex);
        UpdateUI();
    }

    public void PreviousCharacter()
    {
        if (characters == null || characters.Length == 0) return;

        currentIndex--;
        if (currentIndex < 0)
            currentIndex = characters.Length - 1;

        managerdata.manager.SetSelectedCharacterIndex(currentIndex);
        HideAllImages();
        ActiveSelectionImage(currentIndex);
        UpdateUI();
        
    }

    private void UpdateUI()
    {

        CharacterData current = characters[managerdata.manager.GetSelectedCharacterIndex()];
        
        Debug.Log("Current Character Index : " + currentIndex);
        Playermuving.player.setTranformitem();
        if (characterImage != null)
            characterImage.sprite = current.portrait;

        if (nameText != null)
            nameText.text = current.characterName;

        if (descriptionText != null)
            descriptionText.text = current.description;

        if (MainFlag != null)
            MainFlag.sprite = current.Flag;

        if (DiscriptionInSideBox != null)
            DiscriptionInSideBox.text = current.Information;

        if (MoreInfoInSideBox != null)
            MoreInfoInSideBox.text = current.MoreInfo;
    
        if(InsideBoxFlag != null)
            InsideBoxFlag.sprite = current.Flag;
    }

    public void SelectCharacter(int index)
    {
        if(index == 0)
        {
            //Queen Amina
            managerdata.manager.SetSelectedCharacterIndex(index);
            HideAllImages();
            SelectionImages[0].SetActive(true);
            UpdateUI();
        }
        else if (index == 1)
        {
            //Shaka Zuli
            managerdata.manager.SetSelectedCharacterIndex(index);
            HideAllImages();
            SelectionImages[1].SetActive(true);
            UpdateUI();
        }
        else if (index == 2)
        {
            //Jaja Obopobo
            managerdata.manager.SetSelectedCharacterIndex(index);
            HideAllImages();
            SelectionImages[2].SetActive(true);
            UpdateUI();
        }
        else if(index == 3)
        {
            //maktai
            managerdata.manager.SetSelectedCharacterIndex(index);
            HideAllImages();
            SelectionImages[3].SetActive(true);
            UpdateUI();
        }
        else if (index == 4)
        {
            //Mabatin
            managerdata.manager.SetSelectedCharacterIndex(index);
            HideAllImages();
            SelectionImages[4].SetActive(true);
            UpdateUI();
        }
        else if (index == 5)
        {
            //Lawande
            managerdata.manager.SetSelectedCharacterIndex(index);
            HideAllImages();
            SelectionImages[5].SetActive(true);
            UpdateUI();
        }
    }

    void HideAllImages()
    {
        foreach(var Obj in SelectionImages)
        {
            Obj.SetActive(false);
        }
    }

    void ActiveSelectionImage(int Index)
    {
        SelectionImages[Index].SetActive(true);
    }
}
