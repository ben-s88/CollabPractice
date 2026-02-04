using Unity.VisualScripting;
using UnityEngine;

public class movement : MonoBehaviour
{
    int speed = 7;
    GameObject currentDuck;
    Ray ray;
    [SerializeField]
    GameObject duck1;
    [SerializeField]
    GameObject duck2;
    [SerializeField]
    GameObject duck3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentDuck)
        {

            if (Input.GetKey(KeyCode.W))
            {
                currentDuck.transform.Translate(Vector2.up * Time.deltaTime * speed);
            }
            if (Input.GetKey(KeyCode.A))
            {
                currentDuck.transform.Translate(Vector2.left * Time.deltaTime * speed);
            }
            if (Input.GetKey(KeyCode.S))
            {
                currentDuck.transform.Translate(Vector2.down * Time.deltaTime * speed);
            }
            if (Input.GetKey(KeyCode.D))
            {
                currentDuck.transform.Translate(Vector2.right * Time.deltaTime * speed);
            }
        }

    }

    public void setActive(GameObject go)
    {
        currentDuck = go;
    }

}
