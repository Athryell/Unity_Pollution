using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class GameManager : MonoBehaviour
{
    #region Singleton

    public static GameManager Instance;

    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("More than one Game Manager in scene!");
            return;
        }

        Instance = this;
    }
    #endregion

    public GameObject gameoverPanel;

    public TMP_Text finalScoreText;
    public TMP_Text timeAliveText;

    public int lifes;

    public float score;
    [HideInInspector] public int numberOfLoopsAttached = 0;
    [HideInInspector] public float finalScore;

    [SerializeField] private int maxLifes = 3;

    [HideInInspector] public bool isGameOver;


    void Start()
    {
        Time.timeScale = 1;

        lifes = maxLifes;
        isGameOver = false;
    }

    private void Update()
    {
        if (isGameOver)
            return;

        score += Time.deltaTime * (numberOfLoopsAttached * 2);
    }

    public void GameOver()
    {
        SoundManager.PlaySound("GameOver");

        finalScore = score;

        isGameOver = true;
        
        Time.timeScale = 0.3f;

        DisplayGameOverScreen();
    }

    private void DisplayGameOverScreen()
    {
        gameoverPanel.SetActive(true);

        finalScoreText.SetText("Score : {0:0}", score);
        timeAliveText.SetText("Time alive : {0:1} s", Time.time);
      

        Time.timeScale = 0;
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }
}
