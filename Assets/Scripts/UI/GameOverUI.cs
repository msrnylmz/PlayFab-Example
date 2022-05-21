using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameOverUI : MonoBehaviour
{
    #region PublicFields
    public UIManager UIManager;

    public Text KillText;
    public Text TimeText;
    #endregion PublicFields


    #region Methods
    public void Initialize()
    {
        KillText.text = UIManager.GameManager.PlayerController.EnemyDestroyCount.ToString();
        TimeText.text = UIManager.GameManager.GameTime.ToString();
    }
    #endregion Methods
}
