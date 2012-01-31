import System.IO

solution_file = "NExtra.sln"
build_folder  = "_tmpbuild_/"
build_config  = env('build.config')
build_output  = env('build.output')

test_assemblies = (
   "NExtra.Tests/bin/${build_config}/NExtra.Tests.dll", 
   "NExtra.Mvc.Tests/bin/${build_config}/NExtra.Mvc.Tests.dll", 
   "NExtra.Web.Tests/bin/${build_config}/NExtra.Web.Tests.dll", 
   "NExtra.WebForms.Tests/bin/${build_config}/NExtra.WebForms.Tests.dll", 
)

target default, (compile, test):
   pass
   
target zip, (compile, test, copy):
   zip("${build_folder}", "${build_output}")
   rmdir(build_folder)
   
target deploy, (compile, test, copy):
   with FileList(build_folder):
    .Include("**/**")
    .ForEach def(file):
      file.CopyToDirectory(build_output)
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
    .ForEach def(file):
      File.Copy(file.FullName, "${build_folder}/${file.Name}", true)