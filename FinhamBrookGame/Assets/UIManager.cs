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
        SceneManager.LoadScene(1);
        mainMenuUI.SetActive(false);
    }

    public void quitButtonPress()
    {
        Application.Quit();
    }

    public void updateScoreLable(int s)
    {
        text.text = s.ToString();
    }    
}
