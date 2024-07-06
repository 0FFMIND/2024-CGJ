using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpcBar : MonoBehaviour
{
    public Transform npcBar; // Ѫ���� Transform
    public List<GameObject> child; // �洢Ѫ���Ӷ�����б�
    public Color low; // ��Ѫ����ɫ
    public Color high; // ��Ѫ����ɫ
    public Vector3 offset; // Ѫ����ƫ����
    public Vector3 originHealth; // ��ʼѪ��

    private void Start()
    {
        // ��ȡѪ���� Transform ���
        npcBar = this.transform.GetChild(0).gameObject.GetComponent<Transform>();
        // ��Ѫ�����Ӷ�����ӵ��б� child ��
        for (int i = 0; i < 2; i++)
        {
            child.Add(this.transform.GetChild(i).gameObject);
        }
    }

    public void SetHealth(float health, float maxHealth)
    {
        // ��ȡѪ���� Transform ���
        npcBar = this.transform.GetChild(0).gameObject.GetComponent<Transform>();
        // ���ݵ�ǰѪ����������Ѫ��������
        float percentage = health / maxHealth;
        npcBar.localScale = new Vector3(npcBar.localScale.x * percentage, npcBar.localScale.y, npcBar.localScale.z);
        // ���ݵ�ǰѪ����������Ѫ������ɫ
        npcBar.GetComponent<SpriteRenderer>().color = Color.Lerp(low, high, percentage);
    }

    private void Update()
    {
        // ����Ѫ����λ�ã�ʹ����� NPC
        this.transform.position = transform.parent.position + offset;
    }
}
