using UnityEngine;
using System.Collections;
/// <summary>
/// Action grabbing police neck
/// </summary>
public class IkEmty : MonoBehaviour {
    public Animator animationPlayer;
    public static IkEmty IKMAGNET;
    // Use this for initialization
    void Start () {
        IKMAGNET = this;
        sEttaget();

    }
    /// <summary>
    /// Set neck grab position for each character
    /// </summary>
    public void sEttaget()
    {
        // Get selected character index from managerdata
        int selectedIndex = managerdata.manager.GetSelectedCharacterIndex();
        
        // Set target based on character index
        switch (selectedIndex)
        {
            case 0: // First character (nvchinh equivalent)
                if (positionmangnetl != null)
                    maintaget = positionmangnetl;
                break;
            case 1: // Second character (nvgirl equivalent)
                if (positionmangnetlgirl != null)
                    maintaget = positionmangnetlgirl;
                break;
            case 2: // Third character (nvgau equivalent)
                if (positionmangnetlgau != null)
                    maintaget = positionmangnetlgau;
                break;
            case 3: // Fourth character
            case 4: // Fifth character
            case 5: // Sixth character
            default:
                // Use default position for characters 3-5
                if (positionmangnetl != null)
                    maintaget = positionmangnetl;
                break;
        }
    }
    Transform maintaget;
    void OnAnimatorIK()
    {
        animationPlayer.SetIKPositionWeight(AvatarIKGoal.LeftHand, iklegth);
        animationPlayer.SetIKPositionWeight(AvatarIKGoal.RightHand, iklegth1);
        animationPlayer.SetIKPosition(AvatarIKGoal.LeftHand, maintaget.position);
        animationPlayer.SetIKPosition(AvatarIKGoal.RightHand, maintaget.position);
        // animationPlayer.SetIKHintPosition(AvatarIKHint.);
       // animationPlayer.
    }
    public Transform positionmangnetl; // IK neck main player
    public Transform positionmangnetlgau; // IK bear character
    public Transform positionmangnetlgirl; // IK girl character
    public static float iklegth;
    public static float iklegth1;
}
