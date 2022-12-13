using KinematicCharacterController;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterAttribute : MonoBehaviour
{
    [SerializeField, ReadOnly] private int _healthValue;
    [SerializeField] private int _maxHealthValue;
    [SerializeField] private GameObject floatingTextPrefabs;
    [SerializeField] private TMP_Text healthHUDText; 

    public int healthValue { get { return _healthValue; } }
    public int maxHealthValue { get { return _maxHealthValue; } set { _maxHealthValue = value; } }

    // Start is called before the first frame update
    void Start()
    {
        _healthValue = _maxHealthValue;    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DecreaseHealth()
    {
        _healthValue -= 1;
        GameObject newFloatingText = Instantiate(floatingTextPrefabs, transform.position, Quaternion.identity, transform);
        newFloatingText.GetComponentInChildren<TextMeshPro>().text = "MISS";
        newFloatingText.GetComponentInChildren<TextMeshPro>().color = Color.red;
    }

    public void IncreaseHealth()
    {
        _healthValue += 1;
        GameObject newFloatingText = Instantiate(floatingTextPrefabs, transform.position, Quaternion.identity, transform);
        newFloatingText.GetComponentInChildren<TextMeshPro>().text = "HIT";
        newFloatingText.GetComponentInChildren<TextMeshPro>().color = new Color(0, 60, 0, 255);
    }
}
