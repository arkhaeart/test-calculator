using System;
using System.IO;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Common
{
    public class DataHandler
    {
        private static string Path => System.IO.Path.Combine(Application.persistentDataPath, "save");


        public static bool FileExists()
        {
            return File.Exists(Path);
        }


        public static async UniTask<T> GetAsync<T>()
        {
            try
            {
                using (var sr = new StreamReader(Path))
                {
                    var json = await sr.ReadToEndAsync();
                    return JsonUtility.FromJson<T>(json);
                }
            }
            catch (Exception e)
            {
                Debug.LogError(e);
                return default;
            }
        }


        public static async UniTask<bool> SaveAsync<T>(T data)
        {
            try
            {
                var json = JsonUtility.ToJson(data);
                using (var fs = File.Create(Path))
                {
                    using (var sw = new StreamWriter(fs))
                    {
                        await sw.WriteAsync(json);
                    }
                }

                return true;
            }
            catch (Exception e)
            {
                Debug.LogError(e);
                return false;
            }
        }
    }
}