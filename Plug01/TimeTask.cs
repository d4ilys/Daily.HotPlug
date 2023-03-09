using System.Windows.Forms;
using HotPlugBase;

namespace Plug01
{
    public class TimeTask : IDailyTask
    {
        public void Run()
        {
            MessageBox.Show("我是物流插件..");
        }
    }
}