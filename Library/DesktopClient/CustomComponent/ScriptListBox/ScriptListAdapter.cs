using Contracts.Scripts;
using Contracts.Scripts.Base;

namespace DesktopClient.CustomComponent.ScriptListBox
{
    public class ScriptListAdapter
    {
        private const int MARGIN_BETWEEN_ELEMENTS = 5;

        public delegate void ScriptClickHandler(ScriptAbs source);

        public event ScriptClickHandler? ShowMenu;
        public event ScriptClickHandler? StatusClicked;

        private readonly Control _pnlScripts;
        private List<ScriptItem> _controlList;

        public ScriptListAdapter(Control pnlScripts)
        {
            _controlList = new List<ScriptItem>();
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
        public void EditItem(ScriptAbs oldScript, ScriptAbs editedScript)
        {
            var item = FindById(editedScript.Id);
            bool hasScriptTypeChanged = ScriptAbs.HasScriptTypeChanged(oldScript.ScriptType, editedScript.ScriptType);
            if (item != null && item.ModifyScript(editedScript, hasScriptTypeChanged))
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
        public void RefreshScriptStatus(string scriptId, ScriptStatus newStatus)
        {
            var script = FindById(scriptId);
            if (script == null)
                return;
            script.Script.ScriptStatus = newStatus;
            script?.PaintScriptStatus();
        }
        #endregion

        #region Private methods
        private void CreateUIElements(IList<ScriptAbs> list)
        {
            _controlList = new List<ScriptItem>();
            if (list != null && list.Count > 0)
            {
                foreach (var item in list)
                    _controlList.Add(GetScriptItemInstance(item));
            }
        }
        private ScriptItem GetScriptItemInstance(ScriptAbs script)
        {
            var item = new ScriptItem(script);
            item.StatusClicked += Script_StatusClicked;
            item.MenuClicked += Script_MenuClicked;

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
        private ScriptItem? FindById(string id)
        {
            return !IsEmptyList() ? _controlList.Find(s => s.Script.Id == id) : null;
        }
        private bool IsEmptyList()
        {
            return GetListCount() == 0;
        }
        #endregion

        #region Events
        private void Script_MenuClicked(ScriptItem source)
        {
            ShowMenu?.Invoke(source.Script);
        }
        private void Script_StatusClicked(ScriptItem source)
        {
            StatusClicked?.Invoke(source.Script);
        }
        #endregion
    }
}
