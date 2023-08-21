using UnityEngine;

public class DialogueTriggerController : MonoBehaviour
{
    public GameObject UIpanel;

    public bool isSecondTrigger;

    private void Start()
    {
        // Sembunyikan UI panel trigger kedua secara awal
        if (isSecondTrigger)
        {
            UIpanel.SetActive(false);
        }
    }

    public void DeactivateFirstUIPanel()
    {
        UIpanel.SetActive(false);
    }

    public void ReactivateSecondUIPanel()
    {
        UIpanel.SetActive(true);
    }
}
