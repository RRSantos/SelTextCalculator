using SelTextCalculator;
using System.Windows.Forms;
using Kbg.NppPluginNET.PluginInfrastructure;
using System;

namespace Kbg.NppPluginNET
{
    class Main
    {
        internal const string PluginName = "SelText Calculator";
        internal const string SumNumbersMenuItemName = "Sum numbers in selection";
        internal const string MultiplyNumbersMenuItemName = "Multiply numbers in selection";

        static IScintillaGateway editor = new ScintillaGateway(PluginBase.GetCurrentScintilla());
        static INotepadPPGateway notepad = new NotepadPPGateway();

        public static void OnNotification(ScNotification notification)
        {
            // This method is invoked whenever something is happening in notepad++
            // use eg. as
            // if (notification.Header.Code == (uint)NppMsg.NPPN_xxx)
            // { ... }
            // or
            //
            // if (notification.Header.Code == (uint)SciMsg.SCNxxx)
            // { ... }
        }

        internal static void CommandMenuInit()
        {
            PluginBase.SetCommand(0, SumNumbersMenuItemName, sumNumbersInSelection, new ShortcutKey(true, true, false, Keys.A));
            PluginBase.SetCommand(1, MultiplyNumbersMenuItemName, multiplyNumbersInSelection, new ShortcutKey(true, true, false, Keys.M));
        }

        internal static void SetToolBarIcon()
        {

        }

        internal static void PluginCleanUp()
        {

        }


        internal static void sumNumbersInSelection()
        {
            doOperation(StringCalculator.Sum, SumNumbersMenuItemName);
            //string selectedText = editor.GetSelText();
            //decimal result = StringCalculator.Sum(selectedText);            
            //MessageBox.Show(result.ToString(), SumNumbersMenuItemName);
        }

        internal static void multiplyNumbersInSelection()
        {
            doOperation(StringCalculator.Multiply, MultiplyNumbersMenuItemName);
            //string selectedText = editor.GetSelText();
            //decimal result = StringCalculator.Multiply(selectedText);
            //MessageBox.Show(result.ToString(), MultiplyNumbersMenuItemName);
        }

        internal static void doOperation(Func<string, decimal> operation, string operationText)
        {
            string selectedText = editor.GetSelText();
            if (string.IsNullOrEmpty(selectedText))
            {
                MessageBox.Show("No selection found.", operationText, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                decimal result = operation(selectedText);
                MessageBox.Show(result.ToString(), operationText);
            }
            
        }
    }
}