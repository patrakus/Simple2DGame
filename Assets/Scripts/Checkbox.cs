using UnityEngine;
using UnityEngine.UI;

public class Checkbox : MonoBehaviour
{
    #region MEMBERS

    [SerializeField]
    private Image checkMarkImage;
    private bool status;

    #endregion

    #region FUNCTIUONS

    public void Check()
    {
        status = !status;
        SetCheckbox();
    }
    
    private void OnEnable()
    {
        SetCheckbox();
    }

    private void SetCheckbox()
    {
        if (checkMarkImage == null)
        {
            return;
        }

        checkMarkImage.gameObject.SetActive(status);
    }

    #endregion
}
