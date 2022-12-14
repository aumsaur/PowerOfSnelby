using System;
using System.Collections;
using UnityEngine;

public static class TransitionController
{
    // Call for using Transition via material    
    public static IEnumerator ActivateTransition(Material transitionMaterial, string propertyName, float duration, bool isEnterMode = true, Action callBack = null)
    {
        if (isEnterMode)
        {
            transitionMaterial.SetFloat(propertyName, 0f);

            while (transitionMaterial.GetFloat(propertyName) < 1f)
            {
                transitionMaterial.SetFloat(propertyName, Mathf.MoveTowards(transitionMaterial.GetFloat(propertyName), 1f, 1 / duration * Time.deltaTime));
                yield return null;
            }
        }
        else
        {
            transitionMaterial.SetFloat(propertyName, 1f);

            while (transitionMaterial.GetFloat(propertyName) > 0f)
            {
                transitionMaterial.SetFloat(propertyName, Mathf.MoveTowards(transitionMaterial.GetFloat(propertyName), 0f, 1 / duration * Time.deltaTime));
                yield return null;
            }
        }

        if (callBack != null)
        {
            callBack();
        }
    }

    // Call for using Transition via animator
    public static IEnumerator ActivateTransition(Animator transitionAnimator, string parameterToTrigger, Action callBack = null)
    {
        transitionAnimator.SetTrigger(parameterToTrigger);

        yield return null;

        while (transitionAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1f)
        {
            yield return null;
        }

        if (callBack != null)
        {
            callBack();
        }
    }
}
