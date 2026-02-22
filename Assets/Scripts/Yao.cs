using Nova;
using UnityEngine;
using static Nova.AutoSize;
using static UnityEngine.Debug;

public class Yao : MonoBehaviour
{
    [Header("Yao Type")]
    [Tooltip("Loại hào: None, Yang (Dương), Ying (Âm)")]
    public EYao YaoType;

    [Header("Panel Line")]
    [Tooltip("Reference đến UIBlock2D Panel Line")]
    public UIBlock2D PanelLine;

    void Start()
    {
        if (PanelLine == null)
        {
            LogError("Yao: Không tìm thấy Panel Line UIBlock2D component!");
        }

        ApplyYao();
    }

    private void OnValidate() => ApplyYao();

    public void ApplyYao()
    {
        switch (YaoType)
        {
            case EYao.None:
            {
                PanelLine.AutoSize.X = Expand;

                break;
            }
            case EYao.Yang:
            {
                PanelLine.AutoSize.X = None;
                PanelLine.Size.X.Value = 0f;

                break;
            }
            case EYao.Ying:
            {
                PanelLine.AutoSize.X = None;
                PanelLine.Size.X.Value = 12f;

                break;
            }
        }
    }
}
