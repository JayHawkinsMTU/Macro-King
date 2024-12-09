using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PersonalRecordTests
{
    private GameObject menuButton;
    private GameObject editButton;
    private GameObject addButton;
    private Animator canvasAnimator;
    private Animator canvasAnimator2;

    [UnitySetUp]
    public IEnumerator SetUp()
    {
        var asyncLoad = SceneManager.LoadSceneAsync("Personal Record Logging");
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        yield return new WaitForSeconds(0.5f);

        menuButton = GameObject.Find("Menu Button/Image");
        editButton = GameObject.Find("Edit Button/Image");
        addButton = GameObject.Find("Add Button/Image");
        canvasAnimator = GameObject.Find("PR Log Page").GetComponent<Animator>();
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
    public IEnumerator EditButton_PlaysAnimation()
    {
        var button = editButton.GetComponent<Button>();

        button.onClick.Invoke();
        yield return null;
        Assert.IsTrue(canvasAnimator.GetCurrentAnimatorStateInfo(0).length > 0, "Animation did not play on Canvas for Edit Button");
    }

    [UnityTest]
    public IEnumerator AddButton_PlaysAnimation()
    {
        var button = addButton.GetComponent<Button>();

        button.onClick.Invoke();
        yield return null;
        Assert.IsTrue(canvasAnimator.GetCurrentAnimatorStateInfo(0).length > 0, "Animation did not play on Canvas for Add Button");

        yield return new WaitForSeconds(1.0f);

        canvasAnimator2 = GameObject.Find("Add PR").GetComponent<Animator>();
        Assert.IsNotNull(canvasAnimator2, "Add PR canvas not found.");

        yield return null;
        Assert.IsTrue(canvasAnimator2.GetCurrentAnimatorStateInfo(0).length > 0, "Appearance animation did not play on Add PR canvas");

        var closeButton = GameObject.Find("Close Menu Button").GetComponent<Button>();  
        closeButton.onClick.Invoke();
        yield return new WaitForSeconds(1.0f);
        var prLogCanvas = GameObject.Find("PR Log Page").GetComponent<CanvasGroup>();
        Assert.IsTrue(prLogCanvas.interactable, "Add PR canvas did not close properly.");
    }

    [UnityTest]
    public IEnumerator AddPRTest()
    {
        var button = addButton.GetComponent<Button>();

        button.onClick.Invoke();
        yield return new WaitForSeconds(0.5f);

        canvasAnimator2 = GameObject.Find("Add PR").GetComponent<Animator>();
        Assert.IsNotNull(canvasAnimator2, "Add PR canvas not found.");

        var input1 = GameObject.Find("Input 1").GetComponent<TMP_InputField>();
        input1.text = "1";

        var input2 = GameObject.Find("Input 2").GetComponent<TMP_InputField>();
        input2.text = "2000";

        var input4 = GameObject.Find("Input 4").GetComponent<TMP_InputField>();
        input4.text = "12";

        var input5 = GameObject.Find("Input 5").GetComponent<TMP_InputField>();
        input5.text = "Saitama Training";

        var input6 = GameObject.Find("Input 6").GetComponent<TMP_InputField>();
        input6.text = "6000";

        var input7 = GameObject.Find("Input 7").GetComponent<TMP_InputField>();
        input7.text = "Complete";

        var addPrButton = GameObject.Find("Add PR Button").GetComponent<Button>();
        addPrButton.onClick.Invoke();

        yield return new WaitForSeconds(1.0f);

        var prGoalObject = GameObject.FindGameObjectWithTag("PRGoal");
        Assert.IsNotNull(prGoalObject, "PRGoal object not found.");

        var title = prGoalObject.transform.Find("title").GetComponent<TMP_Text>();
        Assert.AreEqual("2000", title.text, "PRGoal title is incorrect.");
    }
}
