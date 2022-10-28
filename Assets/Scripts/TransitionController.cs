using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TransitionController
{
    public static IEnumerator ActivateTransition(Material transitionMaterial, string propertyName, float duration, bool isEnterMode = true, Action todo = null)
    {
        if (isEnterMode)
        {
            transitionMaterial.SetFloat(propertyName, 0f);

            while (transitionMaterial.GetFloat(propertyName) <= 1f)
            {
                transitionMaterial.SetFloat(propertyName, Mathf.MoveTowards(transitionMaterial.GetFloat(propertyName), 1f, 1 / duration * Time.deltaTime));
                yield return null;
            }
        }
        else
        {
            transitionMaterial.SetFloat(propertyName, 1f);

            while (transitionMaterial.GetFloat(propertyName) >= 0f)
            {
                transitionMaterial.SetFloat(propertyName, Mathf.MoveTowards(transitionMaterial.GetFloat(propertyName), 0f, 1 / duration * Time.deltaTime));
                yield return null;
            }
        }

        if (todo != null)
        {
            todo();
        }
    }

    public static IEnumerator ActivateTransition(Animator transitionAnimator, string parameterToTrigger, float duration)
    {
        transitionAnimator.SetTrigger(parameterToTrigger);
        string clipName = transitionAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.name;

        while (transitionAnimator.GetCurrentAnimatorStateInfo(0).IsName(clipName))
        {
            Debug.Log(clipName);
            yield return null;
        }
    }

    public static IEnumerator ActivateTransition(Animator transitionAnimator, string parameterToTrigger, float duration = 0, Action todo = null)
    {
        transitionAnimator.SetTrigger(parameterToTrigger);
        string clipName = transitionAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.name;

        while (transitionAnimator.GetCurrentAnimatorStateInfo(0).IsName(clipName))
        {
            Debug.Log(clipName);
            yield return null;
        }

        if (todo != null)
        {
            todo();
        }
    }
}
