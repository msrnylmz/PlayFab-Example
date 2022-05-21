using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    #region PublicFields
    public PlayerMovement PlayerMovement;
    public GameObject EnemyPrefab;
    public Transform[] EnemySpawnPoints;
    public Transform EnemyParent;
    #endregion PublicFields

    #region Methods
    public void Initialize()
    {
        CancelInvoke(nameof(InstanceEnemy));
        Invoke(nameof(InstanceEnemy), 0.5f);
    }

    public void Reset()
    {
        List<GameObject> enemys = ObjectPool.Instance.PooledObject["Enemy"];
        foreach (GameObject enemy in enemys)
        {
            enemy.SetActive(false);
        }
    }

    private void InstanceEnemy()
    {
        int random = Random.Range(0, EnemySpawnPoints.Length);
        GameObject clone = ObjectPool.Instance.SpawnFromPool("Enemy", EnemySpawnPoints[random].position, Quaternion.identity);
        if (clone != null)
        {
            EnemyMovement enemyMovement = clone.GetComponent<EnemyMovement>();
            if (enemyMovement != null)
            {
                enemyMovement.Target = PlayerMovement.PlayerRigidbody.transform;
            }
        }
        float spawnRandom = Random.Range(0.1f, 1f);
        Invoke(nameof(InstanceEnemy), spawnRandom);
    }
    #endregion Methods
}
