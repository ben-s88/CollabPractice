using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovementLvl1 : MonoBehaviour
{
    float moveTime = 1.5f;
    string lastTag;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StartCRoutine(Vector3 pos, string tag)
    {
        lastTag = tag;
        StartCoroutine(nameof(moveToPos), pos);
        foreach (GameObject go in GameObject.FindGameObjectsWithTag(tag))
        {
            go.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    public IEnumerator moveToPos(Vector3 pos)
    {
        pos.y += 0.2f;
        Vector3 startPos = transform.position;
        float timeMoving = 0.0f;
        do
        {
            timeMoving += Time.deltaTime;
            transform.position = Vector3.Lerp(startPos, pos, timeMoving / moveTime);
            yield return null;
        }
        while (timeMoving < moveTime);
        CouroutineEnd();
    }

    void CouroutineEnd()
    {
        switch (lastTag)
        {
            case "Circle1":
                foreach (GameObject go in GameObject.FindGameObjectsWithTag("Circle2"))
                {
                    go.GetComponent<BoxCollider2D>().enabled = true;
                }
                break;
            case "Circle2":
                foreach (GameObject go in GameObject.FindGameObjectsWithTag("Circle3"))
                {
                    go.GetComponent<BoxCollider2D>().enabled = true;
                }
                SceneManager.LoadScene(2, LoadSceneMode.Additive);
                StartCoroutine(nameof(waitAndUnload));
                break;
        }
        lastTag = "";
    }

    IEnumerator waitAndUnload()
    {
        yield return new WaitForSeconds(5);
        SceneManager.UnloadSceneAsync(2);
    }
}
