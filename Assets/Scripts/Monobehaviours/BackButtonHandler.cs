using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEditor.PackageManager.Requests;

public class BackButtonHandler : MonoBehaviour
{
    public GameObject backBtn;

    void Start()
    {
        if (ChangeSceneButton.showBackBtn)
        {
            backBtn.SetActive(true);
        }
        else
        {
            backBtn.SetActive(false);
        }
    }
}
