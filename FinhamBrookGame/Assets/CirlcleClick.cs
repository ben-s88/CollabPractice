using System;
using UnityEngine;

public class CirlcleClick : MonoBehaviour
{
    PlayerMovementLvl1 pms;
    [SerializeField]
    bool doNotScore = true;
    [SerializeField]
    bool correct = false;
    GameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pms = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovementLvl1>();

        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        if (!gameManager)
        {
            Debug.Log("did not get gamemanager");
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnMouseDown()
    {
        bool a = pms.StartCRoutine(transform.position, tag);
        if (a)
        {
            if (!doNotScore && correct)
            {
                gameManager.updateScore(10);
            }
            else if (!doNotScore && !correct)
            {
                gameManager.updateScore(-3);
            }
        }
        
        
    }
    
}
