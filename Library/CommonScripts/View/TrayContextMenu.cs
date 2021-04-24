using CommonScripts.Model.Pojo;
using CommonScripts.Model.Pojo.Base;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CommonScripts.View
{
    public class TrayContextMenu : ContextMenuStrip
    {
        public delegate void ScriptStatusClickHandler(ScriptAbs script);

        public event Action OpenClicked;
        public event Action CloseClicked;
        public event ScriptStatusClickHandler ScriptStatusClicked;

        private const string OPEN_OPTION = "Open";
        private const string CLOSE_OPTION = "Close";
        private const string SCRIPTS_OPTION = "Scripts";
        private const string SCRIPT_STATUS_STOP_OPTION = "Stop";
        private const string SCRIPT_STATUS_RUN_OPTION = "Run";

        public TrayContextMenu() : base()
        {

            this.Items.Add(OPEN_OPTION, null, ContextMenu_Open_Click);
            this.Items.Add(CLOSE_OPTION, null, ContextMenu_Close_Click);
            this.Items.Add(SCRIPTS_OPTION);
        }
        #region Events
        private void ContextMenu_Close_Click(object sender, EventArgs e)
        {
            CloseClicked?.Invoke();
        }
        private void ContextMenu_Open_Click(object sender, EventArgs e)
        {
            OpenClicked?.Invoke();
        }
        private void ContextMenu_StatusClick(object sender, EventArgs e)
        {
            ScriptStatusClicked?.Invoke((ScriptAbs)((ToolStripMenuItem)sender).Tag);
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
            EnableDropDownItemsPerStatus(contextMenu.DropDownItems, script.ScriptStatus);
        }
        public void AddScript(ScriptAbs script)
        {
            AddScriptToContextMenu(script);
        }
        public void EditScript(ScriptAbs script)
        {
            var contextMenu = GetContextMenuByScriptId(script.Id);
            contextMenu.Text = script.ScriptName;
            AttachScriptToContextMenu(contextMenu.DropDownItems, script);
            EnableDropDownItemsPerStatus(contextMenu.DropDownItems, script.ScriptStatus);
        }
        public void RemoveScript(string scriptId)
        {
            ((ToolStripMenuItem)this.Items[2]).DropDownItems.Remove(GetContextMenuByScriptId(scriptId));
        }
        #endregion
        #region Private methods
        private void AddScriptToContextMenu(ScriptAbs script)
        {
            ToolStripMenuItem aux = new ToolStripMenuItem(script.ScriptName, null
                    ,new ToolStripMenuItem(SCRIPT_STATUS_STOP_OPTION, null, ContextMenu_StatusClick)
                    ,new ToolStripMenuItem(SCRIPT_STATUS_RUN_OPTION, null, ContextMenu_StatusClick));
            AttachScriptToContextMenu(aux.DropDownItems, script);
            EnableDropDownItemsPerStatus(aux.DropDownItems, script.ScriptStatus);
            ((ToolStripMenuItem)this.Items[2]).DropDownItems.Add(aux);
            aux.Tag = script.Id;
        }
        private void AttachScriptToContextMenu(ToolStripItemCollection dropDownItems, ScriptAbs script)
        {
            dropDownItems[0].Tag = script;
            dropDownItems[1].Tag = script;
        }
        private void EnableDropDownItemsPerStatus(ToolStripItemCollection dropDownItems, ScriptStatus scriptStatus)
        {
            dropDownItems[0].Enabled = scriptStatus == ScriptStatus.Running;
            dropDownItems[1].Enabled = scriptStatus != ScriptStatus.Running;
        }
        private ToolStripMenuItem GetContextMenuByScriptId(string scriptId)
        {
            var dropDownItems = ((ToolStripMenuItem)this.Items[2]).DropDownItems;
            ToolStripMenuItem result = null;
            foreach (ToolStripMenuItem item in dropDownItems)
            {
                if (item.Tag.ToString() == scriptId)
                {
                    result = item;
                }
            }
            return result;
        }
        #endregion
    }
}
