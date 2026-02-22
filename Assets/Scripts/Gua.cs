using UnityEngine;

public class Gua : MonoBehaviour
{
    [Header("Gua Number")]
    [Tooltip("Số thứ tự quẻ (1–64), 0 = không xác định")]
    [Range(0, 64)]
    public int GuaNumber;

    [Header("Gong Xia (Cung Hạ)")]
    [Tooltip("Reference đến Gong component của cung dưới")]
    public Gong GongXia;

    [Header("Gong Shang (Cung Thượng)")]
    [Tooltip("Reference đến Gong component của cung trên")]
    public Gong GongShang;

    void Start() => ApplyGua();

    private void OnValidate() => ApplyGua();

    public void ApplyGua()
    {
        var (xia, shang) = GuaNumber switch
        {
            1 => (EGong.Quian, EGong.Quian),
            2 => (EGong.Kun, EGong.Kun),
            3 => (EGong.Zhen, EGong.Kan),
            4 => (EGong.Kan, EGong.Gen),
            5 => (EGong.Quian, EGong.Kan),
            6 => (EGong.Kan, EGong.Quian),
            7 => (EGong.Kan, EGong.Kun),
            8 => (EGong.Kun, EGong.Kan),
            9 => (EGong.Quian, EGong.Xun),
            10 => (EGong.Dui, EGong.Quian),
            11 => (EGong.Quian, EGong.Kun),
            12 => (EGong.Kun, EGong.Quian),
            13 => (EGong.Li, EGong.Quian),
            14 => (EGong.Quian, EGong.Li),
            15 => (EGong.Gen, EGong.Kun),
            16 => (EGong.Kun, EGong.Zhen),
            17 => (EGong.Zhen, EGong.Dui),
            18 => (EGong.Xun, EGong.Gen),
            19 => (EGong.Dui, EGong.Kun),
            20 => (EGong.Kun, EGong.Xun),
            21 => (EGong.Zhen, EGong.Li),
            22 => (EGong.Li, EGong.Gen),
            23 => (EGong.Kun, EGong.Gen),
            24 => (EGong.Zhen, EGong.Kun),
            25 => (EGong.Zhen, EGong.Quian),
            26 => (EGong.Quian, EGong.Gen),
            27 => (EGong.Zhen, EGong.Gen),
            28 => (EGong.Xun, EGong.Dui),
            29 => (EGong.Kan, EGong.Kan),
            30 => (EGong.Li, EGong.Li),
            31 => (EGong.Gen, EGong.Dui),
            32 => (EGong.Xun, EGong.Zhen),
            33 => (EGong.Gen, EGong.Quian),
            34 => (EGong.Quian, EGong.Zhen),
            35 => (EGong.Kun, EGong.Li),
            36 => (EGong.Li, EGong.Kun),
            37 => (EGong.Li, EGong.Xun),
            38 => (EGong.Dui, EGong.Li),
            39 => (EGong.Gen, EGong.Kan),
            40 => (EGong.Kan, EGong.Zhen),
            41 => (EGong.Dui, EGong.Gen),
            42 => (EGong.Zhen, EGong.Xun),
            43 => (EGong.Quian, EGong.Dui),
            44 => (EGong.Xun, EGong.Quian),
            45 => (EGong.Kun, EGong.Dui),
            46 => (EGong.Xun, EGong.Kun),
            47 => (EGong.Kan, EGong.Dui),
            48 => (EGong.Xun, EGong.Kan),
            49 => (EGong.Li, EGong.Dui),
            50 => (EGong.Xun, EGong.Li),
            51 => (EGong.Zhen, EGong.Zhen),
            52 => (EGong.Gen, EGong.Gen),
            53 => (EGong.Gen, EGong.Xun),
            54 => (EGong.Dui, EGong.Zhen),
            55 => (EGong.Li, EGong.Zhen),
            56 => (EGong.Gen, EGong.Li),
            57 => (EGong.Xun, EGong.Xun),
            58 => (EGong.Dui, EGong.Dui),
            59 => (EGong.Kan, EGong.Xun),
            60 => (EGong.Dui, EGong.Kan),
            61 => (EGong.Dui, EGong.Xun),
            62 => (EGong.Gen, EGong.Zhen),
            63 => (EGong.Li, EGong.Kan),
            64 => (EGong.Kan, EGong.Li),
            _ => (EGong.None, EGong.None)
        };

        GongXia.GongType = xia;
        GongShang.GongType = shang;

        GongXia.ApplyGong();
        GongShang.ApplyGong();
    }
}
