using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaRottaO.CSharp.Utils.TableGenerator
{
    public class GenerateTable
    {
        public String generateWholeTable(String argTableTitle, Boolean argFirstRowIsHeader, StringBuilder argSbTableDataToInsert, Char argRowSeparator, Char argColumnSeparator)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(addHtmlHeader());
            sb.Append(addHtmlTable(argTableTitle, argFirstRowIsHeader, argSbTableDataToInsert, argRowSeparator, argColumnSeparator));
            sb.Append(addHtmlFooter());

            return sb.ToString();
        }

        public StringBuilder addHtmlHeader()
        {
            try
            {
                StringBuilder sbHeader = new StringBuilder();

                sbHeader.Append("<html>" + Environment.NewLine);
                sbHeader.Append("<head>" + Environment.NewLine);
                sbHeader.Append("<style>" + Environment.NewLine);
                sbHeader.Append("table {" + Environment.NewLine);
                sbHeader.Append("font-family: arial, sans-serif;" + Environment.NewLine);
                sbHeader.Append("border-collapse: collapse;  " + Environment.NewLine);
                sbHeader.Append("width: 100%;" + Environment.NewLine);
                sbHeader.Append("}" + Environment.NewLine);
                sbHeader.Append("td, th {" + Environment.NewLine);
                sbHeader.Append("border: 1px solid #dddddd;" + Environment.NewLine);
                sbHeader.Append("text-align: left;" + Environment.NewLine);
                sbHeader.Append("padding: 8px;" + Environment.NewLine);
                sbHeader.Append("}" + Environment.NewLine);
                sbHeader.Append("tr:nth-child(even) {" + Environment.NewLine);
                sbHeader.Append("background-color: #dddddd;" + Environment.NewLine);
                sbHeader.Append("}" + Environment.NewLine);
                sbHeader.Append("</style>" + Environment.NewLine);
                sbHeader.Append("</head>" + Environment.NewLine);
                sbHeader.Append("<body style=\"font-family: arial, sans-serif\">" + Environment.NewLine);
                sbHeader.Append("<br>" + Environment.NewLine);

                return sbHeader;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: Unable to generate table header: " + ex.ToString());

                return null;
            }
        }

        /*******************************************************************/
        // Usage
        //List<List<String>> tableContents = new List<List<String>>();
        // tableContents.Add(new List<string> { "Name", "Price", "Tax" });
        // tableContents.Add(new List<string> { "Blue", "10.00", "16.00" });
        /*******************************************************************/

        public StringBuilder addHtmlTable(String argTableTitle, Boolean argFirstRowIsHeader, List<List<String>> argTableDataToInsert)
        {
            try
            {
                StringBuilder sbTable = new StringBuilder();

                if (!String.IsNullOrEmpty(argTableTitle))
                {
                    sbTable.Append("<h3>" + argTableTitle + "</h3>" + Environment.NewLine);
                }

                sbTable.Append("<br>" + Environment.NewLine);

                sbTable.Append("</body>" + Environment.NewLine);
                sbTable.Append("</html>" + Environment.NewLine);

                //Add table headers

                sbTable.Append("<table>" + Environment.NewLine);
                sbTable.Append("<tr>" + Environment.NewLine);

                if (argFirstRowIsHeader)
                {
                    List<String> headerArray = argTableDataToInsert[0];

                    foreach (String headerCell in headerArray)
                    {
                        sbTable.Append("<th>" + headerCell + "</th>" + Environment.NewLine);
                    }
                }

                sbTable.Append("</tr>" + Environment.NewLine);

                int i = 0;

                if (argFirstRowIsHeader)
                {
                    i = 1;
                }

                for (; i < argTableDataToInsert.Count; i++)
                {
                    sbTable.Append("<tr>");

                    foreach (String cell in argTableDataToInsert[i])
                    {
                        sbTable.Append("<td>" + cell + "</td>");
                    }

                    sbTable.Append("</tr>");
                }

                sbTable.Append("</table>" + Environment.NewLine);

                return sbTable;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: Unable to parse List<String[]> to HTML table: " + ex.ToString());

                return null;
            }
        }

        //Depreciated
        public StringBuilder addHtmlTable(String argTableTitle, Boolean argFirstRowIsHeader, StringBuilder argSbTableDataToInsert, Char argRowSeparator, Char argColumnSeparator)
        {
            try
            {
                List<String> dataAsList = argSbTableDataToInsert.ToString().Split(argRowSeparator).ToList<String>();

                StringBuilder sbTable = new StringBuilder();

                if (!String.IsNullOrEmpty(argTableTitle))
                {
                    sbTable.Append("<h3>" + argTableTitle + "</h3>" + Environment.NewLine);
                }

                sbTable.Append("<br>" + Environment.NewLine);

                sbTable.Append("</body>" + Environment.NewLine);
                sbTable.Append("</html>" + Environment.NewLine);

                //Add table headers

                sbTable.Append("<table>" + Environment.NewLine);
                sbTable.Append("<tr>" + Environment.NewLine);

                if (argFirstRowIsHeader)
                {
                    sbTable.Append("<th>" + dataAsList[0].Replace(argColumnSeparator.ToString(), "</th><th>") + "</th>" + Environment.NewLine);
                }
                sbTable.Append("<tr>" + Environment.NewLine);

                int i = 0;

                if (argFirstRowIsHeader)
                {
                    i = 1;
                }

                for (; i < dataAsList.Count; i++)
                {
                    sbTable.Append("<tr>");
                    sbTable.Append("<td>" + dataAsList[i].Replace(argColumnSeparator.ToString(), "</td><td>") + "</td>");
                    sbTable.Append("<tr>");
                }

                //End table

                sbTable.Append("</table>" + Environment.NewLine);

                return sbTable;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: Unable to parse Strings to HTML table: " + ex.ToString());

                return null;
            }
        }

        public StringBuilder addHtmlFooter()
        {
            try
            {
                StringBuilder sbFooter = new StringBuilder();

                //Add html headers and a title, to make table look better

                sbFooter.Append("<html>" + Environment.NewLine);
                sbFooter.Append("<head>" + Environment.NewLine);
                sbFooter.Append("<style>" + Environment.NewLine);
                sbFooter.Append("table {" + Environment.NewLine);
                sbFooter.Append("font-family: arial, sans-serif;" + Environment.NewLine);
                sbFooter.Append("border-collapse: collapse;  " + Environment.NewLine);
                sbFooter.Append("width: 100%;" + Environment.NewLine);
                sbFooter.Append("}" + Environment.NewLine);
                sbFooter.Append("td, th {" + Environment.NewLine);
                sbFooter.Append("border: 1px solid #dddddd;" + Environment.NewLine);
                sbFooter.Append("text-align: left;" + Environment.NewLine);
                sbFooter.Append("padding: 8px;" + Environment.NewLine);
                sbFooter.Append("}" + Environment.NewLine);
                sbFooter.Append("tr:nth-child(even) {" + Environment.NewLine);
                sbFooter.Append("background-color: #dddddd;" + Environment.NewLine);
                sbFooter.Append("}" + Environment.NewLine);
                sbFooter.Append("</style>" + Environment.NewLine);
                sbFooter.Append("</head>" + Environment.NewLine);
                sbFooter.Append("<body style=\"font-family: arial, sans-serif\">" + Environment.NewLine);
                sbFooter.Append("<br>" + Environment.NewLine);

                return sbFooter;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: Unable to generate table footer: " + ex.ToString());

                return null;
            }
        }
    }
}