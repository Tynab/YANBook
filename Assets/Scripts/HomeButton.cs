using NovaSamples.UIControls;
using UnityEngine;
using static UnityEngine.Debug;

[RequireComponent(typeof(Button))]
public class HomeButton : MonoBehaviour
{
    [Header("Level Loader")]
    [Tooltip("Reference đến LevelLoader component")]
    public LevelLoader LevelLoader;

    private Button _button;
    private bool _isTransitioning = false;

    void Start()
    {
        _button = GetComponent<Button>();

        if (_button == null)
        {
            LogError("HomeButton: Không tìm thấy Button component!");
        }
        else
        {
            _button.OnClicked.AddListener(OnHomeButtonClicked);
        }

        if (LevelLoader == null)
        {
            LogError("HomeButton: Không tìm thấy LevelLoader trong scene!");
        }
    }

    void OnDestroy()
    {
        if (_button != null)
        {
            _button.OnClicked.RemoveListener(OnHomeButtonClicked);
        }
    }

    private void OnHomeButtonClicked()
    {
        if (!_isTransitioning && LevelLoader != null)
        {
            const string targetSceneName = "YiJingScene";

            _isTransitioning = true;

            _ = StartCoroutine(LevelLoader.LoadSceneWithAnimation(targetSceneName));
        }
    }
}
