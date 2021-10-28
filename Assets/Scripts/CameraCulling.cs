using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraCulling : MonoBehaviour
{
    [SerializeField] private List<CullSetting> cullSettings;
    [SerializeField] private Camera mainCamera;
    
    public void CameraCutCulling(CinemachineBrain brain)
    {
        var newCam = brain.ActiveVirtualCamera;
        foreach (var setting in cullSettings)
        {
            if (setting.camera != newCam) continue;
            mainCamera.cullingMask = setting.cullingMask;
        }
    }
}

[System.Serializable]
public struct CullSetting
{
    public CinemachineVirtualCameraBase camera;
    public LayerMask cullingMask;
}
