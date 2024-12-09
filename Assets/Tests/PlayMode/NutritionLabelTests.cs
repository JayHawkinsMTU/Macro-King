using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NutritionLabelTests
{
    private GameObject backButton;
    private GameObject menuButton;
    private Animator canvasAnimator;

    [UnitySetUp]
    public IEnumerator SetUp()
    {
        var asyncLoad = SceneManager.LoadSceneAsync("Nutrition Label");
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        backButton = GameObject.Find("Back Button/Image");
        menuButton = GameObject.Find("Menu Button/Image");
        canvasAnimator = GameObject.Find("Nutrition Label Page").GetComponent<Animator>();
    }

    [UnityTest]
    public IEnumerator BackButtonChangesScene_Test()
    {
        var button = backButton.GetComponent<Button>();

        bool sceneChanged = false;
        SceneManager.sceneLoaded += (scene, mode) =>
        {
            if (scene.name == "Daily Nutrition")
            {
                sceneChanged = true;
            }
        };

        button.onClick.Invoke();
        yield return null;
        Assert.IsTrue(canvasAnimator.GetCurrentAnimatorStateInfo(0).length > 0, "Animation did not play on Canvas for Back Button");
        yield return new WaitForSeconds(1.0f);
        Assert.IsTrue(sceneChanged, "Scene change to 'Daily Nutrition' failed.");
    }

    [UnityTest]
    public IEnumerator MenuButtonOpensAndAnimation_Test()
    {
        var button = menuButton.GetComponent<Button>();

        button.onClick.Invoke();
        yield return null;
        Assert.IsTrue(canvasAnimator.GetCurrentAnimatorStateInfo(0).length > 0, "Animation did not play on Canvas for Menu Button");
        yield return new WaitForSeconds(1.0f);
        var menuOverlay = GameObject.Find("MenuOverlay");
        Assert.IsTrue(menuOverlay.activeSelf, "Menu overlay activation failed.");
    }
}
