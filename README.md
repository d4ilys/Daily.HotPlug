# Daily.HotPlug
.NET 6.0 实现热插拔 

在.NET Framework 时代通过AppDomain来实现程序集动态加载与卸载

在.NET Core中则是通过AssemblyLoadContext来实现程序集的卸载

应用场景：插件化开发时的热插拔、不重启主程序更新其功能

**程序会默认加载第一个插件**

![image](https://user-images.githubusercontent.com/54463101/223910390-e5f9d885-f7b3-4e73-a88f-00cd172e2029.png)

**手动加载插件**

![image](https://user-images.githubusercontent.com/54463101/223910620-67813fd7-c274-4d28-a2e7-bf5c51763b49.png)

**执行插件**

![image](https://user-images.githubusercontent.com/54463101/223910696-5933dd6b-869e-42c9-81c1-740104cef0ef.png)

![image](https://user-images.githubusercontent.com/54463101/223910733-6d84cfc6-d1b7-4e59-9ce6-ffa1dfb4df65.png)

**热更新**

> 将需要更新的插件卸载并移除
>
> 然后重新加载更新后的DLL

![image](https://user-images.githubusercontent.com/54463101/223911397-935edae5-e79c-451e-bb3a-b435f3171223.png)

![image](https://user-images.githubusercontent.com/54463101/223911413-54aed511-bcb9-4b9b-818e-cd794eb92daf.png)

**多个版本并存**

![image](https://user-images.githubusercontent.com/54463101/224198349-2f2dcb62-66c3-45f8-b09e-6b1473501600.png)

![image](https://user-images.githubusercontent.com/54463101/224198399-9aa0951a-a4f7-45ca-ac3e-2fd4293ac8f5.png)
![image](https://user-images.githubusercontent.com/54463101/224198464-197fb725-7b69-4702-8abc-e3db6e3bb10a.png)
