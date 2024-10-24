using UnityEngine;
using UnityEngine.InputSystem;

public class InputRebinder : MonoBehaviour
{
    public InputActionAsset actionAsset;
    private InputAction spaceAction;

    private InputActionRebindingExtensions.RebindingOperation _rebindingOperation;
    
    void Start()
    {
        // [구현사항 1] actionAsset에서 Space 찾고 활성화합니다.
        spaceAction = actionAsset.FindAction("Space");
        spaceAction.Enable();
    }
    
    // [구현사항 2] ContextMenu 어트리뷰트를 활용해서 인스펙터창에서 적용할 수 있도록 함
    [ContextMenu("Rebind")]
    public void RebindSpaceToEscape()
    {
        if (spaceAction == null)
            return;

        // [구현사항 3] 기존 바인딩을 비활성화하고 새 키로 재바인딩
        spaceAction.Disable();
        _rebindingOperation = spaceAction.PerformInteractiveRebinding().Start();
        _rebindingOperation.Dispose();
        Debug.Log("Done!" + spaceAction.bindingMask);
    }

    [ContextMenu("OnSkill")]
    public void OnSkill()
    {
            Debug.Log("1번 스킬 " + value.action.bindings[0].overridePath + " 입력");
    }

    
    void OnDestroy()
    {
        // 액션을 비활성화합니다.
        spaceAction?.Disable();
    }
}