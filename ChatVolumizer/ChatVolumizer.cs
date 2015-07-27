using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using ChatGenerator;

namespace ChatVolumizer
{
    public partial class ChatVolumizer : Form
    {
        private const int concurrencyLimit = 100;
        private const int threadDelayMin = 30000;
        private const int threadDelayMax = 300000;
        private const int volumizingLimit = 100;
        private const string widgetTitle = "TestText";

        #region MESSAGES
        private const string msg_init = "----- ChatVolumizer initialization has started.\r\n";
        private const string msg_init_finished = "----- ChatVolumizer initialization has successfully finished.\r\n";
        private const string msg_err_init_failed = "----- ERROR: ChatVolumizer initialization has failed.\r\n";

        private const string msg_start_btn = ">>>>> Start button: processing has started.\r\n";
        private const string msg_start_btn_finished = "<<<<< Start button: processing has finished.\r\n";

        private const string msg_start_param = "----- Checking user parameters before generation starts.\r\n";
        private const string msg_start_param_finished = "----- User parameters are fine.\r\n";
        private const string msg_wrn_start_param_failed = "----- WARNING: user parameters were incorrect. Using default values.\r\n";

        private const string msg_stop_btn = ">>>>> Stop button: processing has started.\r\n";
        private const string msg_stop_btn_finished = ">>>>> Stop button: processing has finished.\r\n";

        private const string msg_thread_start = "----- Starting new worker thread: ";
        private const string msg_thread_finished = "----- Thread worker method has succesfully finished.\r\n";
        private const string msg_err_thread_failed = "----- ERROR: Thread worker method has failed.\r\n";
        #endregion

        private bool forceClosing;
        private bool useThreading;
        private int concurrentChats;
        private int threadDelay;
        private int volumizingCount; 
        private List<ChatGeneratorClass> listOfChats;
        private List<Thread> listOfThreads;
        private string siteId;
        private string volumedMsg;
        private StringBuilder sbLog;
        

        public ChatVolumizer()
        {
            listOfChats = new List<ChatGeneratorClass>();
            listOfThreads = new List<Thread>();

            concurrentChats = 1;
            forceClosing = false;
            sbLog = new StringBuilder();
            siteId = "";
            threadDelay = 60000;
            useThreading = false;
            volumedMsg = null;
            volumizingCount = 10;

            InitializeComponent();
            //LogAddLine(IDT_LOG, sbLog, msg_init);
            try
            {
                AdditionalInitialization();
                //LogAddLine(IDT_LOG, sbLog, msg_init_finished);
            }
            catch (Exception ex)
            {
                string err = "EXCEPTION: " + ex.Message;
                //LogAddLine(IDT_LOG, sbLog, msg_err_init_failed + err);
            }
        }

        private void AdditionalInitialization()
        {
            lblChatsNotifier.Text = "* If number of chats is not set it'll be set to 1 by default";
            lblThreadingNotifier.Text = "* If checked chats will be generated simultaneously, otherwise chats will be sequential\r\n" +
                "Delay sets the gap in miliseconds between threads being started";
            IDT_CHATCOUNT.Text = concurrentChats.ToString();
            IDT_DELAY.Text = threadDelay.ToString();
            IDT_VOLUMECOUNT.Text = volumizingCount.ToString();

            volumedMsg = File.ReadAllText("SmallMsg_512.txt");
        }

        private bool IsTextFieldValid(string Value)
        {
            if (Value != "" && Value != null) return true;
            else return false;
        }        

        private void EnableThreadingFunctionality(bool isEnabled)
        {
            IDCB_THREADING.Enabled = isEnabled;
        }

        private void EnableForceClosing(bool isEnabled)
        {
            IDCB_FORCECLOSE.Enabled = isEnabled;
        }

        private void EnableStartButton(bool isEnabled)
        {
            IDB_START.Enabled = isEnabled;
        }

        private static void LogAddLine(TextBox tb, StringBuilder sb, string line)
        {
            sb.Append(line);
            //tb.BeginInvoke((MethodInvoker)(() => tb.Text = sb.ToString()));
            tb.Text = sb.ToString();
            tb.Update();
        }

        private void HardWorkingMethod(ChatGeneratorClass chatGen, string siteId, string userName, string volumedMsg, int volumizingCount)
        {
            try
            {
                //string line = "----- Thread name: " + threadName + ".\r\n";
                //LogAddLine(IDT_LOG, sbLog, msg_thread_start + line);

                chatGen.GenerateClientChat(siteId, widgetTitle, userName, "Hello, this is my message!!!", volumedMsg, volumizingCount);
                if (forceClosing) chatGen.GarbageCleaner();

                //LogAddLine(IDT_LOG, sbLog, msg_thread_finished + line);
            }
            catch (Exception ex)
            {
                string err = "EXCEPTION: " + ex.Message;
                //LogAddLine(IDT_LOG, sbLog, msg_err_thread_failed + err);
            }
        }

        private void IDB_START_Click(object sender, EventArgs e)
        {
            LogAddLine(IDT_LOG, sbLog, msg_start_btn);
            if (IsTextFieldValid(IDT_SITEID.Text))
            {
                EnableThreadingFunctionality(false);
                EnableForceClosing(false);
                EnableStartButton(false);
                try
                {
                    LogAddLine(IDT_LOG, sbLog, msg_start_param);
                    siteId = IDT_SITEID.Text;
                    int count = Convert.ToInt32(IDT_CHATCOUNT.Text);
                    int count1 = Convert.ToInt32(IDT_VOLUMECOUNT.Text);
                    int delay = Convert.ToInt32(IDT_DELAY.Text);
                    if (count > 1 && count < concurrencyLimit) concurrentChats = count;
                    if (count1 > 1 && count1 < volumizingLimit) volumizingCount = count1;
                    if (delay > threadDelayMin && delay < threadDelayMax) threadDelay = delay;
                    LogAddLine(IDT_LOG, sbLog, msg_start_param_finished);
                }
                catch (Exception ex)
                {
                    string err = "EXCEPTION: " + ex.Message;
                    LogAddLine(IDT_LOG, sbLog, msg_wrn_start_param_failed + err);
                }

                if (!useThreading)
                {
                    for (int i = 0; i < concurrentChats; i++)
                    {
                        string userName = "TestUser__" + i.ToString();
                        ChatGeneratorClass chatGen = new ChatGeneratorClass();

                        listOfChats.Add(chatGen);

                        chatGen.GenerateClientChat(siteId, widgetTitle, userName, "Hello, this is my message!!!", volumedMsg, volumizingCount);
                    }
                }
                else
                {
                    for (int i = 0; i < concurrentChats; i++)
                    {
                        string userName = "TestUser__" + i.ToString();
                        string thName = "Worker__" + i.ToString(); 
                        ChatGeneratorClass chatGen = new ChatGeneratorClass();
                        Thread th = new Thread(() => HardWorkingMethod(chatGen, siteId, userName, volumedMsg, volumizingCount));

                        if (!forceClosing) listOfChats.Add(chatGen);
                        listOfThreads.Add(th);

                        th.Name = thName;
                        LogAddLine(IDT_LOG, sbLog, msg_thread_start + thName + ".\r\n");
                        th.Start();
                        LogAddLine(IDT_LOG, sbLog, "----- Main thread sleeps for " + threadDelay + "ms.\r\n");
                        Thread.Sleep(threadDelay);
                    }
                }
            }
            LogAddLine(IDT_LOG, sbLog, msg_start_btn_finished);
        }

        private void IDB_STOP_Click(object sender, EventArgs e)
        {
            LogAddLine(IDT_LOG, sbLog, msg_stop_btn);
            if (!useThreading)
            {
                foreach (ChatGeneratorClass gen in listOfChats)
                {
                    gen.GarbageCleaner();
                }
                listOfChats = null;
                listOfChats = new List<ChatGeneratorClass>();
            }
            else
            {
                foreach (ChatGeneratorClass gen in listOfChats)
                {
                    gen.GarbageCleaner();
                }
                foreach (Thread th in listOfThreads)
                {
                    th.Abort();
                }
                listOfChats = null;
                listOfThreads = null;
                listOfChats = new List<ChatGeneratorClass>();
                listOfThreads = new List<Thread>();
            }
            EnableThreadingFunctionality(true);
            EnableForceClosing(true);
            EnableStartButton(true);
            LogAddLine(IDT_LOG, sbLog, msg_stop_btn_finished);
        }

        private void IDCB_THREADING_CheckedChanged(object sender, EventArgs e)
        {
            if (IDCB_THREADING.Checked) useThreading = true;
            else useThreading = false;
        }

        private void IDCB_FORCECLOSE_CheckedChanged(object sender, EventArgs e)
        {
            if (IDCB_FORCECLOSE.Checked) forceClosing = true;
            else forceClosing = false;
        }
    }
}
