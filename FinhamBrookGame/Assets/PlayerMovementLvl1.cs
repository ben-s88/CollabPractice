using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class PlayerMovementLvl1 : MonoBehaviour
{
    float moveTime = 1.5f;
    string lastTag;
    Camera camera;
    float cameraYDiff;
    bool minigame2Unloaded = true;
    VideoPlayer VP;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camera = Camera.main;
        VP = GameObject.FindGameObjectWithTag("VPlayer").GetComponent<VideoPlayer>();
        cameraYDiff = math.abs(transform.position.y - camera.transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public bool StartCRoutine(Vector3 pos, string tag)
    {
        if (!minigame2Unloaded) { return false; };
        lastTag = tag;
        StartCoroutine(nameof(moveToPos), pos);
        foreach (GameObject go in GameObject.FindGameObjectsWithTag(tag))
        {
            go.GetComponent<BoxCollider2D>().enabled = false;
        }
        return true;
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
            camera.transform.position = new Vector3(camera.transform.position.x, transform.position.y + cameraYDiff, camera.transform.position.z);
            yield return null;
        }
        while (timeMoving < moveTime);
        CouroutineEnd();
    }

    IEnumerator moveCamera(Vector3 pos)
    {
        Vector3 startPos = camera.transform.position;
        float timeMoving = 0.0f;
        float newY;
        do
        {
            timeMoving += Time.deltaTime;
            newY = Vector3.Lerp(startPos, pos, timeMoving / moveTime).y;
            camera.transform.position = new Vector3(camera.transform.position.x, newY, camera.transform.position.z);
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
                minigame2Unloaded = false;
                StartCoroutine(nameof(waitAndUnload));
                break;
            case "Circle3":
                foreach (GameObject go in GameObject.FindGameObjectsWithTag("Circle4"))
                {
                    go.GetComponent<BoxCollider2D>().enabled = true;
                }
                break;
            case "Circle4":
                VP.Play();
                break;

        }
        lastTag = "";
    }

    IEnumerator waitAndUnload()
    {
        yield return new WaitForSeconds(5);
        SceneManager.UnloadSceneAsync(2);
        minigame2Unloaded = true;
    }
}
