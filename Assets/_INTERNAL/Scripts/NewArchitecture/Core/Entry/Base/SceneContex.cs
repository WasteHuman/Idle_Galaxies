using UnityEngine;
using Utils.DI;

namespace NewArchitecture.Core.Entry.Base
{
    public abstract class SceneContex : MonoBehaviour
    {
        protected DIContainer Container { get; private set; }

        public void Initialize(DIContainer parentContainer)
        {
            Container = new DIContainer(parentContainer);

            RegisterDependencies(Container);
            Run();
        }

        protected abstract void RegisterDependencies(DIContainer container);
        protected abstract void Run();

        protected virtual void OnDestroy()
        {
            Container.Dispose();
        }
    }
}