using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBaseControl : MonoBehaviour {

  protected CharacterMovementModel m_MovementModel;

  private void Awake()
  {
    m_MovementModel = GetComponent<CharacterMovementModel>();
  }

  protected void SetDirection(Vector2 direction)
  {
    m_MovementModel.SetDirection(direction);
  }


}
