using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Net;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace EveCall
{
    public partial class formMain : Form
    {
        public formMain()
        {
            InitializeComponent();

            Icon = EveCall.Properties.Resources.evecall_off;
            notifyIcon1.Icon = EveCall.Properties.Resources.evecall_off;

            notifyIcon1.Visible = true;
            MaximizeBox = false;            
        }

        private formItem formWatchItem = new formItem();
        private formAbout formAbout = new formAbout();
        private formSettings formSettings = new formSettings();

        //main class to keep stuff
        public static class EveCallSettings
        {
            public static bool isInitializationDone = false;
            public static string xmlFileName = "config.xml";
            public static bool isActive = false;
            public static string path = "";            

            public static int combatLogEntryInterval = 5;
            public static int combatLogFileInterval = 60;
            public static int combatBroadcastDelay = 300;
            public static int fileCountWarning = 2000;

            public static List<singleFile> fileList = new List<singleFile>();
            public static List<watchItem> itemList = new List<watchItem>();   
            
            //function to recreate xml file with settings
            public static void CreateXML()
            {               
                //create file
                XmlDocument xmlDoc = new XmlDocument();
                //create root element with some attributes
                //!!! change attributes
                XmlNode rootNode = xmlDoc.CreateElement("EveCall");
                XmlAttribute attribute = xmlDoc.CreateAttribute("version");
                rootNode.Attributes.Append(attribute);
                attribute.Value = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(); 
                attribute = xmlDoc.CreateAttribute("timestamp");
                rootNode.Attributes.Append(attribute);
                attribute.Value = DateTime.UtcNow.ToString();
                attribute = xmlDoc.CreateAttribute("path");
                rootNode.Attributes.Append(attribute);
                attribute.Value = path;

                attribute = xmlDoc.CreateAttribute("combatLogEntryInterval");
                rootNode.Attributes.Append(attribute);
                attribute.Value = combatLogEntryInterval.ToString();
                attribute = xmlDoc.CreateAttribute("combatLogFileInterval");
                rootNode.Attributes.Append(attribute);
                attribute.Value = combatLogFileInterval.ToString();
                attribute = xmlDoc.CreateAttribute("combatBroadcastDelay");
                rootNode.Attributes.Append(attribute);
                attribute.Value = combatBroadcastDelay.ToString();
                attribute = xmlDoc.CreateAttribute("fileCountWarning");
                rootNode.Attributes.Append(attribute);
                attribute.Value = fileCountWarning.ToString();

                xmlDoc.AppendChild(rootNode);

                //create all watchItem elements
                for (int i = 0; i < EveCallSettings.itemList.Count; i++)
                {
                    //main node
                    XmlNode watchItemNode = xmlDoc.CreateElement("watchItem");
                    rootNode.AppendChild(watchItemNode);
                    //main node details
                    XmlNode watchItemAttributeNode = xmlDoc.CreateElement("title");
                    watchItemAttributeNode.InnerText = EveCallSettings.itemList[i].title;
                    watchItemNode.AppendChild(watchItemAttributeNode);
                    //!!!watchItemAttributeNode = xmlDoc.CreateElement("path");
                    //!!!watchItemAttributeNode.InnerText = EveCallSettings.itemList[i].path;
                    //!!!watchItemNode.AppendChild(watchItemAttributeNode);

                    watchItemAttributeNode = xmlDoc.CreateElement("slackActive");
                    watchItemAttributeNode.InnerText = ((EveCallSettings.itemList[i].slackActive >= 1) ? "1" : "0");
                    watchItemNode.AppendChild(watchItemAttributeNode);
                    watchItemAttributeNode = xmlDoc.CreateElement("slackWebhookUrl");
                    watchItemAttributeNode.InnerText = EveCallSettings.itemList[i].slackWebhookUrl;
                    watchItemNode.AppendChild(watchItemAttributeNode);

                    watchItemAttributeNode = xmlDoc.CreateElement("discordActive");
                    watchItemAttributeNode.InnerText = ((EveCallSettings.itemList[i].discordActive >= 1) ? "1" : "0");
                    watchItemNode.AppendChild(watchItemAttributeNode);
                    watchItemAttributeNode = xmlDoc.CreateElement("discordWebhookUrl");
                    watchItemAttributeNode.InnerText = EveCallSettings.itemList[i].discordWebhookUrl;
                    watchItemNode.AppendChild(watchItemAttributeNode);

                    watchItemAttributeNode = xmlDoc.CreateElement("characterName");
                    watchItemAttributeNode.InnerText = EveCallSettings.itemList[i].characterName;
                    watchItemNode.AppendChild(watchItemAttributeNode);                    

                    watchItemAttributeNode = xmlDoc.CreateElement("isActive");
                    watchItemAttributeNode.InnerText = ( (EveCallSettings.itemList[i].isActive >=1) ? "1" : "0" );
                    watchItemNode.AppendChild(watchItemAttributeNode);
                }
                //finalize xml file
                xmlDoc.Save("config.xml");
            }         
        }

        //object to store item details
        public class watchItem
        {         
            //values from xml file and settings   
            public string title { get; set; }
            //!!!public string path { get; set; }
            public int slackActive { get; set; }
            public string slackWebhookUrl { get; set; }
            public int discordActive { get; set; }
            public string discordWebhookUrl { get; set; }
            public string characterName { get; set; }
            public int isActive { get; set; }
            //variables for runtime check                       
            public DateTime lastTimestamp { get; set; }
            //remember values from last record
            public string recordLocationValue { get; set; }
            public string recordTimestampValue { get; set; }
        }

        //object to store unique file info
        public class singleFile
        {
            public string characterName { get; set; }
            public string fileName { get; set; }
            public DateTime lastTimestamp { get; set; }
            public string lastPlayerLocation { get; set; }
        }

        //method to update UI 
        private void refreshCheckedListBox()
        {            
            checkedListBoxItems.Items.Clear();
            foreach (watchItem item in EveCallSettings.itemList)
            {
                checkedListBoxItems.Items.Add(item.title, (item.isActive > 0 ? true : false) );
            }
        }

        //method to update UI 
        private void refreshUIButtons()
        {
            //update enabled properties for buttons
            if (!(checkedListBoxItems.SelectedIndex == -1))
            {                
                buttonCloneItem.Enabled = true;
                buttonEditItem.Enabled = true;
                buttonDeleteItem.Enabled = true;
                buttonMoveItemUp.Enabled = true;
                buttonMoveItemDown.Enabled = true;
                //first item selected => move up not available
                if (checkedListBoxItems.SelectedIndex == 0)
                {
                    buttonMoveItemUp.Enabled = false;
                }
                //if last item selected
                if (checkedListBoxItems.SelectedIndex == (checkedListBoxItems.Items.Count-1))
                {
                    buttonMoveItemDown.Enabled = false;
                }
            }
            else
            {
                buttonCloneItem.Enabled = false;
                buttonEditItem.Enabled = false;
                buttonDeleteItem.Enabled = false;
                buttonMoveItemUp.Enabled = false;
                buttonMoveItemDown.Enabled = false;
            }
        }

        //method to update UI 
        private void refreshUIBroadcastButton(bool paIsActive)
        {
            if (paIsActive == true)
            {
                buttonToggleActive.BackColor = Color.MediumAquamarine;
                buttonToggleActive.ForeColor = Color.White;
                buttonToggleActive.Text = "ACTIVE - click to disable";
                Icon = EveCall.Properties.Resources.evecall_on;
                notifyIcon1.Icon = EveCall.Properties.Resources.evecall_on;
                //change tray icon context menu item text
                itemToolStripMenuItemToggleActive.Text = "Dectivate";
            }
            else
            {
                buttonToggleActive.BackColor = Color.Crimson;
                buttonToggleActive.ForeColor = Color.White;
                buttonToggleActive.Text = "NOT ACTIVE - click to enable";
                Icon = EveCall.Properties.Resources.evecall_off;
                notifyIcon1.Icon = EveCall.Properties.Resources.evecall_off;
                //change tray icon context menu item text
                itemToolStripMenuItemToggleActive.Text = "Activate";
            }
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            /*
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            this.Show();
            */
        }

        private void buttonNewCharacter_Click(object sender, EventArgs e)
        {   
            //Create new item                                        
            if (formWatchItem.Created)
            {
                formItem.isCloning = false;
                formItem.isUpdating = false;
                DialogResult result = formWatchItem.ShowDialog();
                if (result == DialogResult.OK)
                {
                    //refresh ui
                    refreshCheckedListBox();
                    //recreate xml
                    EveCallSettings.CreateXML();
                    //update UI                    
                    refreshUIButtons();
                }
            }
            else
            {
                formWatchItem = new formItem();
                formItem.isCloning = false;
                formItem.isUpdating = false;
                DialogResult result = formWatchItem.ShowDialog();
                if (result == DialogResult.OK)
                {
                    //refresh ui
                    refreshCheckedListBox();
                    //recreate xml
                    EveCallSettings.CreateXML();
                    //update UI                    
                    refreshUIButtons();
                }                
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Create new item via cloning
            int selectedIndex = checkedListBoxItems.SelectedIndex;
            if (selectedIndex >= 0)
            {
                if (formWatchItem.Created)
                {
                    formItem.isCloning = true;
                    formItem.isUpdating = false;
                    formItem.itemValues.title = EveCallSettings.itemList[selectedIndex].title;
                    formItem.itemValues.slackActive = EveCallSettings.itemList[selectedIndex].slackActive;
                    formItem.itemValues.slackWebhookUrl = EveCallSettings.itemList[selectedIndex].slackWebhookUrl;
                    formItem.itemValues.discordActive = EveCallSettings.itemList[selectedIndex].discordActive;
                    formItem.itemValues.discordWebhookUrl = EveCallSettings.itemList[selectedIndex].discordWebhookUrl;
                    formItem.itemValues.characterName = EveCallSettings.itemList[selectedIndex].characterName;
                    DialogResult result = formWatchItem.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        //refresh ui
                        refreshCheckedListBox();
                        //recreate xml
                        EveCallSettings.CreateXML();
                        //update UI                    
                        refreshUIButtons();
                    }
                }
                else
                {
                    formWatchItem = new formItem();
                    formItem.isCloning = true;
                    formItem.isUpdating = false;
                    formItem.itemValues.title = EveCallSettings.itemList[selectedIndex].title;
                    formItem.itemValues.slackActive = EveCallSettings.itemList[selectedIndex].slackActive;
                    formItem.itemValues.slackWebhookUrl = EveCallSettings.itemList[selectedIndex].slackWebhookUrl;
                    formItem.itemValues.discordActive = EveCallSettings.itemList[selectedIndex].discordActive;
                    formItem.itemValues.discordWebhookUrl = EveCallSettings.itemList[selectedIndex].discordWebhookUrl;
                    formItem.itemValues.characterName = EveCallSettings.itemList[selectedIndex].characterName;
                    DialogResult result = formWatchItem.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        //refresh ui
                        refreshCheckedListBox();
                        //recreate xml
                        EveCallSettings.CreateXML();
                        //update UI                    
                        refreshUIButtons();
                    }
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {            
            //check number of items to watch
            //if 0, disable button and show warning message
            if (EveCallSettings.itemList.Count <= 0)
            {
                EveCallSettings.isActive = false;
                refreshUIBroadcastButton(false);                
                MessageBox.Show("Activation is not possible. You need to add at least one item. (Click on the 'new' button)", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);                
                return;
            }

            //check if path is defined properly
            if (EveCallSettings.path.Length <= 0)
            {
                EveCallSettings.isActive = false;
                refreshUIBroadcastButton(false);                
                MessageBox.Show("Activation is not possible. You need to define the path to your combat log directory. (Click on the '...' button below)", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);                
                return;
            }

            //check if path is valid
            try
            {
                int files_count = Directory.GetFiles(EveCallSettings.path).Count();
            }
            catch
            {
                EveCallSettings.isActive = false;
                refreshUIBroadcastButton(false);
                MessageBox.Show("Activation is not possible. You need to define a correct path to your combat log directory. (Click on the '...' button below)", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //0 checked items
            if (checkedListBoxItems.CheckedItems.Count <= 0)
            {
                EveCallSettings.isActive = false;
                refreshUIBroadcastButton(false);
                MessageBox.Show("Activation is not possible. Please mark at least one item as checked!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //change state
            if (EveCallSettings.isActive)
            {
                //app is active => set state to not active and stop log files analysis
                EveCallSettings.isActive = false;
                refreshUIBroadcastButton(false);
                //stop log files analysis timers                
                timerCombatLog.Stop();
                timerLogFilesUpdate.Stop();
            }
            else
            {
                //app is not active => set state to active and start log files analysis
                timerCombatLog.Stop();
                timerLogFilesUpdate.Stop();
                timerCombatLog.Interval = EveCallSettings.combatLogEntryInterval*1000;
                timerLogFilesUpdate.Interval = EveCallSettings.combatLogFileInterval*1000;
                               
                EveCallSettings.isActive = true;
                refreshUIBroadcastButton(true);                

                if (EveCallSettings.path.Length > 0)
                {
                    //remove actual remembered files
                    EveCallSettings.fileList.Clear();

                    //get 50 most recent files                
                    //create list of files that will be used
                    FileInfo[] recentFilesList = Directory.GetFiles(EveCallSettings.path).Select(x => new FileInfo(x)).OrderByDescending(x => x.LastWriteTimeUtc).Take(50).ToArray();
                    for (int i = 0; i < recentFilesList.Count(); i++)
                    {
                        //process only files in last 24h. (Eve Online downtime, the file must be modified in last 24 to be usable for EveCall
                        if (recentFilesList[i].LastWriteTimeUtc > DateTime.UtcNow.AddHours(-25))
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
                                //we can skip older files
                                for (int j = 0; j < EveCallSettings.fileList.Count(); j++)
                                {
                                    //compare character names
                                    if (characterName == EveCallSettings.fileList[j].characterName)
                                    {
                                        //we already have the most recent file for this character name
                                        //we can finish the loop
                                        characterNameAlreadyExists = true;
                                        break;
                                    }
                                }
                                //we didnt find character name yet. we can add new item to the buffer 
                                if (characterNameAlreadyExists == false)
                                {
                                    EveCallSettings.fileList.Add(new singleFile
                                    {
                                        characterName = characterName,
                                        fileName = recentFilesList[i].FullName,
                                        lastTimestamp = recentFilesList[i].LastWriteTimeUtc,
                                        lastPlayerLocation = ""
                                    });
                                }
                            }
                        }
                    }

                    //start combat log check if any settings available
                    //!!!
                    if (EveCallSettings.isActive)
                    {
                        //reactivate timers                        
                        timerLogFilesUpdate.Stop();
                        timerLogFilesUpdate.Start();
                        timerCombatLog.Stop();
                        timerCombatLog.Start();
                    }
                }
            }                        
        }

        private void timerCombatLog_Tick(object sender, EventArgs e)
        {            
            //analyze combat logs and send appropriate messages
            //loop through all characters with logs in last 24 hours
            for (int i = 0; i < EveCallSettings.fileList.Count(); i++)
            {
                //get file info for actual charactername
                FileInfo characterFileInfo = new FileInfo(EveCallSettings.fileList[i].fileName);
                //loop through all watched items
                for (int j=0; j < EveCallSettings.itemList.Count(); j++)
                {
                    bool combatEntryFound = false;
                    bool locationEntryFound = false;
                    bool aggressorSelf = false;
                    string recordTargetValue = "";
                    string recordLocationValue = "";
                    //continue only if the watch is active
                    if (EveCallSettings.itemList[j].isActive >= 1)
                    {
                        //continue only if file changed since the last check (file lastwritetime is later than last check time) and (character names match or character name is any name (empty value) )
                        if ( ( (EveCallSettings.fileList[i].characterName == EveCallSettings.itemList[j].characterName) || (EveCallSettings.itemList[j].characterName.Length <= 0) ) && (DateTime.Compare(characterFileInfo.LastWriteTimeUtc,EveCallSettings.itemList[j].lastTimestamp) > 0) )
                        {
                            //there was a change in the file, we need to analyze it
                            //we need to find latest combat log value
                            //load current file
                            string[] fileLines = File.ReadAllLines(EveCallSettings.fileList[i].fileName);
                            string recordTimestampValue = "";
                            //trace from end to start
                            for (int currentLine = (fileLines.Count()-1); currentLine > 0; currentLine--)
                            {
                                //get timestamp from the log entry
                                string searchPattern = ".*\\[\\s(.*)\\s\\].*";
                                Regex regexResult = new Regex(searchPattern);
                                Match matchResult = regexResult.Match(fileLines[currentLine]);
                                if (matchResult.Success)
                                {
                                    //get timestamp for the record
                                    recordTimestampValue = matchResult.Groups[1].Value;
                                    DateTime recordTimestamp = DateTime.ParseExact(recordTimestampValue, "yyyy.MM.dd HH:mm:ss", null);
                                    //continue only if file changed since the last check (file lastwritetime is later than last check time)
                                    if (DateTime.Compare(recordTimestamp, EveCallSettings.itemList[j].lastTimestamp) > 0)
                                    {
                                        //find combat info - aggresor vs victim name[corp](ship)                                
                                        //search pattern to find: combat line, aggresor self, target hostile                                
                                        //search only if still not found                                        
                                        //green dps check
                                        if (combatEntryFound == false)
                                        {
                                            searchPattern = ".*\\(combat\\) <color=.{10}><b>.*</b> <color=.{10}><font size=.*>to</font> <b><color=.{10}>(.*\\(.*\\))</b><font size=.*";
                                            regexResult = new Regex(searchPattern);
                                            matchResult = regexResult.Match(fileLines[currentLine]);
                                            if (matchResult.Success)
                                            {
                                                recordTargetValue = matchResult.Groups[1].Value;
                                                combatEntryFound = true;
                                                aggressorSelf = true;
                                                EveCallSettings.itemList[j].lastTimestamp = characterFileInfo.LastWriteTimeUtc;
                                            }
                                        }
                                        //red dps check
                                        if (combatEntryFound == false)
                                        {
                                            searchPattern = ".*\\(combat\\) <color=.{10}><b>.*</b> <color=.{10}><font size=.*>from</font> <b><color=.{10}>(.*\\(.*\\))</b><font size=.*";
                                            regexResult = new Regex(searchPattern);
                                            matchResult = regexResult.Match(fileLines[currentLine]);
                                            if (matchResult.Success)
                                            {
                                                recordTargetValue = matchResult.Groups[1].Value;
                                                combatEntryFound = true;
                                                aggressorSelf = false;
                                                EveCallSettings.itemList[j].lastTimestamp = characterFileInfo.LastWriteTimeUtc;
                                            }
                                        }
                                        //green warp scramble/distrupt check
                                        if (combatEntryFound == false)
                                        {
                                            searchPattern = ".*\\(combat\\) <color=.{10}><b>Warp.*</b> <color=.{10}><font size=.*>from</font> <color=.{10}><b>you</b> <color=.{10}><font size=.*>to <b><color=.{10}></font>(.*\\(.*\\))";
                                            regexResult = new Regex(searchPattern);
                                            matchResult = regexResult.Match(fileLines[currentLine]);
                                            if (matchResult.Success)
                                            {
                                                recordTargetValue = matchResult.Groups[1].Value;
                                                combatEntryFound = true;
                                                aggressorSelf = true;
                                                EveCallSettings.itemList[j].lastTimestamp = characterFileInfo.LastWriteTimeUtc;                                                
                                            }
                                        }
                                        //red warp scramble/distrupt check
                                        if (combatEntryFound == false)
                                        {
                                            searchPattern = ".*\\(combat\\) <color=.{10}><b>Warp.*</b> <color=.{10}><font size=.*>from</font> <color=.{10}><b>(.*\\(.*\\))</b> <color=.{10}><font size=.*>to <b><color=.{10}></font>you!";
                                            regexResult = new Regex(searchPattern);
                                            matchResult = regexResult.Match(fileLines[currentLine]);
                                            if (matchResult.Success)
                                            {
                                                recordTargetValue = matchResult.Groups[1].Value;
                                                combatEntryFound = true;
                                                aggressorSelf = false;
                                                EveCallSettings.itemList[j].lastTimestamp = characterFileInfo.LastWriteTimeUtc;
                                            }
                                        }
                                        
                                        //search for the last location - undocking pattern
                                        if (locationEntryFound == false)
                                        {
                                            searchPattern = ".*Undocking from (.*) to (.*) solar system.";
                                            regexResult = new Regex(searchPattern);
                                            matchResult = regexResult.Match(fileLines[currentLine]);                                            
                                            if (matchResult.Success)
                                            {
                                                recordLocationValue = matchResult.Groups[2].Value;
                                                locationEntryFound = true;                                                                                                                                              
                                            }
                                        }
                                        //search for the last location - gate jump pattern
                                        if (locationEntryFound == false)
                                        {
                                            searchPattern = ".*Jumping from (.*) to (.*)";
                                            regexResult = new Regex(searchPattern);
                                            matchResult = regexResult.Match(fileLines[currentLine]);
                                            if (matchResult.Success)
                                            {
                                                recordLocationValue = matchResult.Groups[2].Value;
                                                locationEntryFound = true;
                                            }
                                        }

                                        //if we already found everything we can finish processing
                                        if ( (combatEntryFound == true) && (locationEntryFound == true) )
                                        {
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        //do not process older lines, current timestamp is later than entry timestamp
                                        break;
                                    }
                                }
                                else
                                {
                                    //no valid match, finish line processing
                                    break;
                                }                                
                            }

                            //searching the file lines again, this time for locations even older than current timestamp. we are trying to find any possible location
                            if (locationEntryFound == false)
                            {
                                //trace from end to start
                                for (int currentLine = (fileLines.Count() - 1); currentLine > 0; currentLine--)
                                {
                                    //get timestamp from the log entry
                                    string searchPattern; //= ".*\\[\\s(.*)\\s\\].*";
                                    Regex regexResult; //= new Regex(searchPattern);
                                    Match matchResult; //= regexResult.Match(fileLines[currentLine]);
                                    
                                    //search for the last location - undocking pattern
                                    if (locationEntryFound == false)
                                    {
                                        searchPattern = ".*Undocking from (.*) to (.*) solar system.";
                                        regexResult = new Regex(searchPattern);
                                        matchResult = regexResult.Match(fileLines[currentLine]);
                                        if (matchResult.Success)
                                        {
                                            recordLocationValue = matchResult.Groups[2].Value;
                                            locationEntryFound = true;
                                        }
                                    }
                                    //search for the last location - gate jump pattern
                                    if (locationEntryFound == false)
                                    {
                                        searchPattern = ".*Jumping from (.*) to (.*)";
                                        regexResult = new Regex(searchPattern);
                                        matchResult = regexResult.Match(fileLines[currentLine]);
                                        if (matchResult.Success)
                                        {
                                            recordLocationValue = matchResult.Groups[2].Value;
                                            locationEntryFound = true;
                                        }
                                    }

                                    //if we already found everything we can finish processing
                                    if (locationEntryFound == true)
                                    {
                                        break;
                                    }
                                }    
                            }

                            //broadcast to Slack/Discord if valid values found
                            if (combatEntryFound == true)
                            {
                                //decide what kind of intel is broadcasted. green if aggresor is self, or red if aggressor is some hostile player
                                //this could be confusing due to timer tick delay
                                if (aggressorSelf == true)
                                {
                                    if (EveCallSettings.itemList[j].slackActive > 0)
                                    {
                                        if ( (EveCallSettings.itemList[j].recordLocationValue != recordLocationValue) || ((DateTime.ParseExact(recordTimestampValue, "yyyy.MM.dd HH:mm:ss", null) - DateTime.ParseExact(EveCallSettings.itemList[j].recordTimestampValue, "yyyy.MM.dd HH:mm:ss", null)).TotalSeconds > EveCallSettings.combatBroadcastDelay) )
                                        {
                                            using (WebClient webClient = new WebClient())
                                            {                                                
                                                NameValueCollection data = new NameValueCollection();
                                                recordTargetValue = recordTargetValue.Replace("[", " ");
                                                recordTargetValue = recordTargetValue.Replace("]", " ");
                                                data["payload"] = "{\"username\":\"Intel\",\"attachments\": [{\"color\":\"#8BC34A\",\"text\": \"" + EveCallSettings.fileList[i].characterName + " vs " + recordTargetValue + " / " + recordLocationValue + " / " + recordTimestampValue + "\"}]}";
                                                var response = webClient.UploadValues(EveCallSettings.itemList[j].slackWebhookUrl, "POST", data);
                                                //timerCombatLog.Stop();
                                                EveCallSettings.itemList[j].recordLocationValue = recordLocationValue;
                                                EveCallSettings.itemList[j].recordTimestampValue = recordTimestampValue;
                                            }
                                        }
                                    }
                                    if (EveCallSettings.itemList[j].discordActive > 0)
                                    {
                                        if ((EveCallSettings.itemList[j].recordLocationValue != recordLocationValue) || ((DateTime.ParseExact(recordTimestampValue, "yyyy.MM.dd HH:mm:ss", null) - DateTime.ParseExact(EveCallSettings.itemList[j].recordTimestampValue, "yyyy.MM.dd HH:mm:ss", null)).TotalSeconds > EveCallSettings.combatBroadcastDelay))
                                        {
                                            using (WebClient webClient = new WebClient())
                                            {                                                
                                                webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
                                                recordTargetValue = recordTargetValue.Replace("[", " ");
                                                recordTargetValue = recordTargetValue.Replace("]", " ");
                                                string jsonString = "{\"content\":\"" + EveCallSettings.fileList[i].characterName + " vs " + recordTargetValue + " / " + recordLocationValue + " / " + recordTimestampValue + "\"}";
                                                string responseDiscord = webClient.UploadString(EveCallSettings.itemList[j].discordWebhookUrl, jsonString);
                                                EveCallSettings.itemList[j].recordLocationValue = recordLocationValue;
                                                EveCallSettings.itemList[j].recordTimestampValue = recordTimestampValue;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    if (EveCallSettings.itemList[j].slackActive > 0)
                                    {
                                        if ((EveCallSettings.itemList[j].recordLocationValue != recordLocationValue) || ((DateTime.ParseExact(recordTimestampValue, "yyyy.MM.dd HH:mm:ss", null) - DateTime.ParseExact(EveCallSettings.itemList[j].recordTimestampValue, "yyyy.MM.dd HH:mm:ss", null)).TotalSeconds > EveCallSettings.combatBroadcastDelay))
                                        {
                                            using (WebClient webClient = new WebClient())
                                            {                                                
                                                NameValueCollection data = new NameValueCollection();
                                                recordTargetValue = recordTargetValue.Replace("[", " ");
                                                recordTargetValue = recordTargetValue.Replace("]", " ");
                                                data["payload"] = "{\"username\":\"Intel\",\"attachments\": [{\"color\":\"#F44336\",\"text\": \"" + EveCallSettings.fileList[i].characterName + " vs " + recordTargetValue + " / " + recordLocationValue + " / " + recordTimestampValue + "\"}]}";                                                
                                                try
                                                {
                                                    var response = webClient.UploadValues(EveCallSettings.itemList[j].slackWebhookUrl, "POST", data);
                                                }
                                                catch
                                                {
                                                    //error handling                                                
                                                    //Additional information: The remote server returned an error: (404) Not Found.                                                    
                                                    checkedListBoxItems.SetItemChecked(j, false);
                                                    
                                                }

                                                EveCallSettings.itemList[j].recordLocationValue = recordLocationValue;
                                                EveCallSettings.itemList[j].recordTimestampValue = recordTimestampValue;
                                            }
                                        }
                                    }
                                    if (EveCallSettings.itemList[j].discordActive > 0)
                                    {
                                        if ((EveCallSettings.itemList[j].recordLocationValue != recordLocationValue) || ((DateTime.ParseExact(recordTimestampValue, "yyyy.MM.dd HH:mm:ss", null) - DateTime.ParseExact(EveCallSettings.itemList[j].recordTimestampValue, "yyyy.MM.dd HH:mm:ss", null)).TotalSeconds > EveCallSettings.combatBroadcastDelay))
                                        {
                                            using (WebClient webClient = new WebClient())
                                            {                                                
                                                webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
                                                recordTargetValue = recordTargetValue.Replace("[", " ");
                                                recordTargetValue = recordTargetValue.Replace("]", " ");
                                                string jsonString = "{\"content\":\"" + EveCallSettings.fileList[i].characterName + " vs " + recordTargetValue + " / " + recordLocationValue + " / " + recordTimestampValue + "\"}";
                                                
                                                try
                                                {
                                                    string responseDiscord = webClient.UploadString(EveCallSettings.itemList[j].discordWebhookUrl, jsonString);
                                                }
                                                catch
                                                {
                                                    //error handling
                                                    //Additional information: The remote server returned an error: (401) Unauthorized.
                                                    checkedListBoxItems.SetItemChecked(j, false);
                                                }
                                                EveCallSettings.itemList[j].recordLocationValue = recordLocationValue;
                                                EveCallSettings.itemList[j].recordTimestampValue = recordTimestampValue;
                                            }
                                        }
                                    }
                                }
                            } 
                            else
                            {
                                //combat entry found
                                //we can set timestamp for the item to NOW, so we dont need to check it again until the log file will be modiefied
                                EveCallSettings.itemList[j].lastTimestamp = DateTime.UtcNow;
                            }
                        }
                    }
                }
            }            
        }

        private void checkedListBoxItems_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //item check status changes triggered

            if (EveCallSettings.isInitializationDone)
            {
                //update check states in list                
                if (e.NewValue == CheckState.Checked)
                {
                    EveCallSettings.itemList[e.Index].isActive = 1;
                }
                else
                {
                    EveCallSettings.itemList[e.Index].isActive = 0;
                }                                
                //rebuild xml file
                EveCallSettings.CreateXML();

                //app active doenst matter => set state to not active and stop log files analysis
                EveCallSettings.isActive = false;
                refreshUIBroadcastButton(false);
                //stop log files analysis                
                timerCombatLog.Stop();
                timerLogFilesUpdate.Stop();
            }
            
        }

        private void checkedListBoxItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            //update UI                    
            refreshUIButtons();
        }

        private void buttonDeleteItem_Click(object sender, EventArgs e)
        {
            int selectedIndex = checkedListBoxItems.SelectedIndex;

            if (selectedIndex >= 0)
            {
                //confirm dialog
                DialogResult result = MessageBox.Show("Are you sure you want to delete the selected item?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    //remove item from list
                    EveCallSettings.itemList.RemoveAt(selectedIndex);
                    //recreate xml
                    EveCallSettings.CreateXML();
                    //update ui
                    refreshCheckedListBox();
                    //update UI                    
                    refreshUIButtons();
                }
            }
        }

        private void timerLogFilesUpdate_Tick(object sender, EventArgs e)
        {
            //update actual list of combat log files, that are used in the second timer
            if (EveCallSettings.path.Length > 0)
            {
                //remove actual remembered files
                EveCallSettings.fileList.Clear();

                //get 50 most recent files                
                //create list of files that will be used
                FileInfo[] recentFilesList = Directory.GetFiles(EveCallSettings.path).Select(x => new FileInfo(x)).OrderByDescending(x => x.LastWriteTimeUtc).Take(50).ToArray();
                for (int i = 0; i < recentFilesList.Count(); i++)
                {
                    //process only files in last 24h. (Eve Online downtime, the file must be modified in last 24 to be usable for EveCall
                    if (recentFilesList[i].LastWriteTimeUtc > DateTime.UtcNow.AddHours(-25))
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
                            //we can skip older files
                            for (int j = 0; j < EveCallSettings.fileList.Count(); j++)
                            {
                                //compare character names
                                if (characterName == EveCallSettings.fileList[j].characterName)
                                {
                                    //we already have the most recent file for this character name
                                    //we can finish the loop
                                    characterNameAlreadyExists = true;
                                    break;
                                }
                            }
                            //we didnt find character name yet. we can add new item to the buffer 
                            if (characterNameAlreadyExists == false)
                            {
                                EveCallSettings.fileList.Add(new singleFile
                                {
                                    characterName = characterName,
                                    fileName = recentFilesList[i].FullName,
                                    lastTimestamp = recentFilesList[i].LastWriteTimeUtc,
                                    lastPlayerLocation = ""
                                });
                            }
                        }
                    }
                }                
            }            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //define path to combat log directory
            //✓ specified directory seems to be valid
            //⚠ directory path is not defined

            //try to initialize path to the eve online combat logs
            if (folderBrowserDialog1.SelectedPath.Length <= 0)
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                folderBrowserDialog1.SelectedPath = path + "\\EVE\\logs\\Gamelogs";
            }            

            // Show the FolderBrowserDialog.
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                bool combatLogFilesExist = false;
                string folderName = folderBrowserDialog1.SelectedPath;
                textBoxPath.Text = folderName;
                //save path to object  
                EveCallSettings.path = textBoxPath.Text;

                //check possible combat log files count
                string[] recentFilesList = Directory.GetFiles(EveCallSettings.path,"*.txt");
                int files_count = recentFilesList.Count();
                for (int i = 0; i < files_count; i++)
                {
                    //read file
                    string[] fileLines = File.ReadAllLines(recentFilesList[i]);
                    //find Listener: substring to indicate we are working with a log file for specific user
                    if (Regex.IsMatch(fileLines[2], "Listener:*"))
                    {
                        combatLogFilesExist = true;
                        break;
                    }
                }                                

                //check files count in the folder                
                if ((files_count > EveCallSettings.fileCountWarning) && (combatLogFilesExist == true))
                {
                    //open location in windows explorer so user can delete some log files manually
                    result = MessageBox.Show("Your selected combat log directory contains " + files_count.ToString() + " files. You might want to manually delete them to prevent EveCall lags. Click OK to open the location in windows explorer. (Go to File->Settings if you want to change the limit for this warning message)", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (result == DialogResult.OK)
                    {
                        Process.Start(@folderName);
                    }
                }
                                
                labelPathInfo.Text = "✓ directory path is defined"+" ("+files_count.ToString()+" log files found)";
                //recreate xml config file
                EveCallSettings.CreateXML();

                //app active status doesnt matter => set state to not active and stop log files analysis
                EveCallSettings.isActive = false;
                refreshUIBroadcastButton(false);
                //stop log files analysis                
                timerCombatLog.Stop();
                timerLogFilesUpdate.Stop();
            }
        }

        private void buttonEditItem_Click(object sender, EventArgs e)
        {
            //Update item 
            int selectedIndex = checkedListBoxItems.SelectedIndex;
            if (selectedIndex >= 0)
            {
                if (formWatchItem.Created)
                {
                    formItem.isCloning = false;
                    formItem.isUpdating = true;
                    formItem.itemValues.title = EveCallSettings.itemList[selectedIndex].title;
                    formItem.itemValues.slackActive = EveCallSettings.itemList[selectedIndex].slackActive;
                    formItem.itemValues.slackWebhookUrl = EveCallSettings.itemList[selectedIndex].slackWebhookUrl;
                    formItem.itemValues.discordActive = EveCallSettings.itemList[selectedIndex].discordActive;
                    formItem.itemValues.discordWebhookUrl = EveCallSettings.itemList[selectedIndex].discordWebhookUrl;
                    formItem.itemValues.characterName = EveCallSettings.itemList[selectedIndex].characterName;
                    DialogResult result = formWatchItem.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        //update values in the list
                        EveCallSettings.itemList[selectedIndex].title = formItem.itemValues.title;
                        EveCallSettings.itemList[selectedIndex].slackActive = formItem.itemValues.slackActive;
                        EveCallSettings.itemList[selectedIndex].slackWebhookUrl = formItem.itemValues.slackWebhookUrl;
                        EveCallSettings.itemList[selectedIndex].discordActive = formItem.itemValues.discordActive;
                        EveCallSettings.itemList[selectedIndex].discordWebhookUrl = formItem.itemValues.discordWebhookUrl;
                        EveCallSettings.itemList[selectedIndex].characterName = formItem.itemValues.characterName;

                        //refresh ui
                        refreshCheckedListBox();
                        //recreate xml
                        EveCallSettings.CreateXML();
                        //update UI                    
                        refreshUIButtons();
                    }
                }
                else
                {
                    formWatchItem = new formItem();
                    formItem.isCloning = false;
                    formItem.isUpdating = true;
                    formItem.itemValues.title = EveCallSettings.itemList[selectedIndex].title;
                    formItem.itemValues.slackActive = EveCallSettings.itemList[selectedIndex].slackActive;
                    formItem.itemValues.slackWebhookUrl = EveCallSettings.itemList[selectedIndex].slackWebhookUrl;
                    formItem.itemValues.discordActive = EveCallSettings.itemList[selectedIndex].discordActive;
                    formItem.itemValues.discordWebhookUrl = EveCallSettings.itemList[selectedIndex].discordWebhookUrl;
                    formItem.itemValues.characterName = EveCallSettings.itemList[selectedIndex].characterName;
                    DialogResult result = formWatchItem.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        //update values in the list
                        EveCallSettings.itemList[selectedIndex].title = formItem.itemValues.title;
                        EveCallSettings.itemList[selectedIndex].slackActive = formItem.itemValues.slackActive;
                        EveCallSettings.itemList[selectedIndex].slackWebhookUrl = formItem.itemValues.slackWebhookUrl;
                        EveCallSettings.itemList[selectedIndex].discordActive = formItem.itemValues.discordActive;
                        EveCallSettings.itemList[selectedIndex].discordWebhookUrl = formItem.itemValues.discordWebhookUrl;
                        EveCallSettings.itemList[selectedIndex].characterName = formItem.itemValues.characterName;

                        //refresh ui
                        refreshCheckedListBox();
                        //recreate xml
                        EveCallSettings.CreateXML();
                        //update UI                    
                        refreshUIButtons();
                    }
                }
            }

        }

        private void buttonMoveItemUp_Click(object sender, EventArgs e)
        {
            //!!! todo check position (button is disabled for an invalid value, check anyways)
            //move up
            int selectedIndex = checkedListBoxItems.SelectedIndex;
            watchItem tempWatchItem = EveCallSettings.itemList[selectedIndex];
            EveCallSettings.itemList.RemoveAt(selectedIndex);
            EveCallSettings.itemList.Insert((selectedIndex-1), tempWatchItem);
            EveCallSettings.CreateXML();
            refreshCheckedListBox();
            checkedListBoxItems.SelectedIndex = (selectedIndex - 1);
            refreshUIButtons();
        }

        private void buttonMoveItemDown_Click(object sender, EventArgs e)
        {
            //!!! todo check position (button is disabled for an invalid value, check anyways)
            //move down
            int selectedIndex = checkedListBoxItems.SelectedIndex;
            watchItem tempWatchItem = EveCallSettings.itemList[selectedIndex];
            EveCallSettings.itemList.RemoveAt(selectedIndex);
            EveCallSettings.itemList.Insert((selectedIndex+1), tempWatchItem);
            EveCallSettings.CreateXML();
            refreshCheckedListBox();
            checkedListBoxItems.SelectedIndex = (selectedIndex+1);
            refreshUIButtons();
        }

        private void formMain_Shown(object sender, EventArgs e)
        {            
            //initialize settings file
            //if doesnt exist, create new
            //if exist, get values and initialize components
            checkedListBoxItems.Items.Clear();
            if (File.Exists(EveCallSettings.xmlFileName))
            {
                //load settings from configuration files
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(EveCallSettings.xmlFileName);
                XmlNode rootNode = xmlDoc.DocumentElement;
                EveCallSettings.path = rootNode.Attributes["path"].Value;
                folderBrowserDialog1.SelectedPath = EveCallSettings.path;
                if (EveCallSettings.path.Length > 0)
                {
                    textBoxPath.Text = EveCallSettings.path;
                    labelPathInfo.Text = "✓ directory path is defined";                    
                }
                else
                {
                    textBoxPath.Text = "Path to your Eve online combat log directory";
                    labelPathInfo.Text = "⚠ directory path is not defined";
                }
                

                EveCallSettings.combatLogEntryInterval = int.Parse(rootNode.Attributes["combatLogEntryInterval"].Value);
                EveCallSettings.combatLogFileInterval = int.Parse(rootNode.Attributes["combatLogFileInterval"].Value);
                EveCallSettings.combatBroadcastDelay = int.Parse(rootNode.Attributes["combatBroadcastDelay"].Value);
                EveCallSettings.fileCountWarning = int.Parse(rootNode.Attributes["fileCountWarning"].Value);

                //exception block to prevent invalid path
                try
                {
                    //check possible combat log files count
                    bool combatLogFilesExist = false;
                    string[] recentFilesList = Directory.GetFiles(EveCallSettings.path, "*.txt");
                    int files_count = recentFilesList.Count();
                    for (int i = 0; i < files_count; i++)
                    {
                        //read file
                        string[] fileLines = File.ReadAllLines(recentFilesList[i]);
                        //find Listener: substring to indicate we are working with a log file for specific user
                        if (Regex.IsMatch(fileLines[2], "Listener:*"))
                        {
                            combatLogFilesExist = true;
                            break;
                        }
                    }

                    //check files count in the folder                
                    if ((files_count > EveCallSettings.fileCountWarning) && (combatLogFilesExist == true))
                    {
                        //open location in windows explorer so user can delete some log files manually
                        DialogResult result = MessageBox.Show("Your selected combat log directory contains " + files_count.ToString() + " files. You might want to manually delete them to prevent EveCall lags. Click OK to open the location in windows explorer. (Go to File->Settings if you want to change the limit for this warning message) ", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        if (result == DialogResult.OK)
                        {
                            Process.Start(EveCallSettings.path);
                        }
                    }

                    labelPathInfo.Text = "✓ directory path is defined" + " (" + files_count.ToString() + " log files found)";
                }
                catch
                {
                    //!!! todo - any action if path is not valid here?
                }
                

                XmlNodeList itemNodes = xmlDoc.SelectNodes("//watchItem");
                foreach (XmlNode itemNode in itemNodes)
                {
                    //get nodes
                    XmlNode titleNode = itemNode.SelectSingleNode("title");                    
                    XmlNode slackActiveNode = itemNode.SelectSingleNode("slackActive");
                    XmlNode slackWebhookUrlNode = itemNode.SelectSingleNode("slackWebhookUrl");
                    XmlNode discordActiveNode = itemNode.SelectSingleNode("discordActive");
                    XmlNode discordWebhookUrlNode = itemNode.SelectSingleNode("discordWebhookUrl");
                    XmlNode characterNameNode = itemNode.SelectSingleNode("characterName");
                    XmlNode isActiveNode = itemNode.SelectSingleNode("isActive");
                    //create object in the list
                    EveCallSettings.itemList.Add(new watchItem
                    {
                        title = titleNode.InnerText,                        
                        slackActive = int.Parse(slackActiveNode.InnerText),
                        slackWebhookUrl = slackWebhookUrlNode.InnerText,
                        discordActive = int.Parse(discordActiveNode.InnerText),
                        discordWebhookUrl = discordWebhookUrlNode.InnerText,
                        characterName = characterNameNode.InnerText,                        
                        lastTimestamp = DateTime.UtcNow,
                        isActive = int.Parse(isActiveNode.InnerText)
                    });
                    //add item to the listbox
                    //!!! do we need additional informations? like setup is invalid, not finished, etc
                    checkedListBoxItems.Items.Add(titleNode.InnerText);
                }
            }

            //set toggle button state after initialization
            if (EveCallSettings.isActive)
            {
                refreshUIBroadcastButton(true);                
            }
            else
            {
                refreshUIBroadcastButton(false);
            }

            //initialize UI - buttons
            //!!! if everything is ok
            buttonNewItem.Enabled = true;
            //update check states in listbox
            for (int i = 0; i < checkedListBoxItems.Items.Count; i++)
            {
                if (EveCallSettings.itemList[i].isActive >= 1)
                {
                    checkedListBoxItems.SetItemChecked(i, true);
                }
                else
                {
                    checkedListBoxItems.SetItemChecked(i, false);
                }
            }

            if (EveCallSettings.path.Length > 0)
            {
                //get 50 most recent files                
                //create list of files that will be used
                FileInfo[] recentFilesList = Directory.GetFiles(EveCallSettings.path).Select(x => new FileInfo(x)).OrderByDescending(x => x.LastWriteTimeUtc).Take(50).ToArray();
                for (int i = 0; i < recentFilesList.Count(); i++)
                {
                    //process only files in last 24h. (Eve Online downtime, the file must be modified in last 24 to be usable for EveCall
                    if (recentFilesList[i].LastWriteTimeUtc > DateTime.UtcNow.AddHours(-25))
                    {
                        //read file
                        string[] fileLines = File.ReadAllLines(recentFilesList[i].FullName);
                        //find Listener: substring to indicate we are working with a log file for specific user
                        if (System.Text.RegularExpressions.Regex.IsMatch(fileLines[2], "Listener:*"))
                        {
                            //get character name from third line (Listener: bla bla bla is always at this position)
                            string characterName = fileLines[2].Substring(12);
                            bool characterNameAlreadyExists = false;                            
                            //check if the file for a specific user is already remembered. 
                            //only most recent file for a specific character is relevant
                            //we can skip older files
                            for (int j = 0; j < EveCallSettings.fileList.Count(); j++)
                            {
                                //compare character names
                                if (characterName == EveCallSettings.fileList[j].characterName)
                                {
                                    //we already have the most recent file for this character name
                                    //we can finish the loop
                                    characterNameAlreadyExists = true;
                                    break;
                                }
                            }
                            //we didnt find character name yet. we can add new item to the buffer 
                            if (characterNameAlreadyExists == false)
                            {
                                EveCallSettings.fileList.Add(new singleFile
                                {
                                    characterName = characterName,
                                    fileName = recentFilesList[i].FullName,
                                    lastTimestamp = recentFilesList[i].LastWriteTimeUtc,
                                    lastPlayerLocation = ""
                                });
                            }
                        }
                    }
                }

                //start combat log check if any settings available
                //!!!
                if (EveCallSettings.isActive)
                {
                    timerLogFilesUpdate.Start();
                    timerCombatLog.Start();
                }
            }
            EveCallSettings.isInitializationDone = true;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //quit appalication
            System.Windows.Forms.Application.Exit();            
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //show about window
            formAbout.ShowDialog();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //show settings window
            formSettings.settingsValues.combatLogEntryInterval = EveCallSettings.combatLogEntryInterval;
            formSettings.settingsValues.combatLogFileInterval = EveCallSettings.combatLogFileInterval;
            formSettings.settingsValues.combatBroadcastDelay = EveCallSettings.combatBroadcastDelay;
            formSettings.settingsValues.fileCountWarning = EveCallSettings.fileCountWarning;

            DialogResult result = formSettings.ShowDialog();
            if (result == DialogResult.OK)
            {
                //save settings
                EveCallSettings.combatLogEntryInterval = formSettings.settingsValues.combatLogEntryInterval;
                EveCallSettings.combatLogFileInterval = formSettings.settingsValues.combatLogFileInterval;
                EveCallSettings.combatBroadcastDelay = formSettings.settingsValues.combatBroadcastDelay;
                EveCallSettings.fileCountWarning = formSettings.settingsValues.fileCountWarning;

                EveCallSettings.CreateXML();

                //app active doenst matter => set state to not active and stop log files analysis
                EveCallSettings.isActive = false;
                refreshUIBroadcastButton(false);
                //stop log files analysis                
                timerCombatLog.Stop();
                timerLogFilesUpdate.Stop();
            }                
        }

        private void textBoxPath_TextChanged(object sender, EventArgs e)
        {
            //define path, save as object attribute
            EveCallSettings.path = textBoxPath.Text;
        }

        private void formMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //minimize to tray instead closing the application
            if (e.CloseReason == CloseReason.UserClosing)
            {
                notifyIcon1.Visible = true;
                this.ShowInTaskbar = false;
                this.Hide();
                e.Cancel = true;
            }            
        }

        private void notifyIcon1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //MethodInfo mi = typeof(NotifyIcon).GetMethod("ShowContextMenu", BindingFlags.Instance | BindingFlags.NonPublic);
                //mi.Invoke(notifyIcon1, null);

                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
                this.Show();
            }
        }

        private void itemToolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            //quit appalication via tray icon context menu
            System.Windows.Forms.Application.Exit();
        }

        private void itemToolStripMenuItemShow_Click(object sender, EventArgs e)
        {
            //show application via tray icon context menu
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            this.Show();
        }

        private void itemToolStripMenuItemToggleActive_Click(object sender, EventArgs e)
        {            
            //check number of items to watch
            //if 0, disable button and show warning message
            if (EveCallSettings.itemList.Count <= 0)
            {
                //show application via tray icon context menu
                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
                this.Show();

                EveCallSettings.isActive = false;
                refreshUIBroadcastButton(false);
                MessageBox.Show("Activation is not possible. You need to add at least one item. (Click on the 'new' button)", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //check if path is defined properly
            if (EveCallSettings.path.Length <= 0)
            {
                //show application via tray icon context menu
                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
                this.Show();

                EveCallSettings.isActive = false;
                refreshUIBroadcastButton(false);
                MessageBox.Show("Activation is not possible. You need to define the path to your combat log directory. (Click on the '...' button below)", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //check if path is valid
            try
            {
                int files_count = Directory.GetFiles(EveCallSettings.path).Count();
            }
            catch
            {
                //show application via tray icon context menu
                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
                this.Show();

                EveCallSettings.isActive = false;
                refreshUIBroadcastButton(false);
                MessageBox.Show("Activation is not possible. You need to define a correct path to your combat log directory. (Click on the '...' button below)", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //0 checked items
            if (checkedListBoxItems.CheckedItems.Count <= 0)
            {
                //show application via tray icon context menu
                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
                this.Show();

                EveCallSettings.isActive = false;
                refreshUIBroadcastButton(false);
                MessageBox.Show("Activation is not possible. Please mark at least one item as checked!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //change state
            if (EveCallSettings.isActive)
            {
                //app is active => set state to not active and stop log files analysis
                EveCallSettings.isActive = false;
                refreshUIBroadcastButton(false);
                //stop log files analysis timers                
                timerCombatLog.Stop();
                timerLogFilesUpdate.Stop();
            }
            else
            {
                //app is not active => set state to active and start log files analysis
                timerCombatLog.Stop();
                timerLogFilesUpdate.Stop();
                timerCombatLog.Interval = EveCallSettings.combatLogEntryInterval * 1000;
                timerLogFilesUpdate.Interval = EveCallSettings.combatLogFileInterval * 1000;

                EveCallSettings.isActive = true;
                refreshUIBroadcastButton(true);

                if (EveCallSettings.path.Length > 0)
                {
                    //remove actual remembered files
                    EveCallSettings.fileList.Clear();

                    //get 50 most recent files                
                    //create list of files that will be used
                    FileInfo[] recentFilesList = Directory.GetFiles(EveCallSettings.path).Select(x => new FileInfo(x)).OrderByDescending(x => x.LastWriteTimeUtc).Take(50).ToArray();
                    for (int i = 0; i < recentFilesList.Count(); i++)
                    {
                        //process only files in last 24h. (Eve Online downtime, the file must be modified in last 24 to be usable for EveCall
                        if (recentFilesList[i].LastWriteTimeUtc > DateTime.UtcNow.AddHours(-25))
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
                                //we can skip older files
                                for (int j = 0; j < EveCallSettings.fileList.Count(); j++)
                                {
                                    //compare character names
                                    if (characterName == EveCallSettings.fileList[j].characterName)
                                    {
                                        //we already have the most recent file for this character name
                                        //we can finish the loop
                                        characterNameAlreadyExists = true;
                                        break;
                                    }
                                }
                                //we didnt find character name yet. we can add new item to the buffer 
                                if (characterNameAlreadyExists == false)
                                {
                                    EveCallSettings.fileList.Add(new singleFile
                                    {
                                        characterName = characterName,
                                        fileName = recentFilesList[i].FullName,
                                        lastTimestamp = recentFilesList[i].LastWriteTimeUtc,
                                        lastPlayerLocation = ""
                                    });
                                }
                            }
                        }
                    }

                    //start combat log check if any settings available
                    //!!!
                    if (EveCallSettings.isActive)
                    {
                        //reactivate timers                        
                        timerLogFilesUpdate.Stop();
                        timerLogFilesUpdate.Start();
                        timerCombatLog.Stop();
                        timerCombatLog.Start();
                    }
                }
            }
        }

        private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.pvp.tools/evecall");
        }
    }
}
