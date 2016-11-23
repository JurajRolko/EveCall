using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;


namespace EveCall
{
    public partial class formItem : Form
    {
        public formItem()
        {
            InitializeComponent();            
        }

        public static bool isCloning = false;
        public static bool isUpdating = false;

        public static class itemValues
        {
            public static string title = "";
            public static int slackActive = 0;
            public static string slackWebhookUrl = "";
            public static int discordActive = 0;
            public static string discordWebhookUrl = "";
            public static string characterName = "";            
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {            
            //slack and discrod not selected
            if ((checkBoxSlackActive.Checked == false) && (checkBoxDiscordActive.Checked == false))
            {
                this.DialogResult = DialogResult.None;
                MessageBox.Show("Please select at least one service for the broadcast!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //if slack/discord selected, do simple url check
            //!!! todo - maybe create better regex to check valid slack/discord webhook url
            if ((checkBoxSlackActive.Checked == true) && (textBoxWebhookSlack.Text.Contains("slack.com") == false))
            {
                this.DialogResult = DialogResult.None;
                MessageBox.Show("Please type a slack webhook url", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if ((checkBoxDiscordActive.Checked == true) && (textBoxWebhookDiscord.Text.Contains("discordapp.com") == false))
            {
                this.DialogResult = DialogResult.None;
                MessageBox.Show("Please type a discord webhook url", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //define the name of capsuler
            if (comboBoxCharacterName.Text.Length <= 0)
            {
                this.DialogResult = DialogResult.None;
                MessageBox.Show("Please define the name of your capsuler!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            //save to new item into the list 
            if ( (isCloning == true) || (isUpdating == false) )
            {
                formMain.EveCallSettings.itemList.Add(new formMain.watchItem
                {
                    title = textBoxtitle.Text,
                    slackActive = (checkBoxSlackActive.Checked ? 1 : 0),
                    slackWebhookUrl = textBoxWebhookSlack.Text,
                    discordActive = (checkBoxDiscordActive.Checked ? 1 : 0),
                    discordWebhookUrl = textBoxWebhookDiscord.Text,
                    characterName = comboBoxCharacterName.Text,
                    lastTimestamp = DateTime.UtcNow,
                    isActive = 0
                });
            }
            if (isUpdating == true)
            {
                itemValues.title = textBoxtitle.Text;
                itemValues.slackActive = (checkBoxSlackActive.Checked ? 1 : 0);
                itemValues.slackWebhookUrl = textBoxWebhookSlack.Text;
                itemValues.discordActive = (checkBoxDiscordActive.Checked ? 1 : 0);
                itemValues.discordWebhookUrl = textBoxWebhookDiscord.Text;                
                itemValues.characterName = comboBoxCharacterName.Text;
            }
        }

        private void formNewItem_Shown(object sender, EventArgs e)
        {
            //initialize character name - analyse log files
            //find possible values for combobox
            List<string> characterNamesList = new List<string>();
            if (formMain.EveCallSettings.path.Length > 0)
            {               
                //get 100 most recent files                
                //create list of files that will be used
                FileInfo[] recentFilesList = Directory.GetFiles(formMain.EveCallSettings.path).Select(x => new FileInfo(x)).OrderByDescending(x => x.LastWriteTimeUtc).Take(100).ToArray();
                for (int i = 0; i < recentFilesList.Count(); i++)
                {
                    //read file
                    string[] fileLines = File.ReadAllLines(recentFilesList[i].FullName);
                    //find Listener: substring to indicate we are working with a log file for specific user
                    if (Regex.IsMatch(fileLines[2], "Listener:*"))
                    {
                        //get character name from third line (Listener: bla bla bla is always at this position)
                        string characterName = fileLines[2].Substring(12);
                        bool characterNameAlreadyExists = false;
                        //check if the file for a specific user is already remembered. 
                        //only most recent file for a specific character is relevant                        
                        for (int index_list = 0; index_list < characterNamesList.Count(); index_list++)
                        {
                            if (characterNamesList[index_list] == characterName) // (you use the word "contains". either equals or indexof might be appropriate)
                            {
                                characterNameAlreadyExists = true;
                                break;
                            }
                        }

                        //we didnt find character name yet. we can add new item to the buffer 
                        if (characterNameAlreadyExists == false)
                        {
                            characterNamesList.Add(characterName);
                        }
                    }
                }
            }

            //initialize form values
            if ( (isCloning == true) || (isUpdating == true) )
            {
                textBoxtitle.Text = itemValues.title;
                checkBoxSlackActive.Checked = (itemValues.slackActive > 0 ? true : false);
                textBoxWebhookSlack.Text = itemValues.slackWebhookUrl;
                checkBoxDiscordActive.Checked = (itemValues.discordActive > 0 ? true : false);
                textBoxWebhookDiscord.Text = itemValues.discordWebhookUrl;
                //add possible character names
                comboBoxCharacterName.Items.Clear();
                for (int i = 0; i < characterNamesList.Count(); i++)
                {
                    comboBoxCharacterName.Items.Add(characterNamesList[i]);
                }
                comboBoxCharacterName.Text = itemValues.characterName;
            }
            else
            {
                textBoxtitle.Text = "Title";
                checkBoxSlackActive.Checked = false;
                textBoxWebhookSlack.Text = "Slack webhook url";
                checkBoxDiscordActive.Checked = false;
                textBoxWebhookDiscord.Text = "Discord webhook url";
                //add possible character names
                comboBoxCharacterName.Items.Clear();
                for (int i = 0; i < characterNamesList.Count(); i++)
                {
                    comboBoxCharacterName.Items.Add(characterNamesList[i]);
                }
            }
        }
    }
}
