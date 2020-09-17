/*
 * Grading ID: E3780
 * Lab: 1
 * Due Date: September 16 2020
 * Course: CIS 200-76
 * Description: Uses LINQ to sort an array of invoices.
 */

using System.Linq;
using static System.Console;

namespace Lab1
{
    public class LinqTest
    {
        public static void Main(string[] args)
        {
            // initialize array of invoices
            Invoice[] invoices = { 
                new Invoice( 83, "Electric sander", 7, 57.98M ), 
                new Invoice( 24, "Power saw", 18, 99.99M ), 
                new Invoice( 7, "Sledge hammer", 11, 21.5M ), 
                new Invoice( 77, "Hammer", 76, 11.99M ), 
                new Invoice( 39, "Lawn mower", 3, 79.5M ), 
                new Invoice( 68, "Screwdriver", 106, 6.99M ), 
                new Invoice( 56, "Jig saw", 21, 11M ), 
                new Invoice( 3, "Wrench", 34, 7.5M ) };

            // Display original array
            WriteLine("Original Invoice Data\n");
            WriteLine("P.Num Part Description     Quant Price"); // Column Headers
            WriteLine("----- -------------------- ----- ------");

            /*
             * Preconditions: None
             * Postconditions: Array is returned
             */

            foreach (Invoice inv in invoices)
                WriteLine(inv);

            var sortByPartDescription =
                from invoice in invoices
                orderby invoice.PartDescription
                select invoice;

            // Display array sorted by description
            WriteLine("\n Invoice Sorted by Description\n");
            WriteLine("P.Num Part Description     Quant Price"); // Column Headers
            WriteLine("----- -------------------- ----- ------");

            /*
             * Preconditions: None
             * Postconditions: Sorted array is returned
             */

            foreach (Invoice inv in sortByPartDescription)
                WriteLine(inv);

            var sortByPrice =
                from invoice in invoices
                orderby invoice.Price
                select invoice;

            // Display array sorted by price
            WriteLine("\n Invoice Sorted by Price\n");
            WriteLine("P.Num Part Description     Quant Price"); // Column Headers
            WriteLine("----- -------------------- ----- ------");

            /*
            * Preconditions: None
            * Postconditions: Sorted array is returned
            */

            foreach (Invoice inv in sortByPrice)
                WriteLine(inv);

            var sortByDescriptionAndQuantity =
                from invoice in invoices
                orderby invoice.Quantity
                select new { invoice.PartDescription, invoice.Quantity };

            // Display array sorted by description and quantity
            WriteLine("\n Invoice descriptions sorted by quantity\n");

            /*
            * Preconditions: None
            * Postconditions: Sorted array is returned
            */

            foreach (var inv in sortByDescriptionAndQuantity)
                WriteLine(inv);

            var sortByDescriptionAndValue =
                from invoice in invoices
                let invoiceTotal = invoice.Quantity * invoice.Price
                orderby invoiceTotal
                select new { invoice.PartDescription, InvoiceTotal = invoiceTotal };

            // Display array sorted by description and total cost
            WriteLine("\n Invoice descriptions sorted by total cost\n");

            /*
            * Preconditions: None
            * Postconditions: Sorted array is returned
            */

            foreach (var inv in sortByDescriptionAndValue)
                WriteLine(inv);

            var selectInvoiceRange =
                from invoice in sortByDescriptionAndValue
                where invoice.InvoiceTotal >= 200
                where invoice.InvoiceTotal <= 500
                select new { invoice.InvoiceTotal };

            // Display array showing invoices between 200 and 500
            WriteLine("\n Invoices between 200 and 500\n");

            /*
            * Preconditions: None
            * Postconditions: Sorted array is returned
            */

            foreach (var inv in selectInvoiceRange)
                WriteLine(inv);
        }
    }
}
