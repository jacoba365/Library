﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library
{
    public partial class Library : Form
    {
        public static UILogic uiLogic = new UILogic();
        public static Threading threading = new Threading();
        public static Networking networking = new Networking();
        public static Utils utils = new Utils();
        public static MessageBoxData _MessageBoxData = new MessageBoxData();

        public static Label _statusLabel;
        public static ProgressBar _progressBar;
        public static Button _browseButton;
        public static Button _convertButton;
        public static Button _aboutButton;
        public static TextBox _pathBox;

        private string aboutURL = "https://github.com/TastyLollipop/Library";

        private string versionName = "v1.0.0";

        public Library()
        {
            InitializeComponent();
            SetupComponents();
            SetupAppDetails();
        }

        //Setup UI elements so they can be called from other functions
        private void SetupComponents()
        {
            _statusLabel = statusLabel;
            _progressBar = progressBar;
            _browseButton = browseButton;
            _convertButton = convertButton;
            _aboutButton = aboutButton;
            _pathBox = pathBox;
        }

        //Setup the details that need to be configured before the app starts working
        private void SetupAppDetails() { Text = "Library " + versionName; }

        //Open the browse dialog to search for a path
        private void browseButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK) { pathBox.Text = folderBrowserDialog.SelectedPath; }
            else return;
        }

        //Tries to start folder conversion
        private void convertButton_Click(object sender, EventArgs e)
        {
            if (!CheckForParameters()) return;

            //Disable buttons
            uiLogic.InvokeFunctionOn(UILogic.InvokeMode.toggleButtons, null);

            //Change status label
            uiLogic.InvokeFunctionOn(UILogic.InvokeMode.changeStatusLabel, "Starting");

            //Start sorting system
            threading.GenerateThread(0);
        }

        //Opens the "about" URL
        private void aboutButton_Click(object sender, EventArgs e) { System.Diagnostics.Process.Start(aboutURL); }

        //Checks that every needed parameters is valid
        private bool CheckForParameters()
        {
            if (string.IsNullOrWhiteSpace(pathBox.Text))
            {
                uiLogic.InvokeFunctionOn(UILogic.InvokeMode.showMessageBox, 0);
                return false;
            }

            return true;
        }
    }
}