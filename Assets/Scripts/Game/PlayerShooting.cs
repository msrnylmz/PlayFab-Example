using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    #region PublicFields
    public PlayerController PlayerController;
    public Transform FirePoint;
    public GameObject BulletPrefab;

    public float ShootRate;
    #endregion PublicFields

    #region Fields
    private float _nextShootTime;
    #endregion Fields


    #region Methods

    public void Initialize()
    {
        BulletInitialize();
    }

    public void Controller()
    {
        if (Input.GetMouseButton(0) && Time.time > _nextShootTime)
        {
            _nextShootTime = Time.time + ShootRate;
            Shoot();
        }
    }
    private void BulletInitialize()
    {
        List<GameObject> bullets = ObjectPool.Instance.PooledObject["Bullet"];
        foreach (GameObject bullet in bullets)
        {
            bullet.GetComponent<Bullet>().PlayerController = this.PlayerController;
        }
    }

    private void Shoot()
    {
        GameObject cloneBullet = ObjectPool.Instance.SpawnFromPool("Bullet", FirePoint.position, FirePoint.rotation);
        Bullet bullet = cloneBullet.GetComponent<Bullet>();
        if (bullet.PlayerController == null)
        {
            bullet.PlayerController = PlayerController;
        }
    }
    #endregion Methods
}
