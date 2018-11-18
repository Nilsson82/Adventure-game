using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementView : MonoBehaviour {

  public Animator Animator;

  private CharacterMovementModel m_MovementModel;

	// Use this for initialization
	void Awake ()
  {
    m_MovementModel = GetComponent<CharacterMovementModel>();

    if (Animator == null)
    {
      Debug.LogError("Character Animator not setup!");
      enabled = false;
    }
	}
	
	// Update is called once per frame
	void Update ()
  {
    UpdateDirection();

  }

  void UpdateDirection()
  {
    Vector3 direction = m_MovementModel.GetDirection();

    if(direction != Vector3.zero)
    {
      Animator.SetFloat("DirectionX", direction.x);
      Animator.SetFloat("DirectionY", direction.y);
    }

    Animator.SetBool("IsMoving", m_MovementModel.IsMoving());
  }

}
