using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpcBar : MonoBehaviour
{
    public Transform npcBar; // 血条的 Transform
    public List<GameObject> child; // 存储血条子对象的列表
    public Color low; // 低血量颜色
    public Color high; // 高血量颜色
    public Vector3 offset; // 血条的偏移量
    public Vector3 originHealth; // 初始血量

    private void Start()
    {
        // 获取血条的 Transform 组件
        npcBar = this.transform.GetChild(0).gameObject.GetComponent<Transform>();
        // 将血条的子对象添加到列表 child 中
        for (int i = 0; i < 2; i++)
        {
            child.Add(this.transform.GetChild(i).gameObject);
        }
    }

    public void SetHealth(float health, float maxHealth)
    {
        // 获取血条的 Transform 组件
        npcBar = this.transform.GetChild(0).gameObject.GetComponent<Transform>();
        // 根据当前血量比例调整血条的缩放
        float percentage = health / maxHealth;
        npcBar.localScale = new Vector3(npcBar.localScale.x * percentage, npcBar.localScale.y, npcBar.localScale.z);
        // 根据当前血量比例调整血条的颜色
        npcBar.GetComponent<SpriteRenderer>().color = Color.Lerp(low, high, percentage);
    }

    private void Update()
    {
        // 更新血条的位置，使其跟随 NPC
        this.transform.position = transform.parent.position + offset;
    }
}
