using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNDAI.VIEWMODELS.SLAVE;

namespace UNDAI.MODELS.SLAVE
{
    public class LongPressHandleSlave
    {
        private MainPageSlaveViewModel _mainPageSlaveViewModel;
        private MainPageSlaveModel _mainPageSlaveModel;
        public bool isBtnPointerPressed = false;

        public LongPressHandleSlave(MainPageSlaveViewModel mainPageSlaveViewModel, MainPageSlaveModel mainPageSlaveModel)
        {
            _mainPageSlaveViewModel = mainPageSlaveViewModel;
            _mainPageSlaveModel = mainPageSlaveModel;
        }

        public async Task LongPressCheck(int identifier, DateTime pressedTime)
        {
            while (isBtnPointerPressed)
            {
                if (identifier == 1)
                {
                    if ((DateTime.Now - pressedTime).TotalMilliseconds > 2000)
                    {
                        _mainPageSlaveViewModel.IsSendDataLongPress = true;
                        isBtnPointerPressed = false;
                    }
                }

                else if (identifier == 2)
                {
                    if ((DateTime.Now - pressedTime).TotalMilliseconds > 2000)
                    {
                        _mainPageSlaveModel.isBtnUnitNoUpLongPress = true;
                        isBtnPointerPressed = false;
                    }
                }

                else if (identifier == 3)
                {
                    if ((DateTime.Now - pressedTime).TotalMilliseconds > 2000)
                    {
                        _mainPageSlaveModel.isBtnUnitNoDownLongPress = true;
                        isBtnPointerPressed = false;
                    }
                }
                await Task.Delay(50);
            }
        }
    }
}
