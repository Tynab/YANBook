using TMPro;
using UnityEngine;
using static UnityEngine.Debug;
using static Utilities;

public class GuaCell : MonoBehaviour
{
    [Header("Gua Number")]
    [Tooltip("Số thứ tự quẻ (1–64), 0 = không xác định")]
    [Range(0, 64)]
    public int GuaNumber;

    [Header("Gua")]
    [Tooltip("Reference đến Gua component")]
    public Gua Gua;

    [Header("Label Gua")]
    [Tooltip("Reference đến TextMeshPro hiển thị kiểu quẻ")]
    public TMP_Text LabelGua;

    [Header("Label Name")]
    [Tooltip("Reference đến TextMeshPro hiển thị tên quẻ")]
    public TMP_Text LabelName;

    [Header("Label Num")]
    [Tooltip("Reference đến TextMeshPro hiển thị số quẻ")]
    public TMP_Text LabelNumber;

    void Start()
    {
        if (Gua == null)
        {
            LogError("GuaCell: Không tìm thấy Gua component!");
        }

        if (LabelGua == null)
        {
            LogError("GuaCell: Không tìm thấy LabelGua TextMeshPro component!");
        }

        if (LabelName == null)
        {
            LogError("GuaCell: Không tìm thấy LabelName TextMeshPro component!");
        }

        if (LabelNumber == null)
        {
            LogError("GuaCell: Không tìm thấy LabelNumber TextMeshPro component!");
        }

        ApplyGuaCell();
    }

    private void OnValidate() => ApplyGuaCell();

    public void ApplyGuaCell(string gua = null)
    {
        Gua.GuaNumber = GuaNumber;
        Gua.ApplyGua();

        LabelName.text = GuaName.TryGetValue(GuaNumber, out var name) ? name : "Tên Quẻ";
        LabelNumber.text = $"Số: {GuaNumber:D2}";

        if (!string.IsNullOrWhiteSpace(gua))
        {
            LabelGua.text = gua;
        }
    }
}
