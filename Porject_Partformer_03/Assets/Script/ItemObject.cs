using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// MonoBehaviour를 상속받아 Unity 오브젝트에 붙일 수 있는 컴포넌트 클래스입니다.
public class ItemObject : MonoBehaviour
{
    // ScriptableObject 타입의 데이터를 인스펙터에서 드래그해서 할당할 수 있도록 합니다.
    [SerializeField] ItemSO data;  // Inspector 드래그

    // 아이템의 점수를 반환하는 메서드입니다.
    public int GetPoint()
    {
        return data.point;  // ItemSO의 point 값 반환
    }
}
