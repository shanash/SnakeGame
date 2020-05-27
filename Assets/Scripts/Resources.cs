using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace WAPK
{
    public class Resources : ScriptableObject
    {
        [System.Serializable]
        private class ResourceInfo
        {
            public string path;
            public Object asset;
        }

        [SerializeField]
        private List<ResourceInfo> resources;

        static private Resources instance;

        static private Resources Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = UnityEngine.Resources.Load<Resources>("WAPKResources");
                    Debug.AssertFormat(instance != null, "Plz Click Menu - Assets - Create - WAPKResources");
                }

                return instance;
            }
        }

        public static Object Load(string path)
        {
            var record = Instance.resources.FirstOrDefault(resource => resource.path == path);
            return record == null ? null : record.asset;
        }

        public static T Load<T>(string path) where T : Object
        {
            return Load(path) as T;
        }
#if UNITY_EDITOR
        [UnityEditor.MenuItem("Assets/Create/WAPKResources")]
        private static void Create()
        {
            var asset = ScriptableObject.CreateInstance<Resources>();
            var path = "Assets/Resources/WAPKResources.asset";
            UnityEditor.AssetDatabase.CreateAsset(asset, path);
            UnityEditor.AssetDatabase.ImportAsset(path);
        }
#endif
    }
}