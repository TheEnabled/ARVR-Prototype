using UnityEngine;

public class MenuController : MonoBehaviour
{
    [Header("Target UI")]
    // This is the SerializedField you asked for. 
    // Drag your Panel (the menu) here in the Inspector.
    [SerializeField] private GameObject menuPanel;

    // Connect this to your Main Button's OnClick()
    public void OpenMenu()
    {
        if (menuPanel != null)
        {
            menuPanel.SetActive(true);
        }
    }

    // Connect this to your "X" Button's OnClick()
    public void CloseMenu()
    {
        if (menuPanel != null)
        {
            menuPanel.SetActive(false);
        }
    }
}