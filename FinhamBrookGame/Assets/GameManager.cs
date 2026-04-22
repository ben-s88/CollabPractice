using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public delegate void Lvl2UnloadCallback();
    public event Lvl2UnloadCallback Lvl2Unload;

    int trashDone = 0;
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

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(Canvas);

        foreach (GameObject GO in GameObject.FindGameObjectsWithTag("DDOL"))
        {
            DontDestroyOnLoad(GO);
        }
    }

    private void Update()
    {
        if (trashDone > 3)
        {
            trashDone = 0;
            unloadScene2();
        }
    }

    public void updateScore(int s, bool trash =false)
    {
        if (trash)
        {
            trashDone++;
        }
        score += s;
        uiManager.updateScoreLable(score);
    }

    public void unloadScene2()
    {
        Camera.main.transform.position = new Vector3 (0, 2.87f, -10);
        SceneManager.UnloadSceneAsync(2);
        Lvl2Unload();
    }

}
