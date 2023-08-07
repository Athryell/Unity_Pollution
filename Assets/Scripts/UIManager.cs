using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    #region Singleton
    public static UIManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("More than one UI Manager in scene!");
            return;
        }
        Instance = this;
    }
    #endregion

    public TMP_Text scoreText;
    public TMP_Text multiplierText;

    public TMP_Text lifesText;

    void Start()
    {
        scoreText.text = "Score : 0";
        multiplierText.text = "x " + GameManager.Instance.numberOfLoopsAttached.ToString();

        InvokeRepeating("UpdateScore", 0f, .1f);
    }

    void UpdateScore()
    {
        if (GameManager.Instance.isGameOver == true)
        {
            CancelInvoke();
            return;
        }

        scoreText.SetText("Score : {0:0}", GameManager.Instance.score);
        multiplierText.text = "x " + GameManager.Instance.numberOfLoopsAttached * 2;
    }

    public void UpdateLifeCount()
    {
        if (GameManager.Instance.lifes == 3)
        {
            lifesText.text = "<3 <3 <3";
        }
        else if (GameManager.Instance.lifes == 2)
        {
            lifesText.text = "<3 <3";
        }
        else if (GameManager.Instance.lifes == 1)
        {
            lifesText.text = "<3";
        }
    }
}
