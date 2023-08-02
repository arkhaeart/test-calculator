#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace Editor
{
    public static class MenuMethods
    {
        private static string DataPath => Application.persistentDataPath;

        [MenuItem("Edit/OpenSaveFolder")]
        public static void OpenSaveFolder()
        {
            EditorUtility.RevealInFinder(DataPath);
        }
    }
}


#endif