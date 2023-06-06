using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Player _player;

    private int _enemyDamage = 100;
    private float _bulletSpeed = 30f;
    //private Vector3 _diretcionBulletAfterRicochet;
    //private bool _isRecoshetBullet = false;
    private float _lowHealth = 50f;

    private void Start()
    {
        _player = FindObjectOfType<Player>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(_enemyDamage);
            _player.CountEnemy++;
            ChangeDirectionRandom();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Bonus()
    {
        int randomNumberHealth = Random.Range(0, 2);
        if (randomNumberHealth == 1)
        {
            _player.CurrentHealth += 50;
        }
        else
        {
            _player.CurrentStrength += Random.Range(1, 25);
        }
    }

    private void ChangeDirectionRandom()
    {
        //float chance = 1 - (_player.CurrentHealth / 100);
        //float randomNumber = Random.Range(0, 1);
        //if (randomNumber < chance)
        //GetComponent<Rigidbody>().AddForce(direction * _bulletSpeed, ForceMode.VelocityChange);
        //transform.position = Vector3.MoveTowards(transform.position, transform.forward, _bulletSpeed * Time.deltaTime);

        if (_player.CurrentHealth < _lowHealth)
        {
            Enemy nearEnemy = FindNearEnemy();
            Vector3 toNearEnemy = (nearEnemy.transform.position - transform.position).normalized;
            //GetComponent<Rigidbody>().AddForce(toNearEnemy * _bulletSpeed, ForceMode.VelocityChange);
            transform.position = Vector3.MoveTowards(transform.position, toNearEnemy, _bulletSpeed * Time.deltaTime);

            if (transform.position == nearEnemy.transform.position)
            {
                nearEnemy.TakeDamage(_enemyDamage);
                Destroy(gameObject);
                Bonus();
            }
        }
    }

    private Enemy FindNearEnemy()
    {
        List<Enemy> enemies = new List<Enemy>(FindObjectsOfType<Enemy>());
        Enemy targetEnemy = enemies[0];
        foreach (var enemy in enemies)
        {
            if (Vector3.Distance(transform.position, enemy.transform.position) <
                Vector3.Distance(transform.position, targetEnemy.transform.position))
            {
                targetEnemy = enemy;
            }
        }
        return targetEnemy;
    }
}




