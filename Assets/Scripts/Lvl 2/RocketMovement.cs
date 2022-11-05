using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    [SerializeField] private float _maxSpeed = 3f;
    [SerializeField] private float _tilt = 3f;

    private float _currentSpeed = 0;
    private Vector3 _direction = Vector3.zero;


    private void Update()
    {
        if (!GameManager.Instance.IsPlayMode) return;

#if UNITY_EDITOR
        _currentSpeed = Input.GetAxis("Horizontal") * _maxSpeed;
#endif
        _direction = Vector2.right * _currentSpeed;
        transform.Translate(_direction * Time.deltaTime);
        float x = Mathf.Clamp(transform.position.x, GameManager.Instance.MinX, GameManager.Instance.MaxX);
        _direction.x = x;
        _direction.y = GameManager.Instance.PosY;
        transform.position = _direction;
        transform.rotation = Quaternion.Euler(Vector3.down * _currentSpeed * _tilt);
    }
}
