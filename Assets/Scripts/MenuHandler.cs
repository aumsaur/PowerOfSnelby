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

    // Start is called before the first frame update
    public void OnBackToMenu()
    {
        StartCoroutine(TransitionController.ActivateTransition(transitionAnimator, propertyField, null));
        LevelLoader.currentInstance.LoadSceneAsync(MenuSceneID);
    }

    public void OnContinue()
    {
        StartCoroutine(TransitionController.ActivateTransition(transitionAnimator, propertyField, null));
        LevelLoader.currentInstance.LoadSceneAsync(RoamingSceneID);
    }

    public void OnQuitGame()
    {
        Application.Quit();
    }
}
