using System.Collections;
using TMPro;
using UnityEngine;

public class MazeDoor : Door
{
    [SerializeField] private bool isCorrectDoor;
    [SerializeField] private float timeToDissolve;
    [SerializeField] private GameObject floatingTextPrefabs;
    //[SerializeField] private Material material;

    private GameObject newFloatingText;
    private Material _material;

    // Start is called before the first frame update
    void Start()
    {
        _material = GetComponentInChildren<MeshRenderer>().material;
        newFloatingText = Instantiate(floatingTextPrefabs, transform.position, Quaternion.identity, transform);
        newFloatingText.GetComponentInChildren<TextMeshPro>().text = "";
    }

    public override void Interact()
    {
        StartCoroutine(Dissolve());
    }

    IEnumerator Dissolve()
    {
        while (_material.GetFloat("_Dissolve") < 1)
        {
            _material.SetFloat("_Dissolve", Mathf.MoveTowards(_material.GetFloat("_Dissolve"), 1f, 1 / timeToDissolve * Time.deltaTime));
            if (_material.GetFloat("_Dissolve") > .5f)
            {
                transform.GetChild(0).GetComponent<BoxCollider>().isTrigger = true;
            }
            yield return null;
        }
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
