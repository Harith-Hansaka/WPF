using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNDAI.MODELS;
using UNDAI.SERVICES;
using UNDAI.VIEWMODELS.MASTER;
using UNDAI.MODELS.MASTER;
using UNDAI.COMMANDS.BASE;

namespace UNDAI.COMMANDS.MASTER
{
    public class ExecutionConnectionMasterCommand : CommandBase
    {
        private MainPageMasterViewModel _mainPageMasterViewModel;
        private ConnectionMaster _connectionMaster;
        private readonly int _identifier;

        public ExecutionConnectionMasterCommand(MainPageMasterViewModel mainPageMasterViewModel, ConnectionMaster connectionMaster, int Identifier)
        {
            _mainPageMasterViewModel = mainPageMasterViewModel;
            _connectionMaster = connectionMaster;
            _identifier = Identifier;
        }

        public override void Execute(object? parameter)
        {
            _connectionMaster.ConnectClick(_mainPageMasterViewModel, _identifier);
        }

    }
}
