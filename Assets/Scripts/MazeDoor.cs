using System.Collections;
using TMPro;
using UnityEngine;

public class MazeDoor : Door
{
    [SerializeField] private bool isCorrectDoor;
    [SerializeField] private float timeToDissolve;
    [SerializeField] private GameObject floatingTextPrefabs;

    private GameObject newFloatingText;

    // Start is called before the first frame update
    void Start()
    {
        newFloatingText = Instantiate(floatingTextPrefabs, transform.position, Quaternion.identity, transform);
        newFloatingText.GetComponentInChildren<TextMeshPro>().text = "";
    }

    public override void Interact()
    {
        //StartCoroutine(Dissolve());
    }

    IEnumerator Dissolve()
    {
        yield return new WaitForSeconds(timeToDissolve);
        gameObject.SetActive(false);
        newFloatingText.SetActive(false);
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.GetComponent<Player>();
            MazeHandler.currentInstance.GrantReward(isCorrectDoor, Dissolve());
        }
    }
}
