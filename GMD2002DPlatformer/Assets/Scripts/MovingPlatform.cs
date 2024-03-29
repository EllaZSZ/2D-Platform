// Programmed By Arija

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Transform[] movePoints;
    public bool moving = true;

    private int _pointIndex = 0;
    private Transform _currentPoint;

    // Start is called before the first frame update
    void Start()
    {
        _currentPoint = movePoints[_pointIndex];
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (moving)
        {
            transform.position = (Vector3)Vector2.MoveTowards(current: (Vector2)transform.position, target: (Vector2)_currentPoint.position, moveSpeed);
            if (Vector2.Distance(a: transform.position, b: _currentPoint.position) < 0.01f)
            {
                _pointIndex++;
                _pointIndex %= movePoints.Length;
                _currentPoint = movePoints[_pointIndex];
            }
        }
    }
}
