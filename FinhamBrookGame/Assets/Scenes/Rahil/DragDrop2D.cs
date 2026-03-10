using UnityEngine;

public class DragDrop2D : MonoBehaviour
{

    Vector3 offset;
    Collider2D _collider2D;
    public string destinationTag = "DropArea";

    void Start()
    {
        
        _collider2D = GetComponent<Collider2D>();
    }

    void OnMouseDown()
    {
        offset = transform.position - MouseWorldPos();
    }

    void OnMouseDrag()
    {
        transform.position = MouseWorldPos() + offset;
    }

    void OnMouseUp()
    {
        _collider2D.enabled = false;
        var rayOrigin = Camera.main.transform.position;
        var rayDirection = MouseWorldPos() - Camera.main.transform.position;
        RaycastHit2D hitInfo;
        if(hitInfo = Physics2D.Raycast(rayOrigin, rayDirection))
        {
            if (hitInfo.transform.tag == destinationTag)
            {
                transform.position = new Vector3(hitInfo.transform.position.x, hitInfo.transform.position.y + 0.7f, -1f);
            }
        }

        _collider2D.enabled = true;
        
    }

    Vector3 MouseWorldPos()
    {
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }
}
