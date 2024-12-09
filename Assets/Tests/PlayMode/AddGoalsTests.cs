using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class AddGoalsTests
{
    private GameObject caloriesButton;
    private GameObject proteinButton;
    private GameObject carbsButton;
    private GameObject fatButton;
    private GameObject conditionLessButton;
    private GameObject conditionEqualButton;
    private GameObject conditionMoreButton;
    private GameObject backButton;
    private GameObject menuButton;
    private GameObject addButton;
    private Animator canvasAnimator;


    [UnitySetUp]
    public IEnumerator SetUp()
    {
        var asyncLoad = SceneManager.LoadSceneAsync("Add Nutrition Goal");
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
       
        caloriesButton = GameObject.Find("Macro: Calories");
        proteinButton = GameObject.Find("Macro: Protein");
        carbsButton = GameObject.Find("Macro: Carbs");
        fatButton = GameObject.Find("Macro: Fat");
        conditionLessButton = GameObject.Find("Condition: <");
        conditionEqualButton = GameObject.Find("Condition: =");
        conditionMoreButton = GameObject.Find("Condition: >");
        backButton = GameObject.Find("Back Btn");
        menuButton = GameObject.Find("Menu Button (1)/Image");
        addButton = GameObject.Find("Add Btn"); 
        canvasAnimator = GameObject.Find("Add Goals Page").GetComponent<Animator>();
    }

    [UnityTest, Order(1)]
    public IEnumerator CaloriesButton_PlaysAnimation()
    {
        var button = caloriesButton.GetComponent<Button>();
        Assert.IsNotNull(button, "Calories Button component not found");

        button.onClick.Invoke();
        yield return null;
        Assert.IsTrue(canvasAnimator.GetCurrentAnimatorStateInfo(0).length > 0, "Animation did not play on Canvas for Calories Button");
    }

    [UnityTest, Order(2)]
    public IEnumerator ProteinButton_PlaysAnimation()
    {
        var button = proteinButton.GetComponent<Button>();
        Assert.IsNotNull(button, "Protein Button component not found");

        button.onClick.Invoke();
        yield return null;
        Assert.IsTrue(canvasAnimator.GetCurrentAnimatorStateInfo(0).length > 0, "Animation did not play on Canvas for Protein Button");
    }

    [UnityTest, Order(3)]
    public IEnumerator CarbsButton_PlaysAnimation()
    {
        var button = carbsButton.GetComponent<Button>();
        Assert.IsNotNull(button, "Carbs Button component not found");

        button.onClick.Invoke();
        yield return null;
        Assert.IsTrue(canvasAnimator.GetCurrentAnimatorStateInfo(0).length > 0, "Animation did not play on Canvas for Carbs Button");
    }

    [UnityTest, Order(4)]
    public IEnumerator FatButton_PlaysAnimation()
    {
        var button = fatButton.GetComponent<Button>();
        Assert.IsNotNull(button, "Fat Button component not found");

        button.onClick.Invoke();
        yield return null;
        Assert.IsTrue(canvasAnimator.GetCurrentAnimatorStateInfo(0).length > 0, "Animation did not play on Canvas for Fat Button");
    }

    [UnityTest, Order(5)]
    public IEnumerator ConditionLessButton_PlaysAnimation()
    {
        var button = conditionLessButton.GetComponent<Button>();
        Assert.IsNotNull(button, "Condition Less Button component not found");

        button.onClick.Invoke();
        yield return null;
        Assert.IsTrue(canvasAnimator.GetCurrentAnimatorStateInfo(0).length > 0, "Animation did not play on Canvas for Condition Less Button");
    }

    [UnityTest, Order(6)]
    public IEnumerator ConditionEqualButton_PlaysAnimation()
    {
        var button = conditionEqualButton.GetComponent<Button>();
        Assert.IsNotNull(button, "Condition Equal Button component not found");

        button.onClick.Invoke();
        yield return null;
        Assert.IsTrue(canvasAnimator.GetCurrentAnimatorStateInfo(0).length > 0, "Animation did not play on Canvas for Condition Equal Button");
    }

    [UnityTest, Order(7)]
    public IEnumerator ConditionMoreButton_PlaysAnimation()
    {
        var button = conditionMoreButton.GetComponent<Button>();
        Assert.IsNotNull(button, "Condition More Button component not found");

        button.onClick.Invoke();
        yield return null;
        Assert.IsTrue(canvasAnimator.GetCurrentAnimatorStateInfo(0).length > 0, "Animation did not play on Canvas for Condition More Button");
    }

    
    [UnityTest, Order(9)]
    public IEnumerator BackButton_ChangesScene()
    {
        var button = backButton.GetComponent<Button>();
        Assert.IsNotNull(button, "Back Button component not found");

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
        Assert.IsTrue(canvasAnimator.GetCurrentAnimatorStateInfo(0).length > 0, "Animation did not play on Canvas for Back Button");
        yield return new WaitForSeconds(1.0f);
        Assert.IsTrue(sceneChanged, "Scene change failed.");
    }

    [UnityTest, Order(8)]
    public IEnumerator MenuButton_OpensMenu()
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

    [UnityTest, Order(10)]
    public IEnumerator AddButton_ChangesScene()
    {
        var button = addButton.GetComponent<Button>();
        Assert.IsNotNull(button, "Add Button component not found");

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
        Assert.IsTrue(canvasAnimator.GetCurrentAnimatorStateInfo(0).length > 0, "Animation did not play on Canvas for Add Button");
        yield return new WaitForSeconds(1.0f);
        Assert.IsTrue(sceneChanged, "Scene change failed.");
    }
    
}
