using NUnit.Framework.Internal.Execution;
using UnityEngine;

/// <summary>
/// Static manager for player economy (coins)
/// Handles adding, subtracting, and retrieving coins
/// </summary>
public static class PlayerEconomyManager
{
    private static int coins = 0;
    private static int sword = 0;

    /// <summary>
    /// Initialize coins from PlayerPrefs on game start
    /// </summary>
    public static void Initialize()
    {
        coins = PlayerPrefs.GetInt("coin", 0);
        sword = PlayerPrefs.GetInt("sword", 0);
        
    }

    /// <summary>
    /// Get current coin count
    /// </summary>
    /// <returns>Current number of coins</returns>
    public static int GetCoins()
    {
        return coins;
    }

    public static int GetSwords()
    {
        return sword;
    }

    /// <summary>
    /// Add coins to player economy
    /// </summary>
    /// <param name="amount">Amount of coins to add</param>
    public static void AddCoins(int amount)
    {
        coins += amount;
        SaveCoins();
    }

    public static void AddSword(int amount)
    {
        sword += amount;
        SaveSword();
    }
    /// <summary>
    /// Subtract coins from player economy
    /// </summary>
    /// <param name="amount">Amount of coins to subtract</param>
    /// <returns>True if successful, false if insufficient coins</returns>
    public static bool SubtractCoins(int amount)
    {
        if (coins >= amount)
        {
            coins -= amount;
            SaveCoins();
            return true;
        }
        return false;
    }

    public static bool SubtractSwords(int amount)
    {
        if (coins >= amount)
        {
            coins -= amount;
            SaveSword();
            return true;
        }
        return false;
    }
    /// <summary>
    /// Save coins to PlayerPrefs
    /// </summary>
    private static void SaveCoins()
    {
        PlayerPrefs.SetInt("coin", coins);
        PlayerPrefs.Save();
    }

    public static void SaveSword()
    {
        PlayerPrefs.SetInt("sword", sword);
        PlayerPrefs.Save();
    }
    /// <summary>
    /// Set coins directly (for loading from save)
    /// </summary>
    /// <param name="amount">Amount to set</param>
    public static void SetCoins(int amount)
    {
        coins = amount;
        SaveCoins();
    }

    public static void SetSword(int amount)
    {
        sword = amount;
        SaveSword();
    }
}

