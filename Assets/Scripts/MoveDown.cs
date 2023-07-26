using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    [SerializeField] GameObject _particlePrefab;

    private void Update()
    {
        transform.Translate(GameManager.Single.Speed * Time.deltaTime * Vector3.down);
    }

    private void FixedUpdate()
    {
        if (transform.position.y < -4)
        {
            Instantiate(_particlePrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
