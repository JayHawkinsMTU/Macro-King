using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomePageTests
{
    private GameObject nutritionButton;
    private GameObject fitnessButton;
    private GameObject dirButton;
    private Animator canvasAnimator;

    [UnitySetUp]
    public IEnumerator SetUp()
    {
        var asyncLoad = SceneManager.LoadSceneAsync("Home Page");
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        yield return new WaitForSeconds(0.5f);

        nutritionButton = GameObject.Find("Nutrition Button");
        fitnessButton = GameObject.Find("Fitness Button");
        dirButton = GameObject.Find("Menu Opener");
        canvasAnimator = GameObject.Find("Home Page").GetComponent<Animator>();
    }

    [UnityTest]
    public IEnumerator NutritionButtonChangesScene_Test()
    {
        var button = nutritionButton.GetComponent<Button>();
        bool sceneChanged = false;
        SceneManager.sceneLoaded += (scene, mode) =>
        {
            if (scene.name == "Nutrition Overview")
            {
                sceneChanged = true;
            }
        };

        button.onClick.Invoke();
        Assert.IsTrue(canvasAnimator.GetCurrentAnimatorStateInfo(0).length > 0, "Animation did not play on Home Page");
        yield return new WaitForSeconds(1.0f);
        Assert.IsTrue(sceneChanged, "Scene change failed.");
    }

    [UnityTest]
    public IEnumerator FitnessButtonChangesScene_Test()
    {
        var button = fitnessButton.GetComponent<Button>();
        bool sceneChanged = false;
        SceneManager.sceneLoaded += (scene, mode) =>
        {
            if (scene.name == "Personal Record Logging")
            {
                sceneChanged = true;
            }
        };

        button.onClick.Invoke();
        Assert.IsTrue(canvasAnimator.GetCurrentAnimatorStateInfo(0).length > 0, "Animation did not play on Home Page");
        yield return new WaitForSeconds(1.0f);
        Assert.IsTrue(sceneChanged, "Scene change failed.");
    }

    [UnityTest]
    public IEnumerator MenuButtonOpensAndAnimation_Test()
    {
        var button = dirButton.GetComponent<Button>();
        button.onClick.Invoke();
        Assert.IsTrue(canvasAnimator.GetCurrentAnimatorStateInfo(0).length > 0, "Animation did not play on Home Page");
        yield return new WaitForSeconds(1.0f);
        var dirMenu = GameObject.Find("MenuOverlay");
        Assert.IsTrue(dirMenu.activeSelf, "Scene activation failed.");
    }
}
