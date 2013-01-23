$(document).ready(function() {
  
	function setupExternalLinks() {
		$("a[rel='external']").attr("target", "_blank");
	}

	function updateGitHubInfo() {
		var api_base = "https://api.github.com/repos/danielsaidi/nextra";
		var api_tags = api_base + "/tags?callback=?";

		updateVersionInfo("3.0.0");

		/*$.get(api_tags, function(data) {
			updateVersionInfo(data[0]["name"]);
		});*/
	}

	function updateVersionInfo(version) {
		$(".version-target").html(version);
	}

	setupExternalLinks();
	updateGitHubInfo();
});