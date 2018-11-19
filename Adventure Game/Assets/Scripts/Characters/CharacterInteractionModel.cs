using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteractionModel : MonoBehaviour
{
  private Collider2D m_Collider;
  private CharacterMovementModel m_MovementModel;
  // Use this for initialization
  void Awake ()
  {
    m_Collider = GetComponent<Collider2D>();
    m_MovementModel = GetComponent<CharacterMovementModel>();

  }
	
	// Update is called once per frame
	void Update ()
  {
		
	}


  public void OnInteract()
  {
    Interactable usableInteractable = FindUsableInteracable();

    if(usableInteractable == null)
    {
      return;
    }

    Debug.Log("Found Interactable: " + usableInteractable.name);
  }

  Interactable FindUsableInteracable()
  {
    Debug.Log("List of Interactables: ");

    Collider2D[] closeColliders = Physics2D.OverlapCircleAll(transform.position, 1f);
    Interactable closestInteractable = null;
    float angleToClosestInteractble = Mathf.Infinity;
    for (int i = 0; i < closeColliders.Length; ++i)
    {
      //Debug.Log(i + ": " + closeColliders[i].name);

      Interactable colliderInteractable = closeColliders[i].GetComponent<Interactable>();
      if (colliderInteractable == null)
      {
        continue;
      }

      Vector3 directionToInteractble = closeColliders[i].transform.position - transform.position;
      float angleToInteractable = Vector3.Angle(m_MovementModel.GetFacingDirection(), directionToInteractble);

      //Debug.Log(i + ": " + closeColliders[i].name + " - " + angleToInteractable);
      //Debug.Log(m_MovementModel.GetDirection() + " - " + directionToInteractble);

      if (angleToInteractable < 40)
      {
        if (angleToInteractable < angleToClosestInteractble)
        {
          closestInteractable = colliderInteractable;
          angleToClosestInteractble = angleToInteractable;
        }
      }
      
    }

    return closestInteractable;

  }
}
