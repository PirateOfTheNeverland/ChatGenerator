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
        private const int BOOSTMINDURATION = 300000;
        private const int BOOSTTICK = 10000;
        private const int CONCURRENCYLIMIT = 100;
        private const int THREADDELAYMIN = 100;
        private const int THREADDELAYMAX = 300000;
        private const int TIMERMINDURATION = 60000;
        private const int TIMERMAXDURATION = 2000000000;
        private const int VOLUMIZINGLIMIT = 1000;
        private const string widgetTitle = "TestText";

        #region MESSAGES
        private const string msg_init = "----- ChatVolumizer initialization has started.\r\n";
        private const string msg_init_finished = "----- ChatVolumizer initialization has successfully finished.\r\n";
        private const string msg_err_init_failed = "----- ERROR: ChatVolumizer initialization has failed.\r\n";

        private const string msg_start_btn = ">>>>> Start button: processing has started.\r\n";
        private const string msg_start_btn_finished = "<<<<< Start button: processing has finished.\r\n";

        private const string msg_set_common = "----- Applying common settings.\r\n";
        private const string msg_set_common_finished = "----- Common settings applied.\r\n";
        private const string msg_set_common_ex = "Site ID value is incorrect.\r\n";

        private const string msg_set_msg = "----- Applying volumizing message settings.\r\n";
        private const string msg_set_msg_finished = "----- Volumizing message settings applied.\r\n";
        private const string msg_set_msg_ex = "Volumizing count value is incorrect.\r\n";

        private const string msg_set_steady = "----- Applying steady load settings.\r\n";
        private const string msg_set_steady_finished = "----- Steady load settings applied.\r\n";
        private const string msg_set_steady_ex = "Steady load settings values are incorrect.\r\n";

        private const string msg_set_boost = "----- Applying boosted load settings.\r\n";
        private const string msg_set_boost_finished = "----- Boosted load settings applied.\r\n";
        private const string msg_set_boost_ex = "Steady load settings values are incorrect.\r\n";

        private const string msg_stop_btn = ">>>>> Stop button: processing has started.\r\n";
        private const string msg_stop_btn_finished = ">>>>> Stop button: processing has finished.\r\n";

        private const string msg_thread_start = "----- Starting new worker thread: ";
        private const string msg_thread_finished = "----- Thread worker method has succesfully finished.\r\n";
        private const string msg_err_thread_failed = "----- ERROR: Thread worker method has failed.\r\n";
        #endregion

        private enum VolumedMessageType {Minimal, Fat512b, XtraFat1kb};

        <summary>
        private bool gl_ForceClosing;
        private bool gl_SteadyLoadProfile;
        private bool gl_TimeBasedLoad;
        private bool gl_TimerIsAlive;        
        private bool gl_UseThreading;
        private int gl_BoostCurrentDelay;
        private int gl_BoostDelayStart;
        private int gl_BoostDelayFinish;
        private int gl_BoostDuration;
        private int gl_ConcurrentChats;
        private int gl_SteadyThreadDelay;
        private int gl_TimerDuration;
        private int gl_VolumizingCount; 
        private List<ChatGeneratorClass> gl_ListOfChats;
        private List<StringBuilder> gl_ListOfLocalLogs;
        private List<Thread> gl_ListOfThreads;
        private string gl_SiteId;
        private string gl_VolumedMsg;
        private string gl_WidgetTitle;
        private StringBuilder gl_SbLog;
        private VolumedMessageType gl_VolumedMsgType;
        

        public ChatVolumizer()
        {
            gl_ListOfChats = new List<ChatGeneratorClass>();
            gl_ListOfLocalLogs = new List<StringBuilder>();
            gl_ListOfThreads = new List<Thread>();

            gl_BoostCurrentDelay = 0;
            gl_BoostDelayStart = 0;
            gl_BoostDelayFinish = 0;
            gl_BoostDuration = 0;
            gl_TimerDuration = 0;

            gl_ForceClosing = true;
            gl_SteadyLoadProfile = true;
            gl_TimeBasedLoad = false;
            gl_TimerIsAlive = false;
            gl_UseThreading = true;            
            
            gl_SbLog = new StringBuilder();
            gl_SiteId = "";
            gl_VolumedMsg = null;            

            InitializeComponent();            
            AdditionalInitialization();
        }

        private void AdditionalInitialization()
        {
            lblBoostSettingsHint.Text = "  Set initial delay between threads, set final delay between threads\n  Then set duration";
            lblCommonSettingsHint.Text = "  Set site ID then set keep-alive option\n  If checked chats will be automatically closed. Otherwise generated clients will stay alive.";
            lblSteadySettingsHint.Text = "  Choose generation limited by number of generated chats or limited by time\n  Then set delay between threads' initialization";

            gl_ConcurrentChats = 1;
            IDT_CHATCOUNT.Text = gl_ConcurrentChats.ToString();

            gl_TimerDuration = TIMERMINDURATION;
            IDT_TIMECOUNT.Text = TIMERMINDURATION.ToString();

            gl_SteadyThreadDelay = 30000;
            IDT_DELAY.Text = gl_SteadyThreadDelay.ToString();

            gl_BoostDelayStart = 30000;
            IDT_BOOST_START.Text = gl_BoostDelayStart.ToString();
            gl_BoostDelayFinish = 5000;
            IDT_BOOST_FINISH.Text = gl_BoostDelayFinish.ToString();
            gl_BoostDuration = 600000;
            IDT_BOOST_LIFETIME.Text = gl_BoostDuration.ToString();

            gl_VolumizingCount = 10;
            IDT_VOLUMECOUNT.Text = gl_VolumizingCount.ToString();

            // UseThreading is always ON!
            IDCB_THREADING.Visible = false;
            //volumedMsg = File.ReadAllText("SmallMsg_512.txt");
        }

        private bool IsTextFieldValid(string Value)
        {
            if (Value != "" && Value != null && !String.IsNullOrWhiteSpace(Value)) return true;
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

        private void EnableLoadProfileGroup(bool isEnabled)
        {
            GB_LOADPROFILE.Enabled = isEnabled;
        }

        private void EnableSaveLogButton(bool isEnabled)
        {
            IDB_SAVELOG.Enabled = isEnabled;
        }

        private void EnableUI(bool isEnabled)
        {
            EnableThreadingFunctionality(isEnabled);
            EnableForceClosing(isEnabled);
            EnableStartButton(isEnabled);
            EnableLoadProfileGroup(isEnabled);
            EnableSaveLogButton(isEnabled);
        }

        private void SetVolumedMessage()
        {
            try
            {
                switch (gl_VolumedMsgType)
                {
                    case VolumedMessageType.XtraFat1kb:
                        gl_VolumedMsg = File.ReadAllText("FatMsg_1024.txt");
                        break;

                    case VolumedMessageType.Fat512b:
                        gl_VolumedMsg = File.ReadAllText("SmallMsg_512.txt");
                        break;

                    case VolumedMessageType.Minimal:
                        gl_VolumedMsg = DateTime.Now.ToString() + "_";
                        break;

                    default:
                        break;
                }
            }
            catch
            {
                gl_VolumedMsg = "Default_";
            }
        }

        private static void LogAddLine(TextBox tb, StringBuilder sb, string line)
        {
            sb.Append(line);
            //tb.BeginInvoke((MethodInvoker)(() => tb.Text = sb.ToString()));
            tb.Text = sb.ToString();
            tb.Update();
        }

        private void ApplyCommonSettings()
        {
            LogAddLine(IDT_LOG, gl_SbLog, msg_set_common);
            if (!IsTextFieldValid(IDT_SITEID.Text)) throw new Exception(msg_set_common_ex);
            gl_SiteId = IDT_SITEID.Text;

            string line = "SiteID: " + gl_SiteId +
                "\r\nUse threading: " + gl_UseThreading.ToString() +
                "\r\nForce close: " + gl_ForceClosing.ToString() + "\r\n";
            LogAddLine(IDT_LOG, gl_SbLog, line + msg_set_common_finished + "\r\n");
        }

        private void ApplyVolumizingSettings()
        {
            LogAddLine(IDT_LOG, gl_SbLog, msg_set_msg);
            if (!IsTextFieldValid(IDT_VOLUMECOUNT.Text)) throw new Exception(msg_set_msg_ex);

            int volumeCount = Convert.ToInt32(IDT_VOLUMECOUNT.Text);
            if (volumeCount >= 1 && volumeCount <= VOLUMIZINGLIMIT) gl_VolumizingCount = volumeCount;

            string line = "Messages in one chat: " + gl_VolumizingCount.ToString() + "\r\n";
            LogAddLine(IDT_LOG, gl_SbLog, line + msg_set_msg_finished + "\r\n");
        }

        private void ApplySteadyLoadSettings()
        {
            try
            {
                LogAddLine(IDT_LOG, gl_SbLog, msg_set_steady);
                int chatCount = 1;
                int timer = TIMERMINDURATION;
                int delay = THREADDELAYMIN;
                string line = "";

                delay = Convert.ToInt32(IDT_DELAY.Text);
                if (gl_TimeBasedLoad) timer = Convert.ToInt32(IDT_TIMECOUNT.Text);
                else chatCount = Convert.ToInt32(IDT_CHATCOUNT.Text);                

                if (delay >= THREADDELAYMIN && delay <= THREADDELAYMAX) gl_SteadyThreadDelay = delay;
                if (chatCount >= 1 && chatCount <= CONCURRENCYLIMIT) gl_ConcurrentChats = chatCount;                
                if (timer >= TIMERMINDURATION && timer <= TIMERMAXDURATION) gl_TimerDuration = timer;

                if (gl_TimeBasedLoad) line = "Time based load: " + gl_TimeBasedLoad.ToString() +
                    "\r\nTimer duration: " + gl_TimerDuration.ToString() +
                    "\r\nDelay between threads: " + gl_SteadyThreadDelay.ToString() + "\r\n";
                else line = "Time based load: " + gl_TimeBasedLoad.ToString() +
                    "\r\nConcurrent chats: " + gl_ConcurrentChats.ToString() +
                    "\r\nDelay between threads: " + gl_SteadyThreadDelay.ToString() + "\r\n";
                
                LogAddLine(IDT_LOG, gl_SbLog, line + msg_set_steady_finished);
            }
            catch
            {
                throw new Exception(msg_set_steady_ex);
            }
        }

        private void ApplyBoostLoadSettings()
        {
            try
            {
                LogAddLine(IDT_LOG, gl_SbLog, msg_set_boost);
                int boostDelayStart = 30000;
                int boostDelayFinish = 5000;
                int boostDuration = BOOSTMINDURATION;
                string line = "";

                boostDelayStart = Convert.ToInt32(IDT_BOOST_START.Text);
                boostDelayFinish = Convert.ToInt32(IDT_BOOST_FINISH.Text);
                boostDuration = Convert.ToInt32(IDT_BOOST_LIFETIME.Text);

                if (boostDelayStart < boostDuration
                    && boostDelayStart >= THREADDELAYMIN
                    && boostDelayStart <= THREADDELAYMAX) gl_BoostDelayStart = boostDelayStart;
                else throw new Exception();
                if (boostDelayFinish < boostDelayStart && boostDelayFinish >= THREADDELAYMIN) gl_BoostDelayFinish = boostDelayFinish;
                else throw new Exception();
                if (boostDuration >= TIMERMINDURATION && boostDuration <= TIMERMAXDURATION) gl_BoostDuration = boostDuration;

                line = "Delay on start: " + gl_BoostDelayStart.ToString() +
                    "\r\nDelay on finish: " + gl_BoostDelayFinish.ToString() +
                    "\r\nBoost duration: " + gl_BoostDuration.ToString() + "\r\n";
                LogAddLine(IDT_LOG, gl_SbLog, line + msg_set_boost_finished);
            }
            catch
            {
                throw new Exception(msg_set_boost_ex);
            }
        }

        // Worker Thread
        private void HardWorkingMethod(ChatGeneratorClass chatGen, 
            string siteId, 
            string userName, 
            string volumedMsg, 
            int volumizingCount, 
            StringBuilder sb,
            string threadName)
        {
            try
            {
                //string line = "----- Thread name: " + threadName + ".\r\n";
                //LogAddLine(IDT_LOG, sbLog, msg_thread_start + line);

                chatGen.GenerateClientChat(siteId, widgetTitle, userName, "Hello, this is my first message!!!", volumedMsg, volumizingCount, sb, threadName);
                if (gl_ForceClosing) chatGen.GarbageCleaner();

                //LogAddLine(IDT_LOG, sbLog, msg_thread_finished + line);
            }
            catch (Exception ex)
            {
                string err = "EXCEPTION: " + ex.Message;
                //LogAddLine(IDT_LOG, sbLog, msg_err_thread_failed + err);
            }
        }

        // Main Thread of consequential load profile
        private void ConsequentialMainThread()
        {
            for (int i = 0; i < gl_ConcurrentChats; i++)
            {
                string userName = "TestUser__" + i.ToString();
                StringBuilder sb_helper1 = new StringBuilder();
                ChatGeneratorClass chatGen = new ChatGeneratorClass();

                gl_ListOfChats.Add(chatGen);
                gl_ListOfLocalLogs.Add(sb_helper1);

                chatGen.GenerateClientChat(gl_SiteId, widgetTitle, userName, "CONSEQUENTIAL LOAD: first message!!!", gl_VolumedMsg, gl_VolumizingCount, sb_helper1, userName);
            }
        }

        // Main Thread for concurrent load profile
        private void ConcurrentMainThread()
        {
            for (int i = 0; i < gl_ConcurrentChats; i++)
            {
                string userName = "TestUser__" + i.ToString();
                string thName = "Worker__" + i.ToString();
                StringBuilder sb_helper2 = new StringBuilder();
                ChatGeneratorClass chatGen = new ChatGeneratorClass();

                SetVolumedMessage();

                Thread th = new Thread(() => HardWorkingMethod(chatGen, gl_SiteId, userName, gl_VolumedMsg, gl_VolumizingCount, sb_helper2, thName));

                if (!gl_ForceClosing) gl_ListOfChats.Add(chatGen);
                gl_ListOfLocalLogs.Add(sb_helper2);
                gl_ListOfThreads.Add(th);

                th.Name = thName;
                //LogAddLine(IDT_LOG, gl_SbLog, msg_thread_start + thName + ".\r\n");
                th.Start();
                //LogAddLine(IDT_LOG, gl_SbLog, "----- Main thread sleeps for " + gl_ThreadDelay + "ms.\r\n");
                Thread.Sleep(gl_SteadyThreadDelay);
            }
        }

        // Main Thread for time based load
        private void TimeBaseLoadMainThread()
        {
            int i = 0;
            while(gl_TimerIsAlive)
            {
                string userName = "TestUser__" + i.ToString();
                string thName = "Worker__" + i.ToString();
                StringBuilder sb_helper2 = new StringBuilder();
                ChatGeneratorClass chatGen = new ChatGeneratorClass();

                SetVolumedMessage();

                Thread th = new Thread(() => HardWorkingMethod(chatGen, gl_SiteId, userName, gl_VolumedMsg, gl_VolumizingCount, sb_helper2, thName));

                if (!gl_ForceClosing) gl_ListOfChats.Add(chatGen);
                gl_ListOfLocalLogs.Add(sb_helper2);
                gl_ListOfThreads.Add(th);

                th.Name = thName;
                th.Start();
                Thread.Sleep(gl_SteadyThreadDelay);
                i++;
            }
        }

        // Main Thread for boosted load
        private void BoostLoadMainThread()
        {
            int i = 0;
            while (gl_TimerIsAlive)
            {
                string userName = "TestUser__" + i.ToString();
                string thName = "Worker__" + i.ToString();
                StringBuilder sb_helper2 = new StringBuilder();
                ChatGeneratorClass chatGen = new ChatGeneratorClass();

                SetVolumedMessage();

                Thread th = new Thread(() => HardWorkingMethod(chatGen, gl_SiteId, userName, gl_VolumedMsg, gl_VolumizingCount, sb_helper2, thName));

                if (!gl_ForceClosing) gl_ListOfChats.Add(chatGen);
                gl_ListOfLocalLogs.Add(sb_helper2);
                gl_ListOfThreads.Add(th);

                th.Name = thName;
                th.Start();
                Thread.Sleep(gl_BoostCurrentDelay);
                i++;
            }
        }

        // Helper Thread for boosted load
        private void BoostLoadHelperThread(int boostStep)
        {
            while (gl_TimerIsAlive)
            {
                Thread.Sleep(BOOSTTICK);
                gl_BoostCurrentDelay -= boostStep;
            }
        }

        // Timer Thread
        private void TimerThread(int timeToWait)
        {
            System.Threading.Thread.Sleep(timeToWait);
            gl_TimerIsAlive = false;
        }

        private void IDB_START_Click(object sender, EventArgs e)
        {
            EnableUI(false);                
            try
            {
                ApplyCommonSettings();
                ApplyVolumizingSettings();

                if (!gl_UseThreading)
                {
                    Thread thCons = new Thread(() => ConsequentialMainThread());
                    thCons.Name = "ConsequentialMainThread";
                    thCons.Start();
                }
                // STEADY LOAD
                if (gl_SteadyLoadProfile)
                {
                    ApplySteadyLoadSettings();
                    // TIME LIMITED STEADY LOAD
                    if (gl_TimeBasedLoad)
                    {
                        gl_TimerIsAlive = true;
                        Thread thTimer = new Thread(() => TimerThread(gl_TimerDuration));
                        thTimer.Name = "TimerThread";

                        Thread thTimeBased = new Thread(() => TimeBaseLoadMainThread());
                        thTimeBased.Name = "TimeBasedLoadThread";

                        thTimer.Start();
                        thTimeBased.Start();
                    }
                    // STEADY LOAD LIMITED BY NUMBER OF CHATS
                    else
                    {
                        Thread thConc = new Thread(() => ConcurrentMainThread());
                        thConc.Name = "ConcurrentMainThread";
                        thConc.Start();
                    }
                }
                // BOOSTED LOAD
                else
                {
                    ApplyBoostLoadSettings();

                    gl_TimerIsAlive = true;
                    Thread thTimer = new Thread(() => TimerThread(gl_BoostDuration));
                    thTimer.Name = "TimerThread";

                    Thread thBoost = new Thread(() => BoostLoadMainThread());
                    thBoost.Name = "BoostLoadMainThread";

                    gl_BoostCurrentDelay = gl_BoostDelayStart;
                    int boostStep = Convert.ToInt32((gl_BoostDelayStart - gl_BoostDelayFinish) * BOOSTTICK / gl_BoostDuration);
                    Thread thBoostHelper = new Thread(() => BoostLoadHelperThread(boostStep));
                    thBoostHelper.Name = "BoostLoadHelperThread";

                    thTimer.Start();
                    thBoostHelper.Start();
                    thBoost.Start();
                }
            }
            catch (Exception ex)
            {
                string err = "EXCEPTION: " + ex.Message;
                LogAddLine(IDT_LOG, gl_SbLog, err + "\r\n");
                EnableUI(true);
            }                

        }

        private void IDB_STOP_Click(object sender, EventArgs e)
        {
            if (!gl_UseThreading)
            {
                foreach (ChatGeneratorClass gen in gl_ListOfChats)
                {
                    gen.GarbageCleaner();
                }
                gl_ListOfChats = null;
                gl_ListOfChats = new List<ChatGeneratorClass>();
            }
            else
            {
                foreach (StringBuilder sb in gl_ListOfLocalLogs)
                {
                    gl_SbLog.Append(sb);
                }
                foreach (ChatGeneratorClass gen in gl_ListOfChats)
                {
                    gen.GarbageCleaner();
                }
                foreach (Thread th in gl_ListOfThreads)
                {
                    th.Abort();
                }
                
                gl_ListOfChats = null;
                gl_ListOfLocalLogs = null;
                gl_ListOfThreads = null;
                gl_ListOfChats = new List<ChatGeneratorClass>();
                gl_ListOfLocalLogs = new List<StringBuilder>();
                gl_ListOfThreads = new List<Thread>();
            }
            IDT_LOG.Text = gl_SbLog.ToString();

            EnableUI(true);
        }

        private void IDCB_THREADING_CheckedChanged(object sender, EventArgs e)
        {
            if (IDCB_THREADING.Checked) gl_UseThreading = true;
            else gl_UseThreading = false;
        }

        private void IDCB_FORCECLOSE_CheckedChanged(object sender, EventArgs e)
        {
            if (IDCB_FORCECLOSE.Checked) gl_ForceClosing = true;
            else gl_ForceClosing = false;
        }

        private void IDRB_MSGTYPE_MINIMAL_CheckedChanged(object sender, EventArgs e)
        {
            if (IDRB_MSGTYPE_MINIMAL.Checked) gl_VolumedMsgType = VolumedMessageType.Minimal;
            if (IDRB_MSGTYPE_FAT512.Checked) gl_VolumedMsgType = VolumedMessageType.Fat512b;
            if (IDRB_MSGTYPE_XTRAFAT1KB.Checked) gl_VolumedMsgType = VolumedMessageType.XtraFat1kb;
        }

        private void IDRB_MSGTYPE_FAT512_CheckedChanged(object sender, EventArgs e)
        {
            if (IDRB_MSGTYPE_FAT512.Checked) gl_VolumedMsgType = VolumedMessageType.Fat512b;
            if (IDRB_MSGTYPE_MINIMAL.Checked) gl_VolumedMsgType = VolumedMessageType.Minimal;
            if (IDRB_MSGTYPE_XTRAFAT1KB.Checked) gl_VolumedMsgType = VolumedMessageType.XtraFat1kb;
        }

        private void IDRB_MSGTYPE_XTRAFAT1MB_CheckedChanged(object sender, EventArgs e)
        {
            if (IDRB_MSGTYPE_FAT512.Checked) gl_VolumedMsgType = VolumedMessageType.Fat512b;
            if (IDRB_MSGTYPE_MINIMAL.Checked) gl_VolumedMsgType = VolumedMessageType.Minimal;
            if (IDRB_MSGTYPE_XTRAFAT1KB.Checked) gl_VolumedMsgType = VolumedMessageType.XtraFat1kb;
        }

        private void IDRB_LPTYPE_STEADY_CheckedChanged(object sender, EventArgs e)
        {
            if (IDRB_LPTYPE_STEADY.Checked) 
            { 
                GB_STEADY_SETTINGS.Enabled = true; 
                GB_BOOST_SETTINGS.Enabled = false;
                gl_SteadyLoadProfile = true;
            }
            if (IDRB_LPTYPE_BOOST.Checked) 
            { 
                GB_STEADY_SETTINGS.Enabled = false; 
                GB_BOOST_SETTINGS.Enabled = true;
                gl_SteadyLoadProfile = false;
            }
        }

        private void IDRB_LPTYPE_BOOST_CheckedChanged(object sender, EventArgs e)
        {
            if (IDRB_LPTYPE_STEADY.Checked) 
            { 
                GB_STEADY_SETTINGS.Enabled = true; 
                GB_BOOST_SETTINGS.Enabled = false;
                gl_SteadyLoadProfile = true;
            }
            if (IDRB_LPTYPE_BOOST.Checked) 
            { 
                GB_STEADY_SETTINGS.Enabled = false; 
                GB_BOOST_SETTINGS.Enabled = true;
                gl_SteadyLoadProfile = false;
            }
        }

        private void IDRB_STEADYLIMIT_CHAT_CheckedChanged(object sender, EventArgs e)
        {
            if (IDRB_STEADYLIMIT_CHAT.Checked) 
            { 
                IDT_CHATCOUNT.Enabled = true;
                IDT_TIMECOUNT.Enabled = false;
                gl_TimeBasedLoad = false;
            }
            if (IDRB_STEADYLIMIT_TIME.Checked)
            {
                IDT_CHATCOUNT.Enabled = false;
                IDT_TIMECOUNT.Enabled = true;
                gl_TimeBasedLoad = true;
            }
        }

        private void IDRB_STEADYLIMIT_TIME_CheckedChanged(object sender, EventArgs e)
        {
            if (IDRB_STEADYLIMIT_CHAT.Checked)
            {
                IDT_CHATCOUNT.Enabled = true;
                IDT_TIMECOUNT.Enabled = false;
                gl_TimeBasedLoad = false;
            }
            if (IDRB_STEADYLIMIT_TIME.Checked)
            {
                IDT_CHATCOUNT.Enabled = false;
                IDT_TIMECOUNT.Enabled = true;
                gl_TimeBasedLoad = true;
            }
        }

        private void IDT_SITEID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        private void IDT_CHATCOUNT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        private void IDT_TIMECOUNT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        private void IDT_DELAY_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        private void IDT_BOOST_START_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        private void IDT_BOOST_FINISH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        private void IDT_BOOST_LIFETIME_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        private void IDT_VOLUMECOUNT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        private void IDB_SAVELOG_Click(object sender, EventArgs e)
        {
            string path = "log_" + DateTime.Now.ToString("yyyy-MM-ddTHH-mm-ss") + ".txt";
            File.WriteAllText(path, IDT_LOG.Text);
        }
    }
}
