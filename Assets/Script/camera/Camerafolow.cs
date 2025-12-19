using UnityEngine;
using System.Collections;
public class Camerafolow : MonoBehaviour {


    public GameObject Effects; // Explosion effect when using item
    GameObject child;
    public enum camfolow{left , betwen,right};
    camfolow cam;
    Transform taget;
    float cameraDistOffset = 10;
    public static Camerafolow camfolowplayer;

    float camx, camy, camz;
    float distincamx, distincamy = 4.5f, distincamz = 5.5f;
    // Handle camera going under bridge
    public static bool downcamlef;
    public static bool downcamrigh;
    public static bool downcam;
    // Use this for initialization
    public GameObject folowtoleft, folowtoright, folowtobetwen, folowtoup, folowtofly, cameramain;
    public Transform pointfolowtoleft, pointfolowtoright, pointfolowtobetwen; //, folowtoup, folowtofly, cameramain;
    void Start () {
        taget = GameObject.Find("Player").transform;
        camfolowplayer = this;
        rb = GetComponent<Rigidbody>();
        downcamlef = false;
        downcamrigh = false;
        downcam  = false;
        folow = 0;
        alowcall = true;
        isdowham = false;
        Camera camera = GetComponent<Camera>();
        float[] distances = new float[32];
        distances[10] = 15;
        camera.layerCullDistances = distances;
    }
	
	// Update is called once per frame
	void Update () {
       
    }

   public void Intanceectff()
    {
        child = Instantiate(Effects, new Vector3(transform.position.x,transform.position.y-2,transform.position.z +5),transform.rotation) as GameObject;
        child.transform.parent = this.gameObject.transform;
    }

    public Transform target; // Target to follow
    public  float distance = 10.0f; // Distance x - z with player
    public float height = 0f;   // Height distance with player on y axis
    public  float height1 = 0f; // Horizontal distance with player on x axis
    public float heightDamping = 2.0f; // Follow delay on y axis
    public float heightDamping1 = 2.0f; // Follow delay on z axis
    public float rotationDamping = 3.0f; // Follow delay rotation angle

    /// <summary>
    /// Handle camera following player, changes for different item types
    /// </summary>
    void LateUpdate()
    {
        if (Playermuving.isplay)  // Fix camera follow not smooth bug
        {


 
            if (Perencamera.isfolowwenstartnew)
            {
                transform.position = folowtofly.transform.position;
            }
          //  
            if ((Manageritem.baycoin || Manageritem.baylongcoin) && downcam == false)
            {
                Manageritem.giay = false;
                if (Manageritem.baycoin)
                {
                    if (Playermuving.player.transform.position.y <= 4.1f && Playermuving.player.GetComponent<Rigidbody>().linearVelocity.y < -1f)
                    {
                        Manageritem.baycoin = false;
                    }
                }
                if (Manageritem.baylongcoin)
                {
                    if (Playermuving.player.transform.position.y <= 4.1f && Playermuving.player.GetComponent<Rigidbody>().linearVelocity.y < -1f)
                    {
                        Manageritem.baylongcoin = false;
                    }
                }
            }
        }
        if (Playermuving.player.transform.position.z > -2f)
        {
            if (Manageritem.baylongcoin == false||Playermuving.player.transform.position.y<12)
            {
                var targetRotation = Quaternion.LookRotation(tagetlockat.transform.position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
            }

        }

    }
    public static float speed = 1.5f;
    public static int folow;
    public Transform tagetlockat;
    /// <summary>
    /// Follow when lost
    /// </summary>
    public void folowinthelos(float x , float  y  , float z)
    {
        // Didn't select key to play again
        if (UImanager.selectkey == false)
        {
            folowtofly.transform.position = new Vector3(0, 4.5f, (transform.position.z + z) );
        }
        // If selected key, keep x still
        else if (UImanager.selectkey)
        {
            folowtofly.transform.position = new Vector3(0, 3.54f, (transform.position.z + z) - 3);
        }

    }
    // Delay camera follow to right
    public IEnumerator delaytofolowleft()
    {
        yield return new WaitForSeconds(0.1f);
        
    }
    Vector3 pointst, pointen;
    Rigidbody rb;
    // Delay camera follow to right
    public IEnumerator delaytofolowright()
    {  
       yield return new WaitForSeconds(0.2f);
       }
        //// Delay camera up and down
    public IEnumerator delaycameraup(float value)
    {
        //// yield return new WaitForSeconds(0.2f);
        //for (int i = 0; i < 100; i++)
        //{
        yield return new WaitForSeconds(0.01f);
         
    }
    bool alowcall;

    /// <summary>
    /// Reset camera position in air to always see player
    /// </summary>
    /// <returns></returns>
    public IEnumerator dowcamwenFly()
    {
        
        if (alowcall)
        {
            alowcall = false;
            for (int i = 0; i < 18; i++)
            {
                yield return new WaitForSeconds(0.001f);
                transform.Translate(new Vector3(0, -0.1f, 0));
            }
            yield return new WaitForSeconds(1f);
            alowcall = true;
        }
        
    }
    
    /// <summary>
    /// Camera encounters ship, move down to left
    /// </summary>
    /// <returns></returns>
    public IEnumerable inthedowcam()
    {
        //for (int i = 0; i < 100; i++)
        //{
           yield return new WaitForSeconds(0.01f);
        //    transform.Translate(new Vector3(-0.1f,-0.13f,0));
        //    if (transform.position.y<=1.7f)
        //    {
        //        break;
        //    }
        //}
    }

    /// <summary>
    /// Camera shake effect
    /// </summary>
    /// <returns></returns>
   public IEnumerator Effect()
    {
        Soundmanager.soundmanager.Playruang();
        float ranx = 0.2f;
        float rany = 0.2f;
        for (int i = 0; i < 6; i++)
        {
            yield return new WaitForSeconds(0.02f);
            transform.Translate(new Vector3(ranx, rany, 0));
            ranx = ranx * -1;
            rany = rany * -1;
        }

        // Reset to correct position if camera is in wrong position
        //if (transform.position.x !=-1.5f&& transform.position.x != 0&&transform.position.x != 1.5f)
        //{
        //    float d1, d2, d3, min;
        //    d1 = Vector3.Distance(new Vector3(transform.position.x, 0, 0), new Vector3(-1.5f, 0, 0));
        //    d2 = Vector3.Distance(new Vector3(transform.position.x, 0, 0), new Vector3(0, 0, 0));
        //    d3 = Vector3.Distance(new Vector3(transform.position.x, 0, 0), new Vector3(1.5f, 0, 0));
        //    min = d1;
        //    if (min > d2)
        //    {
        //        min = d2;
        //        if (min > d3)
        //        {
        //            min = d3;
        //        }
        //    }
        //    else if (min > d3)
        //    {
        //        min = d3;
        //        if (min > d2)
        //        {
        //            min = d2;
        //        }
        //    }

        //    if (min == d1)
        //    {
        //        transform.position = new Vector3(-1.5f, transform.position.y, transform.position.z);
        //    }
        //    else if (min == d2)
        //    {
        //        transform.position = new Vector3(0, transform.position.y, transform.position.z);
        //    }
        //    else if (min == d3)
        //    {
        //        transform.position = new Vector3(1.5f, transform.position.y, transform.position.z);
        //    }
          
        //}
    }
    bool allow = true;
   public static bool isdowham;
    /// <summary>
    /// Lower camera by 1 unit when passing under bridge
    /// </summary>
    /// <returns></returns>
    public IEnumerator dowcamera(string value)
    {
        //switch (value)
        //{
        //    case "down":
        //        if (allow)
        //        {
        //            isdowham = true;
        //            allow = false;
        //            for (int i = 0; i < 12; i++)
        //            {
                        yield return new WaitForSeconds(0.00001f);
        //                distincamy = distincamy - 0.2f;
        //            }
        //            allow = true;
        //        }
        //        break;
        //    case "up":
        //        if (allow)
        //        {
        //            allow = false;
        //            for (int i = 0; i < 10; i++)
        //            {
        //                yield return new WaitForSeconds(0.00001f);
        //                distincamy = distincamy + 0.2f;
        //            }
        //            allow = true;
        //            isdowham = false;

        //        }
        //        break;
        //    default:
        //        break;
        //}
    }

     public void ShowShop3D()
    {
        this.GetComponent<Camera>().orthographic = true;
    }

    public void HideShop3D()
    {
        this.GetComponent<Camera>().orthographic = false;
    }

}
