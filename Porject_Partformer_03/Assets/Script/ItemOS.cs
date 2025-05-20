using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 이 스크립트는 Unity에서 ScriptableObject를 통해 아이템 데이터를 생성할 수 있도록 합니다.
// 에디터 상단 메뉴에 "Game/Item" 항목으로 생성 메뉴가 나타납니다.
[CreateAssetMenu(menuName = "Game/Item", fileName = "NewItem")]
public class ItemSO : ScriptableObject
{
    // 인스펙터에서 이 변수 위에 "Score Value"라는 헤더 텍스트가 표시됩니다.
    [Header("Score Value")]

    // 아이템이 가지고 있는 점수 값입니다. 기본값은 10입니다.
    public int point = 10;
}