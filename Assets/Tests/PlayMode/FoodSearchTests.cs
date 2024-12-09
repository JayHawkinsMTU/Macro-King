using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SearchFoodTests
{
    private GameObject backButton;
    private GameObject menuButton;
    private GameObject searchButton;
    private GameObject backButtonS;
    private GameObject forwardButton;
    private TMP_InputField searchBar;
    private GameObject pageDisplay;
    private Animator canvasAnimator;

    [UnitySetUp]
    public IEnumerator SetUp()
    {
        var asyncLoad = SceneManager.LoadSceneAsync("Search Food");
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        backButton = GameObject.Find("Back Button/Image");
        menuButton = GameObject.Find("Menu Button/Image");
        searchButton = GameObject.Find("Search Bar");
        backButtonS = GameObject.Find("Back Button/Text (TMP)");
        forwardButton = GameObject.Find("Forward Button/Text (TMP)");
        searchBar = GameObject.Find("Search Bar").GetComponent<TMP_InputField>();
        pageDisplay = GameObject.Find("Page #");
        canvasAnimator = GameObject.Find("Search Food Page").GetComponent<Animator>();
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
        var dirMenu = GameObject.Find("MenuOverlay");
        Assert.IsTrue(dirMenu.activeSelf, "Menu overlay activation failed.");
    }

    [UnityTest]
    public IEnumerator SearchButtonFunction_Test()
    {
        searchBar.text = "beef wellington";
        var searchButton = GameObject.Find("Search Button/Image").GetComponent<Button>();

        searchButton.onClick.Invoke();
        yield return null;
        Assert.IsTrue(canvasAnimator.GetCurrentAnimatorStateInfo(0).length > 0, "Animation did not play for Search Button");
        yield return new WaitForSeconds(1.0f);
        var foodEntries = GameObject.FindGameObjectsWithTag("FoodEntry");
        Assert.IsTrue(foodEntries.Length == 13, "No FoodEntry objects were created.");
    }

    [UnityTest]
    public IEnumerator PageNavigationFunction_Test()
    {
        searchBar.text = "beef wellington";
        var searchButton = GameObject.Find("Search Button/Image").GetComponent<Button>();
        searchButton.onClick.Invoke();
        yield return new WaitForSeconds(1.5f);

        var initialPageDisplay = pageDisplay.GetComponent<TMP_Text>();
        Assert.AreEqual("Showing 13 / 19592", initialPageDisplay.text, "Initial page display is incorrect.");

        var forwardBtn = forwardButton.GetComponent<Button>();
        forwardBtn.onClick.Invoke();
        yield return null;
        Assert.IsTrue(canvasAnimator.GetCurrentAnimatorStateInfo(0).length > 0, "Animation did not play for Forward Button");
        yield return new WaitForSeconds(1.0f);


        var updatedPageDisplay = pageDisplay.GetComponent<TMP_Text>();
        Assert.AreEqual("Showing 26 / 19592", updatedPageDisplay.text, "Forward navigation failed.");

        var backBtnS = backButtonS.GetComponent<Button>();
        backBtnS.onClick.Invoke();
        yield return null;
        Assert.IsTrue(canvasAnimator.GetCurrentAnimatorStateInfo(0).length > 0, "Animation did not play for Back ButtonS");
        yield return new WaitForSeconds(1.0f);

        var revertedPageDisplay = pageDisplay.GetComponent<TMP_Text>();
        Assert.AreEqual("Showing 13 / 19592", revertedPageDisplay.text, "Back navigation failed.");
    }
}
