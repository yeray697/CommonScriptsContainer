using CommonScripts.Model;
using System.Collections.Generic;
using System.Drawing;

namespace CommonScripts.CustomComponent.ScriptListBox
{
    public class ScriptListManager
    {
        public List<ScriptItem> ControlList { get; private set; }

        public int MarginBetweenElements { get; set; }

        public ScriptListManager()
        {
            MarginBetweenElements = 5;
            ControlList = new List<ScriptItem>();
        }

        public List<ScriptItem> CreateWithList(IList<Script> list)
        {
            CreateUI(list);

            return ControlList;
        }

        public ScriptItem AddItem(Script item)
        {
            ScriptItem newItem = new ScriptItem(item);

            ControlList.Add(newItem);

            return newItem;
        }

        public bool EditItem(Script editItem)
        {
            var item = FindById(editItem.Id);
            if (item != null)
            {
                item.ModifyScriptName(editItem.ScriptName);
                item.ModifyScriptStatus(editItem.ScriptStatus);
                return true;
            }

            return false;
        }

        public ScriptItem RemoveItem(Script removeItem)
        {
            var item = FindById(removeItem.Id);
            if (item != null)
                ControlList.Remove(item);
            return item;
        }

        public void ChangeItemStatus(int position, Script.Status status)
        {
            if (GetListCount() > (position - 1) && position >= 0)
            {
                ControlList[position].ModifyScriptStatus(status);
            }
        }

        private void CreateUI(IList<Script> list)
        {
            ControlList = new List<ScriptItem>();
            ScriptItem aux = null;
            int lastYLocation = 0;
            if ((list?.Count ?? 0) > 0)
            {
                foreach (var item in list)
                {
                    aux = new ScriptItem(item);
                    aux.Location = new Point(0, lastYLocation);
                    ControlList.Add(aux);

                    lastYLocation += aux.Height + MarginBetweenElements;
                }
            }
        }

        private int GetListCount()
        {
            return ControlList?.Count ?? 0;
        }

        private void SortControls()
        {
            //ControlList.Sort()
        }

        private ScriptItem FindById(int id)
        {
            return !IsEmptyList() ? ControlList.Find(s => s.GetScriptId() == id) : null;
        }

        private bool IsEmptyList()
        {
            return GetListCount() == 0;
        }
    }
}
