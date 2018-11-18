using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementModel : MonoBehaviour
{
  public float Speed;

  private Vector3 m_MovementDirection;

  Rigidbody2D m_Body;

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

  void UpdateMovement()
  {
    if (m_MovementDirection != Vector3.zero)
    {
      //Normalize only works if it has motion, so not zero. Used to move as fast on diagonal as up, down left and right.
      m_MovementDirection.Normalize();
    }

    m_Body.velocity = m_MovementDirection * Speed;
  }

  public void SetDirection(Vector2 direction)
  {
    m_MovementDirection = new Vector3(direction.x, direction.y, 0);
  }

  public Vector3 GetDirection()
  {
    return m_MovementDirection;
  }

  public bool IsMoving()
  {
    return m_MovementDirection != Vector3.zero;
  }
}
