using UnityEngine;

public class CursorFollower : Singleton<CursorFollower>
{
    public float rotateSpeed;
    private void Start()
    {
        Cursor.visible = false;
    }
    private void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePosition;
        float angle = rotateSpeed * Time.deltaTime;
        transform.Rotate(0, 0, angle);
    }
    public void Init()
    {

    }
}
