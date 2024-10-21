using UnityEngine;
using UnityEngine.InputSystem;

public class InputRebinder : MonoBehaviour
{
    public InputActionAsset actionAsset;
    private InputAction spaceAction;

    void Start()
    {
        // [�������� 1] actionAsset���� Space �׼��� ã�� Ȱ��ȭ�մϴ�.

        spaceAction = actionAsset.FindAction("Space");

    }

    // [�������� 2] ContextMenu ��Ʈ����Ʈ�� Ȱ���ؼ� �ν�����â���� ������ �� �ֵ��� ��

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
        // �׼��� ��Ȱ��ȭ�մϴ�.
        spaceAction?.Disable();
    }
}