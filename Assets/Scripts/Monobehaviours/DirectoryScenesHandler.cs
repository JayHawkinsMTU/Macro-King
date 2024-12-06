using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Stefan K: Chooses which scene to change to based on which menu is selected
/// </summary>


public class DirectoryScenesHandler : MonoBehaviour
{
    [SerializeField] string sceneName;
    public Animator animator;
    public AnimationClip anim;

    public void ChangeScene(string animTrigger)
    {
        animator.SetTrigger(animTrigger);
        StartCoroutine(ChangeSceneAfterAnim());
    }

    private IEnumerator ChangeSceneAfterAnim()
    {
        float length = anim.length;
        yield return new WaitForSeconds(length - 0.05f);
        SceneManager.LoadScene(sceneName);
    }
}







