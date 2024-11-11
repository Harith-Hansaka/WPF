using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNDAI.MODELS.SLAVE;
using UNDAI.SERVICES;
using UNDAI.VIEWMODELS.SLAVE;
using UNDAI.COMMANDS.BASE;
using UNDAI.VIEWMODELS.MASTER;
using UNDAI.VIEWS.SLAVE;
using UNDAI.MODELS.MASTER;

namespace UNDAI.COMMANDS.SLAVE
{
    public class SelfRegPageSlaveCommand : CommandBase
    {
        public SelfRegPageSlaveViewModel _selfRegPageSlaveViewModel;
        public ConnectionSlave _connectionSlave;
        public SelfRegPageSlaveModel _selfRegPageSlaveModel;
        public MainPageSlaveModel _mainPageSlaveModel;

        public SelfRegPageSlaveCommand
        (
            SelfRegPageSlaveViewModel selfRegPageSlaveViewModel, 
            ConnectionSlave connectionSlave,
            SelfRegPageSlaveModel selfRegPageSlaveModel,
            MainPageSlaveModel mainPageSlaveModel
        )
        {
            _connectionSlave = connectionSlave;
            _mainPageSlaveModel = mainPageSlaveModel;
            _selfRegPageSlaveViewModel = selfRegPageSlaveViewModel;
            _selfRegPageSlaveModel = selfRegPageSlaveModel;

        }
        public override void Execute(object? parameter)
        {
            _selfRegPageSlaveModel.Button_Click();
        }
    }
}