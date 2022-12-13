using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor;
using UnityEngine;

public class Door : InteractableObject
{
    //[SerializeField] private float initDegrees;
    [SerializeField] protected float targetDegrees;
    [SerializeField] protected bool isLocked;

    protected bool isOpen = false;

    protected float t = 0f;

    void Start()
    {
        
    }

    public virtual void Unlock()
    {
        isLocked = false;
    }

    public override void Interact()
    {
        if (!isLocked)
        {
            StartCoroutine(Flipflop());
        }
        else
        {
            Debug.Log("This door is locked.");
        }
    }

    public virtual IEnumerator Flipflop()
    {
        while (t <= 1f)
        {
            yield return null;
            t += Time.deltaTime;
            Vector3 rotation = transform.localEulerAngles;
            rotation.y = Mathf.Lerp(isOpen ? targetDegrees : 0, isOpen ? 0 : targetDegrees, t);
            transform.localEulerAngles = rotation;
        }

        if (t > 1f)
        {
            isOpen = !isOpen;
            t = 0f;
        }
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(Door))]
    public class DoorEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            Door script = (Door)target;
            if (GUILayout.Button("Interact"))
            {
                script.Interact(); // how do i call this?
            }
        }
    }
#endif
}
