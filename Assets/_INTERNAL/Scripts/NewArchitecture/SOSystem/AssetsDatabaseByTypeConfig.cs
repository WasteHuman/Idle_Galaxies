using System.Collections.Generic;
using UnityEngine;

namespace NewArchitecture.SOSystem
{
    [CreateAssetMenu(fileName = "AssetsDatabaseByTypeConfig", menuName = "SO System/Assets Database By Type Config")]
    public class AssetsDatabaseByTypeConfig : ScriptableObject
    {
        [field: SerializeField] public AssetType Type { get; private set; }
        [field: SerializeField] public List<AssetEntry> Assets { get; private set; } = new();
    }
}