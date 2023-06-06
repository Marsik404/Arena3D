using UnityEngine;

public class EnemyRedMove : MonoBehaviour
{
    private Player _player;
    private Vector3 _startPositionEnemy;

    private float _upDistance = 0.7f;
    [SerializeField] private float _freezeTime = 1f;
    private float _moveSpeed = 1.3f;

    private bool _isMoveUp = true;
    private bool _isFrozen = false;

    private void Start()
    {
        _player = FindObjectOfType<Player>();
        _startPositionEnemy = transform.position;
    }

    private void Update()
    {
        if (_isMoveUp && !_isFrozen)
        {
            Vector3 newPositionEnemy = _startPositionEnemy + Vector3.up * _upDistance;
            transform.position = Vector3.MoveTowards(transform.position, newPositionEnemy, _moveSpeed * Time.deltaTime);

            if (transform.position == newPositionEnemy)
            {
                _isMoveUp = false;
                _isFrozen = true;
                Invoke("StartMovingToPlayer", _freezeTime);
            }
        }
        else if (!_isMoveUp && !_isFrozen)
        {
            if (_player != null)
            {
                Vector3 toPlayer = _player.transform.position;
                transform.position = Vector3.MoveTowards(transform.position, toPlayer, _moveSpeed * Time.deltaTime);
            }
        }
    }

    private void StartMovingToPlayer()
    {
        _isFrozen = false;
    }
}



