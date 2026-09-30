using Game.GameStages.FirstStage.BaseMVC;
using Game.Shop.UpgradesBaseMVC.Interfaces;

namespace Game.GameStages.SecondStage.Protostar
{
    public class ProtostarController : IStageController
    {
        private ProtostarModel _model;
        private ProtostarView _view;

        public ProtostarController(ProtostarModel model, ProtostarView view)
        {
            _model = model;
            _view = view;
        }

        public void ApplyGravityUpgrade()
        {
        }

        public void ApplyMassUpgrade()
        {
        }

        public void ShowUpgradeDetails()
        {
        }

        public void UpdateGravitationView(IUpgradeModel model)
        {
        }

        public void UpdateMassView(IUpgradeModel model)
        {
        }
    }
}