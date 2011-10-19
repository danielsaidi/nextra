$(document).ready(function() {
  var repo = new gh.repo("danielsaidi", "NExtra");
  var tags = repo.getLatestRelease(function(result){ $("#version").html(result); });
  
  $("a[rel='external']").attr("target", "_blank");
});