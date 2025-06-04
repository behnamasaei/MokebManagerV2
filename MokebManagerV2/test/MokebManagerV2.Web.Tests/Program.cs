using Microsoft.AspNetCore.Builder;
using MokebManagerV2;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();

builder.Environment.ContentRootPath = GetWebProjectContentRootPathHelper.Get("MokebManagerV2.Web.csproj");
await builder.RunAbpModuleAsync<MokebManagerV2WebTestModule>(applicationName: "MokebManagerV2.Web" );

public partial class Program
{
}
