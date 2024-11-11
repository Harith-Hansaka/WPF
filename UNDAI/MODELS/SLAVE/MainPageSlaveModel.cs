using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using UNDAI.VIEWMODELS;
using UNDAI.COMMANDS;
using UNDAI.VIEWMODELS.SLAVE;
using UNDAI.COMMANDS.SLAVE;
using System.Timers;
using Timer = System.Timers.Timer;
using UNDAI.VIEWMODELS.MASTER;
using System.IO;
using UNDAI.MODELS.MASTER;
using UNDAI.VIEWS.BASE;
using System.Net;

namespace UNDAI.MODELS.SLAVE
{
    public class MainPageSlaveModel
    {
        MainPageSlaveViewModel _mainPageSlaveViewModel;
        public LongPressHandleSlave _longPressHandleSlave;
        MessageSendSlaveCommand _messageSendSlaveCommand;
        SystemSettingSlaveViewModel _systemSettingSlaveViewModel;
        SystemSettingMasterViewModel _systemSettingMasterViewModel;
        AlarmHistorySlaveViewModel _alarmHistorySlaveViewModel;
        StationDBPageSlaveViewModel _stationDBPageSlaveViewModel;
        BaseStationRegistrationSlaveViewModel _baseStationRegistrationSlaveViewModel;
        ConnectionSlave _connectionSlave;
        SelfRegPageSlaveViewModel _selfRegPageSlaveViewModel;
        App app;

        private Timer _timer;
        string _message;
        List<string> messageList;
        int dataCount;
        List<int> dataCountList;
        public int randomNumber = 0;
        public int messageReceivedCount = 0;
        public bool isBtnUnitNoUpLongPress = false;
        public bool isBtnUnitNoDownLongPress = false;
        DateTime pressedTime;
        bool isBtnPointerPressed;
        bool isBtnPointerReleased = true;
        bool isLongPressed = false;
        string newIPAddress;

        public MainPageSlaveModel(MainPageSlaveViewModel mainPageSlaveViewModel, ConnectionSlave connectionSlave)
        {
            _mainPageSlaveViewModel = mainPageSlaveViewModel;
            _connectionSlave = connectionSlave;
            _stationDBPageSlaveViewModel = mainPageSlaveViewModel._stationDBPageSlaveViewModel;
            _baseStationRegistrationSlaveViewModel = mainPageSlaveViewModel._baseStationRegistrationSlaveViewModel;
            _longPressHandleSlave = new LongPressHandleSlave(_mainPageSlaveViewModel, this);
            _messageSendSlaveCommand = new MessageSendSlaveCommand(_connectionSlave, _mainPageSlaveViewModel, string.Empty);
            _timer = new Timer(1000); // Initialize timer
            _message = string.Empty; // Initialize message
            messageList = new List<string>(); // Initialize message list
            dataCountList = new List<int>(); // Initialize data count list
            UpdateDateTime();
            StartTimer();
            app = (App)Application.Current;
            CreateAppClassAfterDelay();
        }

        private async void CreateAppClassAfterDelay()
        {
            await Task.Delay(500);
            if (_systemSettingSlaveViewModel == null || _systemSettingMasterViewModel == null)
            {
                // Access properties directly
                _systemSettingSlaveViewModel = app._systemSettingSlaveViewModel;
                _systemSettingMasterViewModel = app._systemSettingMasterViewModel;
            }
            if (_alarmHistorySlaveViewModel == null)
            {
                // Access properties directly
                _alarmHistorySlaveViewModel = app._alarmHistorySlaveViewModel;
            }
            if (_selfRegPageSlaveViewModel == null)
            {
                // Access properties directly
                _selfRegPageSlaveViewModel = app._selfRegPageSlaveViewModel;
            }
        }

        public void MessageSend(String message)
        {
            _messageSendSlaveCommand = new MessageSendSlaveCommand(_connectionSlave, _mainPageSlaveViewModel, message);
            _messageSendSlaveCommand.Execute(this);
        }

        public void PINCheck(string EnteredPIN)
        {
            string PIN = "1234";
            if (_mainPageSlaveViewModel.PINKeyboardClose)
            {
                if (EnteredPIN == PIN)
                {
                    _mainPageSlaveViewModel.SystemSettingUnlock = true;
                    _mainPageSlaveViewModel.PINKeyboardClose = false;
                    _mainPageSlaveViewModel.SystemSettingSlaveCommand = _mainPageSlaveViewModel.SystemSettingSlavePage;
                    _mainPageSlaveViewModel.SystemSettingSlaveCommand.Execute(null);
                }
                else
                {
                    _mainPageSlaveViewModel.SystemSettingUnlock = false;
                    _mainPageSlaveViewModel.PINKeyboardClose = false;
                }
            }
        }

        public void ReceivedMessage(string message)
        {
            if (_systemSettingMasterViewModel != null &&
                _systemSettingSlaveViewModel != null &&
                _selfRegPageSlaveViewModel != null &&
                _alarmHistorySlaveViewModel != null) { }
            else
            {
                CreateAppClassAfterDelay();
            }
            _message = message;
            //_mainPageSlaveViewModel.ReceivedData = _message;
            messageReceivedCount++;
            try
            {
                messageList = new List<string>(_message.Split(','));
            }

            catch (Exception ex) 
            {
                _mainPageSlaveViewModel.SlaveAlarmData = ex.ToString();
            }
            if (messageList[0] == "A")
            {
                try
                {
                    dataCountList = new List<int>();
                    int dataCount = int.Parse(messageList[2]);
                    int dataCountStartingDataLocation = int.Parse(messageList[1]);
                    randomNumber = int.Parse(messageList[3 + dataCount - 1]);
                    for (int i = 0; i < dataCount; i++)
                    {
                        dataCountList.Add(dataCountStartingDataLocation + i);
                    }
                    _connectionSlave.loadingImg = false;
                    _mainPageSlaveViewModel.LoadingScreenImgVisibility = "";
                    for (int i = 0; i < dataCountList.Count; i++)
                    {
                        switch (dataCountList[i])
                        {
                            // 100 - CurrentValueMasterElevation
                            case 100:
                                _mainPageSlaveViewModel.CurrentValueMasterElevation = messageList[3 + i];
                                _systemSettingSlaveViewModel.ElevationAngleInput100 = messageList[3 + i];
                                break;
                            // 101 - CurrentValueMasterAzimuth
                            case 101:
                                _mainPageSlaveViewModel.CurrentValueMasterAzimuth = messageList[3 + i];
                                _systemSettingSlaveViewModel.AzimuthAngleInput101 = messageList[3 + i];
                                break;
                            // 102 - Latitude
                            case 102:
                                _mainPageSlaveViewModel.Latitude102 = messageList[3 + i];
                                break;
                            // 103 - Longitude
                            case 103:
                                _mainPageSlaveViewModel.Longitude103 = messageList[3 + i];
                                break;
                            // 104 - Elevation
                            case 104:
                                _mainPageSlaveViewModel.Elevation104 = messageList[3 + i];
                                break;
                            // 105 - Installation Direction
                            case 105:
                                _mainPageSlaveViewModel.InstallationDirection105 = messageList[3 + i];
                                break;
                            // 106 - Speed Select
                            case 106:
                                _mainPageSlaveViewModel.SpeedSelect = int.Parse(messageList[3 + i]);
                                break;
                            // 107 - LINK UP/ DOWN
                            case 107:
                                string binaryString = Convert.ToString(int.Parse(messageList[3 + i]), 2).PadLeft(4, '0');
                                if (binaryString[3] == '0')
                                {
                                    _mainPageSlaveViewModel.MasterStatusColor = "false";
                                }
                                else if (binaryString[3] == '1')
                                {
                                    _mainPageSlaveViewModel.MasterStatusColor = "true";
                                }
                                break;
                            // 108 - CurrentValueMasterRSSI
                            case 108:
                                _mainPageSlaveViewModel.CurrentValueMasterRSSI = $"-{(int.Parse(messageList[3 + i]) / 10.0):F1}";
                                break;
                            // 109 - PeakValueMasterRSSI
                            case 109:
                                _mainPageSlaveViewModel.PeakValueMasterRSSI = $"-{(int.Parse(messageList[3 + i]) / 10.0):F1}";
                                break;
                            // 110 - PeakValueMasterElevation
                            case 110:
                                _mainPageSlaveViewModel.PeakValueMasterElevation = messageList[3 + i];
                                break;
                            // 111 - PeakValueMasterAzimuth
                            case 111:
                                _mainPageSlaveViewModel.PeakValueMasterAzimuth = messageList[3 + i];
                                break;
                            // 112 - MODMaster
                            case 112:
                                if (messageList[3 + i] == "0") { _mainPageSlaveViewModel.MODMaster = "ACQUISITION"; }
                                else if (messageList[3 + i] == "1") { _mainPageSlaveViewModel.MODMaster = "BPSK 0.63"; }
                                else if (messageList[3 + i] == "2") { _mainPageSlaveViewModel.MODMaster = "QPSK 0.63 (SINGLE)"; }
                                else if (messageList[3 + i] == "3") { _mainPageSlaveViewModel.MODMaster = "TRANSIENT1"; }
                                else if (messageList[3 + i] == "4") { _mainPageSlaveViewModel.MODMaster = "QPSK 0.87 (SINGLE)"; }
                                else if (messageList[3 + i] == "5") { _mainPageSlaveViewModel.MODMaster = "TRANSIENT2"; }
                                else if (messageList[3 + i] == "6") { _mainPageSlaveViewModel.MODMaster = "16QAM 0.63 (SINGLEA)"; }
                                else if (messageList[3 + i] == "7") { _mainPageSlaveViewModel.MODMaster = "TRANSIENT3"; }
                                else if (messageList[3 + i] == "8") { _mainPageSlaveViewModel.MODMaster = "16QAM 0.87 (SINGLE)"; }
                                else if (messageList[3 + i] == "9") { _mainPageSlaveViewModel.MODMaster = "TRANSIENT4"; }
                                else if (messageList[3 + i] == "10") { _mainPageSlaveViewModel.MODMaster = "64QAM 0.75 (SINGLE)"; }
                                else if (messageList[3 + i] == "11") { _mainPageSlaveViewModel.MODMaster = "TRANSIENT5"; }
                                else if (messageList[3 + i] == "12") { _mainPageSlaveViewModel.MODMaster = "64QAM 0.92 (SINGLE)"; }
                                else if (messageList[3 + i] == "13") { _mainPageSlaveViewModel.MODMaster = "TRANSIENT6"; }
                                else if (messageList[3 + i] == "14") { _mainPageSlaveViewModel.MODMaster = "256QAM 0.81 (SINGLE)"; }
                                else if (messageList[3 + i] == "15") { _mainPageSlaveViewModel.MODMaster = "16QAM 0.63 (SINGLEB)"; }
                                else if (messageList[3 + i] == "16") { _mainPageSlaveViewModel.MODMaster = "16QAM 0.63 (DUAL)"; }
                                else if (messageList[3 + i] == "17") { _mainPageSlaveViewModel.MODMaster = "TRANSIENT7"; }
                                else if (messageList[3 + i] == "18") { _mainPageSlaveViewModel.MODMaster = "16QAM 0.87 (DUAL)"; }
                                else if (messageList[3 + i] == "19") { _mainPageSlaveViewModel.MODMaster = "TRANSIENT8"; }
                                else if (messageList[3 + i] == "20") { _mainPageSlaveViewModel.MODMaster = "64QAM 0.75 (DUAL)"; }
                                else if (messageList[3 + i] == "21") { _mainPageSlaveViewModel.MODMaster = "TRANSIENT9"; }
                                else if (messageList[3 + i] == "22") { _mainPageSlaveViewModel.MODMaster = "64QAM 0.92 (DUAL)"; }
                                else if (messageList[3 + i] == "23") { _mainPageSlaveViewModel.MODMaster = "TRANSIENT10"; }
                                else if (messageList[3 + i] == "24") { _mainPageSlaveViewModel.MODMaster = "256QAM 0.81 (DUAL)"; }
                                else if (messageList[3 + i] == "25") { _mainPageSlaveViewModel.MODMaster = "TRANSIENT11"; }
                                else if (messageList[3 + i] == "26") { _mainPageSlaveViewModel.MODMaster = "256QAM 0.94 (SINGLE)"; }
                                else if (messageList[3 + i] == "27") { _mainPageSlaveViewModel.MODMaster = "TRANSIENT12"; }
                                else if (messageList[3 + i] == "28") { _mainPageSlaveViewModel.MODMaster = "256QAM 0.94 (DUAL)"; }
                                else _mainPageSlaveViewModel.MODMaster = (messageList[3 + i]);
                                break;
                            // 113 - PLMaster
                            case 113:
                                _mainPageSlaveViewModel.RSSIRateMaster = messageList[3 + i];
                                break;
                            // 114 - GPSStatus
                            case 114:
                                _mainPageSlaveViewModel.GPSStatus = int.Parse(messageList[3 + i]);
                                break;
                            // 115 - HomePeakSelect
                            case 115:
                                _mainPageSlaveViewModel.HomePeakSelect = int.Parse(messageList[3 + i]);
                                break;
                            // 116 - MasterName
                            case 116:
                                _mainPageSlaveViewModel.MasterNameBackup = (messageList[3 + i]);
                                break;
                        }
                    }
                }
                catch
                {

                }
            }

            else if (messageList[0] == "DM")
            {
                try 
                {
                    _mainPageSlaveViewModel.SlaveNameTxt = messageList[2];
                    _mainPageSlaveViewModel.SlaveIPAddressTxt = messageList[9];
                    _mainPageSlaveViewModel.SlaveLatitudeTextBackup = messageList[3];
                    _mainPageSlaveViewModel.SlaveLongitudeTextBackup = messageList[4];
                    _mainPageSlaveViewModel.SlaveElevationTextBackup = messageList[5];

                    randomNumber = int.Parse(messageList[12]);

                    _stationDBPageSlaveViewModel.SlaveName = (messageList[2]);
                    _stationDBPageSlaveViewModel.LatitudeSlave = (messageList[3]);
                    _stationDBPageSlaveViewModel.LongitudeSlave = (messageList[4]);
                    _stationDBPageSlaveViewModel.ElevationSlave = (messageList[5]);
                    _stationDBPageSlaveViewModel.PoleHeight = (messageList[6]);
                    _stationDBPageSlaveViewModel.InstallationOrientation = (messageList[7]);

                    _selfRegPageSlaveViewModel.SlaveName = (messageList[2]);
                    _selfRegPageSlaveViewModel.LatitudeSlave = (messageList[3]);
                    _selfRegPageSlaveViewModel.LongitudeSlave = (messageList[4]);
                    _selfRegPageSlaveViewModel.ElevationSlave = (messageList[5]);
                    _selfRegPageSlaveViewModel.PoleHeight = (messageList[6]);
                    _selfRegPageSlaveViewModel.InstallationOrientation = (messageList[7]);

                    _stationDBPageSlaveViewModel.AddStationDBPage
                    (
                        messageList[2],
                        messageList[3],
                        messageList[4],
                        messageList[5],
                        messageList[6],
                        messageList[7],
                        messageList[8],
                        messageList[9],
                        messageList[10],
                        messageList[11]
                    );

                    if (_selfRegPageSlaveViewModel == null)
                    {
                        CreateAppClassAfterDelay();
                    }
                    _selfRegPageSlaveViewModel.SlaveName = (messageList[2]);
                    _selfRegPageSlaveViewModel.LatitudeSlave = (messageList[3]);
                    _selfRegPageSlaveViewModel.LongitudeSlave = (messageList[4]);
                    _selfRegPageSlaveViewModel.ElevationSlave = (messageList[5]);
                    _selfRegPageSlaveViewModel.PoleHeight = (messageList[6]);
                    _selfRegPageSlaveViewModel.InstallationOrientation = (messageList[7]);
                }
                catch 
                {

                }
            }

            else if (messageList[0] == "SM")
            {
                _mainPageSlaveViewModel.backupMasterIPAddress = messageList[1];
                _mainPageSlaveViewModel.MasterJapaneseNameBackup = (messageList[3]);

                _baseStationRegistrationSlaveViewModel.MasterAntennaIPAddress = (messageList[1]);
                _baseStationRegistrationSlaveViewModel.MasterAntennaName = (messageList[2]);
                _baseStationRegistrationSlaveViewModel.MasterName = (messageList[3]);
                _baseStationRegistrationSlaveViewModel.LatitudeMaster = (messageList[4]);
                _baseStationRegistrationSlaveViewModel.LongitudeMaster = (messageList[5]);
                _baseStationRegistrationSlaveViewModel.ElevationMaster = (messageList[6]);
                _baseStationRegistrationSlaveViewModel.PoleHeight = (messageList[7]);

                _baseStationRegistrationSlaveViewModel.canAdd2DB = true;
                _baseStationRegistrationSlaveViewModel.AddStationDBPage
                (
                    messageList[1],
                    messageList[2],
                    messageList[3],
                    messageList[4],
                    messageList[5],
                    messageList[6],
                    messageList[7],
                    messageList[8],
                    messageList[9]
                );
                _baseStationRegistrationSlaveViewModel.canAdd2DB = false;
            }
            else if (messageList[0] == "SY")
            {
                try
                {
                    int dataCount = messageList.Count;
                    if (dataCount < 5)
                    {
                        for (int i = 1; i < dataCount; i++)
                        {
                            switch (i)
                            {
                                case 1:
                                    if (int.Parse(messageList[i]) != 2)
                                    {
                                        //_systemSettingSlaveViewModel.SelectedMode = int.Parse(messageList[i]);
                                        _connectionSlave.CloseConnection();
                                        UNDAIRestartMessageBox messageBox = new UNDAIRestartMessageBox();
                                        if (messageBox.ShowDialog() == true)
                                        {
                                            _systemSettingSlaveViewModel.MainPageNavigateCommand.Execute(null);
                                        }
                                        else
                                        {
                                            _systemSettingSlaveViewModel.MainPageNavigateCommand.Execute(null);
                                        }
                                        string _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _connectionSlave.fileName);
                                        string[] savedData = File.ReadLines(_filePath).First().Split(',');
                                        savedData[0] = messageList[i];
                                        // Write newIPAddress to the file
                                        try
                                        {
                                            using (StreamWriter writer = new StreamWriter(_filePath, false))
                                            {
                                                writer.WriteLine(string.Join(",", savedData));
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            // Handle any errors that may occur
                                            _mainPageSlaveViewModel.SlaveAlarmData = $"Error saving Seleced method address: {ex.Message}";
                                        }
                                    }
                                    break;
                                case 2:
                                    newIPAddress = messageList[i];
                                    if (newIPAddress != _connectionSlave.currentServerIP)
                                    {
                                        // Define the file path in the application installation directory
                                        string _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _connectionSlave.fileName);
                                        string[] savedData = File.ReadLines(_filePath).First().Split(',');
                                        savedData[1] = newIPAddress;
                                        // Write newIPAddress to the file
                                        try
                                        {
                                            using (StreamWriter writer = new StreamWriter(_filePath, false))
                                            {
                                                writer.WriteLine(string.Join(",", savedData));
                                            }
                                            // Optionally, update the currentServerIP with the newIPAddress
                                            _connectionSlave.currentServerIP = newIPAddress;
                                            _connectionSlave.CloseConnection();
                                            UNDAIRestartMessageBox messageBox = new UNDAIRestartMessageBox();
                                            if (messageBox.ShowDialog() == true)
                                            {
                                                _systemSettingSlaveViewModel.MainPageNavigateCommand.Execute(null);
                                            }
                                            else
                                            {
                                                _systemSettingSlaveViewModel.MainPageNavigateCommand.Execute(null);
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            // Handle any errors that may occur
                                            _mainPageSlaveViewModel.SlaveAlarmData = $"Error saving IP address: {ex.Message}";
                                        }
                                    }
                                    break;
                                case 3:
                                    if (int.Parse(messageList[i]) != 1)
                                    {
                                        _connectionSlave.CloseConnection();
                                        UNDAIRestartMessageBox messageBox = new UNDAIRestartMessageBox();
                                        if (messageBox.ShowDialog() == true)
                                        {
                                            _systemSettingMasterViewModel.MainPageNavigateCommand.Execute(null);
                                        }
                                        else
                                        {
                                            _systemSettingMasterViewModel.MainPageNavigateCommand.Execute(null);
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                    else
                    {
                        for (int i = 1; i < dataCount; i++)
                        {
                            switch (i)
                            {
                                case 1:
                                    if (int.Parse(messageList[i]) != 2)
                                    {
                                        if (MessageBox.Show("The operation is different. Please reconnect the device.",
                                            "DEVICE RECONNECTION REQUEST",
                                            MessageBoxButton.OK,
                                            MessageBoxImage.Question) == MessageBoxResult.OK)
                                        {
                                            // Optionally, do something here if the user clicks "OK"
                                            _connectionSlave.CloseConnection();
                                            _systemSettingMasterViewModel.SelectedMode = int.Parse(messageList[i]);
                                            _systemSettingSlaveViewModel.SelectedMode = int.Parse(messageList[i]);
                                            _mainPageSlaveViewModel.ToMasterCommand.Execute(null);
                                            string _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _connectionSlave.fileName);
                                            string[] savedData = File.ReadLines(_filePath).First().Split(',');
                                            savedData[0] = messageList[i];
                                            // Write newIPAddress to the file
                                            try
                                            {
                                                using (StreamWriter writer = new StreamWriter(_filePath, false))
                                                {
                                                    writer.WriteLine(string.Join(",", savedData));
                                                }
                                            }
                                            catch (Exception ex)
                                            {
                                                // Handle any errors that may occur
                                                _mainPageSlaveViewModel.SlaveAlarmData = $"Error saving Seleced method address: {ex.Message}";
                                            }
                                        }
                                    }
                                    break;
                                case 2:
                                    newIPAddress = messageList[i];
                                    if (newIPAddress != _connectionSlave.currentServerIP)
                                    {
                                        // Define the file path in the application installation directory
                                        string _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _connectionSlave.fileName);
                                        string[] savedData = File.ReadLines(_filePath).First().Split(',');
                                        savedData[1] = newIPAddress;
                                        // Write newIPAddress to the file
                                        try
                                        {
                                            using (StreamWriter writer = new StreamWriter(_filePath, false))
                                            {
                                                writer.WriteLine(string.Join(",", savedData));
                                            }

                                            // Optionally, update the currentServerIP with the newIPAddress
                                            _connectionSlave.currentServerIP = newIPAddress;
                                            _connectionSlave.CloseConnection();
                                            _systemSettingSlaveViewModel.MainPageNavigateCommand.Execute(null);
                                        }
                                        catch (Exception ex)
                                        {
                                            // Handle any errors that may occur
                                            _mainPageSlaveViewModel.SlaveAlarmData = $"Error saving IP address: {ex.Message}";
                                        }
                                    }
                                    break;
                                case 3:
                                    _systemSettingSlaveViewModel.UndaiSubnet = messageList[i];
                                    break;
                                case 4:
                                    _systemSettingSlaveViewModel.DefaultGateway = messageList[i];
                                    break;
                                case 5:
                                    _systemSettingSlaveViewModel.SlaveAntennaIPAddress = messageList[i];
                                    break;
                                case 6:
                                    _systemSettingSlaveViewModel.OriginOffsetAzimuth = messageList[i];
                                    break;
                                case 7:
                                    _systemSettingSlaveViewModel.OriginOffsetElevation = messageList[i];
                                    break;
                                case 8:
                                    _systemSettingSlaveViewModel.HighSpeedSetAzimuth = messageList[i];
                                    break;
                                case 9:
                                    _systemSettingSlaveViewModel.HighSpeedSetElevation = messageList[i];
                                    break;
                                case 10:
                                    _systemSettingSlaveViewModel.LowSpeedSetAzimuth = messageList[i];
                                    break;
                                case 11:
                                    _systemSettingSlaveViewModel.LowSpeedSetElevation = messageList[i];
                                    break;
                                case 12:
                                    _systemSettingSlaveViewModel.InchingSpeedSetAzimuth = messageList[i];
                                    break;
                                case 13:
                                    _systemSettingSlaveViewModel.InchingSpeedSetElevation = messageList[i];
                                    break;
                                case 14:
                                    _systemSettingSlaveViewModel.PeakSearchSpeed = messageList[i];
                                    break;
                                case 15:
                                    _systemSettingSlaveViewModel.PeakSearchAzimuth = messageList[i];
                                    break;
                                case 16:
                                    _systemSettingSlaveViewModel.PeakSearchElevation = messageList[i];
                                    break;
                                case 17:
                                    _systemSettingSlaveViewModel.PeakSearchRSSILevel = messageList[i];
                                    break;
                                case 18:
                                    _systemSettingSlaveViewModel.PeakSearchRSSITurnLevel = messageList[i];
                                    break;
                                case 19:
                                    _systemSettingSlaveViewModel.PeakSearchRSSIDelay = messageList[i];
                                    break;
                                case 20:
                                    _systemSettingSlaveViewModel.DetailedPeakSearchSpeed = messageList[i];
                                    break;
                                case 21:
                                    _systemSettingSlaveViewModel.DetailedPeakSearchStepAngle = messageList[i];
                                    break;
                                case 22:
                                    _systemSettingSlaveViewModel.UpDownSearchAngle = messageList[i];
                                    break;
                                case 23:
                                    _systemSettingSlaveViewModel.DetailedPeakSearchAzimuth = messageList[i];
                                    break;
                                case 24:
                                    _systemSettingSlaveViewModel.DetailedPeakSearchRSSILevel = messageList[i];
                                    break;
                                case 25:
                                    _systemSettingSlaveViewModel.StepStability = messageList[i];
                                    break;
                                case 26:
                                    _systemSettingSlaveViewModel.RSSITurnbackThresholdLevel = messageList[i];
                                    break;
                                case 27:
                                    _systemSettingSlaveViewModel.ElevationStepValue = messageList[i];
                                    break;
                                case 28:
                                    _systemSettingSlaveViewModel.AzimuthStepValue = messageList[i];
                                    break;
                            }
                        }
                    }
                }
                catch(Exception ex)
                {
                    _mainPageSlaveViewModel.SlaveAlarmData = ex.Message;
                }
            }
            else if (messageList[0] == "SA")
            {
                if (messageList.Count == 3)
                {
                    _alarmHistorySlaveViewModel.AddAlarmHistory
                    (
                        messageList[1],
                        messageList[2],
                        messageList[3]
                    );
                }
                else
                {
                    _alarmHistorySlaveViewModel.AddAlarmHistory
                    (
                        DateTime.Now.Date.ToString("yyyy-MM-dd"),
                        DateTime.Now.TimeOfDay.ToString(@"hh\:mm\:ss"),
                        messageList[1]
                    );
                }
            }
            else if (messageList[0] == "SI")
            {
                if (int.Parse(messageList[1]) == 12)
                {
                    _systemSettingSlaveViewModel.continuousOperationTimerStart = true;
                    string timeInMinutes = messageList[2];
                    if (messageList[2].Contains(':'))
                    {
                        // Replace any ":" with "." in the input string
                        timeInMinutes = timeInMinutes.Replace(":", ".");
                    }
                    _systemSettingSlaveViewModel.ContinuousOperationTime = timeInMinutes;
                }
            }
        }

        public async void Button_Click(int Identifier)
        {
            switch (Identifier)
            {
                case 1:
                    // UP ARROW MOUSE PRESSED - I,1\n
                    MessageSend("I," + (1).ToString() + "\n");
                    break;

                case 2:
                    // UP ARROW MOUSE RELEASED - I,2\n
                    MessageSend("I," + (2).ToString() + "\n");
                    break;

                case 3:
                    // DOWN ARROW MOUSE PRESSED - I,3\n
                    MessageSend("I," + (3).ToString() + "\n");
                    break;

                case 4:
                    // DOWN ARROW MOUSE RELEASED - I,4\n
                    MessageSend("I," + (4).ToString() + "\n");
                    break;

                case 5:
                    // CCW ARROW MOUSE PRESSED - I,5\n
                    MessageSend("I," + (5).ToString() + "\n");
                    break;

                case 6:
                    // CCW ARROW MOUSE RELEASED - I,6\n
                    MessageSend("I," + (6).ToString() + "\n");
                    break;

                case 7:
                    // CW ARROW MOUSE PRESSED - I,7\n
                    MessageSend("I," + (7).ToString() + "\n");
                    break;

                case 8:
                    // CW ARROW MOUSE RELEASED - I,8\n
                    MessageSend("I," + (8).ToString() + "\n");
                    break;


                case 9:
                    // HIGH SPEED COMMAND - I,18\n
                    MessageSend("I," + (18).ToString() + "\n");
                    break;

                case 10:
                    // LOW SPEED COMMAND - I,19\n
                    MessageSend("I," + (19).ToString() + "\n");
                    break;

                case 11:
                    // INCHING SPEED COMMAND - I,20\n
                    MessageSend("I," + (20).ToString() + "\n");
                    break;

                case 12:
                    // ELEVATION ANGLE SET COMMAND - R,1,Value\n
                    if(_mainPageSlaveViewModel.ElevationAngleInputSlave != "")
                    {
                        MessageSend("R," + (1).ToString() + "," + _mainPageSlaveViewModel.ElevationAngleInputSlave + "\n");
                    }
                    break;

                case 13:
                    // AZIMUTH ANGLE SET COMMAND - R,2,Value\n
                    if (_mainPageSlaveViewModel.AzimuthAngleInputSlave != "")
                    {
                        MessageSend("R," + (2).ToString() + "," + _mainPageSlaveViewModel.AzimuthAngleInputSlave + "\n");
                    }
                    break;

                case 14:
                    // SAVE ANGLE COMMAND - I,21\n
                    MessageSend("I," + (21).ToString() + "\n");
                    break;

                case 15:
                    // LOAD ANGLE COMMAND - I,22\n
                    MessageSend("I," + (22).ToString() + "\n");
                    break;

                case 16:
                    // UNIT CHANGE COMMAND - DMS/ DD
                    if (_mainPageSlaveViewModel.UnitMainSlave == "DMS")
                    {
                        _mainPageSlaveViewModel.UnitMainSlave = "DD";
                    }
                    else
                    {
                        _mainPageSlaveViewModel.UnitMainSlave = "DMS";
                    }
                    break;

                case 17:
                    // STOP COMMAND - I,30\n
                    MessageSend("I," + (30).ToString() + "\n");
                    break;

                case 18:
                    // HOME POSITION COMMAND PRESS - I,13\n
                    pressedTime = DateTime.Now;
                    isBtnPointerPressed = true;
                    await LongPressCheck(pressedTime);
                    if (isLongPressed)
                    {
                        MessageSend("I," + (13).ToString() + "\n");
                        isLongPressed = false;
                    }
                    break;

                case 19:
                    // HOME POSITION COMMAND RELEASE - I,13\n
                    isBtnPointerPressed = false;
                    break;

                case 20:
                    // PEAK SEARCH COMMAND PRESS - I,29\n
                    pressedTime = DateTime.Now;
                    isBtnPointerPressed = true;
                    await LongPressCheck(pressedTime);
                    if (isLongPressed)
                    {
                        MessageSend("I," + (29).ToString() + "\n");
                        isLongPressed = false;
                    }
                    break;

                case 21:
                    // PEAK SEARCH COMMAND RELEASE - I,29\n
                    isBtnPointerPressed = false;
                    break;
                case 22:
                    // Direction SEARCH COMMAND PRESS - I,17\n
                    pressedTime = DateTime.Now;
                    isBtnPointerPressed = true;
                    await LongPressCheck(pressedTime);
                    if (isLongPressed)
                    {
                        MessageSend("I," + (17).ToString() + "\n");
                        isLongPressed = false;
                    }
                    break;
                case 23:
                    // PEAK SEARCH COMMAND RELEASE - I,17\n
                    isBtnPointerPressed = false;
                    break;
            }
        }

        // Date and Time
        private void StartTimer()
        {
            _timer = new Timer(1000); // Update every second
            _timer.Elapsed += OnTimerElapsed;
            _timer.Start();
        }

        // Date and Time
        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            UpdateDateTime();
        }

        // Date and Time
        private void UpdateDateTime()
        {
            _mainPageSlaveViewModel.TxtBlockTime = DateTime.Now.ToString("HH:mm:ss");
            _mainPageSlaveViewModel.TxtBlockDate = DateTime.Now.ToShortDateString();
        }

        public async Task LongPressCheck(DateTime pressedTime)
        {
            while (isBtnPointerPressed)
            {
                if ((DateTime.Now - pressedTime).TotalMilliseconds > 1000)
                {
                    isLongPressed = true;
                    isBtnPointerPressed = false;
                }
                await Task.Delay(50);
            }
        }
        public static bool IsValidIPAddress(string ipAddress)
        {
            // Use IPAddress.TryParse to check if the input string is a valid IP address
            if (!ipAddress.Contains('.'))
            {
                return false;
            }
            if ((ipAddress.Split('.').Length - 1) != 3)
            {
                return false;
            }
            return IPAddress.TryParse(ipAddress, out _);
        }
        public static bool IsValidSubnetMask(string subnetMask)
        {
            if (IPAddress.TryParse(subnetMask, out IPAddress address))
            {
                byte[] bytes = address.GetAddressBytes();

                // Check if it's a valid subnet mask (between 255.0.0.0 and 255.255.255.255)
                // A valid subnet mask must start with 255 and follow CIDR mask rules (continuously filled bits)
                return IsSubnetMask(bytes);
            }

            return false; // Invalid IP format
        }

        private static bool IsSubnetMask(byte[] bytes)
        {
            uint mask = 0;

            // Convert subnet mask to an integer by shifting and OR-ing
            for (int i = 0; i < bytes.Length; i++)
            {
                mask = (mask << 8) | bytes[i];
                if (bytes[i] < 0 || bytes[i] > 255)
                {
                    return false;
                }
            }

            // Subnet masks are a contiguous sequence of 1s followed by 0s, e.g. 11111111 11111111 00000000 00000000
            // If we OR mask and mask + 1, the result must be all 1s for a valid subnet mask
            return true;
        }
    }
}
