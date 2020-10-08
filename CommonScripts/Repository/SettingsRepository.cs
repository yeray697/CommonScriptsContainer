using CommonScripts.Model.Base;
using CommonScripts.Repository.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace CommonScripts.Repository
{
    public class SettingsRepository : ISettingsRepository
    {
        private const string ScriptFile = "scripts.json";

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
                if (File.Exists(fileName))
                {
                    string json = File.ReadAllText(fileName);
                    t = JsonConvert.DeserializeObject<T>(json, new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.Auto
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
