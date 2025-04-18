using UnityEngine;
using UnityEngine.InputSystem;

public class InputRebinder : MonoBehaviour
{
    public InputActionAsset actionAsset;
    private InputAction spaceAction;

    void Start()
    {
        // [구현사항 1] actionAsset에서 Space 액션을 찾고 활성화합니다.

        spaceAction = actionAsset.FindAction("Space");

    }

    // [구현사항 2] ContextMenu 어트리뷰트를 활용해서 인스펙터창에서 적용할 수 있도록 함

    [ContextMenu("Input Rebinder")]
    public void RebindSpaceToEscape()
    {
        if (spaceAction == null)
            return;

        var binding = spaceAction.GetBindingIndexForControl(Keyboard.current.spaceKey);
        spaceAction.ApplyBindingOverride(binding, "<Keyboard>/escape");

        Debug.Log("Done!");
    }

    void OnDestroy()
    {
        // 액션을 비활성화합니다.
        spaceAction?.Disable();
    }
}