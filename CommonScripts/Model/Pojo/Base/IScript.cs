namespace CommonScripts.Model.Pojo.Base
{
    interface IScript
    {
        string Id { get; set; }
        string ScriptName { get; set; }
        ScriptStatus ScriptStatus { get; set; }
        string ScriptPath { get; set; }
    }
}
