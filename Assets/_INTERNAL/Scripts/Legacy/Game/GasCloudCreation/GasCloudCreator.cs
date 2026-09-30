using Game.GameStages.FirstStage;
using Interfaces;
using UnityEngine;

namespace Game.GasCloudCreation
{
    public class GasCloudCreator : MonoBehaviour, IGasCloudCreation
    {
        [SerializeField] private GasCloudStage _gasCloudSystemPrefab;

        public GasCloudStage CreateGasCloud()
        {
            if (_gasCloudSystemPrefab == null)
            {
                Debug.LogWarning($"Газовая система не привязана!");
                return null;
            }

            return Instantiate(_gasCloudSystemPrefab);
        }
    }
}