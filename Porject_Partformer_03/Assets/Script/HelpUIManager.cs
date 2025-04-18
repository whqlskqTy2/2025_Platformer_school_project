using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpUIManager : MonoBehaviour
{
    public GameObject helpPanel;

    public void ToggleHelpPanel()
    {
        helpPanel.SetActive(!helpPanel.activeSelf);
    }

    public void CloseHelpPanel()
    {
        helpPanel.SetActive(false);
    }
}