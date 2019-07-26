/*
 * JavaScript for for my solution to DealerOn's coding test
 * problem number two: Sales Taxes.
 * Author: Jeffrey Trotz
 * Date: 7/25/2019
 */
jQuery(document).ready(function ()
{
    /*
     * Variable to save if it is the first visit of the page
     * or not so the animations only play once and not every
     * time a button is clicked
     */
    var isPostBack = document.getElementById('isPostBack');

    /*
     * If the page is not loaded in post back from a button click,
     * animate the inner div so the input form slides down the
     * screen when the page is first loaded
     */
    if (isPostBack == null)
    {
        jQuery('#innerDiv').animate({ top: '25%' }, 1000);
    }

    /*
     * If the page is loaded in post back from a button click,
     * set the CSS attributes for the inner div so the input
     * form stays where it is rather than animate again
     */
    else
    {
        jQuery('#innerDiv').css({ top: '25%' });
    }
});