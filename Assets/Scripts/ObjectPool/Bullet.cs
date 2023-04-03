using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Vector3 speed;

    private IObjectPool<Bullet> bulletPool;


    private void Update()
    {
        transform.position += speed * Time.deltaTime;
    }

    public void SetPool(IObjectPool<Bullet> _pool)
    {
        bulletPool = _pool;
    }

    private void OnBecameInvisible()
    {
        bulletPool.Release(this);
    }
}
