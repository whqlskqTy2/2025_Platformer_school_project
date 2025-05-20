using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// MonoBehaviour�� ��ӹ޾� Unity ������Ʈ�� ���� �� �ִ� ������Ʈ Ŭ�����Դϴ�.
public class ItemObject : MonoBehaviour
{
    // ScriptableObject Ÿ���� �����͸� �ν����Ϳ��� �巡���ؼ� �Ҵ��� �� �ֵ��� �մϴ�.
    [SerializeField] ItemSO data;  // Inspector �巡��

    // �������� ������ ��ȯ�ϴ� �޼����Դϴ�.
    public int GetPoint()
    {
        return data.point;  // ItemSO�� point �� ��ȯ
    }
}
