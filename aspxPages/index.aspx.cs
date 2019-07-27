using System;

/**
 * C# code for the main ASPX page used in my solution for DealerOn's coding 
 * test. This page is designed to solve problem number two: Sales Taxes.
 * @author Jeffrey Trotz
 * @date 7/24/2019
 */
namespace SalesTax.WebPages
{
    public partial class index : System.Web.UI.Page
    {
        // These are used to keep track if the screen has been
        // updated for the first time or not and keeps a running
        // total of the taxes/sale
        private static bool firstTime = true;
        private static double taxTotal = 0;
        private static double saleTotal = 0;

        /**
         * Executed when the page is loaded. Sets a hidden field so the JavaScript script
         * can tell if the page is loaded in post back or not so the animations don't play
         * everytime a button is clicked
         * @param sender Object that contains a reference to the control/object that raised the event
         * @param e Event data
         */
        protected void Page_Load(object sender, EventArgs e)
        {
            /**
             * Sets a hidden field so the JavaScript can tell if the page is
             * loaded in post back or not so the animations don't play every
             * time a button is clicked
             */
            if (IsPostBack)
            {
                ClientScript.RegisterHiddenField("isPostBack", "True");
            }
        }

        /**
         * This is called when the "submit" button is clicked. It collects all data from the form,
         * verifies the user's input, and if everything checks out then it performs some calculations
         * and updates the screen
         * @param sender Object that contains a reference to the control/object that raised the event
         * @param e Event data
         */
        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            // Collect data from the input form
            string type = ddList.SelectedValue;
            string name = txtName.Text;
            string price = txtPrice.Text;
            string quantity = txtQuantity.Text;
            bool isImported = cBxImported.Checked;

            // Make sure the user's input is usable before proceeding
            if (this.VerifyInput(type, name, price, quantity))
            {
                // If it checks out, create Calculator object and convert
                // numbers to a format we can us
                Calculator calculator = new Calculator();
                double.TryParse(price, out double itemPrice);
                Int32.TryParse(quantity, out int totalQuantity);

                // Calculate/format the final price and update the tax/sale totals, then display results
                double finalPrice = Math.Round(calculator.CalculatePrice(type, itemPrice, totalQuantity, isImported), 2);
                taxTotal += Math.Round(calculator.tax, 2);
                saleTotal += Math.Round(finalPrice, 2);
                resultDiv.Visible = true;

                // If the item is imported, add it to the name so it is shown on the receipt
                if (isImported == true)
                {
                    name = "Imported " + name;
                }

                // Call the method to update the screen
                UpdateScreen(name, finalPrice, totalQuantity);
            }
        }

        /**
         * This is called when the "clear" button is clicked. It clears all text
         * boxes, unchecks the "imported item" checkbox, and resets the drop dow list
         * @param sender Object that contains a reference to the control/object that raised the event
         * @param e Event data
         */
        protected void BtnClear_Click(object sender, EventArgs e)
        {
            ddList.SelectedValue = "Default";
            txtName.Text = "";
            txtPrice.Text = "";
            txtQuantity.Text = "";
            cBxImported.Checked = false;
        }

        /**
         * This is called when the "reset" button is clicked. It clears all text
         * boxes, unchecks the "imported item" checkbox, resets the drop down list,
         * and clears all variables used to keep a running total
         * @param sender Object that contains a reference to the control/object that raised the event
         * @param e Event data
         */
        protected void BtnReset_Click(object sender, EventArgs e)
        {
            ddList.SelectedValue = "Default";
            txtName.Text = "";
            txtPrice.Text = "";
            txtQuantity.Text = "";
            lblResults.Text = "";
            lblTaxTotal.Text = "";
            lblOrderTotal.Text = "";
            firstTime = true;
            taxTotal = 0;
            saleTotal = 0;
            cBxImported.Checked = false;
            resultDiv.Visible = false;
        }

        /**
         * This method is used to update information on the screen, like the
         * running sale/tax total, to add an item to the list, etc.
         * @param name Name of the item
         * @param price Price of the item
         * @param quantity Amount of the item
         */
        private void UpdateScreen(string name, double price, int quantity)
        {
            // If it's the first time the screen is being updated, then use a "special" 
            // version of this method to avoid an unessesary line break
            if (firstTime)
            {
                // Set firstTime to false so the code in this 'if' block isn't
                // used again until the app is restarted
                firstTime = false;

                // If there's more than one, then use a different display format
                if (quantity > 1)
                {
                    lblResults.Text = name + ": $" + price.ToString("f2") + " (" +
                        quantity + " @ " + (price / quantity).ToString("f2") + ")";

                    lblTaxTotal.Text = "<br/>Sales Tax: $" + taxTotal.ToString("f2");
                    lblOrderTotal.Text = "<br/>Total: $" + saleTotal.ToString("f2");
                }

                // If not, then just stick to the standard format
                else
                {
                    lblResults.Text = name + ": $" + price.ToString("f2");
                    lblTaxTotal.Text = "<br/>Sales Tax: $" + taxTotal.ToString("f2");
                    lblOrderTotal.Text = "<br/>Total: $" + saleTotal.ToString("f2");
                }
            }

            // If it's not the first time, then just use the standard version
            else
            {
                // If there's more than one, then use a different display format
                if (quantity > 1)
                {
                    lblResults.Text += "<br/>" + name + ": $" + price.ToString("f2") + " (" +
                        quantity + " @ " + (price / quantity).ToString("f2") + ")";

                    lblTaxTotal.Text = "<br/>Sales Tax: $" + taxTotal.ToString("f2");
                    lblOrderTotal.Text = "<br/>Total: $" + saleTotal.ToString("f2");
                }

                // If not, then just stick to the standard format
                else
                {
                    lblResults.Text += "<br/>" + name + ": $" + price.ToString("f2");
                    lblTaxTotal.Text = "<br/>Sales Tax: $" + taxTotal.ToString("f2");
                    lblOrderTotal.Text = "<br/>Total: $" + saleTotal.ToString("f2");
                }
            }
        }

        /**
         * Verifies the user's input before calculating anything to avoid 
         * errors, like trying to calculate tax on the letter B
         * @param name Name of the item
         * @param price Price of the item
         * @param quantity Amount of the item
         */
        private bool VerifyInput(string type, string name, string price, string quantity)
        {
            // Show error message of no item type was selected
            if (type.Equals("Default"))
            {
                resultDiv.Visible = true;
                lblResults.Text = "Please choose an item type";
                return false;
            }

            // Show error message if no item name was entered
            if (name.Length == 0)
            {
                resultDiv.Visible = true;
                lblResults.Text = "Please enter an item name";
                return false;
            }

            // Show error message if no price was entered
            if (price.Length == 0)
            {
                resultDiv.Visible = true;
                lblResults.Text = "Please enter a price";
                return false;
            }

            // Show error message if no item quantity was entered
            if (quantity.Length == 0)
            {
                resultDiv.Visible = true;
                lblResults.Text = "Please enter a quantity";
                return false;
            }

            // Show error message if the price entered cannot be converted to a double
            if (!double.TryParse(price, out double priceResult))
            {
                resultDiv.Visible = true;
                lblResults.Text = "Please enter a valid number for price";
                return false;
            }

            // Show error message if the quantity entered cannot be converted to an integer
            if (!int.TryParse(quantity, out int quantityResult))
            {
                resultDiv.Visible = true;
                lblResults.Text = "Please enter a valid number for quantity";
                return false;
            }

            // If everything checks out, return true so we can continue on above
            else
            {
                return true;
            }
        }
    }
}