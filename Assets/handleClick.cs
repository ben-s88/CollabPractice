using UnityEngine;

public class handleClick : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    movement movement_;
    private void OnMouseDown()
    {
        movement_.setActive(gameObject);
    }
}
