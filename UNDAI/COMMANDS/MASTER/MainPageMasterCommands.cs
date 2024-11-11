using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using UNDAI.MODELS.MASTER;
using UNDAI.VIEWMODELS.MASTER;
using UNDAI.COMMANDS.BASE;

namespace UNDAI.COMMANDS.MASTER
{
    public class MainPageMasterCommands : CommandBase
    {
        private int _commandNo;
        private MainPageMasterViewModel _mainPageMasterViewModel;
        public MainPageMasterModel _mainPageMasterModel;
        ConnectionMaster _connectionMaster;

        public MainPageMasterCommands(MainPageMasterViewModel mainPageMasterViewModel, ConnectionMaster connectionMaster, MainPageMasterModel mainPageMasterModel, int commandNo) 
        {
            _mainPageMasterViewModel = mainPageMasterViewModel;
            _commandNo = commandNo;
            _connectionMaster = connectionMaster;
            _mainPageMasterModel = mainPageMasterModel;
        }

        public override void Execute(object? parameter)
        {
            _commandNo = (int)parameter;
            _mainPageMasterModel.Button_Click(_commandNo);

        }
    }
}
