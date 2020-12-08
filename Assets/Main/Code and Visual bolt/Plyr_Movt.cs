using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Plyr_Movt : MonoBehaviour
{
    [SerializeField]
    private Vector2 _velocity;
    [SerializeField]
    private int _lineVision = 3;
    [SerializeField]
    private Vector3 _direction;
    [SerializeField]
    private bool _hasMoved;

    public Tilemap fogtiles;

    private void Update()
    {
        if (_velocity.x == 0)
        {
            _hasMoved = false;
        }
        else if (_velocity.x != 0 && !_hasMoved)
        {
            _hasMoved = true;
            MoveDirection();
        }
        _velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    private void MoveDirection()
    {
        if (_velocity.x < 0)
        {
            if (_velocity.y > 0)
            {
                _direction = new Vector3(-0.5f, 0.5f);
            }
            else if (_velocity.y < 0)
            {
                _direction = new Vector3(-0.5f, -0.5f);
            }
            else
            {
                _direction = new Vector3(-1, 0);
            }
        }
        else if (_velocity.x > 0)
        {
            if (_velocity.y > 0)
            {
                _direction = new Vector3(0.5f, 0.5f);
            }
            else if (_velocity.y < 0)
            {
                _direction = new Vector3(0.5f, -0.5f);
            }
            else
            {
                _direction = new Vector3(1, 0);
            }
        }

        transform.position += _direction;
        UpdateFog();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        transform.position -= _direction;
    }

    void UpdateFog()
    {
        Vector3Int currentPlyPos = fogtiles.WorldToCell(transform.position);
        for (int i = -3; i <= 3; i++)
        {
            for (int j = -3; j <= 3; j++)
            {
                fogtiles.SetTile(currentPlyPos + new Vector3Int(i, j, 0), null);
            }
        }
    }

}
