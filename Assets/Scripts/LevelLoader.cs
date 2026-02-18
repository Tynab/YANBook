using System.Collections;
using UnityEngine;
using static UnityEngine.SceneManagement.SceneManager;

public class LevelLoader : MonoBehaviour
{
    [Header("Animation Settings")]
    [Tooltip("Animator cho transition animation")]
    public Animator TransitionAnimator;

    public IEnumerator LoadSceneWithAnimation(string targetSceneName)
    {
        const float delayBeforeLoad = 1f;

        if (TransitionAnimator != null)
        {
            const string animationTrigger = "Start";

            TransitionAnimator.SetTrigger(animationTrigger);
        }

        yield return new WaitForSeconds(delayBeforeLoad);

        LoadScene(targetSceneName);
    }
}
