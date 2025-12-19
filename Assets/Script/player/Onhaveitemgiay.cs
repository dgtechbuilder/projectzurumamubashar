using UnityEngine;
using System.Collections;
/// <summary>
/// Handle lifting player up when having shoes item
/// </summary>
public class Onhaveitemgiay : MonoBehaviour
{
    void OnTriggerEnter(Collider coll)
    {

        if (coll.gameObject.tag != "coin"&& coll.gameObject.tag != this.gameObject.tag)
        {
            if (Playermuving.isplay)
            {
 
                Playermuving.player.GetComponent<Rigidbody>().linearVelocity = new Vector3(0, 5, 0);
                Physics.gravity = new Vector3(0, -15, 0);
            }
        }
     
    }

}
