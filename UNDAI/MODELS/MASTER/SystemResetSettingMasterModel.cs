using System.IO;
using System.Text;
using UNDAI.VIEWMODELS.MASTER;

namespace UNDAI.MODELS.MASTER
{
    public class SystemResetSettingMasterModel
    {
        private int _commandNo;
        SystemResetSettingMasterViewModel _systemResetSettingMasterViewModel;
        ConnectionMaster _connectionMaster;

        public SystemResetSettingMasterModel(SystemResetSettingMasterViewModel systemResetSettingMasterViewModel)
        {
            _systemResetSettingMasterViewModel = systemResetSettingMasterViewModel;
            _connectionMaster = _systemResetSettingMasterViewModel._connectionMaster;
        }

        public void ButtonClick(int _commandNo)
        {
            switch (_commandNo)
            {
                case 1:
                    // UP ARROW MOUSE PRESSED - SY,1\n
                    if(_systemResetSettingMasterViewModel.CurrentIPAddress != _systemResetSettingMasterViewModel.DefaultIPAddress)
                    {
                        // Define the file path in the application installation directory
                        string _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _connectionMaster.fileName);
                        // Write newIPAddress to the file
                        try
                        {
                            string savedData = "1,"+ _systemResetSettingMasterViewModel.DefaultIPAddress;
                            using (StreamWriter writer = new StreamWriter(_filePath, false, Encoding.UTF8))
                            {
                                writer.WriteLine(savedData); // This writes the response on a new line
                            }
                            // Optionally, update the currentServerIP with the newIPAddress
                            _connectionMaster.currentServerIP = _systemResetSettingMasterViewModel.DefaultIPAddress;
                            _connectionMaster.CloseConnection();
                        }
                        catch (Exception ex)
                        {
                            // Handle any errors that may occur
                            Console.WriteLine($"Error saving IP address: {ex.Message}");
                        }
                    }
                    _systemResetSettingMasterViewModel.CurrentIPAddress = _connectionMaster.currentServerIP;
                    break;
            }
        }
    }
}
