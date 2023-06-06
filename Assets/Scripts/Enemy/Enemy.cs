using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public virtual void TakeDamage(int damage)
    {
    }

    public virtual void Destroy()
    {
    }
}
