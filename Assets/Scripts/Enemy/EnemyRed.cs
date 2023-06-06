using UnityEngine;

public class EnemyRed : Enemy
{
    private Blink _blink;
    private EnemyRed _redEnemy;
    private Player _targetPlayer;

    [SerializeField] private int _maxHealth = 50;
    [SerializeField] private int _currentHealth;
    [SerializeField] private int _pointsDeath = 15;

    private void Start()
    {
        _blink = FindObjectOfType<Blink>();
        _redEnemy = GetComponent<EnemyRed>();
        _targetPlayer = FindObjectOfType<Player>();
        _currentHealth = _maxHealth;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_redEnemy != null)
        {
            if (collision.gameObject.GetComponent<Player>())
            {
                if (_targetPlayer != null)
                {
                    _blink.ActivateBlink();

                    _targetPlayer.TakeDamage(_pointsDeath);
                }
                Destroy(gameObject);
            }
        }
    }

    public override void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            Destroy();
        }
    }

    public override void Destroy()
    {
        Player _player = FindObjectOfType<Player>();
        if (_player != null)
        {
            _player.TakeStrength(_pointsDeath);
        }
        Destroy(gameObject);
    }
}
