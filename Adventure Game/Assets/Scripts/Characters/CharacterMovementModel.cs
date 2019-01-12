using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementModel : MonoBehaviour
{
    public float Speed;

    private Vector3 m_MovementDirection;
    private Vector3 m_FacingDirection;

    Rigidbody2D m_Body;

    private bool m_IsFrozen;
    private bool m_IsAttacking;

    // Use this for initialization
    void Awake()
    {
        m_Body = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        //Set the player to start lock down.
        SetDirection(new Vector2(0, -1));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateMovement();
    }

    public void SetFrozen(bool isFrozen)
    {
        m_IsFrozen = isFrozen;
    }

    void UpdateMovement()
    {
        if(m_IsFrozen == true)
        {
            return;
        }

        if (m_MovementDirection != Vector3.zero)
        {
            //Normalize only works if it has motion, so not zero. Used to move as fast on diagonal as up, down left and right.
            m_MovementDirection.Normalize();
        }

        m_Body.velocity = m_MovementDirection * Speed;
    }

    public void SetDirection(Vector2 direction)
    {
        if (m_IsFrozen == true)
        {
            return;
        }

        m_MovementDirection = new Vector3(direction.x, direction.y, 0);

        if (direction != Vector2.zero)
        {
            m_FacingDirection = m_MovementDirection;
        }
    }

    public Vector3 GetFacingDirection()
    {
        return m_FacingDirection;
    }

    public Vector3 GetDirection()
    {
        return m_MovementDirection;
    }

    public bool IsMoving()
    {
        if(m_IsFrozen == true)
        {
            return false;
        }
        return m_MovementDirection != Vector3.zero;
    }

    public bool CanAttack()
    {
        if(m_IsAttacking == true)
        {
            return false;
        }
        return true;
    }

    public void DoAttack()
    {
  
    }

    public void OnAttackStarted()
    {
        m_IsAttacking = true;
        Debug.Log("OnAttackStarted");
    }

    public void OnAttackFinished()
    {
        m_IsAttacking = false;
        Debug.Log("OnAttackFinished");
    }

}
