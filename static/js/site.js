$(document).ready(function() {
  
	function setupExternalLinks() {
		$("a[rel='external']").attr("target", "_blank");
	}

	function updateGitHubInfo() {
		var api_base = "https://api.github.com/repos/danielsaidi/nextra";
		var api_tags = api_base + "/tags?callback=?";

		$.get(api_tags, function(data) {
			$(".version-target").html("(v. " + data[0]["name"] + ")");
		});
	}

	setupExternalLinks();
	updateGitHubInfo();
});