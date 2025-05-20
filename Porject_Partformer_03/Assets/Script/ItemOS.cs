using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �� ��ũ��Ʈ�� Unity���� ScriptableObject�� ���� ������ �����͸� ������ �� �ֵ��� �մϴ�.
// ������ ��� �޴��� "Game/Item" �׸����� ���� �޴��� ��Ÿ���ϴ�.
[CreateAssetMenu(menuName = "Game/Item", fileName = "NewItem")]
public class ItemSO : ScriptableObject
{
    // �ν����Ϳ��� �� ���� ���� "Score Value"��� ��� �ؽ�Ʈ�� ǥ�õ˴ϴ�.
    [Header("Score Value")]

    // �������� ������ �ִ� ���� ���Դϴ�. �⺻���� 10�Դϴ�.
    public int point = 10;
}