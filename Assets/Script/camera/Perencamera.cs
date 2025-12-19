using UnityEngine;
using System.Collections;

public class Perencamera : MonoBehaviour {

     public static Perencamera managerscen;
    // Use this for initialization
    void Start () {
     

        managerscen = this;
        amin = GetComponent<Animator>();
        // Disable camera animator at start to prevent start animation
        if (amin != null)
        {
            amin.enabled = false;
        }
        alow = true;
        isfolowwenstartnew = false;
        distance = 5;
        isfolowsoll = true;
        heightDamping2 = 3;
       // Soundmanager.soundmanager.PlayBackgroudSound();
        
    }
	
	// Update is called once per frame
	void Update () {
     // Debug.Log(Manageritem.baylongcoin);
    }
    public Transform target; // Target to follow
    float distance = 10f; // Distance x - z with player
    public float height = 0f;   // Height distance with player on y axis
    public  float height1 = 0f; // Horizontal distance with player on x axis
    float height2 = -5f; // Horizontal distance with player on z axis
    public static float heightDamping = 2.0f; // Follow delay on y axis
    public float heightDamping1 = 2.0f; // Follow delay on z axis
    public static float heightDamping2 = 3f; // Follow delay on z axis
    public float rotationDamping = 3.0f; // Follow delay rotation angle
    float wantedRotationAngle;
    float wantedHeight;
    float wantedHeight1;
    float wantedHeight2;
    float currentRotationAngle;
    float currentHeight;
    float currentHeight1;
    float currentHeight2;
    void LateUpdate()
    {
     
        if (Playermuving.player&& Playermuving.isplay)   
        {
            if (!target)
                return;
            
                if (isfolowwenstartnew)
                {
                    if (Manageritem.baycoin == false && Manageritem.baylongcoin == false)
                    {
                        if (Playermuving.player.gameObject.transform.position.y > 5)
                        {
                            height = 2;
                        }
                        else if (Playermuving.player.gameObject.transform.position.y <= 5 && Playermuving.player.gameObject.transform.position.y >= 4)
                        {
                            height = 3;
                        }
                    }
                      wantedRotationAngle = target.eulerAngles.y;
                      wantedHeight = target.position.y + height;
                      wantedHeight1 = target.position.x + height1;
                      wantedHeight2 = target.position.z + height2;
                      currentRotationAngle = transform.eulerAngles.y;
                      currentHeight = transform.position.y;
                      currentHeight1 = transform.position.x;
                      currentHeight2 = transform.position.z;
                    currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);
                    currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);
                    currentHeight1 = Mathf.Lerp(currentHeight1, wantedHeight1, heightDamping1 * Time.deltaTime);
                    currentHeight2 = Mathf.Lerp(currentHeight2, wantedHeight2, heightDamping2 * Time.deltaTime);
                    if (isfolowsoll)
                    {
                        transform.position = new Vector3(currentHeight1, currentHeight, currentHeight2);
                    }
                    else if (isfolowsoll == false)
                    {
                    transform.position = new Vector3(currentHeight1, currentHeight, target.position.z - distance);
                    
                }
                }
              
          }
        }
        Animator amin;

    public void GetItemFly()
    {
        heightDamping = 1;
       // isfolowsoll = true;
    }
    public void DeleteIItemFly()
    {
        StartCoroutine(delay());
    }

   public IEnumerator delayfolowcameradie()
    {
 
        yield return new WaitForSeconds(1);
    }
    IEnumerator delay()
    {
        yield return new WaitForSeconds(2);
        heightDamping = 5;
        //isfolowsoll = false;

    }
    /// <summary>
    /// Lock camera rotation state
    /// </summary>
    public void locktheagain()
    {
        amin.SetBool("again", false);
    }
    bool isfolowsoll;
    public static bool isfolowwenstartnew;
    /// <summary>
    /// Start playing
    /// </summary>
    public void playallgame()
    {
        if (alow)
        {
            Perencamera.managerscen.height = 3;
            amin = GetComponent<Animator>();
            // Enable animator for gameplay camera following
            if (amin != null)
            {
                amin.enabled = true;
            }
 
          Playermuving.player.intheplaysceenmain();
        
            if (emty.emtyplayer != null)
        {
            emty.emtyplayer.StartCoroutine(emty.emtyplayer.animationrunplay());
        }
      
            StartCoroutine(delaydisball());
            StartCoroutine(checkstart());
            alow = false;
        }
    }
    public bool alow;

    IEnumerator folowTaget()
    {
        if (Playermuving.player.gameObject.transform.position.z <10)
        {
            for (int i = 0; i < 100; i++)
            {
                yield return new WaitForSeconds(0.002f);
                if (Playermuving.speedmuving <= 15)
                {
                    Playermuving.speedmuving += 1;
                }

                if (heightDamping2 <= 25)
                {
                    heightDamping2 += 1f;
                    if (heightDamping2 == 20)
                    {
                        isfolowsoll = false;
                        heightDamping2 = 20;
                        break;
                    }
                }
            }
        }
        else
        {
        
            Playermuving.player.gameObject.transform.Translate(0,0,-5);
            transform.Translate(0,0,-7);
            distance = 15;

            for (int i = 0; i < 100; i++)
            {
                yield return new WaitForSeconds(0.001f);
                distance -= 0.1f;
            }
        }
        
    }


   IEnumerable delayfolowwendie()
    {
        for (int i = 0; i < 100; i++)
        {
            yield return new WaitForSeconds(0.01f);
        }
    }
    /// <summary>
    /// Fix camera blur bug
    /// </summary>
    /// <returns></returns>
    IEnumerator delaydisball()
    {
        //Soundmanager.soundmanager.PlayPoliceSound();
          Time.timeScale = 0.8f;
        if (PlayerPrefs.HasKey("hd") == false)
        {
            Time.timeScale = 0.6f;
        }
        StartCoroutine(folowTaget());
        UImanager.coinforuplv = 1000;
        yield return new WaitForSeconds(1.5f);
        amin.enabled = false;
        alow = true;
        yield return new WaitForSeconds(3);
      //  Soundmanager.soundmanager.PlayBackgroudSound();
    }

    IEnumerator checkstart()
    {
        isfolowwenstartnew = true;
        for (int i = 0; i < 100; i++)
        {
            yield return new WaitForSeconds(0.005f);
            if (Playermuving.isstartnow)
            {
                Playermuving.isplay = true;
                break;
            }
        }
    }
    public GameObject EffctsFly;
   public void HidemapItro()
    {
        mapitro.instance.HidemapItro();
    }

  public   void ShowEffcts(bool value)
    {
        if (value)
        {
            EffctsFly.SetActive(true);
        }
        else
        {
            EffctsFly.SetActive(false);
        }
    }

    public void OpenUIAnimation()
    {
        UImanager.uimanager.GetComponent<Animator>().enabled = true;
    }
}
