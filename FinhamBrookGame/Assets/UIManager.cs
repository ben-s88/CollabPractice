using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    GameObject scoreLabel;
    TMP_Text text;
    [SerializeField]
    GameObject mainMenuUI;
    [SerializeField]
    GameObject howToPlayUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text = scoreLabel.GetComponent<TMP_Text>();

        if (text == null )
        {
            Debug.Log("text null");
        }
    }

    public void startButtonPress()
    {
        nextScene();
        mainMenuUI.SetActive(false);
    }

    public void quitButtonPress()
    {
        Application.Quit();
    }

    public void updateScoreLable(int s)
    {
        text.text = "Score: " + s.ToString();
    }

    public void nextScene()
    {
        mainMenuUI.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void howToPlay()
    {
        mainMenuUI.SetActive(false);
        howToPlayUI.SetActive(true);
    }

    public void closeHowToPlay()
    {
        mainMenuUI.SetActive(true);
        howToPlayUI.SetActive(false);
    }

}
