/**
 * C# code for the calculator object used in my solution for DealerOn's 
 * coding test. This simply calculates the price with tax and keeps a
 * running total of the taxes/overal cost
 * @author Jeffrey Trotz
 * @date 7/25/2019
 */
namespace SalesTax.WebPages
{
    public partial class Calculator
    {
        // Variable to store total tax for the item
        public double tax = 0;

        /**
         * This function is used to calculate the final price after taxes for an item.
         * @param type Type of item (book, medication, etc). Used to decide if we should tax it or not
         * @param price Cost for one item
         * @param quantity Total number of the item
         * @param isChecked Status of the "imported" checkbox (true if checked, false if not)
         */
        public double CalculatePrice(string type, double price, int quantity, bool isChecked)
        {
            // Stores tax values for this round of calculations
            double placeholder = 0;

            // If the item is taxable, then add 5% to the price
            if (IsTaxableItem(type))
            {
                placeholder += price * 0.05;
                price += price * .05;
            }

            // If the item is imported, then add 10% to the price
            if (isChecked == true)
            {
                placeholder += price * 0.1;
                price += price * 0.1;
            }

            // Update total tax and return the total price with taxes
            tax += placeholder;
            return price * quantity;
        }

        /**
         * This function is used to determine if an item should be taxed or not.
         * @param type Type of the item (book, medication, etc)
         */
        private bool IsTaxableItem(string type)
        {
            // If the item is not a book, type of medication, or food, then
            // it is not a taxable item, so return false
            if (type.Equals("Other"))
            {
                return true;
            }

            // If it's not a book, medication, or food, then return true
            else
            {
                return false;
            }
        }
    }
}