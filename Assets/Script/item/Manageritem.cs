using UnityEngine;
using System.Collections;

/// <summary>
/// Class manages some items
/// </summary>
public class Manageritem : MonoBehaviour {
    public static bool giay;
    public static bool x2coin;
    public static bool hutcoin;
    public static bool baycoin;
    public static bool van;
    public static bool baylongcoin;
    public static bool box;
    public static bool sword; // Sword item (spawns once per game)
    public static bool usingbayitembuy;
    public static Manageritem mngitem;
    // Use this for initialization
    void Awake()
    {
        van = false;
        giay = false;
        x2coin = false;
        hutcoin = false;
        baycoin = false;
        baylongcoin = false;
        sword = false;
        usingbayitembuy = false;
    }
    /// <summary>
    /// Delete all items when player dies
    /// </summary>
    public void DeleteAllItemWendie()
    {
        van = false;
        giay = false;
        x2coin = false;
        hutcoin = false;
        baycoin = false;
        baylongcoin = false;
        sword = false;
        usingbayitembuy = false;
    }
    void Start () {
        mngitem = this;
  }
    public IEnumerator delayfordestroiiteam(int value, string nameiteam)
    {
        Debug.Log(giay);
        yield return new WaitForSeconds(5);
        Debug.Log("sau " + giay);
        switch (nameiteam)
        {
            case "giay":
                giay = false;
                Debug.Log("sau " + giay);
                break;
            case "x2coin":
                Manageritem.x2coin = false;
                break;
            case "jupm":
                Manageritem.baycoin = false;
                break;
            case "jupmtong":
                Manageritem.baylongcoin = false;
                break;
            case "hutcoin":
                Manageritem.hutcoin = false;
                break;
            default:
                break;
        }
    }
    // Update is called once per frame
    void Update () {
	
	}
}
