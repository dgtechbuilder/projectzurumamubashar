using UnityEngine;
using System.Collections;

public class emty : MonoBehaviour {
    public Animator amin;
    public static emty emtyplayer;
    public static bool isactac;
    public static bool isfolowplayer;
    public static int die;
    public GameObject con;
    public GameObject playertaget;
    public Transform taget;
    public static bool alowcallhere; 
                                     
    void Start () {
        emtyplayer = this;
        alowcallhere = true;
        amin = gameObject.GetComponent<Animator>();
        isactac = false;
        isfolowplayer = false;
        con = gameObject.transform.Find("police").gameObject;
        die = 1;
    }

    /// <summary>
    /// Play again
    /// </summary>
    public void Agan()
    {
        transform.Translate(new Vector3(0,0,-10));
        isactac = true;
        isfolowplayer = false;
        alowcallhere = true;
        die = 1;
    }
    /// <summary>
    /// Start chasing
    /// </summary>
    public void actac()
    {
        isactac = true;
        
    }
    public void actacisfolowplayer()
    {
        amin.SetBool("play", true);
    }

    /// <summary>
    /// Chase immediately at start
    /// </summary>
    /// <returns></returns>
    public IEnumerator  intheplay()
    {
        con.SetActive(true);
        amin.SetBool("play", true);
        for (int i = 0; i < 100; i++)
        {
            yield return new WaitForSeconds(0.0001f);
            if (folow.distance <= 2f)
            {
                break;
            }
            folow.distance -= 0.2f;

        }
    }
    /// <summary>
    /// Start playing, police chase
    /// </summary>
    /// <returns></returns>
    public IEnumerator animationrunplay()
    {
        con.SetActive(true);
        for (int i = 0; i < 100; i++)
        {
            yield return new WaitForSeconds(0.0001f);
            if (folow.distance <= 2f)
            {
                break;
            }
            folow.distance -= 0.2f;
           
        }
        amin.SetBool("play",true);
      //  amin.SetBool("cut", false);
       
        isfolowplayer = true;
        for (int i = 0; i < 32; i++)
        {
            yield return new WaitForSeconds(0.2f);
            if (inthepanelpause.fixFlylong)
            {
                yield return new WaitForSeconds(3);
                inthepanelpause.fixFlylong = false;
            }
            //if (Playermuving.isplay == false)
            //{
            //    for (int j = 0; j < 100; j++)
            //    {
            //        //yield return new WaitForSeconds(0.0001f);
            //        //if (folow.distance >= 10f)
            //        //{
            //        //    break;
            //        //}
            //        //folow.distance += 0.1f;

            //    }
            //    break;
            //}
            if (i>=31&&Playermuving.isplay)
            {
                isfolowplayer = false;
                die = 0;
                yield return new WaitForSeconds(2);
                for (int j = 0; j < 100; j++)
                {
                   // Debug.Log("lcsalcl");
                    yield return new WaitForSeconds(0.01f);
                    if (folow.distance >= 10f)
                    {
                        break;
                    }
                    if (Playermuving.isplay == false)
                    {
                       // break;
                    }
                  //  folow.distance += 0.1f;

                }
                if (Playermuving.isplay)
                {
                    con.SetActive(false);

                }
            }
        }
       
       
    }
    /// <summary>
    /// Each touch makes police chase, if touched 2 times then die
    /// </summary>
    public void startatact()
    {
     
        die++;
        if (die == 2)
        {
           // enterthedie
               OnanimationCash();
            Camerafolow.isdowham = false; // Fix camera
            if (Manageritem.van ==false)
            {
         
                UImanager.uimanager.Lost();
               // Playermuving.player.gamelost();
                Playermuving.player.enterthedie();
                Playermuving.player.StartCoroutine(Playermuving.player.DelaytoFixAnimation());
                die = 0;
            }
            else if (Manageritem.van)
            {
                die = 0;
            }
        }
    }

    public void OnanimationCash()
    {
        amin.SetBool("cut", true); 
        Playermuving.player.StartCoroutine(Playermuving.player.OntheCasth());
        if (Playermuving.player.gameObject.transform.position.x<=-2)
        {
            folow.distance = 0.5f;
            IkEmty.iklegth1 = 1;
            folow.height1 = 0.5f;
            Playermuving.player.Inthecatch();
            transform.eulerAngles = new Vector3(0, -160, 0);
        }
        else
        {
            folow.distance = 0.5f;
            IkEmty.iklegth = 1;
            folow.height1 = -1.3f;
            Playermuving.player.Inthecatch();
            transform.eulerAngles = new Vector3(0, 120, 0);
        }
       
    }
    public IEnumerator alowcalltheactact()
    {
        alowcallhere = false;
        yield return new WaitForSeconds(0.1f);
        alowcallhere = true;
    }

    /// <summary>
    /// Reload initial coordinates
    /// </summary>
    public void ResutTranformemty()
    {
        folow.distance = 10;
        IkEmty.iklegth = 0;
        IkEmty.iklegth1 = 0;
        folow.height1 = 0;
        transform.eulerAngles = new Vector3(0, 0, 0);
        amin.SetBool("cut", false);  // Run animation catching main character
    }


    /// <summary>
    /// Exit all states when having item
    /// </summary>
    /// <param name="m"> Save</param>
    public void exittheactack()
    {
        isfolowplayer = false;
        die = 0;
        con.SetActive(false);

    }
     // Update is called once per frame
    void Update () {
      //  Debug.Log("cheets "+die);
        if (isactac)
        {
            if (transform.position.z < playertaget.transform.position.z-2.5f)
            {
             // transform.Translate(new Vector3(0,0,8*Time.deltaTime));
            }
            if (transform.position.z >= playertaget.transform.position.z - 2f)
            {
                amin.SetBool("play", false);
                isactac = false;
            }
        }
       
	}

    /// <summary>
    /// Set jump up animation
    /// </summary>
    public void jump()
    {
        amin.SetBool("jump", true);
    }
    public void ExitJump()
    {
        amin.SetBool("jump", false);
    }
   
    public void OnthePause()
    {
        amin.enabled = false;
    }
    public void OntheResume()
    {
        amin.enabled = true;
    }
}
