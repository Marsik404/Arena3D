using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    private Blink _blink;
    [SerializeField] private Player _playerTarget;

    private Vector3 _targetPositionAfterTeleport;

    [SerializeField] private float _bulletSpeed = 2f;
    [SerializeField] private int _playerDamage = 25;

    void Start()
    {
        _blink = FindObjectOfType<Blink>();
        _playerTarget = FindObjectOfType<Player>();
    }

    void Update()
    {
        if (_playerTarget != null && _playerTarget.IsTeleport == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, _playerTarget.transform.position, _bulletSpeed * Time.deltaTime);
            _targetPositionAfterTeleport = _playerTarget.transform.position;
        }
        else if (_playerTarget.IsTeleport == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPositionAfterTeleport, _bulletSpeed * Time.deltaTime);
            if (transform.position == _targetPositionAfterTeleport)
            {
                _playerTarget.IsTeleport = false;
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            if (_playerTarget != null)
            {
                _blink.ActivateBlink();
                _playerTarget.TakeDamage(_playerDamage);
            }
            Destroy(gameObject);
        }
        Destroy(gameObject);
    }
}
