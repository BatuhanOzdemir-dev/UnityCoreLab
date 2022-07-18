using UnityEngine;
using Cinemachine;

public class CinemachineVirtualDynamic : MonoBehaviour
{
    private CinemachineVirtualCamera cmVCam;
    private Cinemachine3rdPersonFollow tpfollow;
    [SerializeField]
    private float sideLerpCoeff;
    [SerializeField]
    private float cameraSide;

    private void Awake()
    {
        sideLerpCoeff = (sideLerpCoeff == 0) ? 0.1f : sideLerpCoeff;
        cmVCam = FindObjectOfType<CinemachineVirtualCamera> ();
        tpfollow = cmVCam.GetCinemachineComponent<Cinemachine3rdPersonFollow>();

    }
    private void Update()
    {
        tpfollow.CameraSide = Mathf.Lerp(tpfollow.CameraSide, cameraSide, sideLerpCoeff);
    }

    public void SetCameraSide(float camSide)
    {
        cameraSide = camSide;
    }
}
