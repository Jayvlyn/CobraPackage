using TMPro;
using UnityEngine;

namespace Cobra.GUI
{
    public class KeyRebindOverlayListener : MonoBehaviour
    {
        [SerializeField] private TMP_Text bindingDisplayText;
        public void UpdateBindingOverlay(KeyRebindController rebind, string displayString, string deviceLayoutName, string controlPath)
        {
            bindingDisplayText.text = displayString;
        }
    }
}