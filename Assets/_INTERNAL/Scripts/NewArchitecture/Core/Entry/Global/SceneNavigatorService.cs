using Cysharp.Threading.Tasks;

using NewArchitecture.Core.Entry.Base;

using Utils.DI;
using Utils.SceneLoader;

namespace NewArchitecture.Core.Entry.Global
{
    public class SceneNavigatorService
    {
        private readonly SceneLoaderService _sceneLoaderService;
        private readonly DIContainer _rootContainer;

        public SceneNavigatorService(SceneLoaderService sceneLoaderService, DIContainer rootContainer)
        {
            _sceneLoaderService = sceneLoaderService;
            _rootContainer = rootContainer;
        }

        public async UniTask LoadSceneAsync(string sceneName)
        {
            await _sceneLoaderService.LoadScene(sceneName);
            var sceneContext = UnityEngine.Object.FindAnyObjectByType<SceneContex>();
            sceneContext.Initialize(_rootContainer);
        }
    }
}