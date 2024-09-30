using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraEditors;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace SagaProjectV2.View
{
    class HelperClass
        //change image to stream//
    { public static byte[] SaveImage(PictureEdit pictureEdit)
        {
            MemoryStream ms = new MemoryStream();
            pictureEdit.Image.Save(ms, pictureEdit.Image.RawFormat);
            byte[] image = ms.ToArray();
            return image;
        }

        // change stream to image//
        public static void retrieveImage(byte[] arrayImage,PictureEdit pictureEdit)
        {
            
            MemoryStream ms = new MemoryStream(arrayImage);
            pictureEdit.Image = Image.FromStream(ms);
        }
         public static void ClearValue(TableLayoutPanel tp)
        {
            foreach(Control item in tp.Controls)
            {
                if(item is TextEdit) { item.Text = ""; }
                if(item is ComboBoxEdit) { item.Text = ""; }
                if(item is DateEdit) { item.Text = ""; }
                if(item is TextBox) { item.Text = ""; }
                
            }
        }
        

        public static void EnableControls(TableLayoutPanel tp)
        {
            foreach(Control item in tp.Controls)
          {
                if (item is TextEdit) { item.Enabled = true; }
                if (item is ComboBoxEdit) { item.Enabled = true; }
                if (item is DateEdit) { item.Enabled = true; }
                if (item is TextBox) { item.Enabled = true; }
                if (item is PictureEdit) { item.Enabled = true; }
            }
        }
        public static void NotEnableControls(TableLayoutPanel tp)
        {
            foreach (Control item in tp.Controls)
            {
                if (item is TextEdit) { item.Enabled = false; }
                if (item is ComboBoxEdit) { item.Enabled = false; }
                if (item is DateEdit) { item.Enabled = false; }
                if (item is TextBox) { item.Enabled = false; }
                if (item is PictureEdit) { item.Enabled = false; }
            }
        }
        public static void StartOperation(Form frm)
        {
            frm.Cursor = Cursors.WaitCursor;
            frm.Enabled = false;
        }
        public static void EndOperation(Form frm)
        {
            frm.Cursor = Cursors.WaitCursor;
            frm.Enabled = true;
        }
        public static string Encryptpassword(string s)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(s));
            byte[] Result = md5.Hash;
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < Result.Length; i++)
            {
                str.Append(Result[i].ToString("x4"));
            }
            return str.ToString();
        }
    }
}
