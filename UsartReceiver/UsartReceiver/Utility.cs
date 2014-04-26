using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Data;
using System.Windows.Forms;

namespace UsartReceiver
{
    static class Utility
    {
        /// <summary>
        /// テキストボックスのテキストを選択せずにフォーカスをあてます
        /// </summary>
        /// <param name="textBox"></param>
        public static void FocusWithoutSelecting(this TextBox textBox)
        {
            textBox.Focus();
            textBox.SelectionLength = 0;
        }
    }
}
