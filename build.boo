import System.IO

project_name = "NExtra"
solution_file = "NExtra.sln"
assembly_file = "SharedAssemblyInfo.cs"

build_folder  = "_tmpbuild_/"
build_version = ""
build_config  = env('config')

test_assemblies = (
   "NExtra.Tests/bin/${build_config}/NExtra.Tests.dll", 
   "NExtra.Web.Tests/bin/${build_config}/NExtra.Web.Tests.dll", 
   "NExtra.Mvc.Tests/bin/${build_config}/NExtra.Mvc.Tests.dll", 
   "NExtra.WPF.Tests/bin/${build_config}/NExtra.WPF.Tests.dll", 
   "NExtra.WebForms.Tests/bin/${build_config}/NExtra.WebForms.Tests.dll", 
   "NExtra.WinForms.Tests/bin/${build_config}/NExtra.WinForms.Tests.dll", 
)



target default, (compile, test):
   pass

target zip, (compile, test, copy):
   zip("${build_folder}", "${project_name}.${build_version}.zip")
   rmdir(build_folder)
   
target deploy, (compile, test, copy):
   with FileList(build_folder):
    .Include("**/**")
    .ForEach def(file):
      file.CopyToDirectory("{project_name}.${build_version}")
   rmdir(build_folder)

target publish, (zip, publish_nuget, publish_github):
   pass

   
  

target compile:
   msbuild(file: solution_file, configuration: build_config, version: "4")
   
   //Probably a really crappy way to retrieve assembly
   //version, but I cannot use System.Reflection since
   //Phantom is old and if I recompile Phantom it does
   //not work. Also, since Phantom is old, it does not
   //find my plugin that can get new assembly versions.
   content = File.ReadAllText("${assembly_file}")
   start_index = content.IndexOf("AssemblyVersion(") + 17
   content = content.Substring(start_index)
   end_index = content.IndexOf("\"")
   build_version = content.Substring(0, end_index)

target test:
   nunit(assemblies: test_assemblies, enableTeamCity: true, toolPath: "resources/phantom/lib/nunit/nunit-console.exe", teamCityArgs: "v4.0 x86 NUnit-2.5.5")
   exec("del TestResult.xml")

target copy:
   rmdir(build_folder)
   mkdir(build_folder)
   
   File.Copy("README.md", "${build_folder}/README.txt", true)
   File.Copy("Release-notes.md", "${build_folder}/Release-notes.txt", true)
   
   with FileList(""):
    .Include("**/bin/${build_config}/*.dll")
    .Include("**/bin/${build_config}/*.pdb")
    .Include("**/bin/${build_config}/*.xml")
    .Exclude("**/bin/${build_config}/*.Tests.*")
    .Exclude("**/bin/${build_config}/nunit.framework.*")
    .Exclude("**/bin/${build_config}/nsubstitute.*")
    .ForEach def(file):
      File.Copy(file.FullName, "${build_folder}/${file.Name}", true)
	  

target publish_nuget:
   File.Copy("README.md", "Resources\\README.txt", true)
   File.Copy("Release-notes.md", "Resources\\Release-notes.txt", true)
   
   exec("nuget" , "pack nextra\\nextra.csproj -prop configuration=release")
   exec("nuget" , "pack nextra.web\\nextra.web.csproj -prop configuration=release")
   exec("nuget" , "pack nextra.mvc\\nextra.mvc.csproj -prop configuration=release")
   exec("nuget" , "pack nextra.wpf\\nextra.wpf.csproj -prop configuration=release")
   exec("nuget" , "pack nextra.webforms\\nextra.webforms.csproj -prop configuration=release")
   exec("nuget" , "pack nextra.winforms\\nextra.winforms.csproj -prop configuration=release")
   
   exec("nuget push nextra.${build_version}.nupkg")
   exec("nuget push nextra.web.${build_version}.nupkg")
   exec("nuget push nextra.mvc.${build_version}.nupkg")
   exec("nuget push nextra.wpf.${build_version}.nupkg")
   exec("nuget push nextra.webforms.${build_version}.nupkg")
   exec("nuget push nextra.winforms.${build_version}.nupkg")
   
   exec("del *.nupkg")
   exec("del Resources\\README.txt")
   exec("del Resources\\Release-notes.txt")

target publish_github:
   exec("git add .")
   exec('git commit . -m "Publishing .NExtra ' + "${build_version}" + '"')
   exec("git tag ${build_version}")
   exec("git push origin master")
   exec("git push origin ${build_version}")
   
   
   
   
   