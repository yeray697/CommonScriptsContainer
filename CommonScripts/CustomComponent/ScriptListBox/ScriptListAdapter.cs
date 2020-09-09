using CommonScripts.Model;
using MetroSet_UI;
using MetroSet_UI.Controls;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace CommonScripts.CustomComponent.ScriptListBox
{
    public class ScriptListAdapter
    {

        public delegate void ScriptClickHandler(Script source);

        public event ScriptClickHandler RemoveClicked;
        public event ScriptClickHandler EditClicked;
        public event ScriptClickHandler StatusClicked;

        private List<ScriptItem> ControlList { get; set; }

        private const int MarginBetweenElements = 5;

        private StyleManager _styleManager;
        private MetroSetPanel _pnlScripts;

        public ScriptListAdapter(StyleManager styleManager, MetroSet_UI.Controls.MetroSetPanel pnlScripts)
        {
            ControlList = new List<ScriptItem>();
            _styleManager = styleManager;
            _pnlScripts = pnlScripts;
        }

        public void CreateWithList(IList<Script> list)
        {
            CreateUIElements(list);
            PaintUI();
        }

        private void CreateUIElements(IList<Script> list)
        {
            ControlList = new List<ScriptItem>();
            if ((list?.Count ?? 0) > 0)
                foreach (var item in list)
                    ControlList.Add(GetScriptItemInstance(item));
        }

        private ScriptItem GetScriptItemInstance(Script script)
        {
            ScriptItem item = new ScriptItem(script, _styleManager);
            item.StatusClicked += Script_StatusClicked;
            item.EditClicked += Script_EditClicked;
            item.RemoveClicked += Script_RemoveClicked;

            return item;
        }

        private void PaintUI()
        {
            if (_pnlScripts != null)
            {
                _pnlScripts.Controls.Clear();

                foreach (var item in ControlList)
                {
                    AddItemToPanel(item);
                }
                SortControls();
            }
        }

        private void AddItemToPanel(ScriptItem item)
        {
            item.SetWidth(_pnlScripts.Width);
            _pnlScripts.Controls.Add(item);
        }

        #region Control List methods
        public void AddItem(Script item)
        {
            ScriptItem scriptItem = GetScriptItemInstance(item);
            ControlList.Add(scriptItem);
            AddItemToPanel(scriptItem);
            SortControls();
        }

        public void EditItem(Script editItem)
        {
            var item = FindById(editItem.Id);
            if (item != null && item.ModifyScriptName(editItem.ScriptName))
                SortControls();
        }

        public void RemoveItem(int scriptId)
        {
            var item = FindById(scriptId);
            if (item != null)
            {
                ControlList.Remove(item);
                _pnlScripts.Controls.Remove(item);
                SortControls();
            }
        }

        public void ChangeScriptStatus(int scriptId, Script.Status newStatus)
        {
            var item = FindById(scriptId);
            if (item != null)
                item.ModifyScriptStatus(newStatus);
        }
        #endregion

        private int GetListCount()
        {
            return ControlList?.Count ?? 0;
        }

        private void SortControls()
        {
            //TODO This may change based on the type of the script and the status
            if (!IsEmptyList())
            {
                int lastYLocation = 0;
                foreach (var item in ControlList.OrderBy(i => i.GetScript().ScriptName))
                {
                    item.Location = new Point(0, lastYLocation);
                    lastYLocation += item.Height + MarginBetweenElements;
                }
            }
        }

        private ScriptItem FindById(int id)
        {
            return !IsEmptyList() ? ControlList.Find(s => s.GetScriptId() == id) : null;
        }

        private bool IsEmptyList()
        {
            return GetListCount() == 0;
        }

        #region Events
        private void Script_RemoveClicked(ScriptItem source)
        {
            RemoveClicked?.Invoke(source.GetScript());
        }

        private void Script_EditClicked(ScriptItem source)
        {
            EditClicked?.Invoke(source.GetScript());
        }

        private void Script_StatusClicked(ScriptItem source)
        {
            StatusClicked?.Invoke(source.GetScript());
        }
        #endregion
    }
}
