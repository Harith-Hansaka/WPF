using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNDAI.MODELS;
using UNDAI.SERVICES;
using UNDAI.VIEWMODELS.SLAVE;
using UNDAI.MODELS.SLAVE;
using UNDAI.COMMANDS.BASE;

namespace UNDAI.COMMANDS.SLAVE
{
    public class ExecutionConnectionSlaveCommand : CommandBase
    {
        private MainPageSlaveViewModel _mainPageSlaveViewModel;
        private ConnectionSlave _connectionSlave;
        private readonly NavigationService _mainPageNavigationService;
        private readonly int _identifier;

        public ExecutionConnectionSlaveCommand(MainPageSlaveViewModel mainPageSlaveViewModel, ConnectionSlave connectionSlave, int Identifier)
        {
            _mainPageSlaveViewModel = mainPageSlaveViewModel;
            _connectionSlave = connectionSlave;
            _identifier = Identifier;
        }

        public override void Execute(object? parameter)
        {
            _connectionSlave.ConnectClick(_mainPageSlaveViewModel, _identifier);
        }

    }
}
