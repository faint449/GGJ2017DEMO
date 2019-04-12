using System;
using System.Collections.Generic;

namespace Tiinoo.FindPro
{
    public class DataItemMgr
    {
        private List<DataItem> m_items = new List<DataItem>();

        private int m_lastSelectedItemIndex;

        public int Count
        {
            get
            {
                return this.m_items.Count;
            }
        }

        public List<DataItem> Items
        {
            get
            {
                return this.m_items;
            }
        }

        public int LastSelectedItemIndex
        {
            get
            {
                return this.m_lastSelectedItemIndex;
            }
            set
            {
                this.m_lastSelectedItemIndex = value;
            }
        }

        public DataItemMgr()
        {
            this.ResetLastSelectedItemIndex();
        }

        public DataItem GetItem(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                return null;
            }
            return this.m_items[index];
        }

        public void AddItem(DataItem item)
        {
            this.m_items.Add(item);
        }

        public void ClearAllItems()
        {
            this.m_items.Clear();
            this.ResetLastSelectedItemIndex();
        }

        public void RemoveSelectedItems()
        {
            for (int i = this.m_items.Count - 1; i >= 0; i--)
            {
                if (this.m_items[i].IsSelected)
                {
                    this.m_items.RemoveAt(i);
                }
            }
            this.ResetLastSelectedItemIndex();
        }

        public void SetAllItemsSelected(bool isSelected)
        {
            foreach (DataItem current in this.m_items)
            {
                current.IsSelected = isSelected;
            }
        }

        public void SetAllItemsRevertSelected()
        {
            foreach (DataItem current in this.m_items)
            {
                current.SwitchSelected();
            }
        }

        private void ResetLastSelectedItemIndex()
        {
            this.m_lastSelectedItemIndex = -1;
        }

        public int GetSelectedItemCount()
        {
            int num = 0;
            foreach (DataItem current in this.m_items)
            {
                if (current.IsSelected)
                {
                    num++;
                }
            }
            return num;
        }
    }
}
