using UnityEngine;

public class GameManager : MonoBehaviour
{
    int score = 0;
    [SerializeField]
    GameObject UIobj;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UIobj = GameObject.FindGameObjectWithTag("UI");

        if (UIobj != null)
        {
            Debug.Log("did not get ui");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(UIobj);
    }

    public void updateScore(int s)
    {
        score += s;
    }

    void updateScoreUI()
    {

    }
}
