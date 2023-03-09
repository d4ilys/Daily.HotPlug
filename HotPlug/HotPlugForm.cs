using System.Data;
using System.Reflection;
using System.Windows.Forms;

namespace HotPlug
{
    public partial class HotPlugForm : Form
    {
        public HotPlugForm()
        {
            InitializeComponent();
        }

        private Dictionary<string, LoadDll> dlls = new();

        private int id = 1;

        private void HotPlugForm_Load(object sender, EventArgs e)
        {
            var loadDll = LoadDll.CreateInstance(Path.Combine(AppContext.BaseDirectory, "Plugs", "Plug01.dll"));
            dlls.Add(loadDll.AssemblyInfo.GetName().Name, loadDll);
            DataViewInit();
        }

        private void DataViewInit()
        {
            var dllInfos = dlls.Select(dll => new
            {
                Id = id++,
                Name = dll.Key,
                Value = dll.Value.AssemblyInfo.GetName().Version.ToString(),
                Status = Enum.GetName(typeof(LoadedState), dll.Value.LoadedState)
            }).ToList();
            dataGridView1.DataSource = dllInfos;
            dataGridView1.Columns[0].Visible = false;
        }

        private string GetDataViewSelectName(string col = "Name")
        {
            int a = dataGridView1.CurrentRow.Index;
            var dataGridViewRow = dataGridView1.Rows[a];
            var dataGridViewCell = dataGridViewRow.Cells[col];
            var value = dataGridViewCell.Value.ToString();
            return value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var status = GetDataViewSelectName("Status");
            if (status == "Unload")
            {
                MessageBox.Show("插件已经卸载无法执行.");
            }
            else
            {
                var value = GetDataViewSelectName();
                //执行插件
                dlls[value].Run();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var dialogResult = openFileDialog1.ShowDialog();
            var localFilePath = "";
            if (dialogResult == DialogResult.OK)
            {
                localFilePath = openFileDialog1.FileName;
            }
            else
            {
                return;
            }

            if (dlls.Any(pair => pair.Key == Path.GetFileNameWithoutExtension(openFileDialog1.SafeFileName)))
            {
                MessageBox.Show("已经存在这个插件，请移除后添加..");
                return;
            }

            var loadDll = LoadDll.CreateInstance(localFilePath);

            dlls.Add(loadDll.AssemblyInfo.GetName().Name, loadDll);
            DataViewInit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var value = GetDataViewSelectName();
            dlls[value].UnLoad();
            MessageBox.Show("卸载成功.");
            DataViewInit();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var value = GetDataViewSelectName();
            var status = GetDataViewSelectName("Status");
            if (status == "Success")
                dlls[value].UnLoad();
            dlls.Remove(value);
            DataViewInit();
        }
    }
}