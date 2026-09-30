using System.Collections.Generic;
using UnityEngine;

namespace NewArchitecture.SOSystem
{
    [CreateAssetMenu(fileName = "AssetsDatabaseConfig", menuName = "SO System/Assets Database Config")]
    public class AssetsDatabaseConfig : ScriptableObject
    {
        [field: SerializeField] public List<AssetsDatabaseByTypeConfig> Assets { get; private set; } = new();
    }
}