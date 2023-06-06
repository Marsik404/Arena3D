using UnityEngine;

public class Player : MonoBehaviour
{
    private Camera _camera;
    private ScoreManager _scoreHelper;
    public GameObject BulletPrefab;
    public Transform SpawnBullet;

    private int _maxHealth = 100;
    private int _maxStrength = 100;
    [field: SerializeField] public int CurrentStrength { get; set; }
    [field: SerializeField] public int CurrentHealth { get; set; }
    [field: SerializeField] public int CountEnemy { get; set; }

    private bool _isUltimateReady = false;
    public bool IsTeleport { get; set; } = false;

    private float _bulletSpeed = 2f;

    private void Start()
    {
        _scoreHelper = FindObjectOfType<ScoreManager>();
        _camera = FindObjectOfType<Camera>();
        CurrentHealth = _maxHealth;
        CurrentStrength = 50;
    }

    private void Update()
    {
        if (transform.position.x < -3.5f || transform.position.x > 3.5f || transform.position.z < -3.5f || transform.position.z > 3.5f)
        {
            TeleportToRandomLocation();
        }
    }

    public void Attack()
    {
        Vector3 cameraCenter = _camera.ScreenToWorldPoint(new Vector3(Screen.width / 2f, Screen.height / 2f, _camera.nearClipPlane));
        GameObject newBullet = Instantiate(BulletPrefab, cameraCenter, Quaternion.identity);
        newBullet.GetComponent<Rigidbody>().AddForce(_camera.transform.forward * _bulletSpeed, ForceMode.VelocityChange);
        Destroy(newBullet, 5f);
    }

    public void Ulta()
    {
        if (_isUltimateReady)
        {
            Enemy[] enemies = FindObjectsOfType<Enemy>();
            foreach (Enemy enemy in enemies)
            {
                CountEnemy++;
                enemy.Destroy();
            }
            CurrentStrength = 0;
            _isUltimateReady = false;
        }
    }

    private void TeleportToRandomLocation()
    {
        Vector3 randomPosition = new Vector3(Random.Range(-4.4f, 4.4f), 0f, Random.Range(-4.4f, 4.4f));
        transform.position = randomPosition;
        IsTeleport = true;
    }

    public void TakeDamage(int value)
    {
        CurrentHealth -= value;
        if (CurrentHealth <= 0)
        {
            _scoreHelper.GameOver();
        }
    }

    public void TakeStrength(int value)
    {
        CurrentStrength += value;
        if (CurrentStrength >= _maxStrength)
        {
            _isUltimateReady = true;
            CurrentStrength = _maxStrength;
        }
    }
}