using CommonScripts.Model.Pojo.Base;
using MetroSet_UI.Components;
using MetroSet_UI.Controls;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace CommonScripts.CustomComponent.ScriptListBox
{
    public class ScriptListAdapter
    {
        private const int MARGIN_BETWEEN_ELEMENTS = 5;

        public delegate void ScriptClickHandler(ScriptAbs source);

        public event ScriptClickHandler RemoveClicked;
        public event ScriptClickHandler EditClicked;
        public event ScriptClickHandler StatusClicked;

        private readonly StyleManager _styleManager;
        private readonly MetroSetPanel _pnlScripts;
        private List<ScriptItem> _controlList;

        public ScriptListAdapter(StyleManager styleManager, MetroSet_UI.Controls.MetroSetPanel pnlScripts)
        {
            _controlList = new List<ScriptItem>();
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
            _controlList.Add(scriptItem);
            AddItemToPanel(scriptItem);
            SortControls();
        }
        public void EditItem(ScriptAbs editItem, bool hasScriptTypeChanged)
        {
            var item = FindById(editItem.Id);
            if (item != null && item.ModifyScript(editItem, hasScriptTypeChanged))
                SortControls();
        }
        public void RemoveItem(string scriptId)
        {
            var item = FindById(scriptId);
            if (item != null)
            {
                _controlList.Remove(item);
                _pnlScripts.Controls.Remove(item);
                SortControls();
            }
        }
        public void RefreshScriptStatus(string scriptId)
        {
            FindById(scriptId)?.PaintScriptStatus();
        }
        public void RefreshMetroStyles()
        {
            foreach (var item in _controlList)
            {
                item.RefreshMetroStyles();
            }
        }
        #endregion

        #region Private methods
        private void CreateUIElements(IList<ScriptAbs> list)
        {
            _controlList = new List<ScriptItem>();
            if ((list?.Count ?? 0) > 0)
                foreach (var item in list)
                    _controlList.Add(GetScriptItemInstance(item));
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

                foreach (var item in _controlList)
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
            return _controlList?.Count ?? 0;
        }
        private void SortControls()
        {
            //TODO This may change based on the type of the script and the status
            if (!IsEmptyList())
            {
                int lastYLocation = 0;
                foreach (var item in _controlList.OrderBy(i => i.Script.ScriptName))
                {
                    item.Location = new Point(0, lastYLocation);
                    lastYLocation += item.Height + MARGIN_BETWEEN_ELEMENTS;
                }
            }
        }
        private ScriptItem FindById(string id)
        {
            return !IsEmptyList() ? _controlList.Find(s => s.Script.Id == id) : null;
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
