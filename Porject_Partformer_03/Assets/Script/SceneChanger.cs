using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Level_1���� UI ������ �̵��ϴ� �޼���
    public void ChangeToUI()
    {
        // UI ���� �ε��մϴ�.
        SceneManager.LoadScene("UI");
    }
}