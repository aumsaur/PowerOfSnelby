using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader: MonoBehaviour
{
    public static LevelLoader currentInstance { get; private set; }

    [SerializeField] private Material _material; // SceneTransition Material
    [SerializeField] private Animator _animator; // SceneTransition Animator

    [SerializeField] private string _fieldName; // Var to manipulate in SceneTransition

    [SerializeField] private float _duration; // Duration of transition

    private void Start()
    {
        currentInstance = this;
    }

    public void LoadScene(int levelIndex)
    {
        StartCoroutine(LoadSceneAsync(levelIndex));
    }

    public void LoadScene(string levelName)
    {
        StartCoroutine(LoadSceneAsync(levelName));
    }

    public IEnumerator LoadSceneAsync(int levelIndex)
    {
        AsyncOperation progress = SceneManager.LoadSceneAsync(levelIndex);
        while (!progress.isDone)
        {
            yield return null;
        }
    }
    public IEnumerator LoadSceneAsync(string levelName)
    {
        AsyncOperation progress = SceneManager.LoadSceneAsync(levelName);
        while (!progress.isDone)
        {
            yield return null;
        }
    }
}
