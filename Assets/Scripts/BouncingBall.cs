using UnityEngine;

public class BouncingBall : MonoBehaviour
{
    [SerializeField] private float _threshold;
    [SerializeField] private float _bounceForce;
    [SerializeField] private Color _belowColor;
    [SerializeField] private Color _normalColor;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Renderer _ballRenderer;

    private bool _belowThreshold = false;
    private float _timeBelowThreshold = 0f;

    private void Awake()
    {
        _rigidbody.velocity = Vector3.up * _bounceForce;
    }

    private void FixedUpdate()
    {
        if (_rigidbody.velocity.magnitude < _threshold)
        {
            if (!_belowThreshold)
            {
                _belowThreshold = true;
                _ballRenderer.material.color = _belowColor;
                _timeBelowThreshold = 0f;
            }

            _timeBelowThreshold += Time.fixedDeltaTime;
        }
        else
        {
            if (_belowThreshold)
            {
                _belowThreshold = false;
                _ballRenderer.material.color = _normalColor;
                Debug.Log($"Время ниже порога: {_timeBelowThreshold} секунд");
            }
        }

        if (transform.position.y <= 0.51f && _rigidbody.velocity.y <= 0f)
        {
            do
            {
                _rigidbody.velocity = Vector3.up * _bounceForce;
            } while (_rigidbody.velocity.y < _bounceForce * 0.9f);
        }
    }
}
