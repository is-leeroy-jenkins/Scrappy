<div align="left">
  <p>
    <a href="https://github.com/is-leeroy-jenkins/Scrappy/tree/master/Resources/Github/Users.md">Download</a> •  <a href="">Documentation</a> •<a href="https://github.com/is-leeroy-jenkins/Scrappy/tree/master/Resources/Github/Compilation.md">Build</a> • <a href="#-license">License</a>
  </p>
  <p>
    
  </p>
</div>

![](https://github.com/is-leeroy-jenkins/Scrappy/blob/master/Source/Resources/Assets/GitHubImages/ProjectTemplate.png)



## ![](https://github.com/is-leeroy-jenkins/Scrappy/blob/master/Source/Resources/Assets/GitHubImages/features.png) Features

- Scrappy is a web scraping application built using .NET 8.0 and WPF written in C#. 
- It collects various types of data and exports them into organized and structured databases. 
- The application features a modern UI design with detailed and comprehensive logging.
- **Asynchronous Web Scraping**: Efficiently scrape web pages using asynchronous tasks with minimized latency and multi-threading for parallel processing.
- **Data Collection**: Collects data such as PDFs, CSVs, DOCX, XLS, PPTX, TXT, Images, Videos, JSON, DBSQL, XML, HTML, PHP, JS, Archives, and Miscellaneous files.
- **Comprehensive JSON, XML, and HTML Parsing**: Utilizes advanced parsing techniques to extract valuable information from JSON, XML, and HTML documents, including finding and processing hidden element data and meta data.
- **Database Integration**: Organizes scraped URLs into SQLite databases based on their file types.
- **Modern UI Design**: User-friendly WPF interface with rich text logging.
- **Detailed Logging**: Comprehensive log messages with timestamps, log levels, and thread IDs.
- **Export Options**: Export scraped data to database files, CSV, and TXT formats.
- **Multi OS Support**: Compatible with Windows x64/x86/ARM, Linux and MacOS.




## ![](https://github.com/is-leeroy-jenkins/Scrappy/blob/master/Source/Resources/Assets/GitHubImages/documentation.png) Documentation

- [User Guide](/Source/Resources/Github/Users.md)
- [Compilation Guide](/Source/Resources/Github/Compilation.md)
- [Configuration Guide](/Source/Resources/Github/Configuration.md)
- [Distribution Guide](/Source/Resources/Github/Distribution.md)


## ![](https://github.com/is-leeroy-jenkins/Scrappy/blob/master/Source/Resources/Assets/GitHubImages/csharp.png) Code

- Scrappy uses CefSharp 106 for Baby Browser and is built on NET 6
- Scrappy supports AnyCPU as well as x86/x64 specific builds
- [Controls](https://github.com/is-leeroy-jenkins/Scrappy/tree/master/Source/UI/Controls) - main UI layer and associated controls and related functionality.
- [Enumerations](https://github.com/is-leeroy-jenkins/Scrappy/tree/master/Source/Enumerations) - various enumerations used for budgetary accounting.
- [Extensions](https://github.com/is-leeroy-jenkins/Scrappy/tree/master/Source/Extensions)- useful extension methods for budget analysis by type.
- [Clients](https://github.com/is-leeroy-jenkins/Scrappy/tree/master/Source/Data/Clients) - other tools used and available.
- [Callbacks](https://github.com/is-leeroy-jenkins/Scrappy/tree/master/Source/Callbacks) - delegates, event-hanlders, and events.
- [IO](https://github.com/is-leeroy-jenkins/Scrappy/tree/master/Source/IO) - input output classes used for networking and the file systemm.
- [Static](https://github.com/is-leeroy-jenkins/Scrappy/tree/master/Source/Static) - static types used in the analysis of environmental budget data.
- [Interfaces](https://github.com/is-leeroy-jenkins/Scrappy/tree/master/Source/UI) - abstractions used in the analysis of environmental budget data.
- `bin` - Binaries are included in the `bin` folder due to the complex Baby setup required. Don't empty this folder.
- `bin/storage` - HTML and JS required for downloads manager and custom error pages


## 📦 Download

Pre-built and binaries (setup, portable and archive) are available on the with install instructions (e.g. silent install). 




## ![](https://github.com/is-leeroy-jenkins/Scrappy/blob/master/Source/Resources/Assets/GitHubImages/tools.png) Build

- [x] VisualStudio 2022
- [x] Based on .NET8 and WPF


```bash
$ git clone https://github.com/is-leeroy-jenkins/Scrappy.git
$ cd Scrappy
```
Run `Scrappy.sln`


You can build the application like any other .NET / WPF application on Windows.

1. Make sure that the following requirements are installed:

   - [.NET 8.x - SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
   - Visual Studio 2022 with `.NET desktop development` and `Universal Windows Platform development`

2. Clone the repository with all submodules:

   ```PowerShell
   # Clone the repository
   git clone https://github.com/is-leeroy-jenkins/Scrappy

   # Navigate to the repository
   cd Scrappy

   # Clone the submodules
   git submodule update --init
   ```

3. Open the project file `.\Source\Scrappy.sln` with Visual Studio or JetBrains Rider to build (or debug)
   the solution.

   > **ALTERNATIVE**
   >
   > With the following commands you can directly build the binaries from the command line:
   >
   > ```PowerShell
   > dotnet restore .\Source\Scrappy.sln
   >
   > dotnet build .\Source\Scrappy.sln --configuration Release --no-restore
   > ```


## ![](https://github.com/is-leeroy-jenkins/Scrappy/blob/master/Source/Resources/Assets/GitHubImages/system_requirements.png) Prerequisites

- .NET 8.0 Desktop Runtime or SDK Framework.
- Visual Studio 2022. (In case you want to build it yourself).

## ![](https://github.com/is-leeroy-jenkins/Scrappy/blob/master/Source/Resources/Assets/GitHubImages/administrative-tools.png) Installation

1. Clone the repository:
   ```sh
   git clone https://github.com/your-username/Scrappy.git
   cd Scrappy
   ```
2. Open the solution file (Scrappy.sln) in Visual Studio.

3. Build the project:

Select `Build > Build Solution`.
Run the application:

Select `Debug > Start Debugging` or press `F5`.


## 🙏 Acknoledgements

Scrappy uses the following projects and libraries. Please consider supporting them as well (e.g., by starring their repositories):

|                                                                               |                                                                        |
| ----------------------------------------------------------------------------- | ---------------------------------------------------------------------- |
| [#SNMP Library](https://github.com/lextudio/sharpsnmplib)                     | SNMP library for .NET                                                  |
| [AirspaceFixer](https://github.com/chris84948/AirspaceFixer)                  | AirspacePanel fixes all Airspace issues with WPF-hosted Winforms.      |
| [ControlzEx](https://github.com/ControlzEx/ControlzEx)                        | Shared Controlz for WPF and more                                       |
| [DnsClient.NET](https://github.com/MichaCo/DnsClient.NET)                     | Powerful, high-performance open-source library for DNS lookups         |
| [Docusaurus](https://docusaurus.io/)                                          | Easy to maintain open source documentation websites.                   |
| [Dragablz](https://dragablz.net/)                                             | Tearable TabControl for WPF                                            |
| [GongSolutions.Wpf.DragDrop](https://github.com/punker76/gong-wpf-dragdrop)   | An easy to use drag'n'drop framework for WPF                           |
| [IPNetwork](https://github.com/lduchosal/ipnetwork)                           | .NET library for complex network, IP, and subnet calculations          |
| [LoadingIndicators.WPF](https://github.com/zeluisping/LoadingIndicators.WPF)  | A collection of loading indicators for WPF                             |
| [MahApps.Metro.IconPacks](https://github.com/MahApps/MahApps.Metro.IconPacks) | Awesome icon packs for WPF and UWP in one library                      |
| [MahApps.Metro](https://mahapps.com/)                                         | UI toolkit for WPF applications                                        |
| [Syncfusion WPF Controls 24.1.41](https://github.com/nulastudio/NetBeauty2)   | UI controls and components and dependencies into a sub-directory       |
| [PSDiscoveryProtocol](https://github.com/lahell/PSDiscoveryProtocol)          | PowerShell module for LLDP/CDP discovery                               |

## ![](https://github.com/is-leeroy-jenkins/Scrappy/blob/master/Source/Resources/Assets/GitHubImages/signature.png)  Code Signing 

Scrappy uses free code signing provided by [SignPath.io](https://signpath.io/) and a free code signing certificate
from [SignPath Foundation](https://signpath.org/).

The binaries and installer are built on [AppVeyor](https://ci.appveyor.com/project/is-leeroy-jenkins/networkmanager) directly from the [GitHub repository](https://github.com/is-leeroy-jenkins/Scrappy/blob/main/appveyor.yml).
Build artifacts are automatically sent to [SignPath.io](https://signpath.io/) via webhook, where they are signed after manual approval by the maintainer.
The signed binaries are then uploaded to the [GitHub releases](https://github.com/is-leeroy-jenkins/Scrappy/releases) page.


## ![](https://github.com/is-leeroy-jenkins/Scrappy/blob/master/Source/Resources/Assets/GitHubImages/guidance.png) Privacy Policy

This program will not transfer any information to other networked systems unless specifically requested by the user or the person installing or operating it.

Scrappy has integrated the following services for additional functions, which can be enabled or disabled at the first start (in the welcome dialog) or at any time in the settings:

- [api.github.com](https://docs.github.com/en/site-policy/privacy-policies/github-general-privacy-statement) (Check for program updates)
- [ipify.org](https://www.ipify.org/) (Retrieve the public IP address used by the client)
- [ip-api.com](https://ip-api.com/docs/legal) (Retrieve network information such as geo location, ISP, DNS resolver used, etc. used by the client)

## 📝 License

Scrappy is published under the [MIT Public License v3](https://github.com/is-leeroy-jenkins/Scrappy/blob/main/LICENSE).

The licenses of the libraries used can be found [here](https://github.com/is-leeroy-jenkins/Scrappy/tree/main/Source/Scrappy.Documentation/Licenses).



