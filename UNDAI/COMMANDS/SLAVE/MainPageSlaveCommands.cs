using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using UNDAI.MODELS.MASTER;
using UNDAI.VIEWMODELS.MASTER;
using UNDAI.COMMANDS.BASE;
using UNDAI.VIEWMODELS.SLAVE;
using UNDAI.MODELS.SLAVE;

namespace UNDAI.COMMANDS.SLAVE
{
    public class MainPageSlaveCommands : CommandBase
    {
        private int _commandNo;
        private MainPageSlaveViewModel _mainPageSlaveViewModel;
        public MainPageSlaveModel _mainPageSlaveModel;
        ConnectionSlave _connectionSlave;

        public MainPageSlaveCommands(MainPageSlaveViewModel mainPageSlaveViewModel, ConnectionSlave connectionSlave, MainPageSlaveModel mainPageSlaveModel, int commandNo) 
        {
            _mainPageSlaveViewModel = mainPageSlaveViewModel;
            _commandNo = commandNo;
            _connectionSlave = connectionSlave;
            _mainPageSlaveModel = mainPageSlaveModel;
        }

        public override void Execute(object? parameter)
        {
            _commandNo = (int)parameter;
            _mainPageSlaveModel.Button_Click(_commandNo);

        }
    }
}
