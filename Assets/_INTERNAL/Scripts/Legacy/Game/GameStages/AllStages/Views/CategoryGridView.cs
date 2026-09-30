using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace Game.GameStages.AllStages.Views
{
    public class CategoryGridView : ViewUIBase
    {
        [Header("Open grid buttons")]
        [SerializeField] private List<Button> _buttons = new();

        [Space(15), Header("Grids")]
        [SerializeField] private GridView _resourceGrid;
        [SerializeField] private GridView _progressGrid;

        private void OnEnable()
        {
            _buttons[0].onClick.AddListener(() => OpenGrid(_resourceGrid, _buttons));
            _buttons[1].onClick.AddListener(() => OpenGrid(_progressGrid, _buttons));

            SubscribeGridButton(_resourceGrid);
            SubscribeGridButton(_progressGrid);
        }

        private void OnDisable()
        {
            _buttons[0].onClick.RemoveListener(() => OpenGrid(_resourceGrid, _buttons));
            _buttons[1].onClick.RemoveListener(() => OpenGrid(_progressGrid, _buttons));

            UnsubscribeGridButton(_resourceGrid);
            UnsubscribeGridButton(_progressGrid);
        }

        private void OpenGrid(GridView grid, List<Button> buttons)
        {
            grid.OpenGrid();

            foreach (Button button in buttons)
            {
                button.gameObject.SetActive(false);
            }
        }

        private void CloseGrid(GridView grid, List<Button> buttons)
        {
            grid.CloseGrid();

            foreach (Button button in buttons)
            {
                button.gameObject.SetActive(true);
            }
        }

        private void SubscribeGridButton(GridView grid)
        {
            grid.CloseButton.onClick.AddListener(() => CloseGrid(grid, _buttons));
        }

        private void UnsubscribeGridButton(GridView grid)
        {
            grid.CloseButton.onClick.RemoveListener(() => CloseGrid(grid, _buttons));
        }
    }
}