using NovaSamples.UIControls;
using UnityEngine;
using static UnityEngine.Debug;
using static Utilities;

[RequireComponent(typeof(Button))]
public class ResultButton : MonoBehaviour
{
    [Header("Level Loader")]
    [Tooltip("Reference đến LevelLoader component")]
    public LevelLoader LevelLoader;

    [Header("Yao 1 Dropdown")]
    [Tooltip("Reference đến Nova Dropdown chứa danh sách Hào Sơ")]
    public Dropdown Yao1Dropdown;

    [Header("Yao 2 Dropdown")]
    [Tooltip("Reference đến Nova Dropdown chứa danh sách Hào Nhị")]
    public Dropdown Yao2Dropdown;

    [Header("Yao 3 Dropdown")]
    [Tooltip("Reference đến Nova Dropdown chứa danh sách Hào Tam")]
    public Dropdown Yao3Dropdown;

    [Header("Yao 4 Dropdown")]
    [Tooltip("Reference đến Nova Dropdown chứa danh sách Hào Tứ")]
    public Dropdown Yao4Dropdown;

    [Header("Yao 5 Dropdown")]
    [Tooltip("Reference đến Nova Dropdown chứa danh sách Hào Ngũ")]
    public Dropdown Yao5Dropdown;

    [Header("Yao 6 Dropdown")]
    [Tooltip("Reference đến Nova Dropdown chứa danh sách Hào Thượng")]
    public Dropdown Yao6Dropdown;

    [Header("Topic Dropdown")]
    [Tooltip("Reference đến Nova Dropdown chứa danh sách chủ đề")]
    public Dropdown TopicDropdown;

    private Button _button;

    private bool _isTransitioning = false;

    private string _selectedYao1 = string.Empty;
    private string _selectedYao2 = string.Empty;
    private string _selectedYao3 = string.Empty;
    private string _selectedYao4 = string.Empty;
    private string _selectedYao5 = string.Empty;
    private string _selectedYao6 = string.Empty;
    private string _selectedTopic = string.Empty;

    void Start()
    {
        _button = GetComponent<Button>();

        if (_button == null)
        {
            LogError("ResultButton: Không tìm thấy Button component!");
        }
        else
        {
            _button.OnClicked.AddListener(OnResultButtonClicked);
        }

        if (LevelLoader == null)
        {
            LogError("ResultButton: Không tìm thấy LevelLoader trong scene!");
        }

        if (Yao1Dropdown == null)
        {
            LogError("ResultButton: Không tìm thấy Dropdown Hào Sơ trong scene!");
        }
        else
        {
            Yao1Dropdown.OnValueChanged.AddListener(OnYao1DropdownValueChanged);
        }

        if (Yao2Dropdown == null)
        {
            LogError("ResultButton: Không tìm thấy Dropdown Hào Nhị trong scene!");
        }
        else
        {
            Yao2Dropdown.OnValueChanged.AddListener(OnYao2DropdownValueChanged);
        }

        if (Yao3Dropdown == null)
        {
            LogError("ResultButton: Không tìm thấy Dropdown Hào Tam trong scene!");
        }
        else
        {
            Yao3Dropdown.OnValueChanged.AddListener(OnYao3DropdownValueChanged);
        }

        if (Yao4Dropdown == null)
        {
            LogError("ResultButton: Không tìm thấy Dropdown Hào Tứ trong scene!");
        }
        else
        {
            Yao4Dropdown.OnValueChanged.AddListener(OnYao4DropdownValueChanged);
        }

        if (Yao5Dropdown == null)
        {
            LogError("ResultButton: Không tìm thấy Dropdown Hào Ngũ trong scene!");
        }
        else
        {
            Yao5Dropdown.OnValueChanged.AddListener(OnYao5DropdownValueChanged);
        }

        if (Yao6Dropdown == null)
        {
            LogError("ResultButton: Không tìm thấy Dropdown Hào Thượng trong scene!");
        }
        else
        {
            Yao6Dropdown.OnValueChanged.AddListener(OnYao6DropdownValueChanged);
        }

        if (TopicDropdown == null)
        {
            LogError("ResultButton: Không tìm thấy Dropdown chủ đề trong scene!");
        }
        else
        {
            TopicDropdown.OnValueChanged.AddListener(OnTopicDropdownValueChanged);
        }
    }

    void OnDestroy()
    {
        if (_button != null)
        {
            _button.OnClicked.RemoveListener(OnResultButtonClicked);
        }

        if (TopicDropdown != null)
        {
            TopicDropdown.OnValueChanged.RemoveListener(OnTopicDropdownValueChanged);
        }
    }

    private void OnYao1DropdownValueChanged(string selectedValue)
    {
        _selectedYao1 = selectedValue;

        YiJingCalculate();
    }

    private void OnYao2DropdownValueChanged(string selectedValue)
    {
        _selectedYao2 = selectedValue;

        YiJingCalculate();
    }

    private void OnYao3DropdownValueChanged(string selectedValue)
    {
        _selectedYao3 = selectedValue;

        YiJingCalculate();
    }

    private void OnYao4DropdownValueChanged(string selectedValue)
    {
        _selectedYao4 = selectedValue;

        YiJingCalculate();
    }

    private void OnYao5DropdownValueChanged(string selectedValue)
    {
        _selectedYao5 = selectedValue;

        YiJingCalculate();
    }

    private void OnYao6DropdownValueChanged(string selectedValue)
    {
        _selectedYao6 = selectedValue;

        YiJingCalculate();
    }

    private void OnTopicDropdownValueChanged(string selectedValue)
    {
        _selectedTopic = selectedValue;

        YiJingCalculate();
    }

    private void OnResultButtonClicked()
    {
        if (!_isTransitioning && LevelLoader != null)
        {
            const string targetSceneName = "ResultScene";

            _isTransitioning = true;

            _ = StartCoroutine(LevelLoader.LoadSceneWithAnimation(targetSceneName));
        }
    }

    private void YiJingCalculate()
    {
        if (string.IsNullOrWhiteSpace(_selectedYao1))
        {
            LogWarning("ResultButton: Chưa chọn Hào Sơ!");

            return;
        }

        if (string.IsNullOrWhiteSpace(_selectedYao2))
        {
            LogWarning("ResultButton: Chưa chọn Hào Nhị!");

            return;
        }

        if (string.IsNullOrWhiteSpace(_selectedYao3))
        {
            LogWarning("ResultButton: Chưa chọn Hào Tam!");

            return;
        }

        if (string.IsNullOrWhiteSpace(_selectedYao4))
        {
            LogWarning("ResultButton: Chưa chọn Hào Tứ!");

            return;
        }

        if (string.IsNullOrWhiteSpace(_selectedYao5))
        {
            LogWarning("ResultButton: Chưa chọn Hào Ngũ!");

            return;
        }

        if (string.IsNullOrWhiteSpace(_selectedYao6))
        {
            LogWarning("ResultButton: Chưa chọn Hào Thượng!");

            return;
        }

        if (string.IsNullOrWhiteSpace(_selectedTopic))
        {
            LogWarning("ResultButton: Chưa chọn chủ đề!");

            return;
        }

        var yaos = (_selectedYao1, _selectedYao2, _selectedYao3, _selectedYao4, _selectedYao5, _selectedYao6).ToYaos();

        // Quẻ Chủ

        var benGua = yaos.ToGua();

        Log($"Quẻ Chủ: {benGua}");

        // Quẻ Biến

        if (HasLao(_selectedYao1, _selectedYao2, _selectedYao3, _selectedYao4, _selectedYao5, _selectedYao6))
        {
            var bianYaos = (_selectedYao1, _selectedYao2, _selectedYao3, _selectedYao4, _selectedYao5, _selectedYao6).ToBianYaos();
            var bianGua = bianYaos.ToGua();

            Log($"Quẻ Biến: {bianGua}");
        }

        // Quẻ Hỗ

        var huYaos = (_selectedYao2, _selectedYao3, _selectedYao4, _selectedYao3, _selectedYao4, _selectedYao5).ToYaos();
        var huGua = huYaos.ToGua();

        Log($"Quẻ Hỗ: {huGua}");

        // Quẻ Sai

        var cuoYaos = yaos.ToCuoYaos();
        var cuoGua = cuoYaos.ToGua();

        Log($"Quẻ Sai: {cuoGua}");
    }
}
