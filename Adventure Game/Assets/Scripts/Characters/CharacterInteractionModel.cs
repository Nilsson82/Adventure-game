using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Character))]
public class CharacterInteractionModel : MonoBehaviour
{
    private Character m_Character;
    private Collider2D m_Collider;
    private CharacterMovementModel m_MovementModel;
    // Use this for initialization
    void Awake ()
    {
        m_Character = GetComponent<Character>();
        m_Collider = GetComponent<Collider2D>();
        m_MovementModel = GetComponent<CharacterMovementModel>();
   
    }
	
    // Update is called once per frame
    void Update ()
    {
		
    }


    public void OnInteract()
    {
        InteractableBase usableInteractable = FindUsableInteracable();

        if(usableInteractable == null)
        {
            return;
        }

        usableInteractable.OnInteract(m_Character);
        // Debug.Log("Found InteractableBase: " + usableInteractable.name);
    }

    InteractableBase FindUsableInteracable()
    {
    //Debug.Log("List of Interactables: ");

    Collider2D[] closeColliders = Physics2D.OverlapCircleAll(transform.position, 0.8f);
    InteractableBase closestInteractable = null;
    float angleToClosestInteractble = Mathf.Infinity;
    for (int i = 0; i < closeColliders.Length; ++i)
    {
        //Debug.Log(i + ": " + closeColliders[i].name);

        InteractableBase colliderInteractable = closeColliders[i].GetComponent<InteractableBase>();
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
