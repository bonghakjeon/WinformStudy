using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Collections;
using System.Diagnostics;
using static System.Windows.Forms.TabControl;

namespace FIXNETCAD
{
    public partial class Form1 : Form
    {
        #region ������Ƽ

        #endregion ������Ƽ

        #region ������

        public Form1()
        {
            InitializeComponent();
            DisplaySetting();
        }

        #endregion ������ 

        #region DisplaySetting

        /// <summary>
        /// ȭ�� ����
        /// </summary>
        private void DisplaySetting()
        {
            TabPageCollection tabPages = tabControl1.TabPages;

            // �� "��Ʈ��ũ" ������ ������ �� ���� ó�� 
            foreach(TabPage tabPage in tabPages)
            {
                // TODO : TabPage Ŭ���� ��ü(tabPage) "��Ʈ��ũ" ������ ������ ���� ����� ó��(tabPage.Visible = false;)
                //        �Ұ��Ͽ� �ش� �� ������ ����ó��(tabPages.Remove(tabPage);) �ؼ� �� ���̵��� ���� (2024.07.01 jbh)
                // ���� URL - https://qodbtn.tistory.com/153
                // if (false == tabPage.Text.Equals("��Ʈ��ũ")) tabPage.Visible = false;
                if (false == tabPage.Text.Equals("��Ʈ��ũ")) tabPages.Remove(tabPage);
            }
        }

        #endregion DisplaySetting


        private void button2_Click(object sender, EventArgs e)
        {
            form2 frm = new form2();
            frm.Show();
            
        }

        public void regclean()
        {

            // �ӽ� ����

            Random r = new Random();
            string R = "";
            RegistryKey reg1;
            reg1 = Registry.LocalMachine.CreateSubKey("SOFTWARE").CreateSubKey("FLEXlm License Manager");

            RegistryKey reg2;
            reg2 = Registry.LocalMachine.CreateSubKey("SYSTEM").CreateSubKey("CurrentControlSet").CreateSubKey("Control").CreateSubKey("Session Manager").CreateSubKey("Environment");

            RegistryKey reg3;
            reg3 = Registry.LocalMachine.CreateSubKey("SYSTEM").CreateSubKey("CurrentControlSet").CreateSubKey("Control").CreateSubKey("Session Manager").CreateSubKey("Environment");

            RegistryKey reg4;
            reg4 = Registry.CurrentUser.CreateSubKey("SOFTWARE").CreateSubKey("FLEXlm License Manager");

            RegistryKey reg5;
            reg5 = Registry.CurrentUser.CreateSubKey("Environment");

            RegistryKey reg6;
            reg6 = Registry.CurrentUser.CreateSubKey("Environment");

            RegistryKey reg7;
            reg7 = Registry.LocalMachine.CreateSubKey("SYSTEM").CreateSubKey("CurrentControlSet").CreateSubKey("Control").CreateSubKey("Session Manager").CreateSubKey("Environment");

            RegistryKey reg8;
            reg8 = Registry.CurrentUser.CreateSubKey("Environment");

            reg1.SetValue("ADSKFLEX_LICENSE_FILE", R);

            reg2.SetValue("ADSKFLEX_LICENSE_FILE", R);

            reg3.SetValue("flexlm_timeout", R );

            reg4.SetValue("ADSKFLEX_LICENSE_FILE", R);

            reg5.SetValue("ADSKFLEX_LICENSE_FILE", R);

            reg6.SetValue("flexlm_timeout", R);

            reg7.SetValue("lm_license_file", R);

            reg8.SetValue("lm_license_file", R);

            //���� ����

            //���� ȯ��
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Environment", true);
            key.DeleteValue("flexlm_timeout");

            RegistryKey key1 = Registry.CurrentUser.OpenSubKey(@"Environment", true);
            key1.DeleteValue("lm_license_file");

            RegistryKey key2 = Registry.CurrentUser.OpenSubKey(@"Environment", true);
            key2.DeleteValue("ADSKFLEX_LICENSE_FILE");

            RegistryKey key3 = Registry.CurrentUser.OpenSubKey(@"Software\FLEXlm License Manager", true);
            key3.DeleteValue("ADSKFLEX_LICENSE_FILE");

            //���� ȯ��
            RegistryKey key4 = Registry.LocalMachine.OpenSubKey(@"Software\FLEXlm License Manager", true);
            key4.DeleteValue("ADSKFLEX_LICENSE_FILE");

            RegistryKey key5 = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Session Manager\Environment", true);
            key5.DeleteValue("ADSKFLEX_LICENSE_FILE");

            RegistryKey key6 = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Session Manager\Environment", true);
            key6.DeleteValue("lm_license_file");

            RegistryKey key7 = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Session Manager\Environment", true);
            key7.DeleteValue("flexlm_timeout");

        }

        public void casfileclean()
        {

            if (File.Exists(@"C:\Documents and Settings\All Users\Application Data\Autodesk\Adlm\CascadeInfo.cas"))
            {
                File.Delete(@"C:\Documents and Settings\All Users\Application Data\Autodesk\Adlm\CascadeInfo.cas");
            }
            if (File.Exists(@"C:\ProgramData\Autodesk\AdLM\CascadeInfo.cas"))
            {
                File.Delete(@"C:\ProgramData\Autodesk\AdLM\CascadeInfo.cas");
            }

        }

        public void text()
        {
            MessageBox.Show("����");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            regclean();
            casfileclean();

            Random r = new Random();
            string R = textBox1.Text;
            string R1 = textBox2.Text;
            string R2 = textBox3.Text;
            string RR = R;
            int type = 0;

            if (radioButton2.Checked)
            {
                type = 0;
            }
            else
            {
                type = 1;
                if (string.IsNullOrEmpty(R1))
                {
                    MessageBox.Show("HOST NAME �Ǵ� IP�� �Է� �ϼ���.");
                    return;
                }
                if (string.IsNullOrEmpty(R2))
                {
                    MessageBox.Show("HOST NAME �Ǵ� IP�� �Է� �ϼ���.");
                    return;
                }

            }

            if (string.IsNullOrEmpty(R))
            {
                MessageBox.Show("HOST NAME �Ǵ� IP�� �Է� �ϼ���.");
                return;
            }


            //���� ����
            RegistryKey reg2;
            reg2 = Registry.LocalMachine.CreateSubKey("SYSTEM").CreateSubKey("CurrentControlSet").CreateSubKey("Control").CreateSubKey("Session Manager").CreateSubKey("Environment");

            RegistryKey reg3;
            reg3 = Registry.LocalMachine.CreateSubKey("SYSTEM").CreateSubKey("CurrentControlSet").CreateSubKey("Control").CreateSubKey("Session Manager").CreateSubKey("Environment");

            RegistryKey reg5;
            reg5 = Registry.CurrentUser.CreateSubKey("Environment");

            RegistryKey reg6;
            reg6 = Registry.CurrentUser.CreateSubKey("Environment");

            RegistryKey reg7;
            reg7 = Registry.LocalMachine.CreateSubKey("SYSTEM").CreateSubKey("CurrentControlSet").CreateSubKey("Control").CreateSubKey("Session Manager").CreateSubKey("Environment");

            RegistryKey reg8;
            reg8 = Registry.CurrentUser.CreateSubKey("Environment");

            reg6.SetValue("flexlm_timeout", "1000000");

            reg3.SetValue("flexlm_timeout", "1000000");





            //�ߺ����� �Ǻ�

            RR = R;

            if (type == 1)
            {
                R = "27005@" + R + ";" + "27005@" + R1 + ";" + "27005@" + R2 + ";";
            }

            //����

            string Rreg = "@" + R;

            RegistryKey reg1;
            reg1 = Registry.LocalMachine.CreateSubKey("SOFTWARE").CreateSubKey("FLEXlm License Manager");

            reg1.SetValue("ADSKFLEX_LICENSE_FILE", Rreg);

            //reg2.SetValue("ADSKFLEX_LICENSE_FILE", R);

            RegistryKey reg4;
            reg4 = Registry.CurrentUser.CreateSubKey("SOFTWARE").CreateSubKey("FLEXlm License Manager");

            reg4.SetValue("ADSKFLEX_LICENSE_FILE", Rreg);

            MessageBox.Show("���� ���� �Ϸ�", "Ȯ��");

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

            textBox2.Enabled = true;
            textBox2.Text="";
            textBox3.Enabled = true;
            textBox3.Text = "";
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

            textBox2.Enabled = false;
            textBox2.Text = "           �Է� ���ʿ�";
            textBox3.Enabled = false;
            textBox3.Text = "           �Է� ���ʿ�";

        }

     

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            string site = @"http://www.autodesk.co.kr/free-trials";
            System.Diagnostics.Process.Start(site);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string site = @"http://www.imbu.co.kr/";
            System.Diagnostics.Process.Start(site);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            string site = @"http://download.microsoft.com/download/9/5/A/95A9616B-7A37-4AF6-BC36-D6EA96C8DAAE/dotNetFx40_Full_x86_x64.exe";
            System.Diagnostics.Process.Start(site);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            string site = @"https://download.microsoft.com/download/D/D/3/DD35CC25-6E9C-484B-A746-C5BE0C923290/NDP47-KB3186497-x86-x64-AllOS-ENU.exe";
            System.Diagnostics.Process.Start(site);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            string site = @"https://download.microsoft.com/download/C/3/A/C3A5200B-D33C-47E9-9D70-2F7C65DAAD94/NDP46-KB3045557-x86-x64-AllOS-ENU.exe";
            System.Diagnostics.Process.Start(site);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            string site = @"https://apps.autodesk.com/ko";
            System.Diagnostics.Process.Start(site);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            string site = @"http://usa.autodesk.com/support/downloads/";
            System.Diagnostics.Process.Start(site);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            string site = @"http://www.autodesk.co.kr/free-trials";
            System.Diagnostics.Process.Start(site);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string site = @"http://www.imbu.co.kr/";
            System.Diagnostics.Process.Start(site);
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            string site = @"http://rsup.net/imbu";
            System.Diagnostics.Process.Start(site);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegistryKey linereg1;
            linereg1 = Registry.LocalMachine.CreateSubKey("SYSTEM").CreateSubKey("CurrentControlSet").CreateSubKey("Control").CreateSubKey("Session Manager").CreateSubKey("Environment");
            linereg1.SetValue("useoldcommandline", "true");

            RegistryKey linereg2;
            linereg2 = Registry.CurrentUser.CreateSubKey("Environment");
            linereg2.SetValue("useoldcommandline", "true");

            //label5.Text = "���� �Ϸ�";
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(@"C:\Program Files\�����ȭ\LSPVirus.bat");
            }

            catch
            {
                MessageBox.Show("���̷����˻��� �������� �ջ�. file error.");
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            string site = @"http://knowledge.autodesk.com/support/autocad/downloads/caas/downloads/content/autocad-language-packs.html?v=2016";
            System.Diagnostics.Process.Start(site);
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            string site = @"https://accounts.autodesk.com";
            System.Diagnostics.Process.Start(site);
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            string site = @"https://a360.autodesk.com/drive/";
            System.Diagnostics.Process.Start(site);
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            string site = @"http://113366.com/imbu";
            System.Diagnostics.Process.Start(site);
        }

        private void pictureBox10_Click_1(object sender, EventArgs e)
        {
            try
            {
                Process.Start(@"C:\Program Files\�����ȭ\LSPVirus.bat");
            }

            catch
            {
                MessageBox.Show("���̷����˻��� �������� �ջ�. file error.");
            }
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            string site = @"http://www.autodesk.co.kr/adsk/servlet/item?id=18419568&siteID=1169528";
            System.Diagnostics.Process.Start(site);
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            string site = @"https://accounts.autodesk.com";
            System.Diagnostics.Process.Start(site);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string site = @"http://knowledge.autodesk.com/support/autocad/downloads/caas/downloads/content/autodesk-licensing-hotfix-poodle-ssl-v3-vulnerability-cve-2014-3566.html";
            System.Diagnostics.Process.Start(site);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string site = @"http://www.bimcenter.co.kr/";
            System.Diagnostics.Process.Start(site);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string site = @"http://www.imbu.co.kr/tip/";
            System.Diagnostics.Process.Start(site);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            webBrowser1.ScriptErrorsSuppressed = true;
            webBrowser1.Navigate(new Uri(@"http://www.bimcenter.co.kr/"));

            //webBrowser2.ScriptErrorsSuppressed = true;
            //webBrowser2.Navigate(new Uri(@"http://www.imbu.co.kr/"));
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}