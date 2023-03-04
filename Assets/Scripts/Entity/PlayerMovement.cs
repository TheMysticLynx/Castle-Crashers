using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 4f;
    public Vector2 movementAxisMultiplier = new Vector2(1, 0.5f);
    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        #region Flip Player Sprite

        var horizontalMovement = Input.GetAxisRaw("Horizontal");

        //Flip sprite towards movement
        if (horizontalMovement < 0)
        {
            var localScale = transform.localScale;
            transform.localScale = new Vector3(-Math.Abs(localScale.x), localScale.y, localScale.z);
        } else if (horizontalMovement > 0)
        {
            var localScale = transform.localScale;
            transform.localScale = new Vector3(Math.Abs(localScale.x), localScale.y, localScale.z);
        }

        #endregion

        #if UNITY_EDITOR

        Debug.DrawLine(transform.position, transform.position + Vector3.right * horizontalMovement);

        #endif
    }

    private void FixedUpdate()
    {
        #region Movement

        var horizontalMovement = Input.GetAxisRaw("Horizontal");
        var verticalMovement = Input.GetAxisRaw("Vertical");

        var moveVector = new Vector3(horizontalMovement, verticalMovement).normalized
                         * (movementSpeed * Time.fixedDeltaTime);
        var newPosition = transform.position + moveVector;

        _rb.MovePosition(newPosition * movementAxisMultiplier);

        #endregion
    }
}