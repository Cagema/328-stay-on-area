using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] float _lifeTime;
    float _timer = 100;
    float _randTime;

    private void NewTime()
    {
        _randTime = _lifeTime + Random.Range(-3, 3);
    }

    private void FixedUpdate()
    {
        if (GameManager.Single.GameActive)
        {
            _timer += Time.deltaTime;
            if (_timer > _randTime )
            {
                _timer = 0;
                NewPos();
                NewTime();
            }
        }
    }

    private void NewPos()
    {
        transform.position = new(Random.Range(-GameManager.Single.RightUpperCorner.x, GameManager.Single.RightUpperCorner.x), transform.position.y);
    }
}
