﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class LoginGUI : Form
    {
        public string Username;
        public string Password;
        public string Pin;
        public bool RememberMe;
        public bool LoginClicked = false;
        public bool CancelClicked = false;

        public LoginGUI()
        {
            InitializeComponent();
            this.FormClosing += (o, x) =>
            {
                if (rememberCredentials.Checked)
                {
                    Properties.Settings.Default.username = username.Text;
                    Properties.Settings.Default.password = password.Text;
                    Properties.Settings.Default.pin = pin.Text;
                    Properties.Settings.Default.remember = rememberCredentials.Checked;
                    Properties.Settings.Default.Save();
                    Properties.Settings.Default.Reload();
                }
            };

            if (Properties.Settings.Default.remember)
            {
                username.Text = Properties.Settings.Default.username;
                password.Text = Properties.Settings.Default.password;
                pin.Text = Properties.Settings.Default.pin;
                rememberCredentials.Checked = Properties.Settings.Default.remember;
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            CancelClicked = true;
            this.Close();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            if (username.Text.Length > 0 && password.Text.Length > 0 && pin.Text.Length > 0)
            {
                Username = username.Text;
                Password = password.Text;
                Pin = pin.Text;
                RememberMe = rememberCredentials.Checked;
                LoginClicked = true;
            }

            this.Close();
        }

        private void LoginGUI_DoubleClick(object sender, EventArgs e)
        {

        }
    }
}
