using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SettingsTests
{
    private GameObject menuButton;
    private Toggle setting1Toggle;
    private Toggle setting2Toggle;
    private Animator canvasAnimator;

    [UnitySetUp]
    public IEnumerator SetUp()
    {
        PlayerPrefs.SetInt("isDark", 1);
        PlayerPrefs.Save();

        var asyncLoad = SceneManager.LoadSceneAsync("Settings");
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        menuButton = GameObject.Find("Menu Button/Image");
        setting1Toggle = GameObject.Find("Setting 1/Toggle").GetComponent<Toggle>();
        setting2Toggle = GameObject.Find("Setting 2/Toggle").GetComponent<Toggle>();
        canvasAnimator = GameObject.Find("SettingsPage").GetComponent<Animator>();
    }

    [UnityTest]
    public IEnumerator MenuButton_OpensMenu()
    {
        var button = menuButton.GetComponent<Button>();

        button.onClick.Invoke();
        yield return null;

        Assert.IsTrue(canvasAnimator.GetCurrentAnimatorStateInfo(0).length > 0, "Animation did not play on Canvas for Menu Button");
        yield return new WaitForSeconds(1.0f);
        var menuOverlay = GameObject.Find("MenuOverlay");
        Assert.IsTrue(menuOverlay.activeSelf, "Menu overlay activation failed.");
    }

    [UnityTest]
    public IEnumerator Setting2Toggle_Works()
    {
        bool initialState = setting2Toggle.isOn;
        setting2Toggle.isOn = !initialState;

        yield return null;
        Assert.AreEqual(!initialState, setting2Toggle.isOn, "Setting 2 Toggle did not change state.");
    }

    [UnityTest]
    public IEnumerator Setting1Toggle_ChangesMode()
    {
        bool initialState = setting1Toggle.isOn;
        setting1Toggle.isOn = !initialState;

        yield return null;
        Assert.AreEqual(!initialState, setting1Toggle.isOn, "Setting 1 Toggle did not change state.");
    }

    private bool CheckColorMode(Color textColor, string bgColorHex, string cameraColorHex)
    {
        var tmpTexts = GameObject.FindObjectsOfType<TMP_Text>();
        foreach (var tmpText in tmpTexts)
        {
            if (tmpText.color != textColor)
            {
                return false;
            }
        }

        var darkObjects = GameObject.FindGameObjectsWithTag("dark");
        foreach (var obj in darkObjects)
        {
            var renderer = obj.GetComponent<Renderer>();
            if (renderer != null && renderer.material.color != textColor)
            {
                return false;
            }
        }

        var bgObjects = GameObject.FindGameObjectsWithTag("bg");
        Color bgColor;
        if (!ColorUtility.TryParseHtmlString(bgColorHex, out bgColor))
        {
            return false;
        }
        foreach (var obj in bgObjects)
        {
            var renderer = obj.GetComponent<Renderer>();
            if (renderer != null && renderer.material.color != bgColor)
            {
                return false;
            }
        }

        var mainCamera = Camera.main;
        Color cameraColor;
        if (!ColorUtility.TryParseHtmlString(cameraColorHex, out cameraColor))
        {
            return false;
        }
        if (mainCamera.backgroundColor != cameraColor)
        {
            return false;
        }

        return true;
    }

    [UnityTest]
    public IEnumerator ValidateModesInAllScenes()
    {
        string[] scenesToTest = {
        "Home Page",
        "Add Nutrition Goal",
        "Calendar",
        "Daily Nutrition",
        "Nutrition Goals",
        "Nutrition Label",
        "Nutrition Overview",
        "Personal Record Logging",
        "Search Food",
        "UnitValueEntry",
        "Food Selection Info Menu",
        "Settings" 
    };

        setting1Toggle.isOn = false; 
        yield return new WaitForSeconds(1.0f);

        foreach (string scene in scenesToTest)
        {
            var asyncLoad = SceneManager.LoadSceneAsync(scene);
            while (!asyncLoad.isDone)
            {
                yield return null;
            }
            Assert.IsTrue(CheckColorMode(Color.black, "#648DB7", "#7FA9CB"), $"Light mode colors are incorrect in scene: {scene}");
        }

        PlayerPrefs.SetInt("isDark", 1);
        PlayerPrefs.Save();
        yield return new WaitForSeconds(1.0f);

        foreach (string scene in scenesToTest)
        {
            var asyncLoad = SceneManager.LoadSceneAsync(scene);
            while (!asyncLoad.isDone)
            {
                yield return null;
            }
            Assert.IsTrue(CheckColorMode(Color.white, "#1B3247", "#20374C"), $"Dark mode colors are incorrect in scene: {scene}");
        }
    }

}
