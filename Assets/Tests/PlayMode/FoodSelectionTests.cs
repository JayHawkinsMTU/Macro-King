using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class FoodSelectionInfoTests
{
    private GameObject backButton;
    private GameObject menuButton;
    private GameObject addButton;
    private TMP_Text foodNameText;
    private Animator canvasAnimator;

    [UnitySetUp]
    public IEnumerator SetUp()
    {
        var asyncLoad = SceneManager.LoadSceneAsync("Food Selection Info Menu");
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        backButton = GameObject.Find("Back Button/Image");
        menuButton = GameObject.Find("Menu Button/Image");
        addButton = GameObject.Find("Add Button/Image");
        canvasAnimator = GameObject.Find("Food Selection Info Page").GetComponent<Animator>();
    }

    [UnityTest]
    public IEnumerator BackButtonChangesScene_Test()
    {
        var button = backButton.GetComponent<Button>();

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
        Assert.IsTrue(canvasAnimator.GetCurrentAnimatorStateInfo(0).length > 0, "Animation did not play on Canvas for Back Button");
        yield return new WaitForSeconds(1.0f);
        Assert.IsTrue(sceneChanged, "Scene change to 'Search Food' failed.");
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
    public IEnumerator AddButtonChangesScene_Test()
    {
        var button = addButton.GetComponent<Button>();

        bool sceneChanged = false;
        SceneManager.sceneLoaded += (scene, mode) =>
        {
            if (scene.name == "UnitValueEntry")
            {
                sceneChanged = true;
            }
        };

        button.onClick.Invoke();
        yield return null;
        Assert.IsTrue(canvasAnimator.GetCurrentAnimatorStateInfo(0).length > 0, "Animation did not play on Canvas for Add Button");
        yield return new WaitForSeconds(1.0f);
        Assert.IsTrue(sceneChanged, "Scene change to 'Unit Value Entry' failed.");
    }

    [UnityTest]
    public IEnumerator FoodNameAndLabelFunction_Test()
    {
        var asyncLoad = SceneManager.LoadSceneAsync("Search Food");
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        var searchBar = GameObject.Find("Search Bar").GetComponent<TMP_InputField>();
        searchBar.text = "beef wellington";
        var searchButton = GameObject.Find("Search Button/Image").GetComponent<Button>();
        searchButton.onClick.Invoke();
        yield return new WaitForSeconds(1.0f);
        var foodEntries = GameObject.FindGameObjectsWithTag("FoodEntry");
        Assert.IsTrue(foodEntries.Length == 13, "No FoodEntry objects were created.");
        var firstFoodEntry = foodEntries[0];
        var firstFoodEntryName = firstFoodEntry.GetComponentInChildren<TMP_Text>().text;
        firstFoodEntry.GetComponent<Button>().onClick.Invoke();
        yield return new WaitForSeconds(1.0f);

        asyncLoad = SceneManager.LoadSceneAsync("Food Selection Info Menu");
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        foodNameText = GameObject.Find("FoodName Text").GetComponent<TMP_Text>();
        var nutritionLabels = GameObject.FindGameObjectsWithTag("NutritionLabel");
        Assert.IsTrue(nutritionLabels.Length > 0, "No NutritionLabel objects found.");
        Assert.AreEqual(firstFoodEntryName, foodNameText.text, "Food Name Text is incorrect.");
    }
}

