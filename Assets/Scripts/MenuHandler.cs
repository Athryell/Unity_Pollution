using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuHandler : MonoBehaviour
{
    public GameObject RulesPanel;
    public GameObject StartPanel;

    private void Start()
    {
        RulesPanel.SetActive(true);
        StartPanel.SetActive(false);
    }

    public void Gotcha()
    {
        RulesPanel.SetActive(false);
        StartPanel.SetActive(true);
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }
}
