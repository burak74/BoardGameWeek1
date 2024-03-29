﻿using System.Windows.Forms;

namespace LoginForm.Properties {
    
    
    // This class allows you to handle specific events on the settings class:
    //  The SettingChanging event is raised before a setting's value is changed.
    //  The PropertyChanged event is raised after a setting's value is changed.
    //  The SettingsLoaded event is raised after the setting values are loaded.
    //  The SettingsSaving event is raised before the setting values are saved.
    internal sealed partial class Settings {
        public object WindowLocation { get; private set; }
        public object Location { get; private set; }
        public FormWindowState WindowState { get; private set; }
        public object WindowSize { get; private set; }
        public object Size { get; private set; }
        public object RestoreBounds { get; private set; }

        public Settings() {
            // // To add event handlers for saving and changing settings, uncomment the lines below:
            //
            // this.SettingChanging += this.SettingChangingEventHandler;
            //
            // this.SettingsSaving += this.SettingsSavingEventHandler;
            //
        }
        
        private void SettingChangingEventHandler(object sender, System.Configuration.SettingChangingEventArgs e) {
            // Add code to handle the SettingChangingEvent event here.
        }
        
        private void SettingsSavingEventHandler(object sender, System.ComponentModel.CancelEventArgs e) {
            // Add code to handle the SettingsSaving event here.
        }
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
        
            Settings.Default.WindowLocation = this.Location;

            
            if (this.WindowState == FormWindowState.Normal)
            {
                Settings.Default.WindowSize = this.Size;
            }
            else
            {
                Default.WindowSize = RestoreBounds;
            }

            
            Settings.Default.Save();
        }
    }
}
