using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NutritionOverviewTests
{
    private GameObject menuButton;
    private GameObject goalsButton;
    private GameObject calendarButton;
    private GameObject todayButton;
    private Animator canvasAnimator;

    [UnitySetUp]
    public IEnumerator SetUp()
    {
        var asyncLoad = SceneManager.LoadSceneAsync("Nutrition Overview");
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        menuButton = GameObject.Find("Menu Button/Image");
        goalsButton = GameObject.Find("Panel/Goals");
        calendarButton = GameObject.Find("Panel (1)/Calendar");
        todayButton = GameObject.Find("Panel (2)/Today");
        canvasAnimator = GameObject.Find("Nutrition Overview Page").GetComponent<Animator>();
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

    [UnityTest]
    public IEnumerator GoalsButtonChangesScene_Test()
    {
        var button = goalsButton.GetComponent<Button>();

        bool sceneChanged = false;
        SceneManager.sceneLoaded += (scene, mode) =>
        {
            if (scene.name == "Nutrition Goals")
            {
                sceneChanged = true;
            }
        };

        button.onClick.Invoke();
        yield return null;
        Assert.IsTrue(canvasAnimator.GetCurrentAnimatorStateInfo(0).length > 0, "Animation did not play on Canvas for Goals Button");
        yield return new WaitForSeconds(1.0f);
        Assert.IsTrue(sceneChanged, "Scene change to 'Nutrition Goals' failed.");
    }

    [UnityTest]
    public IEnumerator CalendarButtonChangesScene_Test()
    {
        var button = calendarButton.GetComponent<Button>();

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
        Assert.IsTrue(canvasAnimator.GetCurrentAnimatorStateInfo(0).length > 0, "Animation did not play on Canvas for Calendar Button");
        yield return new WaitForSeconds(1.0f);
        Assert.IsTrue(sceneChanged, "Scene change to 'Calendar' failed.");
    }

    [UnityTest]
    public IEnumerator TodayButtonChangesScene_Teste()
    {
        var button = todayButton.GetComponent<Button>();

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
        Assert.IsTrue(canvasAnimator.GetCurrentAnimatorStateInfo(0).length > 0, "Animation did not play on Canvas for Today Button");
        yield return new WaitForSeconds(1.0f);
        Assert.IsTrue(sceneChanged, "Scene change to 'Daily Nutrition' failed.");
    }
}
