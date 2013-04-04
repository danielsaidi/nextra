import System.IO

project_name  = "NExtra"
assembly_file = "SharedAssemblyInfo.cs"

build_folder  = "_tmpbuild_/"
build_version = ""
build_config  = env('config')

test_assemblies = (
   "${project_name}.Tests/bin/${build_config}/${project_name}.Tests.dll", 
   "${project_name}.Web.Tests/bin/${build_config}/${project_name}.Web.Tests.dll", 
   "${project_name}.Mvc.Tests/bin/${build_config}/${project_name}.Mvc.Tests.dll", 
   "${project_name}.WPF.Tests/bin/${build_config}/${project_name}.WPF.Tests.dll", 
   "${project_name}.WebForms.Tests/bin/${build_config}/${project_name}.WebForms.Tests.dll", 
   "${project_name}.WinForms.Tests/bin/${build_config}/${project_name}.WinForms.Tests.dll", 
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
   msbuild(file: "${project_name}.sln", configuration: "${build_config}", version: "4")
      
   //Probably a reaaally crappy way to retrieve assembly version,
   //but I cannot use System.Reflection since Phantom is too old.
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
   
   exec("Resources\\nuget" , "pack ${project_name}\\${project_name}.csproj -prop configuration=release")
   exec("Resources\\nuget" , "pack ${project_name}.web\\${project_name}.web.csproj -prop configuration=release")
   exec("Resources\\nuget" , "pack ${project_name}.mvc\\${project_name}.mvc.csproj -prop configuration=release")
   exec("Resources\\nuget" , "pack ${project_name}.wpf\\${project_name}.wpf.csproj -prop configuration=release")
   exec("Resources\\nuget" , "pack ${project_name}.webforms\\${project_name}.webforms.csproj -prop configuration=release")
   exec("Resources\\nuget" , "pack ${project_name}.winforms\\${project_name}.winforms.csproj -prop configuration=release")
   
   exec("Resources\\nuget push ${project_name}.${build_version}.nupkg")
   exec("Resources\\nuget push ${project_name}.web.${build_version}.nupkg")
   exec("Resources\\nuget push ${project_name}.mvc.${build_version}.nupkg")
   exec("Resources\\nuget push ${project_name}.wpf.${build_version}.nupkg")
   exec("Resources\\nuget push ${project_name}.webforms.${build_version}.nupkg")
   exec("Resources\\nuget push ${project_name}.winforms.${build_version}.nupkg")
   
   exec("del *.nupkg")
   exec("del Resources\\README.txt")
   exec("del Resources\\Release-notes.txt")

target publish_github:
   exec("git add .")
   exec('git commit . -m "Creating release tag ' + " ${build_version}" + '"')
   exec("git tag ${build_version}")
   
   
   
   
   