using UnityEngine;

public class SpriteBillboard : MonoBehaviour
{
    private Transform _mainTransform;
    private Animator _animator;
    private SpriteRenderer _renderer;

    [SerializeField] private bool freezeXZAxis = true;
    [SerializeField] private float backAngle = 65f;
    [SerializeField] private float sideAngle = 155f;

    private void Start()
    {
        _mainTransform = transform.parent;


        _renderer = GetComponent<SpriteRenderer>();

        if (TryGetComponent<Animator>(out Animator buffer))
        {
            _animator = buffer;
        }
    }

    void LateUpdate()
    {
        Vector3 camForwardVector = new Vector3(Camera.main.transform.forward.x, 0f, Camera.main.transform.forward.z);

        if (freezeXZAxis)
        {
            transform.rotation = Quaternion.Euler(0f, Camera.main.transform.rotation.eulerAngles.y, 0f);
        }
        else
        {
            transform.rotation = Camera.main.transform.rotation;
        }

        float signedAngle = Vector3.SignedAngle(_mainTransform.forward, camForwardVector, Vector3.up);

        Vector2 animationDirection = new Vector2(0f, -1f);

        float angle = Mathf.Abs(signedAngle);

        if (angle < backAngle) // Look from Back
        {
            animationDirection = new Vector2(0f, -1f);
        }
        else if (angle < sideAngle) // Look from Side
        {
            animationDirection = new Vector2(1f, 0f);

            if (signedAngle < 0)
            {
                if (_renderer != null)
                    _renderer.flipX = false;
                else
                    transform.Rotate(new Vector3(0, 0, 0));
            }
            else
            {
                if (_renderer != null)
                    _renderer.flipX = true;
                else
                    transform.Rotate(new Vector3(0, 180, 0));
            }
        }
        else // Look from Neither (Front)
        {
            animationDirection = new Vector2(0f, 1f);
        }

        if (_animator != null)
        {
            _animator.SetFloat("X", animationDirection.x);
            _animator.SetFloat("Y", animationDirection.y);
        }

    }
}
