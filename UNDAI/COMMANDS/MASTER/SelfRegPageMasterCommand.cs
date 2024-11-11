using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNDAI.MODELS.MASTER;
using UNDAI.SERVICES;
using UNDAI.VIEWMODELS.MASTER;
using UNDAI.COMMANDS.BASE;
using UNDAI.COMMANDS.MASTER;

namespace UNDAI.COMMANDS
{
    public class SelfRegPageMasterCommand : CommandBase
    {
        public SelfRegPageMasterViewModel _selfRegPageMasterViewModel;
        public ConnectionMaster _connectionMaster;
        public SelfRegPageMasterModel _selfRegPageMasterModel;
        public MainPageMasterModel _mainPageMasterModel;


        public SelfRegPageMasterCommand
        (
            SelfRegPageMasterViewModel selfRegPageMasterViewModel, 
            ConnectionMaster connectionMaster, 
            SelfRegPageMasterModel selfRegPageMasterModel,
            MainPageMasterModel mainPageMasterModel
        )

        {
            _selfRegPageMasterViewModel = selfRegPageMasterViewModel;
            _mainPageMasterModel = mainPageMasterModel;
            _connectionMaster = connectionMaster;
            _selfRegPageMasterModel = selfRegPageMasterModel;

        }

        public override void Execute(object? parameter)
        {
            _selfRegPageMasterModel.Button_Click();
        }
    }
}