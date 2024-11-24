using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class XRGrabInteractableHover : XRGrabInteractable
{
    [SerializeField]
    private string outlineLayerName = "OutLine"; // 외곽선 적용 레이어 이름

    private Renderer objectRenderer; // 오브젝트의 Renderer
    private int originalLayer;       // 원래 오브젝트의 레이어

    private void Start()
    {
        // 오브젝트의 Renderer 컴포넌트 가져오기
        objectRenderer = GetComponent<Renderer>();

        // 원래 오브젝트의 레이어 저장
        if (gameObject != null)
        {
            originalLayer = gameObject.layer;
        }
    }

    protected override void OnHoverEntered(HoverEnterEventArgs args)
    {
        base.OnHoverEntered(args);

        // 호버 상태에서 레이어를 외곽선 레이어로 변경
        if (gameObject != null)
        {
            gameObject.layer = LayerMask.NameToLayer(outlineLayerName);
        }
    }

    protected override void OnHoverExited(HoverExitEventArgs args)
    {
        base.OnHoverExited(args);

        // 호버 상태 해제 시 원래 레이어로 복구
        if (gameObject != null)
        {
            gameObject.layer = originalLayer;
        }
    }

    protected override void OnSelectEntering(SelectEnterEventArgs args)
    {
        base.OnSelectEntering(args);

        // 셀렉트시 원래 레이어로 복구
        if (gameObject != null)
        {
            gameObject.layer = originalLayer;
        }
    }
}
