using GameOfLifeWinForms.core;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GameOfLifeWinForms
{
    public partial class GameOfLifeSettings : Form
    {
        public GameOfLifeSettings()
        {
            InitializeComponent();
            BuildControls();
            LoadSettings();
        }

        private void BuildControls()
        {
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            var subtypes = assembly.GetTypes().Where(t => t.IsSubclassOf(typeof (WorldProcessor)));
            foreach(var type in subtypes)
            {
                WorldToDisplay.Items.Add(type.Name);
            }
        }

        /// <summary>
        /// Load display text from the Registry
        /// </summary>
        private void LoadSettings()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\GameOfLife_ScreenSaver");
            if (key == null)
            {
                TextToDisplay.Text = "500";
                WorldToDisplay.SelectedIndex = 0;
            } else
            {
                TextToDisplay.Text = (string)key.GetValue("speed");
                WorldToDisplay.SelectedItem = key.GetValue("type");
            }
        }

        /// <summary>
        /// Save text into the Registry.
        /// </summary>
        private void SaveSettings()
        {
            // Create or get existing subkey
            RegistryKey key = Registry.CurrentUser.CreateSubKey("SOFTWARE\\GameOfLife_ScreenSaver");

            key.SetValue("speed", TextToDisplay.Text);
            key.SetValue("type", WorldToDisplay.SelectedItem.ToString());
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            SaveSettings();
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
