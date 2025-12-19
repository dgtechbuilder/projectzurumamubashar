using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
/// <summary>
/// Class manages all UI menu systems, items and data
/// </summary>
public class UImanager : MonoBehaviour
{

    public static UImanager instance;

    
   
    [Header("Main Menu Coins Text")]
    public List<TextMeshProUGUI> MenuCoinsText;
    public List<TextMeshProUGUI> MenuSwordText;

    /// <summary>
    /// Update all coin text displays in MenuCoinsText list and CollectedCoins
    /// </summary>
    public void UpdateAllCoinsText()
    {
        int currentCoins = PlayerEconomyManager.GetCoins();
        foreach (TextMeshProUGUI coinText in MenuCoinsText)
        {
            if (coinText != null)
            {
                coinText.text = currentCoins.ToString();
            }
        }
        int currentSwords  = PlayerEconomyManager.GetSwords();
        foreach(TextMeshProUGUI sowrdText in  MenuSwordText)
        {
            if(sowrdText != null)
            {
                sowrdText.text = currentSwords.ToString();
            }
        }
    }
    [Header("Total Collected Coins ")]


    
    public TextMeshProUGUI CollectedCoins;
    public GameObject showPlayeronlost;
    // public GameObject Evensystem;
    public TMP_Text cointxt;
    public Button btnplay;
    // Panels in the game over UI
    public TMP_Text yourcoinmuving; // Your record distance score
    public TMP_Text yourcoinmuvingnow; // Your current score
    public TMP_Text yourcoin; // Your total coins
    public TMP_Text yourcoinnow; // Coins from current play session
    public Text yourkeytxt; // Keys
    public Button showbotton; // Play again button
    // Maximum high score
    public Text newsoccoretxt; // Display new high score
    // Show keys
    public Text yourkey;  // Number of keys you currently have
    public Text yourkeyneed;  // Number of keys needed for this revival
    int needkey = 0; // Number of keys needed for this revival
    bool Closebox = true;
    public GameObject showieffcts;
    public TMP_Text coinmain;
    bool alowopen = true;
    float Slidertimerdowload;  // Timer slider value
    public static int coinmuving;
   
    public static int coin;
    
    public Animator amin;
    public GameObject camerafolow;
    public static UImanager uimanager;


    // Display panels
    public GameObject paneloading;
    public GameObject panellost;
    public GameObject panellos2;
    public GameObject panelseleckey;
    public GameObject panelcoin;
    public GameObject newcoinmaxmung;
    public GameObject panelshowitem;
    public GameObject panel_Earm_Coin;
    public GameObject panel_main_shop;
    // Timer sliders
    public Slider timerforkey;
    public Slider Ontheloading;
    public Slider timer;
    public Slider timeriteam;
    public Slider timeriteamhut;
    public Slider timeriteamx2;
    public Slider timeriteamgiay;
    public Slider timeriteambay;


    // Panels containing sliders
    public GameObject panelslidervan;
    public GameObject panelsliderhut;
    public GameObject panelsliderx2;
    public GameObject panelslidergiay;
    public GameObject panelsliderbay;
    // public GameObject btnitemfly;
    private int checkthedie;


    public static bool selectkey;
    public TMP_Text showhighscoreinpanellost;

    public Text ShowHighscor3D;
    // Use this for initialization
    public int frameRate = 60;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
            //yourcoinnow.transform.SetSiblingIndex(1);
            Application.targetFrameRate = frameRate;
    }


    public static void NextScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void AfterFreeSowrd()
    {
        Time.timeScale = 1f;
        panellost.SetActive(false);
        panellos2.SetActive(true);
        UpdateAllCoinsText();
    }
    void Start()
    {

        ShowHighscor3D.text = managerdata.manager.getmuving().ToString();
        if (managerdata.manager.getmuving() == 0)
        {
            ShowHighscor3D.text = "High score";
            showwhisthighscore.text = managerdata.manager.getmuving().ToString();
        }
        SetingInStart();
        if (LogInFb)
        {
            SetImageAvatarFAb();
        }
        getvan = true;
        Closebox = true;

        //  PlayerPrefs.DeleteAll();
      //  Coins.text = managerdata.manager.getmuving().ToString();
      //  coins2.text = managerdata.manager.getmuving().ToString();
      
        // Update all coin text displays on start
        UpdateAllCoinsText();

    }


    public TMP_Text Coins;
    public TMP_Text coins2;
    public void SetingInStart()
    {
        yourkey.text = managerdata.manager.getkey().ToString();
        coin = 0;
        coinmuving = 0;
        coinsAddedAtGameOver = false; // Reset flag for new game
        amin = camerafolow.gameObject.GetComponent<Animator>();
        uimanager = this;
        // Disable all item timers
        panellost.gameObject.SetActive(false);
        panelseleckey.gameObject.SetActive(false);
        timeriteam.gameObject.SetActive(false);
        timeriteamhut.gameObject.SetActive(false);
        timeriteamx2.gameObject.SetActive(false);
        timeriteamgiay.gameObject.SetActive(false);
        timeriteambay.gameObject.SetActive(false);
        panelcoin.SetActive(false);
        paneloading.gameObject.SetActive(true);
        StartCoroutine(Loadingonthestart());
        alowcall = true;
        selectkey = false;
        showthenewsocore = false;
        newcoinmaxmung.gameObject.SetActive(false);
        panelbox.gameObject.SetActive(false);
        calll = true;
        btnplay.gameObject.SetActive(true);
        CloseShop();
        buyitemboxintheshop = false;
        showitembuyflylong();

        btnitemfly.gameObject.SetActive(false);
    }
    public void Again()
    {
        yourkey.text = managerdata.manager.getkey().ToString();
        coin = 0;
        coinmuving = 0;
        amin = camerafolow.gameObject.GetComponent<Animator>();
        uimanager = this;
        // Disable all item timers
        panellost.gameObject.SetActive(false);
        panelseleckey.gameObject.SetActive(false);
        timeriteam.gameObject.SetActive(false);
        timeriteamhut.gameObject.SetActive(false);
        timeriteamx2.gameObject.SetActive(false);
        timeriteamgiay.gameObject.SetActive(false);
        timeriteambay.gameObject.SetActive(false);
        panelcoin.SetActive(false);
        paneloading.gameObject.SetActive(false);
        panelmain.SetActive(true);
        alowcall = true;
        selectkey = false;
        showthenewsocore = false;
        newcoinmaxmung.gameObject.SetActive(false);
        calll = true;
        btnplay.gameObject.SetActive(true);
        CloseShop();
        buyitemboxintheshop = false;
        showitembuyflylong();
        btnitemfly.gameObject.SetActive(false);
    }
    /// <summary>
    /// Play again
    /// </summary>
    /// 

    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void playAgain()
    {
        if (calll)
        {
            BtnPause.gameObject.SetActive(true);

            //  Evensystem.SetActive(false);
            Playermuving.player.GetComponent<CapsuleCollider>().center = new Vector3(0, -0.08f, 0);
            Playermuving.player.GetComponent<CapsuleCollider>().radius = 0.46f;
            Playermuving.player.GetComponent<CapsuleCollider>().height = 1.77f;
            showPlayeronlost.SetActive(false);
            Time.timeScale = 0.8F;
            Playermuving.speedmuving = 15;
            inthepanelpause.playagain = true;
            // GoogleMobileAdsScript.Instance.showbaner();
            Playagainshowhide.gameObject.SetActive(false);
            calll = false;
            coin = 0;
            coinmuving = 0;
            coinsAddedAtGameOver = false; // Reset flag for new game
            panellost.gameObject.SetActive(false);
            panelseleckey.gameObject.SetActive(false);
            timeriteam.gameObject.SetActive(false);
            paneloading.gameObject.SetActive(false);
            Perencamera.managerscen.playallgame();
            // Camerafolow.camfolowplayer.Intanceectff(); // Create effect
            StartCoroutine(playagain());
            showitembuyflylong();
            emty.emtyplayer.ResutTranformemty();

        }

    }
    public Button Playagainshowhide;
    bool calll;
    /// <summary>
    /// Fix animation not running bug
    /// </summary>
    /// <returns></returns>
    IEnumerator playagain()
    {
        Playermuving.isplay = true;
        yield return new WaitForSeconds(0.5f);
        calll = true;
        Playermuving.player.clicontheplayagainseleckey();
        showitembuyflylong();
        OnOpenFlyAgain();
        for (int j = 0; j < 4; j++)
        {
            yield return new WaitForSeconds(0.5f);
            Playermuving.player.clicontheplayagainseleckey(); // Reload animation
        }
        Playagainshowhide.gameObject.SetActive(true);
        StartCoroutine(timerforshowbtnitem()); // Delay 5s to hide fly button

    }

    /// <summary>
    /// Load map
    /// </summary>
    /// <returns></returns>
    IEnumerator Loadingonthestart()
    {
        paneloading.gameObject.SetActive(true);
        awakemainmenu();
        panelmain.SetActive(false);
        for (int i = 0; i < 100; i++)
        {
            yield return new WaitForSeconds(0.05f);
            Ontheloading.value = i;
            if (i == 99)
            {
                paneloading.gameObject.SetActive(false);
                // Camera animation removed - UI appears immediately after loading
                // Perencamera.managerscen.GetComponent<Animator>().enabled = true;
                Soundmanager.soundmanager.PlayBackgroudSound();
                awakemainmenu();

            }
        }
    }

    /// <summary>
    /// timer test
    /// </summary>
	public void Ontherchangetimer()
    {
        Slidertimerdowload = timer.value;
        Slidertimerdowload = Slidertimerdowload / 100;
        Time.timeScale = Slidertimerdowload;

    }
    public GameObject UIHowToPlay;

    /// <summary>
    /// Start playing
    /// </summary>
    public void play()
    {
        panelcoin.SetActive(true);
        panelmain.SetActive(false);
        StartCoroutine(Playdelay());
        Soundmanager.soundmanager.PlayPoliceSound();
        // Evensystem.SetActive(false);
    }

    IEnumerator Playdelay()
    {
        mapitro.instance.Muvingship();
        emty.emtyplayer.StartCoroutine(emty.emtyplayer.intheplay());
        yield return new WaitForSeconds(0.3f);
        // Debug.Log("play again");
        // Enable animator before setting bool (needed for camera following)
        Perencamera.managerscen.GetComponent<Animator>().enabled = true;
        Perencamera.managerscen.GetComponent<Animator>().SetBool("play", true);
        folow.distance = 10;
        yield return new WaitForSeconds(0.5f);
        Playermuving.isplay = true;
        Playermuving.speedmuving = 5;
        // GoogleMobileAdsScript.Instance.showbaner();
        if (PlayerPrefs.HasKey("hd") == false)
        {
            UIHowToPlay.SetActive(true);
        }
        btnitemfly.gameObject.GetComponent<Image>().enabled = false;
        btnitemfly.gameObject.GetComponent<Button>().enabled = false;
        Playermuving.player.muvingtomodelonthestart(); // Move model towards center coordinates
        showitembuyflylong();
        amin.SetBool("play", true);
        amin.SetBool("again", false);
        btnplay.gameObject.SetActive(false);
        emty.emtyplayer.actac();
        emty.emtyplayer.animationrunplay();
        emty.die = 1;
        btnplay.gameObject.SetActive(false);
        if (managerdata.manager.GetFly() >= 1)
        {
            yield return new WaitForSeconds(2f);
            btnitemfly.gameObject.GetComponent<Image>().enabled = true;
            btnitemfly.gameObject.GetComponent<Button>().enabled = true;
            btnitemfly.gameObject.SetActive(true);
            CountItemFly.text = managerdata.manager.GetFly().ToString();
            StartCoroutine(timerforshowbtnitem());
        }

    }


    #region Slider system


    /// <summary>
    /// Timer for skateboard item
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public IEnumerator delayslideritem(int value, string nameitem)
    {


        if (Manageritem.van == false)
        {
            Manageritem.van = true;
            timeriteam.gameObject.SetActive(true);
            panelslidervan.SetActive(true);
            timeriteam.maxValue = 300;
            int vl = 0;
            timeriteam.value = vl;
            for (int i = 0; i < 300; i++)
            {
                timeriteam.gameObject.GetComponent<Slider>().enabled = true;
                timeriteam.gameObject.SetActive(true);
                panelslidervan.SetActive(true);
                vl++;
                timeriteam.value = vl;
                yield return new WaitForSeconds(0.1f);
                if (Manageritem.van == false || Manageritem.baylongcoin == true)
                {
                    timeriteam.gameObject.SetActive(false);
                    panelslidervan.SetActive(false);
                    if (alowdelay)
                    {
                        Playermuving.player.stopanimationitem("van", "van");
                    }

                    break;
                }
            }
            panelslidervan.SetActive(false);
            timeriteam.gameObject.SetActive(false);
            if (alowdelay)
            {
                Playermuving.player.stopanimationitem("van", "van");
            }
        }
        else
        {

            alowdelay = false;
            Manageritem.van = false;
            yield return new WaitForSeconds(0.2f);
            alowdelay = true;

            StartCoroutine(delayslideritem(1, ""));
            Playermuving.player.setalowvan();
        }

    }
    bool alowdelay = true;
    int Getvalueslider(int value)
    {
        int valueoffitem = 10;
        valueoffitem = valueoffitem + value * 3;
        valueoffitem = valueoffitem * 10;
        return valueoffitem;

    }
    int valuex2;

    /// <summary>
    /// Timer for coin magnet item that attracts coins towards player
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public IEnumerator delayslideritemhut(int value)
    {
        Debug.Log(timeriteamhut.maxValue);
        if (Manageritem.hutcoin == false)
        {
            Manageritem.hutcoin = true;
            timeriteamhut.gameObject.SetActive(true);
            panelsliderhut.gameObject.SetActive(true);
            timeriteamhut.maxValue = Getvalueslider(managerdata.manager.GetDataItemMagnet());
            timeriteamhut.value = 0;
            timeriteamhut.gameObject.GetComponent<Slider>().enabled = true;
            valuex2 = 0;
            for (int i = 0; i < timeriteamhut.maxValue; i++)
            {
                valuex2++;
                timeriteamhut.value = valuex2;
                yield return new WaitForSeconds(0.1f);
                if (Manageritem.hutcoin == false)
                {
                    panelsliderhut.gameObject.SetActive(false);
                    timeriteamhut.gameObject.SetActive(false);
                    break;
                }
            }
            timeriteamhut.gameObject.SetActive(false);
            panelsliderhut.gameObject.SetActive(false);
            Playermuving.player.stopanimationitem("hutcoin", "hutcoin");
        }
        else
        {
            Manageritem.hutcoin = false;
            yield return new WaitForSeconds(0.2f);
            Playermuving.player.GetIkmagnet();
            StartCoroutine(delayslideritemhut(1));
        }
    }

    /// <summary>
    /// Timer for x2 coin item
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public IEnumerator delayslideritemx2(int value)
    {
        if (Manageritem.x2coin == false)
        {


            Manageritem.x2coin = true;
            timeriteamx2.gameObject.SetActive(true);
            panelsliderx2.gameObject.SetActive(true);
            //timeriteamx2.maxValue = value * 5;
            timeriteamx2.maxValue = Getvalueslider(managerdata.manager.GetDataItemX2());
            timeriteamx2.value = 0;
            int vl = 0;
            timeriteamx2.value = vl;
            for (int i = 0; i < timeriteamx2.maxValue; i++)
            {
                timeriteamx2.gameObject.GetComponent<Slider>().enabled = true;

                vl++;
                timeriteamx2.value = vl;
                if (Manageritem.x2coin == false)
                {
                    panelsliderx2.gameObject.SetActive(false);
                    break;
                }
                yield return new WaitForSeconds(0.1f);
            }
            panelsliderx2.gameObject.SetActive(false);
            timeriteamx2.gameObject.SetActive(false);
            Playermuving.player.stopanimationitem("x2coin", "x2coin");
        }
        else if (Manageritem.x2coin)
        {
            Manageritem.x2coin = false;
            yield return new WaitForSeconds(0.2f);
            StartCoroutine(delayslideritemx2(1));

        }


    }

    /// <summary>
    /// Timer for shoes item
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public IEnumerator delayslideritemgiay(int value)
    {
        if (Manageritem.giay == false)
        {
            Manageritem.giay = true;
            timeriteamgiay.gameObject.SetActive(true);
            panelslidergiay.gameObject.SetActive(true);
            timeriteamgiay.maxValue = Getvalueslider(managerdata.manager.GetDataItemGiay());
            timeriteamgiay.value = 0;
            // timeriteamgiay.maxValue = value * 10;
            int vl = 0;
            timeriteamgiay.value = vl;
            for (int i = 0; i < timeriteamgiay.maxValue; i++)
            {
                timeriteamgiay.gameObject.GetComponent<Slider>().enabled = true;
                vl++;
                timeriteamgiay.value = vl;
                yield return new WaitForSeconds(0.1f);
                if (Manageritem.giay == false)
                {
                    panelslidergiay.gameObject.SetActive(false);
                    timeriteamgiay.gameObject.SetActive(false);
                    Playermuving.player.stopanimationitem("giay", "giay");
                    break;
                }
            }
            panelslidergiay.gameObject.SetActive(false);
            timeriteamgiay.gameObject.SetActive(false);
            Playermuving.player.stopanimationitem("giay", "giay");
        }
        else if (Manageritem.giay)
        {
            Manageritem.giay = false;
            yield return new WaitForSeconds(0.2f);
            Playermuving.player.GetGiay();
            StartCoroutine(delayslideritemgiay(1));

        }

    }


    /// <summary>
    /// Timer for long flight item
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public IEnumerator delayslideritembay(int value)
    {

        Perencamera.managerscen.GetItemFly();
        timeriteambay.gameObject.SetActive(true);
        panelsliderbay.gameObject.SetActive(true);
        timeriteambay.maxValue = 100 + managerdata.manager.GetDataItemFly() * 30;
        timeriteam.gameObject.SetActive(false);
        panelslidervan.SetActive(false);
        int vl = 0;
        timeriteambay.value = vl;
        for (int i = 0; i < timeriteambay.maxValue; i++)
        {
            if (inthepanelpause.fixFlylong)
            {
                yield return new WaitForSeconds(3);
                inthepanelpause.fixFlylong = false;
            }
            timeriteambay.gameObject.GetComponent<Slider>().enabled = true;
            vl++;
            timeriteambay.value = vl;
            yield return new WaitForSeconds(0.1f);
            if (Manageritem.baylongcoin == false)
            {
                panelsliderbay.gameObject.SetActive(false);
                timeriteambay.gameObject.SetActive(false);
                break;
            }
        }
        if (Manageritem.baylongcoin)
        {
            yield return new WaitForSeconds(3f);
            Playermuving.player.StartCoroutine(Playermuving.player.exitdelaydestroiitemlong());
        }
        timeriteambay.gameObject.SetActive(false);

    }

    #endregion
    bool alowcall;
    private bool showthenewsocore; // Variable to show new high score menu
    private bool coinsAddedAtGameOver = false; // Prevent adding coins multiple times

    /// <summary>
    /// Game over
    /// </summary>
    public void Lost()
    {
        // Prevent adding coins multiple times if Lost() is called more than once
        if (!coinsAddedAtGameOver && coin > 0)
        {
            coinsAddedAtGameOver = true;
            
            // Add collected coins to PlayerEconomyManager at game over
            // coin = total coins collected during this gameplay session
            Debug.Log($"[Lost] Adding {coin} coins to PlayerEconomyManager. Current total before: {PlayerEconomyManager.GetCoins()}");
            PlayerEconomyManager.AddCoins(coin);
            Debug.Log($"[Lost] Total after adding: {PlayerEconomyManager.GetCoins()}");
            
            // Sync managerdata with PlayerEconomyManager total
            int totalEconomyCoins = PlayerEconomyManager.GetCoins();
            PlayerPrefs.SetInt("coin", totalEconomyCoins);
            PlayerPrefs.Save();
            
            UpdateAllCoinsText();
        }
        else if (coinsAddedAtGameOver)
        {
            Debug.Log($"[Lost] Coins already added, skipping. coin value: {coin}");
        }

        if (coinmuving > managerdata.manager.getmuving())
        {
            newsoccoretxt.text = coinmuving.ToString();
            showthenewsocore = true;
        }
        if (PlayerPrefs.HasKey("hd") == false)
        {
            PlayerPrefs.SetInt("hd", 1);
            Makesupway.isnewgame = false;
        }

        PlayerPrefs.Save();
        managerdata.manager.savemuving(coinmuving);
        
        showhighscoreinpanellost.text = managerdata.manager.getmuving().ToString();
        if (alowcall)
        {
            alowcall = false;
            checkthedie++;
            yourkey.text = managerdata.manager.getkey().ToString();
            yourkeyneed.text = needkey.ToString();
            StartCoroutine(delayforAgain());
        }
    }
    int showbane = 0;
    public static bool getvan;
    IEnumerator Delayvankey()
    {
        getvan = false;
        yield return new WaitForSeconds(3);
        getvan = true;

    }

    public GameObject BtnPause;
    /// <summary>
    ///     
    /// </summary>
    /// <returns></returns>
    public IEnumerator delayforAgain()
    {
        yield return new WaitForSeconds(0.25f);
        panelseleckey.gameObject.SetActive(true);
        showbane++;
        Manageritem.mngitem.DeleteAllItemWendie();
        if (checkthedie > 2)
        {
            needkey = (int)(Mathf.Pow(2, checkthedie));
        }
        else if (checkthedie == 1)
        {
            needkey = 1;
        }
        else if (checkthedie == 2)
        {
            needkey = 2;
        }
        yourkeyneed.text = needkey.ToString();
        selectkey = false;
        Playermuving.player.Enterdieinfart();
        btnitemfly.gameObject.SetActive(false);
        panellost.gameObject.SetActive(false);
        DeleteAllSlider();
        for (int i = 0; i < 100; i++)
        {
            yield return new WaitForSeconds(0.001f);
            if (selectkey == true)
            {
                if (managerdata.manager.getkey() >= needkey)
                {
                    Soundmanager.soundmanager.PlayAgain();
                    if (getvan)
                    {
                        StartCoroutine(Delayvankey());
                    }
                    alowcall = true;
                    Playermuving.player.StartCoroutine(Playermuving.player.EffectWenHavaeItem());
                    Playermuving.player.OurtCut();
                    Makesupway.makemap.StartCoroutine(Makesupway.makemap.MuvingbackAllemtyWenhaveitemVan(false));
                    StartCoroutine(playnowintheseleckey());
                    Camerafolow.camfolowplayer.Intanceectff();
                    Playermuving.player.backtodie();
                    yourkey.text = managerdata.manager.getkey().ToString();
                    managerdata.manager.savekey(-needkey);
                    emty.emtyplayer.ResutTranformemty();
                    Perencamera.managerscen.height = 3;
                    break;
                }
                else if (managerdata.manager.getkey() < needkey)
                {
                    selectkey = false;
                    showNorinnapkey();
                }
            }
            timerforkey.value -= 1;
            if (i == 99)
            {
                goodCPU.intance.GetStartrotay(false);
                Camerafolow.camfolowplayer.gameObject.GetComponent<Camera>().farClipPlane = 3;
                Playermuving.player.OurtCut();
                // GoogleMobileAdsScript.Instance.hidebaner();
                inthepanelpause.playagain = true;
                if (showbane >= 2)
                {
                    // GoogleMobileAdsScript.Instance.showfullbaner();
                    showbane = 0;
                }
                if (selectkey == false)
                {
                    Playermuving.isplay = false;
                    needkey = 0;
                    checkthedie = 0;
                    coinforuplv = 5000;
                    Playermuving.player.StartCoroutine(Playermuving.player.playagain(0));
                    if (Manageritem.box == false)
                    {
                        if (Playermuving.isplay == false)
                        {
                            StartCoroutine(playopenmenumainsocore());
                        }
                    }
                    else if (Manageritem.box)
                    {
                        Time.timeScale = 1;
                        panelbox.SetActive(true);
                        openbox();
                        Manageritem.box = false;
                    }
                }
                if (showthenewsocore == false)
                {
                    panelseleckey.gameObject.SetActive(false);
                    BtnPause.gameObject.SetActive(false);
                }
                else if (Manageritem.box == false)
                {
                    // showPlayeronlost.SetActive(true);
                }
                BtnPause.gameObject.SetActive(false);
            }
        }
        yield return new WaitForSeconds(1);
        if (selectkey == false)
        {
            Perencamera.managerscen.StartCoroutine(Perencamera.managerscen.delayfolowcameradie());
        }
        alowcall = true;
        timerforkey.value = 100;
    }
    // Delete all item sliders
    void DeleteAllSlider()
    {
        timeriteam.enabled = false;  //
        timeriteamhut.enabled = false;
        timeriteamx2.enabled = false;
        timeriteamgiay.enabled = false;
        timeriteambay.enabled = false;
    }
    // Show/hide key selection menu
    public GameObject notinapkey;
    public void showNorinnapkey()
    {
        notinapkey.SetActive(true);
    }
    public void OnMainMenuClicked()
    {
        panellost.SetActive(false);
        panelmain.SetActive(true);

        // Reset core gameplay values
        Time.timeScale = 1f;
        Playermuving.isplay = false;
        UImanager.coin = 0;
        UImanager.coinmuving = 0;

        // Optional: reset camera animation or move back to idle position
        camerafolow.GetComponent<Animator>().SetBool("play", false);
    }


    public void Hidenotinnapkey()
    {
        notinapkey.SetActive(false);
    }

    public static bool Playnowintheseleckey;
    /// <summary>
    /// Play immediately
    /// </summary>
    /// <returns></returns>
    private IEnumerator playnowintheseleckey()
    {
        Playnowintheseleckey = true;
        panelseleckey.gameObject.SetActive(false); // Hide key selection menu
        Playermuving.player.playnowthehere();
        Playnowintheseleckey = false;
        yield return new WaitForSeconds(0.5f);

    }

    /// <summary>
    /// Open new play menu
    /// </summary>
    /// <returns></returns>
    private IEnumerator playopenmenumainsocore()
    {
        if (showthenewsocore == false)
        {
            Playermuving.isplay = false;
            panellost.gameObject.SetActive(true);
            yield return new WaitForSeconds(1);
            yourcoinmuving.text = managerdata.manager.getmuving().ToString(); // Maximum distance
            StartCoroutine(delayforcoinmuving(coinmuving, coin));
            yourcoinmuving.text = managerdata.manager.getmuving().ToString();
            yourcoin.text = managerdata.manager.Getcoin().ToString();
            Debug.Log("Coins " + managerdata.manager.Getcoin());
            yourkeytxt.text = managerdata.manager.getkey().ToString();
            coinmuving = 0;
            coin = 0;
            if (coinmuving >= managerdata.manager.getmuving())
            {
                managerdata.manager.savemuving(coinmuving);
            }
            add = 1;
            // fb.checkloging.checkLogin(); 
        }
        else if (showthenewsocore)
        {
            Playermuving.isplay = false;
            Soundmanager.soundmanager.PlaynewHighscore();
            newcoinmaxmung.gameObject.SetActive(true);
            LoaDingcharacterOnshowNewHideSocore();
            showthenewsocore = false;
        }
        panelseleckey.gameObject.SetActive(false);
        yield return new WaitForSeconds(1);
        alowcall = true;

        Playagainshowhide.gameObject.SetActive(true);
        notinapkey.SetActive(false);

    }
    public void tabtabcontinued()
    {
        StartCoroutine(taptocontinuedinthenewsocore());
    }
    public void GetAllValueToPanelCoinLost()
    {
        yourcoin.text = managerdata.manager.Getcoin().ToString();
        yourkeytxt.text = managerdata.manager.getkey().ToString();
    }
    public Transform Lischaracter;
    List<GameObject> showlisChaRacTer = new List<GameObject>();
    public GameObject opennewHideSocore;
    /// <summary>
    /// Load character to display when showing high score
    /// </summary>
    void LoaDingcharacterOnshowNewHideSocore()
    {
        Playermuving.isplay = false;
        panelcoin.SetActive(false); // Hide coins
        opennewHideSocore.gameObject.SetActive(true);
        foreach (Transform item in Lischaracter)
        {
            showlisChaRacTer.Add(item.gameObject);
        }

        // Get selected character index from managerdata
        int selectedIndex = managerdata.manager.GetSelectedCharacterIndex();

        // Ensure index is valid
        if (selectedIndex < 0 || selectedIndex >= showlisChaRacTer.Count)
        {
            selectedIndex = 0; // Default to first character if invalid
        }

        // Activate selected character, deactivate others
        for (int i = 0; i < showlisChaRacTer.Count; i++)
        {
            if (i == selectedIndex)
            {
                showlisChaRacTer[i].SetActive(true);
            }
            else
            {
                showlisChaRacTer[i].SetActive(false);
            }
        }
    }

    public void ShowCharacterLost(bool value)
    {
        if (value)
        {
            showPlayeronlost.SetActive(true);
        }
        else
        {
            showPlayeronlost.SetActive(false);

        }
    }
    /// <summary>
    /// Click to continue when achieving new high score
    /// </summary>
    public IEnumerator taptocontinuedinthenewsocore()
    {
        NewHighscore.newhigh.backtotranform();
        panelcoin.SetActive(true); // Show coins
        opennewHideSocore.gameObject.SetActive(false);
        newcoinmaxmung.gameObject.SetActive(false);
        panellost.gameObject.SetActive(true);
        // showPlayeronlost.SetActive(true);
        yield return new WaitForSeconds(1);
        yourcoinmuving.text = managerdata.manager.getmuving().ToString(); // Maximum distance
        StartCoroutine(delayforcoinmuving(coinmuving, coin));
        yourcoinmuving.text = managerdata.manager.getmuving().ToString();
        yourcoin.text = managerdata.manager.Getcoin().ToString();
        Debug.Log("Total Coins " + managerdata.manager.Getcoin());
        coinmuving = 0;
        coin = 0;
        panellost.gameObject.SetActive(true); // Show game over screen
        add = 1;
        if (coinmuving >= managerdata.manager.getmuving())
        {
            managerdata.manager.savemuving(coinmuving);
        }
        // fb.checkloging.checkLogin(); // Check Facebook menu
        //;
    }
    /// <summary>
    /// Coin and score increment animation effect
    /// </summary>
    /// <param name="value">Distance traveled</param>
    /// <param name="value1"></param>
    /// <returns></returns>
    private IEnumerator delayforcoinmuving(int value, int value1)
    {
        int valuefodelay = value / 20;
        int valuefodelay1 = value1 / 20;
        int valuefordelaysecon = 0;
        int valuefordelaysecon1 = 0;
        for (int i = 0; i < 20; i++)
        {
            yield return new WaitForSeconds(0.06f);
            valuefordelaysecon += valuefodelay;
            valuefordelaysecon1 += valuefodelay1;
            yourcoinmuvingnow.text = valuefordelaysecon.ToString();
            yourcoinnow.text = valuefordelaysecon1.ToString();
        }
        yourcoinmuvingnow.text = value.ToString();
        yourcoinnow.text = value1.ToString();
    }

    /// <summary>
    /// Select revival key
    /// </summary>
    public void ontheseleckey()
    {
        selectkey = true;
    }




    #region Animation management
    public GameObject panelbox;
    /// <summary>
    /// Show box
    /// </summary>
    public void openbox()
    {
        panelbox.SetActive(true);
        gameObject.GetComponent<Animator>().enabled = true;
        gameObject.GetComponent<Animator>().SetBool("box", true);
    }
    /// <summary>
    /// Open gift box
    /// </summary>
    public void tabtothebox()
    {
        if (alowopen)
        {
            alowopen = false;
            StartCoroutine(DelayforOpen());
            gameObject.GetComponent<Animator>().Play("mian", 0);
            gameObject.GetComponent<Animator>().SetBool("open", true);
            randumiteminthebox();
            showieffcts.SetActive(true);
        }
        Closebox = false;
        StartCoroutine(delayOpen());

    }

    IEnumerator DelayforOpen()
    {
        yield return new WaitForSeconds(5);
        alowopen = true;
    }
    /// <summary>
    /// Close gift box
    /// </summary>
    public void tabtoclosebox()
    {

        if (Closebox)
        {
            showieffcts.SetActive(false);

            gameObject.GetComponent<Animator>().SetBool("open", false);
            gameObject.GetComponent<Animator>().SetBool("box", false);
            yourrandumitembox.gameObject.SetActive(false);
            showtexbox.gameObject.SetActive(false);
            gameObject.GetComponent<Animator>().enabled = false;
            panelbox.SetActive(false);
            if (buyitemboxintheshop == false)
            {
                StartCoroutine(playopenmenumainsocore());
            }
            else if (buyitemboxintheshop)
            {
                buyitemboxintheshop = false;
            }
        }
    }
    IEnumerator delayOpen()
    {
        yield return new WaitForSeconds(2);
        Closebox = true;
    }
    #endregion




    /// <summary>
    /// Random gift contains: 500 coins, 1000 coins, 3 skateboards, or 1 revival key
    /// </summary>
    public void randumiteminthebox()
    {
        int ranitem = Random.Range(0, 4);
        int coin = 0;
        int itemvan = 0;
        int key = 0;
        switch (ranitem)
        {
            case 0:
                // 500 coins
                coin = 500;
                yourrandumitembox.text = "Get 500 coin";
                managerdata.manager.savecoin(coin);
                break;
            case 1:
                // 1000 coins
                coin = 1000;
                yourrandumitembox.text = "Get 1000 coin";
                managerdata.manager.savecoin(coin);
                break;
            case 2:
                // 3 skateboards
                itemvan = 3;
                yourrandumitembox.text = "x3 skateboard";
                managerdata.manager.savevan(itemvan);
                break;
            case 3:
                // 1 key
                key = 1;
                yourrandumitembox.text = "x1 Key revival";
                managerdata.manager.savekey(key);
                break;
            default:
                break;
        }
        yourrandumitembox.gameObject.SetActive(true);
        showtexbox.gameObject.SetActive(true);
        // onpenshop();
    }

    public Text yourrandumitembox;

    public Text showtexbox;

    /// <summary>
    /// Return to main menu
    /// </summary>
    public void gotohome()
    {
        // GoogleMobileAdsScript.Instance.hidebaner();
        Time.timeScale = 1;
        IkEmty.iklegth1 = 0;
        IkEmty.iklegth = 0;
        IKanimation.iklegth = 0;
        Playermuving.backnowmuvingship = true;
        Application.LoadLevel("mainlv");
    }


    #region Main menu settings





    /*************************

    Main menu

    ***************************/

    void awakemainmenu()
    {
        showbuyvaninthemain.SetActive(false);
        showsetting.SetActive(false);
        panelmain.SetActive(true);
        showvan.text = managerdata.manager.getvan().ToString();
        showvan1.text = managerdata.manager.getvan().ToString();
        showcoin.text = managerdata.manager.Getcoin().ToString();
        showkey.text = managerdata.manager.getkey().ToString();
    }
    public Text showvan, showvan1, showcoin, showkey;
    public GameObject showbuyvaninthemain, showsetting;
    public GameObject panelmain;
    public Image notshowsound;
    public Text showsown;
    /// <summary>
    /// Click on buy skateboard button
    /// </summary>
    public void openbuyvan()
    {
        showbuyvaninthemain.SetActive(true);
    }


    /// <summary>
    /// Click to buy
    /// </summary>
    public void clicthebtnbuyvan()
    {
        if (managerdata.manager.Getcoin() >= 300)
        {
            managerdata.manager.savecoin(-300);
            managerdata.manager.savevan(1);
            showvan.text = managerdata.manager.getvan().ToString();
            showvan1.text = managerdata.manager.getvan().ToString();
            showcoin.text = managerdata.manager.Getcoin().ToString();
            showkey.text = managerdata.manager.getkey().ToString();
        }
    }


    /// <summary>
    /// Close buy skateboard menu
    /// </summary>
    public void closebuyvan()
    {
        showbuyvaninthemain.SetActive(false);
    }

    /// <summary>
    /// Open settings menu
    /// </summary>
    public void cliconthesetting()
    {
        if (managerdata.manager.getsetting() == 0)
        {
            notshowsound.gameObject.SetActive(true);
            showsown.text = "Sound OFF";
            // Call sound off function here
        }
        else if (managerdata.manager.getsetting() == 1)
        {
            notshowsound.gameObject.SetActive(false);
            showsown.text = "Sound On";
            // Call sound on function here

        }

        showsetting.SetActive(true);

    }


    /// <summary>
    /// Close settings menu
    /// </summary>
    public void closeonthesetting()
    {
        showsetting.SetActive(false);
        if (inthepanelpause.ispause)
        {
            inthepanelpause.pauses.closemenuseting();
        }

    }
    /// <summary>
    /// Change sound settings - call sound toggle function here
    /// </summary>
    public void changesound()
    {


        if (managerdata.manager.getsetting() == 0)
        {
            managerdata.manager.savesetting(1);
        }
        else if (managerdata.manager.getsetting() == 1)
        {
            managerdata.manager.savesetting(0);

        }
        if (managerdata.manager.getsetting() == 0)
        {
            notshowsound.gameObject.SetActive(true);
            showsown.text = "Sound OFF";
            // Call sound off function here
        }
        else if (managerdata.manager.getsetting() == 1)
        {
            notshowsound.gameObject.SetActive(false);
            showsown.text = "Sound On";
        }

        Soundmanager.soundmanager.PlayBackgroudSound();
    }

    public void LoadDataSound()
    {
        if (managerdata.manager.getsetting() == 0)
        {
            notshowsound.gameObject.SetActive(true);
            showsown.text = "Sound OFF";
        }
        else if (managerdata.manager.getsetting() == 1)
        {
            notshowsound.gameObject.SetActive(false);
            showsown.text = "Sound On";
        }
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    /**************************

        Shop menu

    ***************************/
    public GameObject shoppanel; // Panel containing entire shop
    public Text txtkeyinshop, txtcoininshop;  // Coins and score
    public Text counHoverboard;  // Number of skateboards in skateboard banner
    public Image imgHoverboard; // Skateboard menu
    public Image MysteryBox; // Gift box menu
    public Image imgheadstart; // Flight item menu
    bool buyitemboxintheshop; // Distinguish between purchased gift box and free gift box
    ILayoutElement layout;
    Animator layoutamin;

    public Button btnitemfly;

    /// <summary>
    /// Open shop menu when in main menu
    /// </summary>
    public void onpenshop()
    {
        loaditem();
        shoppanel.SetActive(true);
        panel_Earm_Coin.SetActive(false);
        panel_main_shop.SetActive(true);
        txtkeyinshop.text = managerdata.manager.getkey().ToString();
        txtcoininshop.text = managerdata.manager.Getcoin().ToString();
        counHoverboard.text = "You have " + managerdata.manager.getvan().ToString();
        showyouhaveHeadstar.text = "You have" + managerdata.manager.GetFly();
    }
    public Text showtextog_facebook;
    /// <summary>
    /// Open shop menu when in main menu
    /// </summary>
    public void onpenshopEarm()
    {
        if (PlayerPrefs.GetInt("alowgetcoin") != 1)
        {
            showtextog_facebook.text = "Login to get coins";
        }

        else
        {
            showtextog_facebook.text = "You got";
        }
        loaditem();
        shoppanel.SetActive(true);
        panel_Earm_Coin.SetActive(true);
        panel_main_shop.SetActive(false);
        txtkeyinshop.text = managerdata.manager.getkey().ToString();
        txtcoininshop.text = managerdata.manager.Getcoin().ToString();
        counHoverboard.text = "You have " + managerdata.manager.getvan().ToString();
        showyouhaveHeadstar.text = "You have" + managerdata.manager.GetFly();


    }


    /// <summary>
    /// Close shop
    /// </summary>
    public void CloseShop()
    {
        shoppanel.SetActive(false);
    }
    /// <summary>
    /// Open expanded buy skateboard menu
    /// </summary>
    public void OpenBigMenuHoverboard()
    {
        setanimation(imgHoverboard);

    }
    /// <summary>
    /// Open expanded buy gift box menu
    /// </summary>
    public void OpenBigMenuMysteryBox()
    {
        setanimation(MysteryBox);
    }

    /// <summary>
    /// Open expanded buy flight item menu
    /// </summary>
    public void OpenBigMenuHeadstart()
    {
        setanimation(imgheadstart);
    }

    /// <summary>
    /// Set animations when opening
    /// </summary>
    /// <param name="animation"></param>
    private void setanimation(Image animation)
    {
        if (layoutamin != null)
        {
            layoutamin.SetBool("close", true);
            layoutamin.SetBool("open", false);
        }
        layoutamin = animation.GetComponent<Animator>();
        layoutamin.SetBool("open", true);
        layoutamin.SetBool("close", false);
    }

    /// <summary>
    /// Buy skateboard in shop
    /// </summary>
    public void ClicBuyHoverboardInShop()
    {
        if (managerdata.manager.Getcoin() >= 300)
        {
            managerdata.manager.savecoin(-300);
            managerdata.manager.savevan(1);
            txtkeyinshop.text = managerdata.manager.getkey().ToString();
            txtcoininshop.text = managerdata.manager.Getcoin().ToString();
            counHoverboard.text = "You have : " + managerdata.manager.getvan().ToString();
        }

    }

    /// <summary>
    /// Buy gift box in shop
    /// </summary>
    public void ClicBuyMysteryBox()
    {
        if (managerdata.manager.Getcoin() >= 500)
        {

            managerdata.manager.savecoin(-500);
            txtkeyinshop.text = managerdata.manager.getkey().ToString();
            txtcoininshop.text = managerdata.manager.Getcoin().ToString();
            buyitemboxintheshop = true;
            openbox();
        }

    }
    /// <summary>
    /// Show item when starting to play
    /// </summary>
    public void showitembuyflylong()
    {

        if (managerdata.manager.GetFly() > 0)
        {
            btnitemfly.gameObject.SetActive(true);
            if (Playermuving.player.gameObject.transform.position.z > 10)
            {
                btnitemfly.gameObject.GetComponent<Image>().enabled = true;
                btnitemfly.gameObject.GetComponent<Button>().enabled = true;
            }
            btnitemfly.gameObject.SetActive(true);
        }
        else if (managerdata.manager.GetFly() <= 0)
        {
            btnitemfly.gameObject.SetActive(false);

        }
        CountItemFly.text = managerdata.manager.GetFly().ToString();
    }

    /// <summary>
    /// Time to show item
    /// </summary>
    /// <returns></returns>
    IEnumerator timerforshowbtnitem()
    {
        yield return new WaitForSeconds(3);
        btnitemfly.gameObject.SetActive(false);
    }


    public Text CountItemFly;
    /// <summary> 
    /// Select flight item to fly at start of game
    /// </summary>
    public void ClicOnFly()
    {
        if (delayforgetitemfly)
        {
            if (Playermuving.isplay)
            {
                Perencamera.managerscen.ShowEffcts(true);
                delayforgetitemfly = false;
                StartCoroutine(GetFlyItem());
                Manageritem.usingbayitembuy = true;
                Makesupway.makemap.StartCoroutine(Makesupway.makemap.createcoinforitemflylong(Playermuving.player.gameObject.transform.position.z + 40));
                panelshowitem.GetComponent<Animator>().SetBool("clic", true);
                managerdata.manager.SaveFly(-1);
                Playermuving.player.StartCoroutine(Playermuving.player.delaydestroiitemlong());
                CountItemFly.text = managerdata.manager.GetFly().ToString();
            }

        }
    }
    bool delayforgetitemfly = true;
    IEnumerator GetFlyItem()
    {
        yield return new WaitForSeconds(1);
        delayforgetitemfly = true;
    }
    /// <summary>
    /// Check if items remain, if so show button again
    /// </summary>
    void OnOpenFlyAgain()
    {
        if (managerdata.manager.GetFly() > 0)
        {
            //btnitemfly.gameObject.SetActive(true);
            panelshowitem.GetComponent<Animator>().SetBool("clic", false);
        }
    }

    /// <summary>
    /// Buy flight item for one segment at start of level
    /// </summary>
    public void ClicBuyHesdstart()
    {
        if (managerdata.manager.Getcoin() >= 2000)
        {
            managerdata.manager.savecoin(-2000);
            managerdata.manager.SaveFly(1);
            txtkeyinshop.text = managerdata.manager.getkey().ToString();
            txtcoininshop.text = managerdata.manager.Getcoin().ToString();
            showyouhaveHeadstar.text = "You have : " + managerdata.manager.GetFly();

        }
    }




    public Text showyouhaveHeadstar;






    /****************************************8

        ITEM LEVEL SYSTEM - UPGRADE ITEMS LINKED TO DATA

    *****************************************/




    #region lvitem

    public Slider jetpackslider;  // Item slider variable
    public Image imgjetpack;// Long flight upgrade menu
    public Image imgSuperSneakers; // Shoes upgrade menu
    public Image imgSuperMagnet; // Coin magnet upgrade menu
    public Image imgX2Coin; // X2 coin upgrade menu
    public Text txtcoinlvjetpack;  // Store purchase price values for each level
    public Text gettx;
    /// <summary>
    /// Open long flight upgrade menu
    /// </summary>
    public void ClicItemJetpack()
    {
        setanimation(imgjetpack);
    }
    /// <summary>
    /// Open shoes upgrade menu
    /// </summary>
    public void ClicItemSuperSneakers()
    {
        setanimation(imgSuperSneakers);
    }

    /// <summary>
    /// Open coin magnet upgrade menu
    /// </summary>
    public void ClicItemSuperMagnet()
    {
        setanimation(imgSuperMagnet);
    }



    /// <summary>
    /// Open x2 coin upgrade menu
    /// </summary>
    public void ClicItemX2()
    {
        setanimation(imgX2Coin);
    }



    /// <summary>
    /// Load item data when opening menu
    /// </summary>
    public void loaditem()
    {
        int valuelv = managerdata.manager.GetDataItemFly();
        int valueprice = managerdata.manager.Getprice(valuelv);
        loadatherimg(imgjetpack, valuelv, valueprice);
        valuelv = managerdata.manager.GetDataItemGiay();
        valueprice = managerdata.manager.Getprice(valuelv);
        loadatherimg(imgSuperSneakers, valuelv, valueprice);
        valuelv = managerdata.manager.GetDataItemMagnet();
        valueprice = managerdata.manager.Getprice(valuelv);
        loadatherimg(imgSuperMagnet, valuelv, valueprice);
        valuelv = managerdata.manager.GetDataItemX2();
        valueprice = managerdata.manager.Getprice(valuelv);
        loadatherimg(imgX2Coin, valuelv, valueprice);
    }

    public GameObject slder;


    /// <summary>
    /// Load data for each menu bar
    /// </summary>
    /// <param name="img"></param>
    /// <param name="valuelv"></param>
    /// <param name="valueprice"></param>
    void loadatherimg(Image img, int valuelv, int valueprice)
    {

        jetpackslider = img.transform.Find("Slider").gameObject.GetComponent<Slider>();
        gettx = img.transform.Find("txtseo").gameObject.GetComponent<Text>();
        jetpackslider.value = valuelv;
        gettx.text = valueprice.ToString();
        txtkeyinshop.text = managerdata.manager.getkey().ToString();
        txtcoininshop.text = managerdata.manager.Getcoin().ToString();
    }

    /// <summary>
    /// Buy flight item upgrade
    /// </summary>
    public void BuyitemSuperSneakers()
    {
        int valuelv = managerdata.manager.GetDataItemGiay();
        int valueprice = managerdata.manager.Getprice(valuelv);
        // Buyallitem(valuelv , valueprice, imgjetpack);
        if (managerdata.manager.Getcoin() >= valueprice)
        {
            managerdata.manager.savecoin(-valueprice);
            valuelv = valuelv + 1;
            managerdata.manager.SaveDataItemGiay(1);
            valueprice = managerdata.manager.Getprice(valuelv);
            loadatherimg(imgSuperSneakers, valuelv, valueprice);  // Reload menu data
        }
    }


    /// <summary>
    /// Buy x2 coin item upgrade
    /// </summary>
    public void BuyitemX2()
    {
        int valuelv = managerdata.manager.GetDataItemX2();
        int valueprice = managerdata.manager.Getprice(valuelv);
        // Buyallitem(valuelv , valueprice, imgjetpack);
        if (managerdata.manager.Getcoin() >= valueprice)
        {
            managerdata.manager.savecoin(-valueprice);
            valuelv = valuelv + 1;
            managerdata.manager.SaveDataItemX2(1);
            valueprice = managerdata.manager.Getprice(valuelv);
            loadatherimg(imgX2Coin, valuelv, valueprice);  // Reload menu data
        }
    }




    /// <summary>
    /// Buy shoes item upgrade
    /// </summary>
    public void BuyitemJetpack()
    {
        int valuelv = managerdata.manager.GetDataItemFly();
        int valueprice = managerdata.manager.Getprice(valuelv);
        // Buyallitem(valuelv , valueprice, imgjetpack);
        if (managerdata.manager.Getcoin() >= valueprice)
        {
            managerdata.manager.savecoin(-valueprice);
            valuelv = valuelv + 1;
            managerdata.manager.SaveDataItemFly(1);
            valueprice = managerdata.manager.Getprice(valuelv);
            loadatherimg(imgjetpack, valuelv, valueprice);  // Reload menu data
        }
    }


    /// <summary>
    /// Buy magnet item upgrade
    /// </summary>
    public void BuyitemSuperMagnet()
    {
        int valuelv = managerdata.manager.GetDataItemMagnet();
        int valueprice = managerdata.manager.Getprice(valuelv);
        // Buyallitem(valuelv , valueprice, imgjetpack);
        if (managerdata.manager.Getcoin() >= valueprice)
        {
            managerdata.manager.savecoin(-valueprice);
            valuelv = valuelv + 1;
            managerdata.manager.SaveDataItemMagnet(1);
            valueprice = managerdata.manager.Getprice(valuelv);
            loadatherimg(imgSuperMagnet, valuelv, valueprice);  // Reload menu data
        }
    }



    /// <summary>
    /// Function to buy all items
    /// </summary>
    /// <param name="valuelv"></param>
    /// <param name="valuepice"></param>
    /// <param name="img"></param>
    private void Buyallitem(int valuelv, int valuepice, Image img)
    {
        if (managerdata.manager.Getcoin() >= valuepice)
        {
            managerdata.manager.savecoin(-valuepice);
            valuelv = valuelv + 1;
            loadatherimg(img, valuelv, valuepice);  // Reload menu data
        }
    }

    #endregion

    #endregion

    public void Geetcoin()
    {
        cointxt.text = "" + coinmuving;
        coinmain.text = "" + coin;
        
        // Update coins collected in current session display
        if (CollectedCoins != null)
        {
            CollectedCoins.text = coin.ToString();
        }
    }

    float cahe = 0;
    public TMP_Text showwhisthighscore;
    // Update is called once per frame
    void Update()
    {
        cahe += Time.deltaTime;
        if (cahe > 60)
        {
            Caching.ClearCache();
            cahe = 0;
        }
        if (Playermuving.player != null)
        {
            if (Playermuving.isplay)
            {
                panellost.gameObject.SetActive(false);
                Geetcoin();
                if (managerdata.manager.getmuving() - coinmuving > 0)
                {
                    gettex.text = (managerdata.manager.getmuving() - coinmuving).ToString();
                }
                else
                {
                    gettex.text = "000";
                }

                if (Time.timeScale <= 1.1f)
                {
                    if (coinmuving > coinforuplv)
                    {
                        coinforuplv = coinforuplv * 2;
                        Time.timeScale += 0.05f;
                    }
                }
            }

        }
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        float msec = deltaTime * 1000.0f;
        float fps = 1.0f / deltaTime;
        SHOW.text = "FPS : " + fps.ToString();
        layout = imgHoverboard.GetComponent<ILayoutElement>();
    }
    public Text SHOW;
    float deltaTime = 0.0f;
    int add = 1;
    public Text gettex;
    int gettexint = 0;
    float time;
    public static int coinforuplv = 5000;

    /// <summary>
    /// Exit game
    /// </summary>
    void OnApplicationPause()
    {
        if (Playermuving.isplay)
        {
            inthepanelpause.pauses.pause();
        }
    }

    public IEnumerator DelayForLogin()
    {
        yield return new WaitForSeconds(1);


    }


    public Image Avatarfb;
    public static Image saveImage;
    public static bool LogInFb;
    public void SetImageAvatarFAb()
    {
        // Avatarfb.sprite = saveImage.sprite;
    }
    public void SetImgAvatarFB(Image img)
    {
        //saveImage.sprite = img.sprite;
    }
}
