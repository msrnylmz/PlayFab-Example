using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region PublicFields
    public Rigidbody2D PlayerRigidbody;
    public Camera GameCamera;
    public float Speed = 5f;
    #endregion PublicFields

    #region Fields
    private Vector2 _mousePosition;
    private Vector2 _movement;
    #endregion Fields

    #region UnityMethods
    void FixedUpdate()
    {
        Vector2 target = PlayerRigidbody.position + _movement * Time.fixedDeltaTime * Speed;
        PlayerRigidbody.MovePosition(target);

        Vector2 lookDirection = _mousePosition - PlayerRigidbody.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        PlayerRigidbody.rotation = angle;
    }
    #endregion UnityMethods

    #region Methods
    public void PlayerSetInput()
    {
        _mousePosition = GameCamera.ScreenToWorldPoint(Input.mousePosition);
        _movement.y = Input.GetAxisRaw("Vertical");
        _movement.x = Input.GetAxisRaw("Horizontal");
    }
    #endregion Methods
}
