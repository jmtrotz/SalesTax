# SalesTax
This app was created for DealerOn's coding test. It takes the price of the entered item, calculates the taxes on it (if it's taxable), and displays the results. It's basically a receipt generator like you'd find at any store checkout, except you have to enter the information manually instead of simply scanning the item. 

## App Breakdown
Since this app is pretty basic, all it consists of is one active server page, a CSS style sheet, a jQuery script, and two C# classes.

### index.aspx
This is the Active Server Page that contains the markup code to design the user interface.

### index.aspx.cs
This is the codebehind page for index.aspx. It collects and verifies data from the input form, then passes it to the Calculator object to compute taxes on the item that was entered.

### styleSheet.css
This is the CSS style sheet that adds some "pazazz" to the user interface.

### javaScript.js
This is the jQuery script that animates the data entry form across the screen when the app is first launched.

### Calculator.cs
This is the class that performs the sales tax calculations for index.aspx.cs.

## To run the application
1. Clone the repository
2. Unzip the file
3. Start Visual Studio and select "Open a project or solution"
4. Navigate to the downloaded file and double click on "SalesTax.csproj"
5. Click on "IIS Express (browser name)" at the top center of Visual Studio and it will launch in your browser
