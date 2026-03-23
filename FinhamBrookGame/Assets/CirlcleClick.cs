using UnityEngine;

public class CirlcleClick : MonoBehaviour
{
    PlayerMovementLvl1 pms;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pms = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovementLvl1>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        pms.StartCRoutine(transform.position, tag);
    }
    
}
