using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region PublicFields
    public GameManager GameManager;

    public int PlayerXP;
    public int EnemyDestroyCount;
    #endregion PublicFields

    #region Methods
    public void IncrementEnemyDestroyCount()
    {
        EnemyDestroyCount++;
        GameManager.UIManager.GamePlayUI.ShowKillCount(EnemyDestroyCount);
    }

    #endregion UnityMethods
}
