using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EveCall
{
    public partial class formSettings : Form
    {
        public formSettings()
        {
            InitializeComponent();
        }

        public static class settingsValues
        {
            public static int combatLogEntryInterval = 5;
            public static int combatLogFileInterval = 60;
            public static int combatBroadcastDelay = 300;
            public static int fileCountWarning = 2000;            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //save settings
            settingsValues.combatLogEntryInterval = (int)numericCombatLogEntryInterval.Value;
            settingsValues.combatLogFileInterval = (int)numericCombatLogFileInterval.Value;
            settingsValues.combatBroadcastDelay = (int)numericCombatBroadcastDelay.Value;
            settingsValues.fileCountWarning = (int)numericFileCountWarning.Value;
        }

        private void formSettings_Shown(object sender, EventArgs e)
        {
            numericCombatLogEntryInterval.Value = settingsValues.combatLogEntryInterval;
            numericCombatLogFileInterval.Value = settingsValues.combatLogFileInterval;
            numericCombatBroadcastDelay.Value = settingsValues.combatBroadcastDelay;
            numericFileCountWarning.Value = settingsValues.fileCountWarning;
        }
    }
}
