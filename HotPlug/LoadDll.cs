using System.Reflection;
using System.Runtime.Loader;
using HotPlugBase;

namespace HotPlug;

/// <summary>
/// dll文件的加载
/// </summary>
public class LoadDll
{
    /// <summary>
    /// 要执行的任务
    /// </summary>
    private IDailyTask? _task;

    /// <summary>
    /// 核心程序集加载
    /// </summary>
    private AssemblyLoadContext? _context;

    /// <summary>
    /// 获取的程序集
    /// </summary>
    public Assembly AssemblyInfo { get; set; }

    /// <summary>
    /// 文件地址
    /// </summary>
    private string _path = string.Empty;

    /// <summary>
    /// 指定位置的插件库集合
    /// </summary>
    private AssemblyDependencyResolver _resolver;

    /// <summary>
    /// 用于取消Task
    /// </summary>
    private CancellationTokenSource cancelTokenSource = new CancellationTokenSource();

    /// <summary>
    /// 状态 1成功加载 0未成功  -1卸载
    /// </summary>
    public LoadedState LoadedState { get; set; }

    /// <summary>
    /// 加载插件
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    private bool LoadFile(string path)
    {
        this._path = path;
        try
        {
            _resolver = new AssemblyDependencyResolver(_path);
            _context = new AssemblyLoadContext(Guid.NewGuid().ToString("N"), true);
            _context.Resolving += (context, name) =>
            {
                Console.WriteLine($"加载{name.Name}");
                var path = _resolver.ResolveAssemblyToPath(name);
                if (!string.IsNullOrEmpty(path))
                {
                    using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                    {
                        return _context.LoadFromStream(fs);
                    }
                }

                return null;
            };

            using (var fs = File.Open(_path, FileMode.Open))
            {
                AssemblyInfo = _context.LoadFromStream(fs);
                foreach (var type in AssemblyInfo.GetTypes())
                {
                    if (type.GetInterface(nameof(IDailyTask)) != null)
                    {
                        var instance = Activator.CreateInstance(type);
                        if (instance != null)
                        {
                            _task = instance as IDailyTask;
                        }
                    }
                }
                LoadedState = LoadedState.Success;
                return true;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        LoadedState = LoadedState.Failed;

        return false;
    }

    private void InternalRun()
    {
        try
        {
            _task.Run();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    /// <summary>
    /// 执行插件中的任务
    /// </summary>
    /// <returns></returns>
    public bool Run()
    {
        bool runState = false;
        try
        {
            if (_task != null)
            {
                Task.Run(InternalRun, cancelTokenSource.Token);
                runState = true;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return runState;
    }

    /// <summary>
    /// 卸载插件
    /// </summary>
    /// <returns></returns>
    public bool UnLoad()
    {
        try
        {
            //将线程任务取消
            cancelTokenSource.Cancel();
            _context.Unload();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        finally
        {
            _task = null;
            _context = null;
            //GC.Collect();
            //GC.WaitForPendingFinalizers();
        }
        LoadedState = LoadedState.Unload;
        return true;
    }

    public static LoadDll CreateInstance(string path)
    {
        var l = new LoadDll();
        l.LoadFile(path);
        return l;
    }
}

public enum LoadedState
{
    Success,
    Failed,
    Unload
}