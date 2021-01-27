# dotnetCoreDemo
用vscode创建项目的练习demo，
参考https://www.jb51.net/article/186055.htm

.NET Core SDK 2.2.202
开始

首先在 VS Code 安装几个扩展插件

C#
C# Extensions
.NET Core Test Explorer

# 创建类库项目
dotnet new classlib -n Skany.Core
# 创建控制台应用程序
dotnet new console -n Skany.Output
# 创建xUnit单元测试项目
dotnet new xunit -n Skany.Tests
# 为 Output 添加 Core 引用（因为当前在解决方案目录，而不是项目目录，所以add后要加上项目名，以下同理）
dotnet add Skany.Output reference Skany.Core
# 为 Tests 添加 Core 引用
dotnet add Skany.Tests reference Skany.Core
# 为 Core 项目添加 Nuget 引用
dotnet add Skany.Core package Hash --version 4.0.0
# 创建解决方案 sln
dotnet new sln -n Skany
# 添加项目到解决方案
dotnet sln Skany.sln add Skany.Core
dotnet sln Skany.sln add Skany.Output
dotnet sln Skany.sln add Skany.Tests
# 编译一下 Output 和 Tests 项目
dotnet build Skany.Output
dotnet build Skany.Tests


# 单元测试

通过命令执行单元测试

1
dotnet test Skany.Tests
如果只想测试其中一个方法 HashPasswordTest

1
dotnet test Skany.Tests --filter HashPasswordTest
