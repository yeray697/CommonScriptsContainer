using CommonScripts.Model;
using CommonScripts.Model.Base;
using MetroSet_UI;
using MetroSet_UI.Controls;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace CommonScripts.CustomComponent.ScriptListBox
{
    public class ScriptListAdapter
    {

        public delegate void ScriptClickHandler(ScriptAbs source);

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

        #region Public methods
        public void CreateWithList(IList<ScriptAbs> list)
        {
            CreateUIElements(list);
            PaintUI();
        }

        public void AddItem(ScriptAbs item)
        {
            ScriptItem scriptItem = GetScriptItemInstance(item);
            ControlList.Add(scriptItem);
            AddItemToPanel(scriptItem);
            SortControls();
        }

        public void EditItem(ScriptAbs editItem, bool hasScriptTypeChanged)
        {
            var item = FindById(editItem.Id);
            if (item != null && item.ModifyScript(editItem, hasScriptTypeChanged))
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

        public void ChangeScriptStatus(int scriptId, ScriptStatus newStatus)
        {
            var item = FindById(scriptId);
            if (item != null)
                item.ModifyScriptStatus(newStatus);
        }
        #endregion

        #region Private methods
        private void CreateUIElements(IList<ScriptAbs> list)
        {
            ControlList = new List<ScriptItem>();
            if ((list?.Count ?? 0) > 0)
                foreach (var item in list)
                    ControlList.Add(GetScriptItemInstance(item));
        }

        private ScriptItem GetScriptItemInstance(ScriptAbs script)
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
                foreach (var item in ControlList.OrderBy(i => i.Script.ScriptName))
                {
                    item.Location = new Point(0, lastYLocation);
                    lastYLocation += item.Height + MarginBetweenElements;
                }
            }
        }

        private ScriptItem FindById(int id)
        {
            return !IsEmptyList() ? ControlList.Find(s => s.Script.Id == id) : null;
        }

        private bool IsEmptyList()
        {
            return GetListCount() == 0;
        }
        #endregion

        #region Events
        private void Script_RemoveClicked(ScriptItem source)
        {
            RemoveClicked?.Invoke(source.Script);
        }

        private void Script_EditClicked(ScriptItem source)
        {
            EditClicked?.Invoke(source.Script);
        }

        private void Script_StatusClicked(ScriptItem source)
        {
            StatusClicked?.Invoke(source.Script);
        }
        #endregion
    }
}
