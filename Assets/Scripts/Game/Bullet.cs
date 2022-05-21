using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    #region PublicFields
    public int BulletSpeed;
    public int DestroyTime;

    public PlayerController PlayerController;
    #endregion PublicFields

    #region Fields
    private Coroutine _deactiveCoroutine;
    #endregion


    #region UnityMethods


    // Bullet addforce
    void OnEnable()
    {
        Rigidbody2D bulletRigidbody = GetComponent<Rigidbody2D>();
        bulletRigidbody.velocity = Vector2.zero;
        bulletRigidbody.AddForce(transform.right * BulletSpeed, ForceMode2D.Impulse);

        if (_deactiveCoroutine != null)
        {
            StopCoroutine(_deactiveCoroutine);
        }
        _deactiveCoroutine = StartCoroutine(Deactive(DestroyTime));

    }
    // Return to pool
    void OnCollisionEnter2D(Collision2D col)
    {
        GameObject colObject = col.gameObject;
        if (colObject.CompareTag("Enemy"))
        {
            ObjectPool.Instance.ReturnToPool(colObject);
            ObjectPool.Instance.ReturnToPool(gameObject);
            PlayerController.IncrementEnemyDestroyCount();
        }
    }
    #endregion UnityMethods


    #region Methods
    IEnumerator Deactive(float wait)
    {
        yield return new WaitForSeconds(wait);
        ObjectPool.Instance.ReturnToPool(gameObject);
    }
    #endregion Methods
}
