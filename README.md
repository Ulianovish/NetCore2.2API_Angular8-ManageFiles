# NetCore2.2API_Angular8-ManageFiles

## Prerequisites

* [.NET Core 2.2 SDK](https://dotnet.microsoft.com/download)

* [Visual Studio 2019](https://visualstudio.microsoft.com/vs/)

For the Angular front-end we'll also use:

* [VS Code](https://code.visualstudio.com/)

* [Node.js](https://nodejs.org/en/)

## Installation

```
1. Clone the repo:
    git clone https://github.com/Ulianovish/NetCore2.2API_Angular8-ManageFiles.git
2. Change directory:
    cd AspNetCoreSpa
3. Restore packages:
    dotnet restore Blog.sln
4. Install npm packages:
    cd ClientApp:
    - npm install
5. Run .Net project:
    F5 from either [Visual Studio IDE](https://www.visualstudio.com/) OR [VScode] (https://code.visualstudio.com/):
    Note: If you are running using Visual Studio Code, install dev certificates using command:
    dotnet dev-certs https --trust

6. Delete the files in folder Migrations.
7. Open Package Manager Console [Tools->Nuget Package Manager->Package Manager Console].
8. And run this comands

    ```
    Add-Migration Initial
    Update-Database
    ```
