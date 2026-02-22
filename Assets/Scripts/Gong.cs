using UnityEngine;

public class Gong : MonoBehaviour
{
    [Header("Gong Type")]
    [Tooltip("Loại cung: Càn, Đoài, Ly, Tốn, Chấn, Khảm, Cấn, Khôn")]
    public EGong GongType;

    [Header("Yao Xia (Hào Hạ)")]
    [Tooltip("Reference đến Yao component của Hào Hạ (dưới)")]
    public Yao YaoXia;

    [Header("Yao Zhong (Hào Trung)")]
    [Tooltip("Reference đến Yao component của Hào Trung (giữa)")]
    public Yao YaoZhong;

    [Header("Yao Shang (Hào Thượng)")]
    [Tooltip("Reference đến Yao component của Hào Thượng (trên)")]
    public Yao YaoShang;

    void Start() => ApplyGong();

    private void OnValidate() => ApplyGong();

    public void ApplyGong()
    {
        var (xia, zhong, shang) = GongType switch
        {
            EGong.Quian => (EYao.Yang, EYao.Yang, EYao.Yang),
            EGong.Dui => (EYao.Yang, EYao.Yang, EYao.Ying),
            EGong.Li => (EYao.Yang, EYao.Ying, EYao.Yang),
            EGong.Xun => (EYao.Ying, EYao.Yang, EYao.Yang),
            EGong.Zhen => (EYao.Yang, EYao.Ying, EYao.Ying),
            EGong.Kan => (EYao.Ying, EYao.Yang, EYao.Ying),
            EGong.Gen => (EYao.Ying, EYao.Ying, EYao.Yang),
            EGong.Kun => (EYao.Ying, EYao.Ying, EYao.Ying),
            _ => (EYao.None, EYao.None, EYao.None)
        };

        YaoXia.YaoType = xia;
        YaoZhong.YaoType = zhong;
        YaoShang.YaoType = shang;

        YaoXia.ApplyYao();
        YaoShang.ApplyYao();
        YaoZhong.ApplyYao();
    }
}
