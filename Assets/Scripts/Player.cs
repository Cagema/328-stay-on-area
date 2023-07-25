using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] float _timeBetweenScore;

    Vector2 _mousePos;
    float _timeInArea;

    private void Update()
    {
        if (GameManager.Single.GameActive)
        {
            if (Input.GetMouseButton(0))
            {
                _mousePos = GameManager.Single.MainCamera.ScreenToWorldPoint(Input.mousePosition);

                float newX = Mathf.Clamp(transform.position.x + ((_mousePos.x > 0 ? _speed : -_speed) * Time.deltaTime), -GameManager.Single.RightUpperCorner.x + 1, GameManager.Single.RightUpperCorner.x - 1);
                transform.position = new Vector3(newX, transform.position.y, transform.position.z);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            GameManager.Single.Lives--;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Target"))
        {
            _timeInArea += Time.deltaTime;
            if (_timeInArea >= _timeBetweenScore)
            {
                _timeInArea = 0;
                GameManager.Single.Score++;
            }
        }
    }
}
