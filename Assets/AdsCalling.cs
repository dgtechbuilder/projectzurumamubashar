using UnityEngine;

public class AdsCalling : MonoBehaviour
{
    public void RewardedAdOnGameOver()
    {
        Time.timeScale = 1.0f;
        if (AdsManager.Instance  != null)
        {
            AdsManager.Instance.ShowRewardedAd(RewardType.FreeSword);
        }
        // Here We Call Ad and Give 1 Sword Later ....
    }

    public void RewardedAdForDoublePoints()
    {
        Time.timeScale = 1.0f;
        if (AdsManager.Instance != null)
        {
            AdsManager.Instance.ShowRewardedAd(RewardType.FreeCoins);
        }
        // This ad is called for 2x reward .....
    }
}
