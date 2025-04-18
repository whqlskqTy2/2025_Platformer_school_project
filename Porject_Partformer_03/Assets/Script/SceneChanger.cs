using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Level_1에서 UI 씬으로 이동하는 메서드
    public void ChangeToUI()
    {
        // UI 씬을 로드합니다.
        SceneManager.LoadScene("UI");
    }
}