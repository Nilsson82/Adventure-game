using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogBox : MonoBehaviour
{

    static DialogBox Instance;

    private Image m_DialogFrame;
    private Text m_Text;

    // Use this for initialization
    private void Awake()
    {
        Instance = this;

        m_DialogFrame = GetComponent<Image>();
        m_Text = GetComponentInChildren<Text>();
    }

    public static bool IsVisible()
    {
        return Instance.m_DialogFrame.enabled;
    }

    public static void Show(string displayText)
    {
        Instance.DoShow(displayText);
    }

    public static void Hide()
    {
        Instance.DoHide();
    }

    private void DoHide()
    {
        m_DialogFrame.enabled = false;
        m_Text.enabled = false;
    }

    private void DoShow(string displayText)
    {
        m_DialogFrame.enabled = true;
        m_Text.enabled = true;
        m_Text.text = displayText;
    }
}
