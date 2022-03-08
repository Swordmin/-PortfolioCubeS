using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathWalk : MonoBehaviour
{

    [SerializeField] private List<Transform> _points;
    [SerializeField] private Transform _currentPoint;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private SpriteRenderer _sprite;
    [SerializeField] private float _speed;
    [SerializeField] private bool _miror;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        _currentPoint = _points[0];
    }

    private void Update() 
    {
        if (Vector2.Distance(transform.position, _currentPoint.position) > 0.01f)
        {
            Vector2 direction = _currentPoint.position - transform.position;
            _rigidbody.velocity = direction.normalized * _speed;
        }
        else
            GetNextPoint();


        if (!_miror)
            return;
        if (_currentPoint.transform.position.x > transform.position.x)
            _sprite.flipX = false;
        else
            _sprite.flipX = true;
            

    }

    private void OnDrawGizmos()
    {
        foreach(Transform transform in _points) 
        {
            if (_currentPoint == transform)
                Gizmos.color = Color.red;
            else
                Gizmos.color = Color.green;
            Gizmos.DrawSphere(transform.position, 0.04f);
        }
    }

    private void GetNextPoint()
    {
        for (int i = 0; i < _points.Count; i++)
        {
            if (_points[i] == _currentPoint)
                if (i != _points.Count-1)
                {
                    _currentPoint = _points[i + 1];
                    break;
                }
                else
                {
                    _currentPoint = _points[0];
                    break;
                }
        }
    }


}
