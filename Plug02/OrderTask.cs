using System.Windows.Forms;
using HotPlugBase;
using Console = System.Console;

namespace Plug02
{
    public class OrderTask : IDailyTask
    {
        public void Run()
        {
            MessageBox.Show("我是订单插件，我升级为1.0.0.4了");
        }
    }
}