using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBaseControl : MonoBehaviour {

  protected CharacterMovementModel m_MovementModel;
  protected CharacterInteractionModel m_InteractionModel;

  private void Awake()
  {
    m_MovementModel = GetComponent<CharacterMovementModel>();
  }

  protected void SetDirection(Vector2 direction)
  {
    if (m_MovementModel == null)
    {
      return;
    }

    m_MovementModel.SetDirection(direction);
  }

  protected void OnActionPressed()
  {
    if(m_InteractionModel == null)
    {
      return;
    }
  }

}
