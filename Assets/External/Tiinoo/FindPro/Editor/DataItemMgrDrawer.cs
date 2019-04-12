using System;
using System.Collections.Generic;
using Tiinoo.Editor;
using Tiinoo.Engine;
using UnityEngine;

namespace Tiinoo.FindPro
{
    public abstract class DataItemMgrDrawer
    {
        private const string COLOR_LIGHT_LINE = "LightLine";

        private const string COLOR_DARK_LINE = "DarkLine";

        private const string COLOR_FOCUSED_LINE = "FocusedLine";

        public static int WIDTH_CHECK_BOX = 18;

        public static int WIDTH_TITLE = 50;

        public static int WIDTH_CONTENT = 450;

        public static int WIDTH_BUTTON = 60;

        protected GUILayoutOption m_optionCheckBox;

        protected GUILayoutOption m_optionTitle;

        protected GUILayoutOption m_optionContent;

        protected GUILayoutOption m_optionButton;

        private int m_lineHeight = 22;

        private TnThemeColorMgr m_themeColors;

        private GUIStyle m_baseStyle;

        private GUIStyle m_lightLineStyle;

        private GUIStyle m_darkLineStyle;

        private GUIStyle m_focusedLineStyle;

        private Vector2 m_scrollPosition = Vector2.zero;

        protected DataItemMgr m_itemMgr;

        protected void Init(DataItemMgr itemMgr)
        {
            this.InitLayoutOptions();
            this.InitThemeColors();
            this.CreateBaseStyle();
            this.CreateLightLineStyle();
            this.CreateDarkLineStyle();
            this.CreateFocusedLineStyle();
            this.m_itemMgr = itemMgr;
        }

        private void InitLayoutOptions()
        {
            this.m_optionCheckBox = GUILayout.Width((float)DataItemMgrDrawer.WIDTH_CHECK_BOX);
            this.m_optionTitle = GUILayout.Width((float)DataItemMgrDrawer.WIDTH_TITLE);
            this.m_optionContent = GUILayout.Width((float)DataItemMgrDrawer.WIDTH_CONTENT);
            this.m_optionButton = GUILayout.Width((float)DataItemMgrDrawer.WIDTH_BUTTON);
        }

        private void InitThemeColors()
        {
            this.m_themeColors = new TnThemeColorMgr();
            TnThemeColor.useProColor = TnEditorBridge.IsUnityProSkin();
            TnThemeColor tnThemeColor = new TnThemeColor();
            tnThemeColor.freeColor = new Color32(216, 216, 216, 255);
            tnThemeColor.proColor = new Color32(60, 60, 60, 255);
            this.m_themeColors.Add("LightLine", tnThemeColor);
            tnThemeColor = new TnThemeColor();
            tnThemeColor.freeColor = new Color32(222, 222, 222, 255);
            tnThemeColor.proColor = new Color32(55, 55, 55, 255);
            this.m_themeColors.Add("DarkLine", tnThemeColor);
            tnThemeColor = new TnThemeColor();
            tnThemeColor.freeColor = new Color32(62, 125, 231, 255);
            tnThemeColor.proColor = new Color32(62, 95, 150, 255);
            this.m_themeColors.Add("FocusedLine", tnThemeColor);
        }

        private void CreateBaseStyle()
        {
            this.m_baseStyle = new GUIStyle();
            this.m_baseStyle.border = new RectOffset(0, 0, 0, 0);
            this.m_baseStyle.margin = new RectOffset(0, 0, 0, 0);
            this.m_baseStyle.padding = new RectOffset(0, 0, 0, 0);
            this.m_baseStyle.stretchWidth = true;
            this.m_baseStyle.fixedHeight = (float)this.m_lineHeight;
        }

        private void CreateLightLineStyle()
        {
            Color color = this.m_themeColors.Get("LightLine").color;
            Texture2D background = TnGUIUtil.CreateTexture(2, 2, color);
            this.m_lightLineStyle = new GUIStyle(this.m_baseStyle);
            this.m_lightLineStyle.normal.background = background;
        }

        private void CreateDarkLineStyle()
        {
            Color color = this.m_themeColors.Get("DarkLine").color;
            Texture2D background = TnGUIUtil.CreateTexture(2, 2, color);
            this.m_darkLineStyle = new GUIStyle(this.m_baseStyle);
            this.m_darkLineStyle.normal.background = background;
        }

        private void CreateFocusedLineStyle()
        {
            Color color = this.m_themeColors.Get("FocusedLine").color;
            Texture2D background = TnGUIUtil.CreateTexture(2, 2, color);
            this.m_focusedLineStyle = new GUIStyle(this.m_baseStyle);
            this.m_focusedLineStyle.normal.background = background;
            this.m_focusedLineStyle.normal.textColor = Color.white;
        }

        protected virtual void DrawToolButtons()
        {
            GUILayout.BeginHorizontal(new GUILayoutOption[0]);
            bool flag = GUILayout.Button("All", new GUILayoutOption[]
            {
                this.m_optionButton
            });
            GUILayout.Space(10f);
            bool flag2 = GUILayout.Button("None", new GUILayoutOption[]
            {
                this.m_optionButton
            });
            GUILayout.Space(10f);
            bool flag3 = GUILayout.Button("Reverse", new GUILayoutOption[]
            {
                this.m_optionButton
            });
            GUILayout.Space(10f);
            bool flag4 = GUILayout.Button("Remove", new GUILayoutOption[]
            {
                this.m_optionButton
            });
            GUILayout.Space(10f);
            bool flag5 = GUILayout.Button("Clear", new GUILayoutOption[]
            {
                this.m_optionButton
            });
            GUILayout.FlexibleSpace();
            int selectedItemCount = this.m_itemMgr.GetSelectedItemCount();
            int count = this.m_itemMgr.Count;
            GUILayout.Label(string.Format("Selected: {0}, Total: {1}", selectedItemCount, count), new GUILayoutOption[0]);
            GUILayout.EndHorizontal();
            if (flag)
            {
                this.m_itemMgr.SetAllItemsSelected(true);
            }
            if (flag2)
            {
                this.m_itemMgr.SetAllItemsSelected(false);
            }
            if (flag3)
            {
                this.m_itemMgr.SetAllItemsRevertSelected();
            }
            if (flag4)
            {
                this.m_itemMgr.RemoveSelectedItems();
            }
            if (flag5)
            {
                this.m_itemMgr.ClearAllItems();
            }
        }

        public void Draw(int startY)
        {
            int itemCount = this.GetItemCount();
            this.m_scrollPosition = GUILayout.BeginScrollView(this.m_scrollPosition, GUI.skin.box);
            for (int i = 0; i < itemCount; i++)
            {
                DataItem item = this.m_itemMgr.GetItem(i);
                this.DrawResult(item, i);
            }
            GUILayout.EndScrollView();
            this.DrawToolButtons();
            this.DrawEx();
            int dy = startY - (int)this.m_scrollPosition.y;
            this.ProcessSelections(dy);
        }

        private void DrawResult(DataItem item, int index)
        {
            GUIStyle gUIStyle;
            if (item.IsSelected)
            {
                gUIStyle = this.m_focusedLineStyle;
            }
            else
            {
                gUIStyle = ((index % 2 == 0) ? this.m_darkLineStyle : this.m_lightLineStyle);
            }
            GUILayout.BeginHorizontal(gUIStyle, new GUILayoutOption[0]);
            this.DrawItem(item, index);
            GUILayout.EndHorizontal();
        }

        public int GetItemCount()
        {
            return this.m_itemMgr.Count;
        }

        public int GetLineHeight()
        {
            return this.m_lineHeight;
        }

        private void ProcessSelections(int dy)
        {
            bool flag = this.CalculateSelections(dy);
            if (flag)
            {
                Event.current.Use();
            }
        }

        private bool CalculateSelections(int dy)
        {
            List<DataItem> items = this.m_itemMgr.Items;
            if (items.Count < 1)
            {
                return false;
            }
            Event current = Event.current;

            /*if (current.button != 0)
            {
                if (current.type == EventType.MouseUp)
                {
                    int arg_10E_0 = current.button;
                }
                return false;
            }
            */
            if (current.type != EventType.MouseUp)
                return false;
            int clickedItem = this.GetClickedItem(current.mousePosition.y - (float)dy);
            if (clickedItem == -1)
            {
                this.m_itemMgr.SetAllItemsSelected(false);
                return true;
            }
            DataItem dataItem = items[clickedItem];
            if (current.control)
            {
                dataItem.SwitchSelected();
            }
            else if (current.shift)
            {
                int num = Mathf.Clamp(this.m_itemMgr.LastSelectedItemIndex, 0, items.Count - 1);
                int num2 = clickedItem;
                int num3 = num;
                int num4 = num2;
                if (num > num2)
                {
                    num3 = num2;
                    num4 = num;
                }
                this.m_itemMgr.SetAllItemsSelected(false);
                for (int i = num3; i <= num4; i++)
                {
                    items[i].IsSelected = true;
                }
            }
            else
            {
                this.m_itemMgr.SetAllItemsSelected(false);
                dataItem.IsSelected = true;
            }
            this.m_itemMgr.LastSelectedItemIndex = clickedItem;
            return true;
        }

        public void SelectItem(int itemIndex)
        {
            DataItem item = this.m_itemMgr.GetItem(itemIndex);
            if (item == null)
            {
                return;
            }
            this.m_itemMgr.SetAllItemsSelected(false);
            item.IsSelected = true;
            this.m_itemMgr.LastSelectedItemIndex = itemIndex;
        }

        private int GetClickedItem(float y)
        {
            int num = (int)(y / (float)this.m_lineHeight);
            if (num < 0 || num > this.GetItemCount() - 1)
            {
                return -1;
            }
            return num;
        }

        protected virtual void DrawEx()
        {
        }

        protected abstract void DrawItem(DataItem item, int index);
    }
}

