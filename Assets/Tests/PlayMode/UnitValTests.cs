using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UnitValueEntryTests
{
    private GameObject backButton;
    private GameObject menuButton;
    private GameObject addButton;
    private TMP_Dropdown dropdown;
    private TMP_InputField inputField;
    private Animator canvasAnimator;

    [UnitySetUp]
    public IEnumerator SetUp()
    {
        var asyncLoad = SceneManager.LoadSceneAsync("UnitValueEntry");
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        backButton = GameObject.Find("Back Button/Image");
        menuButton = GameObject.Find("Menu Button/Image");
        addButton = GameObject.Find("Add Button/Image");
        dropdown = GameObject.Find("Dropdown").GetComponent<TMP_Dropdown>();
        inputField = GameObject.Find("Input 1").GetComponent<TMP_InputField>();
        canvasAnimator = GameObject.Find("Unit Value Entry Page").GetComponent<Animator>();
    }

    [UnityTest, Order(2)]
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

    [UnityTest, Order(1)]
    public IEnumerator BackButton_ChangesScene()
    {
        var button = backButton.GetComponent<Button>();

        bool sceneChanged = false;
        SceneManager.sceneLoaded += (scene, mode) =>
        {
            if (scene.name == "Food Selection Info Menu")
            {
                sceneChanged = true;
            }
        };
        

        button.onClick.Invoke();
        yield return null;
        Assert.IsTrue(canvasAnimator.GetCurrentAnimatorStateInfo(0).length > 0, "Animation did not play on Canvas for Back Button");
        yield return new WaitForSeconds(1.0f);
        Assert.IsTrue(sceneChanged, "Scene change to 'Food Selection Info Menu' failed.");
    }

    [UnityTest, Order(3)]
    public IEnumerator AddButton_PlaysAnimation_InvalidInput()
    {
        var button = addButton.GetComponent<Button>();
        LogAssert.Expect(LogType.Error, "System.FormatException: Input string was not in a correct format.");

        button.onClick.Invoke();
        yield return null;
        Assert.IsTrue(canvasAnimator.GetCurrentAnimatorStateInfo(0).length > 0, "Animation did not play on Canvas for Add Button");

        bool sceneNotChanged = true;
        SceneManager.sceneLoaded += (scene, mode) =>
        {
            if (scene.name == "Daily Nutrition")
            {
                sceneNotChanged = false;
            }
        };

        
        yield return new WaitForSeconds(1.0f);
        Assert.IsTrue(sceneNotChanged, "Scene should not change due to invalid input.");
    }
    
    [UnityTest, Order(4)]
    public IEnumerator UnitEntryTest()
    {
        SceneManager.LoadScene("Calendar");
        yield return new WaitForSeconds(0.5f);

        var calendarDays = GameObject.FindGameObjectsWithTag("CalendarDay");
        var calendarDay = System.Array.Find(calendarDays, day => day.GetComponentInChildren<TMP_Text>().text == "8");
        Assert.IsNotNull(calendarDay, "CalendarDay object with value '8' not found.");
        calendarDay.GetComponent<Button>().onClick.Invoke();

        yield return new WaitForSeconds(1.0f);
        Assert.AreEqual("Daily Nutrition", SceneManager.GetActiveScene().name, "Did not change to 'Daily Nutrition' scene.");

        var addBtn = GameObject.Find("Add Btn").GetComponent<Button>();
        addBtn.onClick.Invoke();

        yield return new WaitForSeconds(1.0f);
        Assert.AreEqual("Search Food", SceneManager.GetActiveScene().name, "Did not change to 'Search Food' scene.");

        var searchBar = GameObject.Find("Search Bar").GetComponent<TMP_InputField>();
        searchBar.text = "beef jerky";
        var searchButton = GameObject.Find("Search Button/Image").GetComponent<Button>();
        searchButton.onClick.Invoke();

        yield return new WaitForSeconds(1.0f);

        var foodEntries = GameObject.FindGameObjectsWithTag("FoodEntry");
        var firstFoodEntry = foodEntries[0];
        var firstFoodEntryName = firstFoodEntry.GetComponentInChildren<TMP_Text>().text;
        firstFoodEntry.GetComponent<Button>().onClick.Invoke();

        yield return new WaitForSeconds(1.0f);
        Assert.AreEqual("Food Selection Info Menu", SceneManager.GetActiveScene().name, "Did not change to 'Food Selection Info Menu' scene.");

        var addFoodBtn = GameObject.Find("Add Button/Image").GetComponent<Button>();
        addFoodBtn.onClick.Invoke();

        yield return new WaitForSeconds(1.0f);
        Assert.AreEqual("UnitValueEntry", SceneManager.GetActiveScene().name, "Did not change to 'Unit Value Entry' scene.");

        var foodNameText = GameObject.Find("Food Name").GetComponent<TMP_Text>();
        Assert.AreEqual(firstFoodEntryName, foodNameText.text, "Food Name text is incorrect.");

        var input1 = GameObject.Find("Input 1").GetComponent<TMP_InputField>();
        input1.text = "420000";

        var dropdown = GameObject.Find("Dropdown").GetComponent<TMP_Dropdown>();
        dropdown.value = 1; 

        var addButton = GameObject.Find("Add Button/Image").GetComponent<Button>();
        addButton.onClick.Invoke();

        yield return new WaitForSeconds(1.0f);
        Assert.AreEqual("Daily Nutrition", SceneManager.GetActiveScene().name, "Did not change to 'Daily Nutrition' scene.");

        var foodEntryDaily = GameObject.FindGameObjectWithTag("FoodEntryDaily");
        Assert.IsNotNull(foodEntryDaily, "FoodEntryDaily object not found.");

        var amountText = foodEntryDaily.transform.Find("Amount").GetComponent<TMP_Text>();
        Assert.AreEqual("420000 kg", amountText.text, "FoodEntryDaily amount text is incorrect.");
    }
}
