using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class NutritionGoalsTests
{
    private GameObject backButton;
    private GameObject menuButton;
    private GameObject addButton;
    private Animator canvasAnimator;
    private Animator canvasAnimator2;

    [UnitySetUp]
    public IEnumerator SetUp()
    {
        var asyncLoad = SceneManager.LoadSceneAsync("Nutrition Goals");
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        backButton = GameObject.Find("Back Button/Image");
        menuButton = GameObject.Find("Menu Button/Image");
        addButton = GameObject.Find("Add Button/Image");
        canvasAnimator = GameObject.Find("Nutrition Goals Page").GetComponent<Animator>();
    }

    [UnityTest, Order(2)]
    public IEnumerator BackButtonChangesScene_Test()
    {
        var button = backButton.GetComponent<Button>();

        bool sceneChanged = false;
        SceneManager.sceneLoaded += (scene, mode) =>
        {
            if (scene.name == "Nutrition Overview")
            {
                sceneChanged = true;
            }
        };

        button.onClick.Invoke();
        yield return null;
        Assert.IsTrue(canvasAnimator.GetCurrentAnimatorStateInfo(0).length > 0, "Animation did not play on Canvas for Back Button");
        yield return new WaitForSeconds(1.0f);
        Assert.IsTrue(sceneChanged, "Scene change to 'Nutrition Overview' failed.");
    }

    [UnityTest, Order(1)]
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

    [UnityTest, Order(3)]
    public IEnumerator AddButtonChangesScene_Test()
    {
        var button = addButton.GetComponent<Button>();

        bool sceneChanged = false;
        SceneManager.sceneLoaded += (scene, mode) =>
        {
            if (scene.name == "Add Nutrition Goal")
            {
                sceneChanged = true;
            }
        };

        button.onClick.Invoke();
        yield return null;
        Assert.IsTrue(canvasAnimator.GetCurrentAnimatorStateInfo(0).length > 0, "Animation did not play on Canvas for Add Button");
        yield return new WaitForSeconds(1.0f);
        Assert.IsTrue(sceneChanged, "Scene change to 'Add Nutrition Goal' failed.");

        var pageName = GameObject.Find("Page Name").GetComponent<TMP_Text>();
        Assert.AreEqual("ADD GOAL", pageName.text, "Page name is incorrect.");

        var inputField = GameObject.Find("InputField (TMP)").GetComponent<TMP_InputField>();
        inputField.text = "420";

        var macroButton = GameObject.Find("Macro: Protein").GetComponent<Button>();
        macroButton.onClick.Invoke();

        var conditionButton = GameObject.Find("Condition: >").GetComponent<Button>();
        conditionButton.onClick.Invoke();

        var addBtnGoal = GameObject.Find("Add Btn").GetComponent<Button>();
        addBtnGoal.onClick.Invoke();
    }

    [UnityTest, Order(4)]
    public IEnumerator EditGoalButtonFunctionAndAnimation_Test()
    {
        var asyncLoad = SceneManager.LoadSceneAsync("Nutrition Goals");
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        var nutritionGoalObject = GameObject.FindGameObjectWithTag("NutritionGoal");
        Assert.IsNotNull(nutritionGoalObject, "Nutrition Goal object not found.");

        var goalName = nutritionGoalObject.transform.Find("Goal Name").GetComponent<TMP_Text>();
        Assert.AreEqual("Calories=420cals", goalName.text, "Goal Name is incorrect.");

        var editButton = nutritionGoalObject.transform.Find("Edit").GetComponent<Button>();

        bool sceneChanged = false;
        SceneManager.sceneLoaded += (scene, mode) =>
        {
            if (scene.name == "Add Nutrition Goal")
            {
                sceneChanged = true;
            }
        };

        editButton.onClick.Invoke();
        yield return new WaitForSeconds(1.0f);
        Assert.IsTrue(sceneChanged, "Scene change to 'Add Nutrition Goal' failed.");
        canvasAnimator2 = GameObject.Find("Add Goals Page").GetComponent<Animator>();

        var pageName = GameObject.Find("Page Name").GetComponent<TMP_Text>();
        Assert.AreEqual("EDIT GOAL", pageName.text, "Page name is incorrect.");

        var inputField = GameObject.Find("InputField (TMP)").GetComponent<TMP_InputField>();
        inputField.text = "555";

        var macroButton = GameObject.Find("Macro: Fat").GetComponent<Button>();
        macroButton.onClick.Invoke();

        var conditionButton = GameObject.Find("Condition: <").GetComponent<Button>();
        conditionButton.onClick.Invoke();

        var saveExitButton = GameObject.Find("SaveExit Button/Image").GetComponent<Button>();

        sceneChanged = false;
        SceneManager.sceneLoaded += (scene, mode) =>
        {
            if (scene.name == "Nutrition Goals")
            {
                sceneChanged = true;
            }
        };

        saveExitButton.onClick.Invoke();
        yield return null;
        Assert.IsTrue(canvasAnimator2.GetCurrentAnimatorStateInfo(0).length > 0, "Animation did not play on Canvas for Save Button");
        yield return new WaitForSeconds(1.0f);
        Assert.IsTrue(sceneChanged, "Scene change to 'Nutrition Goals' failed.");

        nutritionGoalObject = GameObject.FindGameObjectWithTag("NutritionGoal");
        goalName = nutritionGoalObject.transform.Find("Goal Name").GetComponent<TMP_Text>();
        Assert.AreEqual("Fat<555fat", goalName.text, "Goal Name is incorrect.");
    }

    [UnityTest, Order(5)]
    public IEnumerator DeleteGoalButtonFunctionAndAnimation_Test()
    {
        var asyncLoad = SceneManager.LoadSceneAsync("Nutrition Goals");
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        var nutritionGoalObject = GameObject.FindGameObjectWithTag("NutritionGoal");
        var editButton = nutritionGoalObject.transform.Find("Edit").GetComponent<Button>();

        bool sceneChanged = false;
        SceneManager.sceneLoaded += (scene, mode) =>
        {
            if (scene.name == "Add Nutrition Goal")
            {
                sceneChanged = true;
            }
        };

        editButton.onClick.Invoke();
        yield return new WaitForSeconds(1.0f);
        Assert.IsTrue(sceneChanged, "Scene change to 'Add Nutrition Goal' failed.");
        canvasAnimator2 = GameObject.Find("Add Goals Page").GetComponent<Animator>();

        var removeButton = GameObject.Find("Remove Button/Image").GetComponent<Button>();

        sceneChanged = false;
        SceneManager.sceneLoaded += (scene, mode) =>
        {
            if (scene.name == "Nutrition Goals")
            {
                sceneChanged = true;
            }
        };

        removeButton.onClick.Invoke();
        yield return null;
        Assert.IsTrue(canvasAnimator2.GetCurrentAnimatorStateInfo(0).length > 0, "Animation did not play on Canvas for Delete Button");
        yield return new WaitForSeconds(1.0f);
        Assert.IsTrue(sceneChanged, "Scene change to 'Nutrition Goals' failed.");

        var nutritionGoals = GameObject.FindGameObjectsWithTag("NutritionGoal");
        Assert.AreEqual(0, nutritionGoals.Length, "Nutrition Goal object was not deleted.");
    }
}
