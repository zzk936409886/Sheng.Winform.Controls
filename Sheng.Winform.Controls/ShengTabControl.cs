using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Drawing;
using System.ComponentModel;

namespace Sheng.Winform.Controls
{
    
    public class ShengTabControl : TabControl, IShengValidate
    {
        #region 构造

        public ShengTabControl()
        {
            
        }

        #endregion

        #region ISEValidate 成员

        private string title;
        /// <summary>
        /// 标题
        /// </summary>
        [Description("标题")]
        [Category("Sheng.Winform.Controls")]
        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                this.title = value;
            }
        }

        private bool highLight = false;
        /// <summary>
        /// 验证失败时是否需要高亮显示（改变背景色）
        /// </summary>
        [Description("验证失败时是否需要高亮显示（改变背景色）")]
        [Category("Sheng.Winform.Controls")]
        public bool HighLight
        {
            get
            {
                return this.highLight;
            }
            set
            {
                this.highLight = value;
            }
        }

        /// <summary>
        /// 验证控件
        /// </summary>
        /// <param name="validateMsg"></param>
        /// <returns></returns>
        public bool SEValidate(out string validateMsg)
        {
            bool validateResult = true;
            string tabValidateMsg;
            validateMsg = String.Empty;

            foreach (TabPage tabPage in this.TabPages)
            {
                if (ShengValidateHelper.ValidateContainerControl(tabPage, out tabValidateMsg) == false)
                {
                    validateMsg += tabValidateMsg;
                    validateResult = false;
                }
            }

            return validateResult;
        }

        public CustomValidateMethod CustomValidate
        {
            get;
            set;
        }

        #endregion
    }
}
