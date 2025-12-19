using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIFlowSimple : MonoBehaviour
{
    [Header("Panels")]
    public GameObject panelMain;   // Main menu
    public GameObject panelCoin;   // In-game HUD
    public GameObject panelLost;   // Game over panel

    [Header("Texts")]
    public Text scoreText;         // Current run score
    public Text runCoinText;       // Coins collected this run
    public Text totalCoinText;     // Total coins saved
    public Text highscoreText;     // Best score

    [Header("Buttons")]
    public Button btnPlay;
    public Button btnReplay;

    [Header("References")]
    public Animator cameraAnim;    // Camera animator
    public GameObject playerObj;   // Player reference

    // Static values
    public static int currentScore = 0;
    public static int runCoins = 0;

    void Start()
    {
        InitUI();

        // Hook up buttons
        if (btnPlay != null) btnPlay.onClick.AddListener(PlayGame);
        if (btnReplay != null) btnReplay.onClick.AddListener(Replay);
    }

    void InitUI()
    {
        // Reset scores
        currentScore = 0;
        runCoins = 0;

        // Show main menu only
        panelMain.SetActive(true);
        panelCoin.SetActive(false);
        panelLost.SetActive(false);

        // Load saved values
        highscoreText.text = managerdata.manager.getmuving().ToString();
        totalCoinText.text = managerdata.manager.Getcoin().ToString();
    }

    /// <summary>
    /// Start the game from Main Menu
    /// </summary>
    public void PlayGame()
    {
        panelMain.SetActive(false);
        panelCoin.SetActive(true);
        panelLost.SetActive(false);

        currentScore = 0;
        runCoins = 0;

        StartCoroutine(StartGameplay());
    }

    IEnumerator StartGameplay()
    {
        yield return new WaitForSeconds(0.3f);

        if (cameraAnim != null)
            cameraAnim.SetBool("play", true);

        if (playerObj != null)
        {
            Playermuving.isplay = true;
            Playermuving.speedmuving = 5;
            Playermuving.player.muvingtomodelonthestart();
        }
    }

    /// <summary>
    /// Call this when player dies
    /// </summary>
    public void Lost()
    {
        Playermuving.isplay = false;

        // Save highscore
        if (currentScore > managerdata.manager.getmuving())
        {
            managerdata.manager.savemuving(currentScore);
        }

        // Save coins
        managerdata.manager.savecoin(runCoins);

        // Update lost panel
        panelLost.SetActive(true);
        highscoreText.text = managerdata.manager.getmuving().ToString();
        scoreText.text = currentScore.ToString();
        runCoinText.text = runCoins.ToString();
        totalCoinText.text = managerdata.manager.Getcoin().ToString();

        // Reset run
        currentScore = 0;
        runCoins = 0;
    }

    /// <summary>
    /// Replay the game after death
    /// </summary>
    public void Replay()
    {
        panelLost.SetActive(false);
        PlayGame();
    }

    void Update()
    {
        if (panelCoin.activeSelf)
        {
            // Update HUD live
            scoreText.text = currentScore.ToString();
            runCoinText.text = runCoins.ToString();
        }
    }
}
