using UnityEngine;
using System.Collections;
/// <summary>
///  Class manages all data
///  Items for buying and selling
///  
/// </summary>
public class managerdata : MonoBehaviour {
   public static int play;
    public static int key; // Revival key
    public static int coin;
    public static int coinmoney; // Distance score
    public static managerdata manager;
    void Awake()
    {
      //  PlayerPrefs.DeleteAll();
        loaddata();
        play = 1;
        manager = this;
        loadatalvitem();
        loaditemvan();
        Datacharacter();
        LoadEnvironmentData();
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("coinmuving", 0);
        PlayerPrefs.Save();
        
        // Initialize PlayerEconomyManager with saved coins
        PlayerEconomyManager.Initialize();
    }

    private void GetAllachievement()
    {

    }
    /// <summary>
    /// Check and load save key data for first play session, names of key points
    /// </summary>
    private void loaddata()
    {
       
        if (PlayerPrefs.HasKey("key") == false)
        {
            PlayerPrefs.SetInt("key", 0);
            PlayerPrefs.Save();
        }
      
        if (PlayerPrefs.HasKey("coin") == false)
        {
            PlayerPrefs.SetInt("coin", 0);
            PlayerPrefs.Save();
        }
       
        if (PlayerPrefs.HasKey("coinmuving") == false)
        {
            PlayerPrefs.SetInt("coinmuving", 0);
            PlayerPrefs.Save();
        }
 
        if (PlayerPrefs.HasKey("van") == false)
        {
            PlayerPrefs.SetInt("van", 0);
            PlayerPrefs.Save();
        }
        if (PlayerPrefs.HasKey("setting") == false)
        {
            PlayerPrefs.SetInt("setting", 1);
            PlayerPrefs.Save();
        }
        if (PlayerPrefs.HasKey("fly") == false)
        {
            PlayerPrefs.SetInt("fly", 0);
            PlayerPrefs.Save();
        }
       
    }
    /// <summary>
    /// Names of items to buy
    /// </summary>
    private void loadatalvitem()
    {
        // Flight item level
        if (PlayerPrefs.HasKey("itemfly") == false)
        {
            PlayerPrefs.SetInt("itemfly", 0);
            PlayerPrefs.Save();
        }
        // Shoes item level
        if (PlayerPrefs.HasKey("giay") == false)
        {
            PlayerPrefs.SetInt("giay", 0);
            PlayerPrefs.Save();
        }
        // Coin magnet item level
        if (PlayerPrefs.HasKey("magnet") == false)
        {
            PlayerPrefs.SetInt("magnet", 0);
            PlayerPrefs.Save();
        }
        // X2 coin item level
        if (PlayerPrefs.HasKey("x2") == false)
        {
            PlayerPrefs.SetInt("x2", 0);
            PlayerPrefs.Save();
        }
    }
    /// <summary>
    /// Names of skateboard keys to buy
    /// </summary>
    private void loaditemvan()
    {
        if (PlayerPrefs.HasKey("vanchinh") == false)
        {
            PlayerPrefs.SetInt("vanchinh", 1);
            PlayerPrefs.Save();
        }
        if (PlayerPrefs.HasKey("vantron") == false)
        {
            PlayerPrefs.SetInt("vantron", 0);
            PlayerPrefs.Save();
        }
        if (PlayerPrefs.HasKey("vancamap") == false)
        {
            PlayerPrefs.SetInt("vancamap", 0);
            PlayerPrefs.Save();
        }
        if (PlayerPrefs.HasKey("selectedvan") == false)
        {
            PlayerPrefs.SetString("selectedvan", "vanchinh");
            PlayerPrefs.Save();
           
        }
    }

    /// <summary>
    /// Save characters currently in use and for buying/selling
    /// </summary>
    private void Datacharacter()
    {
        if (PlayerPrefs.HasKey("nvchinh") == false)
        {
            PlayerPrefs.SetInt("nvchinh", 0);
            PlayerPrefs.Save();
        }
        if (PlayerPrefs.HasKey("nvgirl") == false)
        {
            PlayerPrefs.SetInt("nvgirl", 1);
            PlayerPrefs.Save();
        }
        if (PlayerPrefs.HasKey("nvgau") == false)
        {
            PlayerPrefs.SetInt("nvgau", 0);
            PlayerPrefs.Save();
        }
        if (PlayerPrefs.HasKey("nowcharacter") == false)
        {
            PlayerPrefs.SetString("nowcharacter", "nvgirl");
            PlayerPrefs.Save();
        }
        // Initialize selected character index (0-5 for 6 players)
        if (PlayerPrefs.HasKey("selectedCharacterIndex") == false)
        {
            PlayerPrefs.SetInt("selectedCharacterIndex", 1); // Default to index 1 (nvgirl)
            PlayerPrefs.Save();
        }
    }

    // Functions to query character buy/sell data
    //-------------------------------------------------------------------------------------------
   
    /// <summary>
    /// Get name of character currently in use
    /// </summary>
    /// <returns></returns>
      public string Getnowcharacter()
    {
        PlayerPrefs.SetString("nowcharacter", "nvgau");
        return PlayerPrefs.GetString("nowcharacter");
    }
    /// <summary>
    /// Save data of character currently in use
    /// </summary>
    /// <param name="value"></param>
    public void Setnowcharacter(string value)
    {
        PlayerPrefs.SetString("nowcharacter", value);
        PlayerPrefs.Save();
    }
    
    /// <summary>
    /// Get selected character index (0-5 for 6 players)
    /// </summary>
    /// <returns>Character index</returns>
    public int GetSelectedCharacterIndex()
    {
        return PlayerPrefs.GetInt("selectedCharacterIndex", 0);
    }
    
    /// <summary>
    /// Set selected character index (0-5 for 6 players)
    /// </summary>
    /// <param name="index">Character index</param>
    public void SetSelectedCharacterIndex(int index)
    {
        // Ensure index is within valid range (0-5)
        index = Mathf.Clamp(index, 0, 5);
        PlayerPrefs.SetInt("selectedCharacterIndex", index);
        PlayerPrefs.Save();
    }
    /// <summary>
    /// Get main character data
    /// </summary>
    /// <returns></returns>
    public int GetCharacternvchinh()
    {
        return PlayerPrefs.GetInt("nvchinh");
    }
    /// <summary>
    /// Save main character data
    /// </summary>
    /// <param name="value"></param>
    public void SetCharacternvchinh(int value)
    {
         PlayerPrefs.SetInt("nvchinh", value);
         PlayerPrefs.Save();
    }

    /// <summary>
    /// Get female character data
    /// </summary>
    /// <returns></returns>
    public int GetCharacternvgirl()
    {
        return PlayerPrefs.GetInt("nvgirl");
    }
    /// <summary>
    /// Save female character data
    /// </summary>
    /// <param name="value"></param>
    public void SetCharacternvgirl(int value)
    {
        PlayerPrefs.SetInt("nvgirl", value);
        PlayerPrefs.Save();
    }
    /// <summary>
    /// Get bear character data
    /// </summary>
    /// <returns></returns>
    public int GetCharacternvGau()
    {
        return PlayerPrefs.GetInt("nvgau");
    }
    /// <summary>
    /// Save female character data
    /// </summary>
    /// <param name="value"></param>
    public void SetCharacternvGau(int value)
    {
        PlayerPrefs.SetInt("nvgau", value);
        PlayerPrefs.Save();
    }

    //-------------------------------------------------------------------------------------------



    // Functions to query skateboard buy/sell data
    //-------------------------------------------------------------------------------------------

    /// <summary>
    /// Get current skateboard data
    /// </summary>
    /// <returns></returns>
    public string Getvanuser()
    {
        return PlayerPrefs.GetString("selectedvan");
    }
    /// <summary>
    /// Save current skateboard data
    /// </summary>
    /// <returns></returns>
    public void Savevanuser(string value)
    {
        PlayerPrefs.SetString("selectedvan", value);
        PlayerPrefs.Save();
    }

    /// <summary>
    /// Get main skateboard data
    /// </summary>
    /// <returns></returns>
    public int Getvanchinh()
    {
        return PlayerPrefs.GetInt("vanchinh");
    }
    /// <summary>
    /// Save main skateboard data
    /// </summary>
    /// <returns></returns>
    public void Savevanchinh(int value)
    {
        PlayerPrefs.SetInt("vanchinh", value);
        PlayerPrefs.Save();
    }
    /// <summary>
    /// Get round skateboard data
    /// </summary>
    /// <returns></returns>
    public int Getvantron()
    {
        return PlayerPrefs.GetInt("vantron");
    }
    /// <summary>
    /// Save round skateboard data
    /// </summary>
    /// <returns></returns>
    public void Savevantron(int value)
    {
        PlayerPrefs.SetInt("vantron", value);
        PlayerPrefs.Save();
    }
    /// <summary>
    /// Get shark-shaped skateboard data
    /// </summary>
    /// <returns></returns>
    public int Getvancamap()
    {
        return PlayerPrefs.GetInt("vancamap");
    }
    /// <summary>
    /// Save shark skateboard data
    /// </summary>
    /// <returns></returns>
    public void Savevancamap(int value)
    {
        PlayerPrefs.SetInt("vancamap", value);
        PlayerPrefs.Save();
    }

    //-------------------------------------------------------------------------------------------


    //--------------------------------------------------------------------------------------------------



    /// <summary>
    /// Save purchase data for x2 coin item level
    /// </summary>
    /// <returns></returns>
    public void SaveDataItemX2(int value)
    {
        PlayerPrefs.SetInt("x2", (PlayerPrefs.GetInt("x2") + value));
        PlayerPrefs.Save();
    }

    /// <summary>
    /// Get x2 coin item level data
    /// </summary>
    /// <returns></returns>
    public int GetDataItemX2()
    {

        return PlayerPrefs.GetInt("x2");
    }




    //--------------------------------------------------------------------------------------------------



    /// <summary>
    /// Save purchase data for coin magnet item level
    /// </summary>
    /// <returns></returns>
    public void SaveDataItemMagnet(int value)
    {
        // return PlayerPrefs.GetInt("itemfly");
        PlayerPrefs.SetInt("magnet", (PlayerPrefs.GetInt("magnet") + value));
        PlayerPrefs.Save();
    }

    /// <summary>
    /// Get coin magnet item level data
    /// </summary>
    /// <returns></returns>
    public int GetDataItemMagnet()
    {
        return PlayerPrefs.GetInt("magnet");
    }





    //--------------------------------------------------------------------------------------------------



    /// <summary>
    /// Save purchase data for shoes item level
    /// </summary>
    /// <returns></returns>
    public void SaveDataItemGiay(int value)
    {
        // return PlayerPrefs.GetInt("itemfly");
        PlayerPrefs.SetInt("giay", (PlayerPrefs.GetInt("giay") + value));
        PlayerPrefs.Save();
    }

    /// <summary>
    /// Get shoes item level data
    /// </summary>
    /// <returns></returns>
    public int GetDataItemGiay()
    {
        return PlayerPrefs.GetInt("giay");
    }




    //--------------------------------------------------------------------------------------------------

    /// <summary>
    /// Save purchase data for flight item level
    /// </summary>
    /// <returns></returns>
    public void SaveDataItemFly(int value)
    {
       // return PlayerPrefs.GetInt("itemfly");
        PlayerPrefs.SetInt("itemfly", (PlayerPrefs.GetInt("itemfly") + value));
        PlayerPrefs.Save();
    }

    /// <summary>
    /// Get flight item level data
    /// </summary>
    /// <returns></returns>
    public int GetDataItemFly()
    {
        return PlayerPrefs.GetInt("itemfly");
    }

    //----------------------------------------------------------------------------------------------------

    /// <summary>
    /// Get item sale price data
    /// </summary>
    /// <returns></returns>
    public int Getprice(int valuelv)
    {
        int price = 0;

        switch (valuelv)
        {
            case 0:
                price = 500;
                break;
            case 1:
                price = 1500;
                break;
            case 2:
                price = 3000;
                break;
            case 3:
                price = 10000;
                break;
            case 4:
                price = 30000;
                break;
            case 5:
                price = 100000;
                break;

            default:
                break;
        }
        return price;

    }


    //----------------------------------------------------------------------------------------------------
    /// <summary>
    /// Get flight item
    /// </summary>
    /// <returns></returns>
    public int GetFly()
    {
        return PlayerPrefs.GetInt("fly");

    }

    /// <summary>
    /// Save flight item
    /// </summary>
    /// <param name="value"></param>
    public void SaveFly(int value)
    {
        PlayerPrefs.SetInt("fly", (PlayerPrefs.GetInt("fly") + value));
        PlayerPrefs.Save();
    }


    //----------------------------------------------------------------------------------------------------
    /// <summary>
    /// Save settings
    /// </summary>
    /// <param name="value"> </param>
    public void savesetting(int value)
    {
        PlayerPrefs.SetInt("setting", value);
        PlayerPrefs.Save();
    }


    /// <summary>
    /// Get saved settings
    /// </summary>
    /// <param name="value"> </param>
    public int getsetting()
    {
        return PlayerPrefs.GetInt("setting");

    }

    //----------------------------------------------------------------------------------------------------

    /// <summary>
    /// Save number of skateboards
    /// </summary>
    /// <param name="value"></param>
    public void savevan(int value)
    {
        PlayerPrefs.SetInt("van", (PlayerPrefs.GetInt("van") + value));
        PlayerPrefs.Save();
    }

    /// <summary>
    /// Get skateboard
    /// </summary>
    /// <returns></returns>
    public int getvan()
    {
        return PlayerPrefs.GetInt("van");
    }

    //----------------------------------------------------------------------------------------------------

    /// <summary>
    /// Save key when collision adds a key
    /// </summary>
    /// <param name="value"></param>
    public void savekey(int value)
    {
        PlayerPrefs.SetInt("key", (PlayerPrefs.GetInt("key") + value));
        PlayerPrefs.Save();

    }

    /// <summary>
    /// Get key
    /// </summary>
    /// <returns></returns>
    public int getkey()
    {
        return PlayerPrefs.GetInt("key");
    }

    //----------------------------------------------------------------------------------------------------


    /// <summary>
    /// Save coin score
    /// </summary>
    /// <param name="coin"></param>
    public void savecoin(int coin)
    {
        PlayerPrefs.SetInt("coin", (PlayerPrefs.GetInt("coin")+ coin));
        PlayerPrefs.Save();
    }


    /// <summary>
    /// Get coin score
    /// </summary>
    /// <returns></returns>
    public int Getcoin()
    {
        return PlayerPrefs.GetInt("coin");
    }

    //----------------------------------------------------------------------------------------------------

    /// <summary>
    /// Save distance score if current score is greater than max score
    /// </summary>
    /// <param name="maxmuving"></param>
    public void savemuving(int maxmuving)
    {
        if (maxmuving >PlayerPrefs.GetInt("coinmuving"))
        {
            PlayerPrefs.SetInt("coinmuving", maxmuving);
            PlayerPrefs.Save();
        }
    }



    /// <summary>
    /// Get distance score
    /// </summary>
    /// <returns></returns>
    public int getmuving()
    {
        return PlayerPrefs.GetInt("coinmuving");
    }

    //----------------------------------------------------------------------------------------------------

    /// <summary>
    /// Initialize environment data on first play
    /// </summary>
    private void LoadEnvironmentData()
    {
        if (PlayerPrefs.HasKey("environment") == false)
        {
            PlayerPrefs.SetInt("environment", 0); // Default to environment 0
            PlayerPrefs.Save();
        }
    }

    /// <summary>
    /// Get selected environment index
    /// </summary>
    /// <returns>Environment index (0, 1, 2, etc.)</returns>
    public int GetEnvironment()
    {
        return PlayerPrefs.GetInt("environment", 0);
    }

    /// <summary>
    /// Save selected environment index
    /// </summary>
    /// <param name="environmentIndex">Environment index to save</param>
    public void SetEnvironment(int environmentIndex)
    {
        PlayerPrefs.SetInt("environment", environmentIndex);
        PlayerPrefs.Save();
    }
 
}
