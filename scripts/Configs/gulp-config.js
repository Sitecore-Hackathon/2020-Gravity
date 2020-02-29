module.exports = function () {
    var instanceRoot = "C:\\inetpub\\wwwroot\\Sitecore93sc.dev.local";
    var config = {
        websiteRoot: instanceRoot + "\\",
        sitecoreLibraries: instanceRoot + "\\bin",
        licensePath: instanceRoot + "\\App_Data\\license.xml",
        packageXmlBasePath: ".\\src\\Project\\Gravity.Project.Hackathon\\code\\App_Data\\packages\\Hackathon.xml",
        packagePath: instanceRoot + "\\App_Data\\packages",
        solutionName: "Hackathon.Boilerplate",
        buildConfiguration: "Debug",
        buildToolsVersion: '16.0',
        buildMaxCpuCount: 0,
        buildVerbosity: "minimal",
        buildPlatform: "Any CPU",
        publishPlatform: "AnyCpu",
        runCleanBuilds: false
    };
    return config;
}
