using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;

public class DirectoryTests
{
    private GameObject menuOpenerButton;
    private GameObject closeExternalButton;
    private GameObject closeBtnButton;
    private CanvasGroup homePageCanvasGroup;
    private Animator menuOverlayAnimator;
    private GameObject menuOverlay;

    private Dictionary<string, string> pageButtonMapping = new Dictionary<string, string>
    {
        {"Page 1", "Home Page"},
        {"Page 2", "Calendar"},
        {"Page 3", "Nutrition Goals"},
        {"Page 4", "Add Nutrition Goal"},
        {"Page 5", "Daily Nutrition"},
        {"Page 6", "Personal Record Logging"},
        {"Page 7", "Settings"}
    };

    [UnitySetUp]
    public IEnumerator SetUp()
    {
        var asyncLoad = SceneManager.LoadSceneAsync("Home Page");
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        menuOpenerButton = GameObject.Find("Menu Opener");
        
        homePageCanvasGroup = GameObject.Find("Home Page").GetComponent<CanvasGroup>();
        
    }
    
    [UnityTest, Order(1)]
    public IEnumerator OpenCloseTests()
    {
        menuOpenerButton.GetComponent<Button>().onClick.Invoke();
        yield return new WaitForSeconds(0.5f); 
        menuOverlay = GameObject.Find("MenuOverlay");
        closeExternalButton = GameObject.Find("CloseExternal");
        closeBtnButton = GameObject.Find("CloseBtn");
        menuOverlayAnimator = menuOverlay.GetComponent<Animator>();
        Assert.IsFalse(homePageCanvasGroup.interactable, "Home Page Canvas Group should not be interactable");

        closeExternalButton.GetComponent<Button>().onClick.Invoke();
        yield return null; 
        Assert.IsTrue(menuOverlayAnimator.GetCurrentAnimatorStateInfo(0).length > 0, "Animation did not play on Close External");
        yield return new WaitForSeconds(0.25f);
        Assert.IsTrue(homePageCanvasGroup.interactable, "Home Page Canvas Group should be interactable");

        menuOpenerButton.GetComponent<Button>().onClick.Invoke();
        yield return new WaitForSeconds(0.25f);
        Assert.IsTrue(menuOverlayAnimator.GetCurrentAnimatorStateInfo(0).length > 0, "Animation did not play on Menu Overlay");
        yield return new WaitForSeconds(0.25f);

        closeBtnButton.GetComponent<Button>().onClick.Invoke();
        yield return null;
        Assert.IsTrue(menuOverlayAnimator.GetCurrentAnimatorStateInfo(0).length > 0, "Animation did not play on CloseBtn");
        yield return new WaitForSeconds(0.25f);
        Assert.IsTrue(homePageCanvasGroup.interactable, "Home Page Canvas Group should be interactable");

        menuOpenerButton.GetComponent<Button>().onClick.Invoke();
        yield return new WaitForSeconds(0.25f);
        Assert.IsTrue(menuOverlayAnimator.GetCurrentAnimatorStateInfo(0).length > 0, "Animation did not play on Menu Overlay");
        yield return new WaitForSeconds(0.25f);
    }

    
    private IEnumerator NavigateToPage(string buttonName, string expectedSceneName)
    {
        menuOverlay = GameObject.Find("MenuOverlay");
        menuOverlayAnimator = menuOverlay.GetComponent<Animator>();
        var button = GameObject.Find(buttonName).GetComponent<Button>();
        button.onClick.Invoke();
        yield return null;  // Ensure to wait for the animation to start
        Assert.IsTrue(menuOverlayAnimator.GetCurrentAnimatorStateInfo(0).length > 0, "Animation did not play on " + buttonName);
        yield return new WaitForSeconds(1.0f);
        Assert.AreEqual(expectedSceneName, SceneManager.GetActiveScene().name, "Did not change to " + expectedSceneName + " scene.");
    }

    private IEnumerator NavigateThroughPages(string startSceneName, string menuOpenerButtonName)
    {
        foreach (var entry in pageButtonMapping)
        {
            GameObject.Find(menuOpenerButtonName).GetComponent<Button>().onClick.Invoke();
            yield return new WaitForSeconds(0.5f);
            yield return NavigateToPage(entry.Key, entry.Value);
            if (SceneManager.GetActiveScene().name != startSceneName)
            {
                SceneManager.LoadScene(startSceneName);
                yield return new WaitForSeconds(0.5f);
            }
        }
    }
    
    [UnityTest, Order(2)]
    public IEnumerator HomePageNavigationTests()
    {
        yield return NavigateThroughPages("Home Page", "Menu Opener");
    }

    [UnityTest, Order(3)]
    public IEnumerator CalendarNavigationTests()
    {
        SceneManager.LoadScene("Calendar");
        yield return new WaitForSeconds(0.5f);
        yield return NavigateThroughPages("Calendar", "Button Opener");
    }

    [UnityTest, Order(4)]
    public IEnumerator NutritionGoalsNavigationTests()
    {
        SceneManager.LoadScene("Nutrition Goals");
        yield return new WaitForSeconds(0.5f);
        yield return NavigateThroughPages("Nutrition Goals", "Menu Button/Image");
    }

    [UnityTest, Order(5)]
    public IEnumerator AddNutritionGoalNavigationTests()
    {
        SceneManager.LoadScene("Add Nutrition Goal");
        yield return new WaitForSeconds(1.0f);
        yield return NavigateThroughPages("Add Nutrition Goal", "Menu Button (1)/Image");
    }
    
    [UnityTest, Order(6)]
    public IEnumerator DailyNutritionNavigationTests()
    {
        SceneManager.LoadScene("Daily Nutrition");
        yield return new WaitForSeconds(0.5f);
        yield return NavigateThroughPages("Daily Nutrition", "Menu Opener");
    }

    [UnityTest, Order(7)]
    public IEnumerator PersonalRecordLoggingNavigationTests()
    {
        SceneManager.LoadScene("Personal Record Logging");
        yield return new WaitForSeconds(0.5f);
        yield return NavigateThroughPages("Personal Record Logging", "Menu Button/Image");
    }

    [UnityTest, Order(8)]
    public IEnumerator SettingsNavigationTests()
    {
        SceneManager.LoadScene("Settings");
        yield return new WaitForSeconds(0.5f);
        yield return NavigateThroughPages("Settings", "Menu Button/Image");
    }
}
