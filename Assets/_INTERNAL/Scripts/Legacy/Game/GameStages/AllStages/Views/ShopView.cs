using UI;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Game.GameStages.AllStages.Views
{
    public class ShopView : ViewUIBase
    {
        [SerializeField] private Button _shopButton;
        [SerializeField] private RectTransform _shopPanelContainer;

        private RectTransform _shopUI;

        private Vector2 _openPosition;
        private Vector2 _closePosition;

        private void OnEnable()
        {
            _shopButton.onClick.AddListener(ToggleShopState);
        }

        private void OnDisable()
        {
            _shopButton.onClick.RemoveListener(ToggleShopState);
        }

        private void Start()
        {
            ComponentsInitialize();
        }

        private void ComponentsInitialize()
        {
            _shopUI = GetComponent<RectTransform>();
            _shopPanelContainer.gameObject.SetActive(false);

            _openPosition = new(_shopUI.position.x - 500f, _shopUI.position.y);
            _closePosition = new(_shopUI.position.x, _shopUI.position.y);
        }

        private void ToggleShopState()
        {
            if (!_shopPanelContainer.gameObject.activeSelf)
            {
                _shopPanelContainer.gameObject.SetActive(true);
                _shopButton.interactable = false;
                _shopUI.DOMove(_openPosition, 1f).SetEase(Ease.InOutQuad).OnComplete(() =>
                {
                    _shopButton.interactable = true;
                });
            }
            else
            {
                _shopButton.interactable = false;
                _shopUI.DOMove(_closePosition, 1f).SetEase(Ease.InOutQuad).OnComplete(() =>
                {
                    _shopPanelContainer.gameObject.SetActive(false);
                    _shopButton.interactable = true;
                });
            }
        }
    }
}