using System.Collections.Generic;
using UI;
using UnityEngine;

namespace Game.GameStages.FirstStage
{
    public class FirstStageUI : ViewUIBase
    {
        [Space(15), Header("UI")]
        [SerializeField] private List<ViewUIBase> _views = new();
        [SerializeField] private List<ViewUIBase> _resourceViews = new();
        [SerializeField] private List<ViewUIBase> _upgradeViews = new();

        public List<ViewUIBase> Views => _views;
        public List<ViewUIBase> ResourceViews => _resourceViews;
        public List<ViewUIBase> UpgradeViews => _upgradeViews;
    }
}