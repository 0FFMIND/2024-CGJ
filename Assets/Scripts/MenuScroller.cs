using UnityEngine.UI;
using UnityEngine;

public class MenuScroller : MonoBehaviour
{
    public RawImage img;
    public float x, y;

    private void Update()
    {
        img.uvRect = new Rect(img.uvRect.position + new Vector2(x, y)* Time.deltaTime, img.uvRect.size);
    }
}
