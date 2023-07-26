using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimSprites : MonoBehaviour
{
    [SerializeField] Sprite[] _sprites;
    int _index;
    float _timer;
    SpriteRenderer _sr;
    private void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (GameManager.Single.GameActive)
        {
            if (Input.GetMouseButton(0))
            {
                _timer += Time.deltaTime;
                if (_timer > 0.25f)
                {
                    _timer = 0;
                    _sr.sprite = _sprites[++_index % _sprites.Length];
                }
            }
            else
            {
                _sr.sprite = _sprites[1];
            }
        }
    }
}
