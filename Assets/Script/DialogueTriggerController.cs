using UnityEngine;

public class DialogueTriggerController : MonoBehaviour
{
    public GameObject UIpanel;

    public bool isSecondTrigger;

    private void Start()
    {

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
