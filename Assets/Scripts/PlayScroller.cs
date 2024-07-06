using UnityEngine.UI;
using UnityEngine;

public class PlayScroller : MonoBehaviour
{
    public RawImage img;
    public float x, y;
    public float changeTime;
    public float elapsedTime;
    static public int status;
    private void Start()
    {
        status = 0;
        elapsedTime = 0f;
    }
    private void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime < changeTime)
        {
            // 100%时间为红色
            status = 0;
            img.color = new Color(0.2745098f, 0.1372549f, 0.174064f);
        }
        if (elapsedTime >= changeTime && elapsedTime < changeTime * 2)
        {
            // 200%的时间绿色
            status = 1;
            img.color = new Color(0.1378248f, 0.2735849f, 0.1711818f);
        }
        if (elapsedTime >= changeTime * 2 && elapsedTime < changeTime * 3)
        {
            // 300%的时间蓝色
            status = 2;
            img.color = new Color(0.1372549f, 0.1948643f, 0.2745098f);
        }
        if (elapsedTime >= changeTime * 3)
        {
            elapsedTime = 0f;
        }

        img.uvRect = new Rect(img.uvRect.position + new Vector2(x, y) * Time.deltaTime, img.uvRect.size);
    }
}

