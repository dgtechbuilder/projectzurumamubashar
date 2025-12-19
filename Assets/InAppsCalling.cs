using UnityEngine;

public class InAppsCalling : MonoBehaviour
{

    public UImanager UI_Manager;
   public void RewardCoins(int  amount)
    {
        PlayerEconomyManager.AddCoins(100000);
        UI_Manager.UpdateAllCoinsText();
        // Here Reward Given on Successfully Purchase .....
    }


    public void WeeklySubscription()
    {
        // Here Come the code for Weekly Subscription
    }
    public void MontlySubscription()
    {
        // Here Come The Code for Montly Subscription
    }
    public void YearlySubscription()
    {
        // Here Come The Code for Yearly Subscription
    }
}
