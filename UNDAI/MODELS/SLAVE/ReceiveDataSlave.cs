using System.IO;
using System.Net.Sockets;
using System.Text;
using UNDAI.VIEWMODELS.SLAVE;

namespace UNDAI.MODELS.SLAVE
{
    public class ReceiveDataSlave
    {
        bool _connected;
        TcpClient? _client;
        public MainPageSlaveViewModel _mainPageSlaveViewModel;
        public SelfRegPageSlaveViewModel selfRegPageSlaveViewModel;
        public MainPageSlaveModel _mainPageSlaveModel;
        public SelfRegPageSlaveModel _selfRegPageSlaveModel;
        public SystemSettingSlaveViewModel _systemSettingSlaveViewModel;
        ConnectionSlave _connectionSlave;
        int ReceivingDataCount = 0;
        int intFlag = 0;
        bool _isSendDataLongPressed;
        public string response;
        public string result;
        private readonly CancellationTokenSource _cancellationTokenSource;
        string _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SlaveResponse.txt");

        byte[] buffer;
        int received;


        public ReceiveDataSlave(bool connected, TcpClient client, MainPageSlaveViewModel mainPageSlaveViewModel, ConnectionSlave connectionSlave)
        {
            _connected = connected;
            _connectionSlave = connectionSlave;
            _client = _connectionSlave.client;
            _mainPageSlaveViewModel = mainPageSlaveViewModel;
            _cancellationTokenSource = new CancellationTokenSource();
            response = string.Empty; // Initialize the response field
            _mainPageSlaveModel = _mainPageSlaveViewModel.MainPageSlaveModel;
            selfRegPageSlaveViewModel = _mainPageSlaveViewModel._selfRegPageSlaveViewModel;
            _systemSettingSlaveViewModel = _mainPageSlaveViewModel._systemSettingSlaveViewModel;
            StartReceiving(_cancellationTokenSource.Token);

        }

        public async Task StartReceiving(CancellationToken cancellationToken)
        {
            try
            {
                intFlag = 1;
                while (_connected && !cancellationToken.IsCancellationRequested)
                {
                    intFlag = 2;
                    try
                    {
                        intFlag = 3;
                        NetworkStream stream = _client.GetStream();
                        buffer = new byte[200];
                        intFlag = 7;
                        received = await stream.ReadAsync(buffer, 0, buffer.Length, cancellationToken);
                        intFlag = 8;
                        if (received > 0 && !buffer.All(x => x == 0))
                        {
                            intFlag = 4;
                            response = Encoding.UTF8.GetString(buffer, 0, received);
                            using (StreamWriter writer = new StreamWriter(_filePath, true, Encoding.UTF8))
                            {
                                writer.WriteLine(response); // This writes the response on a new line
                            }
                            _mainPageSlaveViewModel.ReceivingDataCount = ReceivingDataCount;
                            // Update the UI with the received response
                            if (response.Contains('\n') && response.IndexOf("\n") > 3)
                            {
                                intFlag = 5;
                                result = response.Substring(0, response.IndexOf("\n") - 1);
                                ReceivingDataCount++;
                                _systemSettingSlaveViewModel.ReceivedData = result;
                                _systemSettingSlaveViewModel.ReceivedData2 = result;
                                _mainPageSlaveModel.ReceivedMessage(result);
                                intFlag = 6;
                            }
                        }
                    }
                    catch (OperationCanceledException)
                    {
                        _mainPageSlaveViewModel.ReceivedData = "";
                        _mainPageSlaveViewModel.SlaveAlarmData = "Receiving operation canceled.";
                        break;
                    }
                    catch (SocketException ex)
                    {
                        _mainPageSlaveViewModel.ReceivedData = "";
                        _mainPageSlaveViewModel.SlaveAlarmData = $"Socket error: {ex.Message}";
                        break;
                    }
                    catch (Exception ex)
                    {
                        _mainPageSlaveViewModel.ReceivedData = "";
                        _mainPageSlaveViewModel.SlaveAlarmData = $"Unexpected error: {ex.Message}";
                        break;
                    }
                    await Task.Delay(10);
                }
            }
            finally
            {
                _connected = false; // or other state management
                if (_client != null)
                {
                    _connectionSlave.CloseConnection();
                    _client = null;
                }
            }
        }

        public void StopReceiving()
        {
            _cancellationTokenSource.Cancel();
            _mainPageSlaveViewModel.ReceivedData = "";
        }
    }
}