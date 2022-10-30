using Contracts.Scripts;
using Contracts.Scripts.Base;

namespace App.Forms
{
    public class TrayContextMenu : ContextMenuStrip
    {
        public delegate void ScriptStatusClickHandler(ScriptAbs script);

        public event Action? OpenClicked;
        public event Action? CloseClicked;
        public event ScriptStatusClickHandler? ScriptStatusClicked;

        private const string OPEN_OPTION = "Open";
        private const string CLOSE_OPTION = "Close";
        private const string SCRIPTS_OPTION = "Scripts";
        private const string SCRIPT_STATUS_STOP_OPTION = "Stop";
        private const string SCRIPT_STATUS_RUN_OPTION = "Run";

        public TrayContextMenu() : base()
        {

            Items.Add(OPEN_OPTION, null, ContextMenu_Open_Click);
            Items.Add(CLOSE_OPTION, null, ContextMenu_Close_Click);
            Items.Add(SCRIPTS_OPTION);
        }
        #region Events
        private void ContextMenu_Close_Click(object? sender, EventArgs e)
        {
            CloseClicked?.Invoke();
        }
        private void ContextMenu_Open_Click(object? sender, EventArgs e)
        {
            OpenClicked?.Invoke();
        }
        private void ContextMenu_StatusClick(object? sender, EventArgs e)
        {
            if (sender == null || sender is not ToolStripMenuItem item || item.Tag is not ScriptAbs script)
                return;
            ScriptStatusClicked?.Invoke(script);
        }
        #endregion

        #region Public methods
        public void LoadScriptList(IList<ScriptAbs> scripts)
        {
            foreach (var script in scripts)
            {
                AddScriptToContextMenu(script);
            }
        }
        public void RefreshScriptStatus(ScriptAbs script)
        {
            var contextMenu = GetContextMenuByScriptId(script.Id);
            if (contextMenu == null)
                return;
            EnableDropDownItemsPerStatus(contextMenu.DropDownItems, script.ScriptStatus);
        }
        public void AddScript(ScriptAbs script)
        {
            AddScriptToContextMenu(script);
        }
        public void EditScript(ScriptAbs script)
        {
            var contextMenu = GetContextMenuByScriptId(script.Id);
            if (contextMenu == null)
                return;
            contextMenu.Text = script.ScriptName;
            AttachScriptToContextMenu(contextMenu.DropDownItems, script);
            EnableDropDownItemsPerStatus(contextMenu.DropDownItems, script.ScriptStatus);
        }
        public void RemoveScript(string scriptId)
        {
            ((ToolStripMenuItem)Items[2]).DropDownItems.Remove(GetContextMenuByScriptId(scriptId));
        }
        #endregion
        #region Private methods
        private void AddScriptToContextMenu(ScriptAbs script)
        {
            var aux = new ToolStripMenuItem(script.ScriptName, null,
                    new ToolStripMenuItem(SCRIPT_STATUS_STOP_OPTION, null, ContextMenu_StatusClick),
                    new ToolStripMenuItem(SCRIPT_STATUS_RUN_OPTION, null, ContextMenu_StatusClick));
            AttachScriptToContextMenu(aux.DropDownItems, script);
            EnableDropDownItemsPerStatus(aux.DropDownItems, script.ScriptStatus);
            ((ToolStripMenuItem)Items[2]).DropDownItems.Add(aux);
            aux.Tag = script.Id;
        }
        private ToolStripMenuItem? GetContextMenuByScriptId(string scriptId)
        {
            var dropDownItems = ((ToolStripMenuItem)Items[2]).DropDownItems;
            ToolStripMenuItem? result = null;
            foreach (ToolStripMenuItem item in dropDownItems)
            {
                if (item.Tag.ToString() == scriptId)
                {
                    result = item;
                }
            }
            return result;
        }
        private static void AttachScriptToContextMenu(ToolStripItemCollection dropDownItems, ScriptAbs script)
        {
            dropDownItems[0].Tag = script;
            dropDownItems[1].Tag = script;
        }
        private static void EnableDropDownItemsPerStatus(ToolStripItemCollection dropDownItems, ScriptStatus scriptStatus)
        {
            dropDownItems[0].Enabled = scriptStatus == ScriptStatus.Running;
            dropDownItems[1].Enabled = scriptStatus != ScriptStatus.Running;
        }
        #endregion
    }
}
