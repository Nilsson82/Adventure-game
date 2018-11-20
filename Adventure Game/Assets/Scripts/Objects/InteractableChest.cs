using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableChest : InteractableBase
{
    public Sprite OpenChestSprite;
    public bool HideRendererWhenOpened;

    private bool m_IsOpen;
    private SpriteRenderer m_Renderer;
    // Use this for initialization
    void Awake ()
    {
        m_IsOpen = false;
        m_Renderer = GetComponentInChildren<SpriteRenderer>();
    }
	
    // Update is called once per frame
    void Update ()
    {
		
    }

    public override void OnInteract(Character character)
    {
        //Debug.LogWarning("Interact with chest");
        if(m_IsOpen == true)
        {
            return;
        }


        m_Renderer.sprite = OpenChestSprite;
        m_IsOpen = true;
    }
}
