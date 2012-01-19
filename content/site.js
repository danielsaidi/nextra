if (location.href == "http://danielsaidi.github.com/NExtra")
	location.href = "http://www.dotnextra.com";
else alert(location.href);

$(document).ready(function() {
  var repo = new gh.repo("danielsaidi", "NExtra");
  var tags = repo.getLatestRelease(function(result){ $("#version").html(result); });
  
  $("a[rel='external']").attr("target", "_blank");
});