using System;

namespace Tiinoo.FindPro
{
    public class DataItem
    {
        private bool m_isSelected;

        private object m_data;

        public bool IsSelected
        {
            get
            {
                return this.m_isSelected;
            }
            set
            {
                this.m_isSelected = value;
            }
        }

        public object Data
        {
            get
            {
                return this.m_data;
            }
            set
            {
                this.m_data = value;
            }
        }

        public void SwitchSelected()
        {
            this.m_isSelected = !this.m_isSelected;
        }
    }
}
