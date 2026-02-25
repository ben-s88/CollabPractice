using UnityEngine;

public class GameManager : MonoBehaviour
{
    int score = 0;
    [SerializeField]
    GameObject Canvas;
    UIManager uiManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Canvas = GameObject.FindGameObjectWithTag("Canvas");

        uiManager = Canvas.GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        updateScore(1);
    }
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(Canvas);
    }

    public void updateScore(int s)
    {
        score += s;
        uiManager.updateScoreLable(score);
    }
}
