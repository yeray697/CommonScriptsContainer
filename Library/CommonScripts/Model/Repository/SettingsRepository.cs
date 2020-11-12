using CommonScripts.Model.Pojo.Base;
using CommonScripts.Model.Repository.Interfaces;
using CommonScripts.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace CommonScripts.Model.Repository
{
    public class SettingsRepository : ISettingsRepository
    {
        private const string ScriptFile = "scripts.json";
        private const string SettingsFile = "settings.json";

        public SettingsRepository()
        {

        }

        public bool SaveScripts(List<ScriptAbs> scripts)
        {
            return Save(scripts, ScriptFile);
        }

        public List<ScriptAbs> GetScripts()
        {
            return Load<List<ScriptAbs>>(ScriptFile);
        }

        private bool Save<T>(T pSettings, string fileName)
        {
            try
            {
                string json = JsonConvert.SerializeObject(pSettings, Formatting.Indented, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                });
                File.WriteAllText(fileName, json);
            }
            catch (Exception e)
            {

                throw e;
            }

            return true;
        }

        public static T Load<T>(string fileName) where T : new()
        {
            T t = new T();
            try
            {
                string realPath = FileUtils.GetAbsolutePath(fileName);
                if (File.Exists(realPath))
                {
                    string json = File.ReadAllText(realPath);
                    t = JsonConvert.DeserializeObject<T>(json, new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.All
                    }); ;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return t;
        }
    }
}
