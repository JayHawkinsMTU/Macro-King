using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneAnimHandler : MonoBehaviour
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
        yield return new WaitForSeconds(length - 0.07f);
        SceneManager.LoadScene(sceneName);
    }
}
