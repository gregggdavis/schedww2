using System;
using System.Windows.Forms;

namespace Scheduler.BusinessLayer
{
	/// <summary>
	/// Summary description for clsMessage.
	/// </summary>
	public class Message
	{
		public Message()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		private static String strDelete = "Are you sure you want to delete this item?";
		private static String strSaveChanges = "Do you want to save changes you have made?";
		private static String strCustomDelete ;

		public static void MsgError(String strMsg)
		{
			MessageBox.Show(strMsg,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);

		}
		public static void MsgInformation(String strMsg)
		{
			MessageBox.Show(strMsg,"Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
		}
		
		public static DialogResult MsgConfirmation(String strMsg)
		{
			return MessageBox.Show(strMsg,"Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
		}

		public static DialogResult MsgOkCancel(String strMsg)
		{
			return MessageBox.Show(strMsg,"Confirm",MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
		}

		public static void MsgWarning(String strMsg)
		{
			MessageBox.Show(strMsg,"Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
		}
		
		public static bool MsgDelete()
		{
			if (MessageBox.Show(strDelete,"Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2) == DialogResult.Yes)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public static bool MsgDelete(String strMsg)
		{
			strCustomDelete = "";
			strCustomDelete = "Are you sure you want to delete this"+" "; 
			strCustomDelete += strMsg +"?";
			if (MessageBox.Show(strCustomDelete,"Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2) == DialogResult.Yes)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public static bool DeleteRecurrence(String strMsg)
		{
			strCustomDelete = "";
			strCustomDelete = strMsg+"\n";
			strCustomDelete += "Are you sure you want to delete this"+"?"; 
			
			if (MessageBox.Show(strCustomDelete,"Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2) == DialogResult.Yes)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		
		
		public static bool MsgDelete(String strMsg,String strCode)
		{
			strCustomDelete = "";
			strCustomDelete = "Are you sure you want to delete this"+" "; 
			strCustomDelete += strMsg +" "+ strCode+ "?";
			if (MessageBox.Show(strCustomDelete,"Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2) == DialogResult.Yes)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

										
		public static DialogResult MsgSaveChanges()
		{
			return MessageBox.Show(strSaveChanges,"Confirm",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question,MessageBoxDefaultButton.Button1);
		}

		public static DialogResult MsgInvalid(String strInValidCode)
		{
			return MessageBox.Show(strInValidCode,"Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
		}

		public static DialogResult MsgEnter(String strEnter)
		{
			return MessageBox.Show(strEnter,"Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
		}

		public static DialogResult MsgRetryCancel(string ErrorMessage)
		{
			return MessageBox.Show(ErrorMessage, "Information", MessageBoxButtons.RetryCancel,MessageBoxIcon.Information);
		}	

		public static void ShowException(string strOperation, string strErrorMessage)
		{
			frm_ErrorDlg ErrDlg = new frm_ErrorDlg(strOperation, strErrorMessage);
			ErrDlg.ShowDialog();
			ErrDlg.Dispose();
		}


	}
}
