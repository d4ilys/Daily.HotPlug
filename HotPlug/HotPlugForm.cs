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
            DllDictionaryAdd(loadDll);
            DataViewInit();
        }

        private void DllDictionaryAdd(LoadDll dll)
        {
            var key = $"{dll.AssemblyInfo.GetName().Name}|{dll.AssemblyInfo.GetName().Version}";
            dlls.Add(key, dll);
        }

        private void DataViewInit()
        {
            var dllInfos = dlls.Select(dll => new
            {
                Id = id++,
                Key = $"{dll.Value.AssemblyInfo.GetName().Name}|{dll.Value.AssemblyInfo.GetName().Version}",
                Name = dll.Value.AssemblyInfo.GetName().Name,
                Version = dll.Value.AssemblyInfo.GetName().Version.ToString(),
                Status = Enum.GetName(typeof(LoadedState), dll.Value.LoadedState)
            }).ToList();
            dataGridView1.DataSource = dllInfos;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns["Key"].Visible = false;
        }

        private string GetDataViewSelectName(string col = "Key")
        {
            int a = dataGridView1.CurrentRow.Index;
            var dataGridViewRow = dataGridView1.Rows[a];
            var dataGridViewCell = dataGridViewRow.Cells[col];
            var key = dataGridViewCell.Value.ToString();
            return key;
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

            var loadDll = LoadDll.CreateInstance(localFilePath);
            try
            {
                DllDictionaryAdd(loadDll);
            }
            catch
            {
                MessageBox.Show("已经存在该版本的插件.");
                loadDll.UnLoad();
            }
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}