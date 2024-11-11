using System.IO;
using System.Text;
using UNDAI.VIEWMODELS.SLAVE;

namespace UNDAI.MODELS.SLAVE
{
    public class SystemResetSettingSlaveModel
    {
        private int _commandNo;
        SystemResetSettingSlaveViewModel _systemResetSettingSlaveViewModel;
        ConnectionSlave _connectionSlave;

        public SystemResetSettingSlaveModel(SystemResetSettingSlaveViewModel systemResetSettingSlaveViewModel)
        {
            _systemResetSettingSlaveViewModel = systemResetSettingSlaveViewModel;
            _connectionSlave = _systemResetSettingSlaveViewModel._connectionSlave;
        }

        public void ButtonClick(int _commandNo)
        {
            switch (_commandNo)
            {
                case 1:
                    // UP ARROW MOUSE PRESSED - SY,1\n
                    if(_systemResetSettingSlaveViewModel.CurrentIPAddress != _systemResetSettingSlaveViewModel.DefaultIPAddress)
                    {
                        // Define the file path in the application installation directory
                        string _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _connectionSlave.fileName);
                        // Write newIPAddress to the file
                        try
                        {
                            string savedData = "2," + _systemResetSettingSlaveViewModel.DefaultIPAddress;
                            using (StreamWriter writer = new StreamWriter(_filePath, false, Encoding.UTF8))
                            {
                                writer.WriteLine(savedData); // This writes the response on a new line
                            }
                            // Optionally, update the currentServerIP with the newIPAddress
                            _connectionSlave.currentServerIP = _systemResetSettingSlaveViewModel.DefaultIPAddress;
                            _connectionSlave.CloseConnection();
                        }
                        catch (Exception ex)
                        {
                            // Handle any errors that may occur
                            Console.WriteLine($"Error saving IP address: {ex.Message}");
                        }
                    }
                    _systemResetSettingSlaveViewModel.CurrentIPAddress = _connectionSlave.currentServerIP;
                    break;
            }
        }
    }
}
