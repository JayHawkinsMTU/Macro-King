using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class CalendarSceneTests
{
    private GameObject backButton;
    private GameObject forwardButton;
    private GameObject menuButton;
    private GameObject monthDisplay;
    private Animator canvasAnimator;

    [UnitySetUp]
    public IEnumerator SetUp()
    {
        var asyncLoad = SceneManager.LoadSceneAsync("Calendar");
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        backButton = GameObject.Find("Backwards");
        forwardButton = GameObject.Find("Forwards");
        menuButton = GameObject.Find("Button Opener");
        monthDisplay = GameObject.Find("Month Name");
        canvasAnimator = GameObject.Find("CalendarPage").GetComponent<Animator>();
    }

    private GameObject FindDayButton(string dayText)
    {
        var calendarDays = GameObject.FindGameObjectsWithTag("CalendarDay");
        foreach (var day in calendarDays)
        {
            var tmpText = day.GetComponentInChildren<TMP_Text>();
            if (tmpText.text == dayText)
            {
                return day;
            }
        }
        return null;
    }

    [UnityTest]
    public IEnumerator BackButtonFunction_Test()
    {
        var button = backButton.GetComponent<Button>();
        string initialMonth = monthDisplay.GetComponent<TMP_Text>().text;

        button.onClick.Invoke();
        yield return new WaitForSeconds(1.0f);

        string newMonth = monthDisplay.GetComponent<TMP_Text>().text;
        Assert.IsTrue(canvasAnimator.GetCurrentAnimatorStateInfo(0).length > 0, "Animation did not play on Calendar Page");
        Assert.AreNotEqual(initialMonth, newMonth, "Month change failed.");
    }

    [UnityTest]
    public IEnumerator ForwardButtonFunction_Test()
    {
        var button = forwardButton.GetComponent<Button>();
        string initialMonth = monthDisplay.GetComponent<TMP_Text>().text;

        button.onClick.Invoke();
        yield return new WaitForSeconds(1.0f);

        string newMonth = monthDisplay.GetComponent<TMP_Text>().text;
        Assert.IsTrue(canvasAnimator.GetCurrentAnimatorStateInfo(0).length > 0, "Animation did not play on Calendar Page");
        Assert.AreNotEqual(initialMonth, newMonth, "Month change failed.");
    }

    [UnityTest]
    public IEnumerator MenuButtonOpensAndAnimation_Test()
    {
        var button = menuButton.GetComponent<Button>();

        button.onClick.Invoke();
        yield return new WaitForSeconds(1.0f);

        var dirMenu = GameObject.Find("MenuOverlay");
        Assert.IsTrue(canvasAnimator.GetCurrentAnimatorStateInfo(0).length > 0, "Animation did not play on Calendar Page");
        Assert.IsTrue(dirMenu.activeSelf, "Menu activation failed.");
    }

    [UnityTest]
    public IEnumerator InvalidDayPopupFunction_Test()
    {
        var invalidDayButton = FindDayButton("");
        var button = invalidDayButton.GetComponent<Button>();

        button.onClick.Invoke();
        yield return new WaitForSeconds(1.0f);

        var invalidPopup = GameObject.Find("Invalid Popup");
        Assert.IsTrue(canvasAnimator.GetCurrentAnimatorStateInfo(0).length > 0, "Animation did not play on Calendar Page");
        Assert.IsTrue(invalidPopup.activeSelf, "Invalid Popup activation failed.");
    }

    [UnityTest]
    public IEnumerator CurrentDayChangesScene_Test()
    {
        var validDayButton = FindDayButton("9"); 
        var button = validDayButton.GetComponent<Button>();

        bool sceneChanged = false;
        SceneManager.sceneLoaded += (scene, mode) =>
        {
            if (scene.name == "Daily Nutrition")
            {
                sceneChanged = true;
            }
        };

        button.onClick.Invoke();
        Assert.IsTrue(canvasAnimator.GetCurrentAnimatorStateInfo(0).length > 0, "Animation did not play on Calendar Page");
        yield return new WaitForSeconds(1.5f);
        Assert.IsTrue(sceneChanged, "Scene change failed.");
    }

    [UnityTest]
    public IEnumerator CurrentDayFunction_Test()
    {
        var validDayButton = FindDayButton("9"); 
        var button = validDayButton.GetComponent<Button>();

        bool sceneChanged = false;
        SceneManager.sceneLoaded += (scene, mode) =>
        {
            if (scene.name == "Daily Nutrition")
            {
                sceneChanged = true;
            }
        };

        button.onClick.Invoke();
        Assert.IsTrue(canvasAnimator.GetCurrentAnimatorStateInfo(0).length > 0, "Animation did not play on Calendar Page");
        yield return new WaitForSeconds(1.5f);
        Assert.IsTrue(sceneChanged, "Scene changed failed.");

        var dateDisplay = GameObject.Find("Date Display").GetComponent<TMP_Text>();
        string expectedDate = "Monday\n12/9/2024";
        Assert.AreEqual(expectedDate, dateDisplay.text, "Displayed date is incorrect");
    }


    [UnityTest]
    public IEnumerator ValidDayChangesScene_Test()
    {
        var validDayButton = FindDayButton("17");
        var button = validDayButton.GetComponent<Button>();

        bool sceneChanged = false;
        SceneManager.sceneLoaded += (scene, mode) =>
        {
            if (scene.name == "Daily Nutrition")
            {
                sceneChanged = true;
            }
        };

        button.onClick.Invoke();
        yield return new WaitForSeconds(1.5f);
        Assert.IsTrue(sceneChanged, "Scene changed failed.");
    }

    [UnityTest]
    public IEnumerator ValidDayFunction_Test()
    {
        var validDayButton = FindDayButton("17"); 
        var button = validDayButton.GetComponent<Button>();

        bool sceneChanged = false;
        SceneManager.sceneLoaded += (scene, mode) =>
        {
            if (scene.name == "Daily Nutrition")
            {
                sceneChanged = true;
            }
        };

        button.onClick.Invoke();
        Assert.IsTrue(canvasAnimator.GetCurrentAnimatorStateInfo(0).length > 0, "Animation did not play on Calendar Page");
        yield return new WaitForSeconds(1.5f);
        Assert.IsTrue(sceneChanged, "Scene changed failed.");

        var dateDisplay = GameObject.Find("Date Display").GetComponent<TMP_Text>();
        string expectedDate = "Tuesday\n12/17/2024";
        Assert.AreEqual(expectedDate, dateDisplay.text, "Displayed date is incorrect");
    }
}
