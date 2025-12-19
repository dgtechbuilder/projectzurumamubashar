using System;
using UnityEngine;

public class MapSelection : MonoBehaviour
{
    public GameObject MapSelectionPanel;
    public Makesupway WayScript;

    public void ShowMapSelectionPanel()
    {
        MapSelectionPanel.SetActive(true);
    }
    public void HideMapSelectionPanel()
    {
        MapSelectionPanel.SetActive(false);
    }

    public void OnSelectMap(int mapIndex)
    {
        if (mapIndex == 0)
        {
            WayScript.SelectMap(0);
        }
        else if (mapIndex == 1)
        {
            WayScript.SelectMap(1);
        }
        else if (mapIndex == 2)
        {
            WayScript.SelectMap(2);
        }
        MapSelectionPanel.SetActive(false);
    }

}
