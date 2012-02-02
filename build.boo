import System.IO

solution_file = "NExtra.sln"
build_folder  = "_tmpbuild_/"
build_version  = env('build.version')
build_config  = env('build.config')

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
   
target nuget, (default):
   pass
   
target zip, (compile, test, copy):
   zip("${build_folder}", "NExtra.${build_version}.zip")
   rmdir(build_folder)
   
target deploy, (compile, test, copy):
   with FileList(build_folder):
    .Include("**/**")
    .ForEach def(file):
      file.CopyToDirectory("NExtra.${build_version}")
   rmdir(build_folder)


target compile:
   msbuild(file: solution_file, configuration: build_config, version: "4")

target test:
   nunit(assemblies: test_assemblies, enableTeamCity: true, toolPath: "Lib/Phantom/lib/nunit/nunit-console.exe", teamCityArgs: "v4.0 x86 NUnit-2.5.5")

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