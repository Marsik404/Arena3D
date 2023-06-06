using UnityEngine;
using UnityEngine.AI;

public class EnemyBlue : Enemy
{
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private BulletEnemy _bulletEnemy;
    [SerializeField] private Player _targetPlayer;

    public GameObject BulletPrefab;
    public Transform SpawnBullet;

    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private int _currentHealth;
    [SerializeField] private int _pointsDeath = 50;

    private float _shotPeriod = 3f;
    private float _timer;

    private void Start()
    {
        _targetPlayer = FindObjectOfType<Player>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _currentHealth = _maxHealth;
    }

    private void Update()
    {
        if (_targetPlayer != null)
        {
            _navMeshAgent.SetDestination(_targetPlayer.transform.position);
        }

        _timer += Time.deltaTime;

        if (_timer >= _shotPeriod)
        {
            _timer = 0;

            Instantiate(BulletPrefab, SpawnBullet.transform.position, _targetPlayer.transform.rotation);
        }
    }

    public override void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            Player _player = FindObjectOfType<Player>();
            if (_player != null)
            {
                _player.TakeStrength(_pointsDeath);
            }
            Destroy();
        }
    }

    public override void Destroy()
    {
        Destroy(gameObject);
    }
}
