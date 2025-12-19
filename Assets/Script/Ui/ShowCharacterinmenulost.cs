using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShowCharacterinmenulost : MonoBehaviour {
    public List<GameObject> Allplayer = new List<GameObject>();
    public Transform allplayer;
    // Use this for initialization
    void Start () {
        foreach (Transform item in allplayer)
        {
            Allplayer.Add(item.gameObject);
        }
        Getcharacter();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void Getcharacter()
    {
        // Get selected character index from managerdata
        int selectedIndex = managerdata.manager.GetSelectedCharacterIndex();
        
        // Ensure index is valid
        if (selectedIndex < 0 || selectedIndex >= Allplayer.Count)
        {
            selectedIndex = 0; // Default to first character if invalid
        }
        
        // Activate selected character, deactivate others
        for (int i = 0; i < Allplayer.Count; i++)
        {
            if (i == selectedIndex)
            {
                Allplayer[i].SetActive(true);
            }
            else
            {
                Allplayer[i].SetActive(false);
            }
        }
    }
    void OnEnable()
    {
        Getcharacter();
    }
}
