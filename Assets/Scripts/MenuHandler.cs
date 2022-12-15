using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHandler : MonoBehaviour
{
    [SerializeField] private Animator transitionAnimator;
    [SerializeField] private string propertyField;

    [SerializeField] private int MenuSceneID;
    [SerializeField] private int RoamingSceneID;
    public int BattleSceneID;

    [SerializeField] private int IntroSceneID;

    public void OnStartScene()
    {
        if (transitionAnimator != null)
            StartCoroutine(TransitionController.ActivateTransition(transitionAnimator, propertyField, null));
        LevelLoader.currentInstance.LoadScene(IntroSceneID);
    }

    // Start is called before the first frame update
    public void OnBackToMenu()
    {
        if (transitionAnimator != null)
            StartCoroutine(TransitionController.ActivateTransition(transitionAnimator, propertyField, null));
        LevelLoader.currentInstance.LoadScene(MenuSceneID);
    }

    public void OnContinue()
    {
        if (transitionAnimator != null)
            StartCoroutine(TransitionController.ActivateTransition(transitionAnimator, propertyField, null));
        LevelLoader.currentInstance.LoadScene(RoamingSceneID);
    }

    public void OnQuitGame()
    {
        Application.Quit();
    }
}
