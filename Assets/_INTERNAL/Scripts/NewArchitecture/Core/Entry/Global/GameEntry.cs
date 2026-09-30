using Cysharp.Threading.Tasks;

using NewArchitecture.UI.Common;
using System;

using UnityEngine;

using Utils.CustomResourceLoader;
using Utils.DI;
using Utils.SceneLoader;

namespace NewArchitecture.Core.Entry.Global
{
    public class GameEntry
    {
        private readonly DIContainer _rootContainer;
        private readonly SceneNavigatorService _sceneNavigatorService;

        private static GameEntry _instance;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void AutoStartGame()
        {
            _instance = new GameEntry();

            AsyncRun().Forget();

#if UNITY_ANDROID
            Application.targetFrameRate = 60;
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
#endif
        }

        private GameEntry()
        {
            _rootContainer = new DIContainer();

            var uiLoadingViewPrefab = ResourceLoader.LoadOrThrow<UILoadingView>("");
            var uiLoadingView = UnityEngine.Object.Instantiate(uiLoadingViewPrefab);
            _sceneNavigatorService = new SceneNavigatorService(new SceneLoaderService(uiLoadingView), _rootContainer);
        }

        private async UniTask Run()
        {

        }

        private static async UniTaskVoid AsyncRun()
        {
            try
            {
                await _instance.Run();
            }
            catch (Exception ex)
            {
                Debug.LogWarning($"GameEntry failed: {ex.GetType().Name}: {ex.Message}");
            }
        }
    }
}