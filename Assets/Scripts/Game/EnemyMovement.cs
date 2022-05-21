using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    #region PublicFields
    public Transform Target;
    public Rigidbody2D EnemyRigidbody;
    public int Speed;
    public bool Follow;
    #endregion PublicFields

    #region Fields
    private Vector2 _explosionObjectDefaultLocalScale;
    private Transform _explosionObject;
    private Animator animator;
    #endregion Fields


    #region UnityMethods

    void Awake()
    {
        Initialize();
    }
    void OnDisable()
    {
        Disable();
    }

    void FixedUpdate()
    {
        FollowPlayer();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            EnemyRigidbody.isKinematic = true;
            Follow = false;
            animator.SetBool("explosion", true);
        }
    }
    #endregion UnityMethods

    #region Methods

    private void FollowPlayer()
    {
        if (Follow)
        {
            Vector3 direction = (Target.transform.position - transform.position).normalized;
            EnemyRigidbody.MovePosition(transform.position + direction * Speed * Time.fixedDeltaTime);
        }
    }

    private void Disable()
    {
        EnemyRigidbody.isKinematic = false;
        animator.SetBool("explosion", false);
        _explosionObject.localScale = _explosionObjectDefaultLocalScale;
        _explosionObject.gameObject.SetActive(false);
        Follow = true;
    }

    private void Initialize()
    {
        EnemyRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Follow = true;
        _explosionObject = transform.GetChild(0);
        _explosionObjectDefaultLocalScale = _explosionObject.localScale;
    }

    public void ReturnToPool()
    {
        ObjectPool.Instance.ReturnToPool(gameObject);
    }
    #endregion Methods

}
