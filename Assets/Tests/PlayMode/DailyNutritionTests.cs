using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class DailyNutritionTests
{
    private GameObject dateDisplay;
    private GameObject backButton;
    private GameObject menuButton;
    private GameObject addButton;
    private Animator canvasAnimator;

    [UnitySetUp]
    public IEnumerator SetUp()
    {
        var asyncLoad = SceneManager.LoadSceneAsync("Daily Nutrition");
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        yield return new WaitForSeconds(0.5f);

        dateDisplay = GameObject.Find("Date Display");
        backButton = GameObject.Find("Back Btn");
        menuButton = GameObject.Find("Menu Opener");
        addButton = GameObject.Find("Add Btn");
        canvasAnimator = GameObject.Find("Daily Nutrition Page").GetComponent<Animator>();
    }

    [UnityTest]
    public IEnumerator BackButtonChangesScene_Test()
    {
        var button = backButton.GetComponent<Button>();
        Assert.IsNotNull(button, "Back Button component not found");

        bool sceneChanged = false;
        SceneManager.sceneLoaded += (scene, mode) =>
        {
            if (scene.name == "Calendar")
            {
                sceneChanged = true;
            }
        };

        button.onClick.Invoke();
        yield return null;
        Assert.IsTrue(canvasAnimator.GetCurrentAnimatorStateInfo(0).length > 0, "Animation did not play on Canvas for Back Button");
        yield return new WaitForSeconds(1.0f);
        Assert.IsTrue(sceneChanged, "Scene change to 'Calendar' failed.");
    }

    [UnityTest]
    public IEnumerator MenuButtonOpensAndAnimation_Test()
    {
        var button = menuButton.GetComponent<Button>();
        Assert.IsNotNull(button, "Menu Button component not found");

        button.onClick.Invoke();
        yield return null;
        Assert.IsTrue(canvasAnimator.GetCurrentAnimatorStateInfo(0).length > 0, "Animation did not play on Canvas for Menu Button");
        yield return new WaitForSeconds(1.0f);
        var dirMenu = GameObject.Find("MenuOverlay");
        Assert.IsTrue(dirMenu.activeSelf, "Menu overlay activation failed.");
    }

    [UnityTest]
    public IEnumerator AddButtonChangesScene_Test()
    {
        var button = addButton.GetComponent<Button>();
        Assert.IsNotNull(button, "Add Button component not found");

        bool sceneChanged = false;
        SceneManager.sceneLoaded += (scene, mode) =>
        {
            if (scene.name == "Search Food")
            {
                sceneChanged = true;
            }
        };

        button.onClick.Invoke();
        yield return null;
        Assert.IsTrue(canvasAnimator.GetCurrentAnimatorStateInfo(0).length > 0, "Animation did not play on Canvas for Add Button");
        yield return new WaitForSeconds(1.0f);
        Assert.IsTrue(sceneChanged, "Scene change to 'Search Food' failed.");
    }
}
