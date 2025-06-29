using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

[RequireComponent(typeof(XRBaseInteractable))]
public class SelectionRelay : MonoBehaviour
{
    AssemblyUIButtonManager uiMgr;

    void Awake() => uiMgr = Object.FindFirstObjectByType<AssemblyUIButtonManager>();

    public void OnSelectEntered(SelectEnterEventArgs _) =>
        uiMgr?.RegisterSelected(gameObject);

    public void OnSelectExited(SelectExitEventArgs _) =>
        uiMgr?.RegisterDeselected(gameObject);
}
