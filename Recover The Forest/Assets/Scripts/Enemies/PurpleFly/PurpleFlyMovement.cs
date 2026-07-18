using System.Collections.Generic;
using UnityEngine;

public class PurpleFlyMovement : MonoBehaviour
{
    [Header("WayPoints")]
    [SerializeField] List<Transform> _waypoints;
    int _currentWaypointIndex;

    [Header("AreaDetectPlayer")]    
    [SerializeField] Transform _areaDetectPlayer;
    [SerializeField] LayerMask _playerLayer;
    [SerializeField] float _areaDetectRadius;
    public Collider2D _circleAreaPlayer { get; private set; }

    [Header("Scripts")]
    PlayerHealth _playerHealth;
    PurpleFlyAttack _purpleFlyAttack;

    [Header("Enemy Info")]
    [SerializeField] float _speed = 3f;
    [SerializeField] float _arriveDistance = 0.1f;
    [SerializeField] SpriteRenderer _spriteRenderer;
    Rigidbody2D _rig;

    enum EnemyState { Walking, Chasing, Attacking }
    EnemyState _currentState = EnemyState.Walking;
    Vector2 _direction;

    private void Awake()
    {
        _rig = GetComponent<Rigidbody2D>();
        _purpleFlyAttack = GetComponent<PurpleFlyAttack>();
    }

    void FixedUpdate()
    {
        SystemAreaDetect();
        UpdateState();        
        ActionState();
        Movement();
        RotateSprite();
    }

    void Movement()
    {
        switch (_currentState)
        {
            case EnemyState.Walking:
            case EnemyState.Chasing:
                _rig.velocity = _direction * _speed;
                break;

            case EnemyState.Attacking:
                _rig.velocity = Vector2.zero;
                break;
        }
    }

    void SystemAreaDetect()
    {
        _circleAreaPlayer = Physics2D.OverlapCircle(_areaDetectPlayer.position, _areaDetectRadius, _playerLayer);

        if(_circleAreaPlayer != null)
            _playerHealth = _circleAreaPlayer.GetComponent<PlayerHealth>();
    }

    void UpdateState()
    {
        if (_circleAreaPlayer == null)
            _currentState = EnemyState.Walking;

        else if(Vector2.Distance(_rig.position, _circleAreaPlayer.transform.position) <= 1)
            _currentState = EnemyState.Attacking;

        else
            _currentState = EnemyState.Chasing;
    }

    void Walking()
    {
        Transform targetWaypoint = _waypoints[_currentWaypointIndex];
        _direction = ((Vector2)targetWaypoint.position - _rig.position).normalized;

        float distance = Vector2.Distance(_rig.position, targetWaypoint.position);

        if (distance <= _arriveDistance)
        {
            _currentWaypointIndex++;

            if (_currentWaypointIndex >= _waypoints.Count)
                _currentWaypointIndex = 0;
        }
    }

    void Attacking()
        => _purpleFlyAttack.ExecuteAttack(_playerHealth);

    void Chasing()
        => _direction = ((Vector2)_circleAreaPlayer.transform.position - _rig.position).normalized;

    void RotateSprite()
    {
        if (_direction.x > 0)
            _spriteRenderer.flipX = true;

        else if (_direction.x < 0)
            _spriteRenderer.flipX = false;
    }
    
    void ActionState()
    {
        switch (_currentState)
        {
            case EnemyState.Walking:
                Walking();
                break;

            case EnemyState.Chasing:
                Chasing();
                break;

            case EnemyState.Attacking:
                Attacking();
                break;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(_areaDetectPlayer.position, _areaDetectRadius);

        if (_waypoints == null || _waypoints.Count == 0)
            return;

        Gizmos.color = Color.cyan;

        for (int i = 0; i < _waypoints.Count; i++)
        {
            if (_waypoints[i] == null)
                continue;

            Gizmos.DrawSphere(_waypoints[i].position, 0.15f);
            Transform nextWaypoint = _waypoints[(i + 1) % _waypoints.Count];

            if (nextWaypoint != null)
                Gizmos.DrawLine(_waypoints[i].position, nextWaypoint.position);
        }
    }
}