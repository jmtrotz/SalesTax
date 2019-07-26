# SalesTax
This app was created for DealerOn's coding test. It takes the price of the entered item, calculates the taxes on it (if it's taxable), and displays the results. It's basically a receipt generator like you'd find at any store checkout, except you have to enter the information manually instead of simply scanning the item. 

## App Breakdown
Since this app is pretty basic, all it consists of is one active server page, a CSS style sheet, a jQuery script, and two C# classes.

### index.aspx
This is the Active Server Page that contains the markup code to design the user interface.

### index.aspx.cs
This is the codebehind page for index.aspx. It collects and verifies data from the input form, then passes it to Calculator object to compute taxes on the item that was entered.

### styleSheet.css
This is the CSS style sheet that adds some "pazazz" to the user interface.

### javaScript.js
This is the jQuery script that animates the data entry form across the screen when the app is first launched.

### Calculator.cs
This is the class that performs the sales tax calculations for index.aspx.cs.

## To run the application:
### 1. Clone the repository
### 2. Unzip the file
### 3. Start Visual Studio and select "Open a project or solution"
### 4. Navigate to the downloaded file and double click on "SalesTax.csproj"
### 5. Click on "IIS Express (browser name)" at the top center of Visual Studio and it will launch in your browser

## IF THE APP FAILS TO LAUNCH
### 1. Close Visual Studio
### 2. Open "SalesTax.csproj" with a text editor (Notepad++ works great)
### 3. Search for:
<Target Name="EnsureNuGetPackageBuildImports" BeforeTargets="PrepareForBuild">
    <PropertyGroup>
      <ErrorText>This project references NuGet package(s) that are missing on this computer. Use NuGet Package Restore to download them. For more information, see http://go.microsoft.com/fwlink/?LinkID=322105. The missing file is {0}.</ErrorText>
    </PropertyGroup>
    <Error Condition="!Exists('..\packages\Microsoft.CodeDom.Providers.DotNetCompilerPlatform.2.0.0\build\net46\Microsoft.CodeDom.Providers.DotNetCompilerPlatform.props')" Text="$([System.String]::Format('$(ErrorText)', '..\packages\Microsoft.CodeDom.Providers.DotNetCompilerPlatform.2.0.0\build\net46\Microsoft.CodeDom.Providers.DotNetCompilerPlatform.props'))" />
</Target>
### 4. Delete it, save the file, and try again

## 403.14 Errors
If you get a 403 error while trying to launch the app, in Visual Studio right click on index.aspx and select "Set As Start Page" from the menu.
