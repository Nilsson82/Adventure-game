using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableSign : InteractableBase
{
    public string Text;

	// Use this for initialization
	void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void OnInteract(Character character)
    {
        //Debug.LogWarning("Interact with sign");
        if (DialogBox.IsVisible())
        {
            Time.timeScale = 1;
            character.Movement.SetFrozen(false);
            DialogBox.Hide();
            
        }
        else
        {
            character.Movement.SetFrozen(true);
            StartCoroutine(FreezeTimeRoutine());
            DialogBox.Show(Text);
            
        }

        
    }

    IEnumerator FreezeTimeRoutine()
    {
        yield return null;
        Time.timeScale = 0;
    }
}

