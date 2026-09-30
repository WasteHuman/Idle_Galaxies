using UnityEngine;

namespace OtherUtils
{
    public class ObjectLifecycle
    {
        private GameObject _object;
        private float _lifeTime;

        public ObjectLifecycle(GameObject obj, float lifeTime = 0f)
        {
            _object = obj;
            _lifeTime = lifeTime;
        }

        public void DestroyObject()
        {
            if (_object == null)
                return;

            Object.Destroy(_object, _lifeTime);
        }
    }

    public static class ObjectLifecycleFactory
    {
        public static ObjectLifecycle Create(GameObject gameObject, float lifeTime = 0f)
        {
            if(gameObject == null)
            {
                Debug.LogWarning($"Невозможно создать ObjectLifecycle: GameObject равен null");
                return null;
            }

            return new ObjectLifecycle(gameObject, lifeTime);
        }
    }
}