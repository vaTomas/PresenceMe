using OfficeOpenXml;
using PresenceMe.classes;
using PresenceMe.LocalDatabase;
using System;
using System.Collections.Generic;
using System.IO;

namespace PresenceMe.MyPackages
{
    internal static class ImportManager
    {
        public static void ReadExcelFile(string filePath)
        {
            // Set the license context before using EPPlus
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            //try
            //{
                using (var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    // Assuming your columns start from the second row (index 2)
                    var worksheet = package.Workbook.Worksheets[0];

                    if (worksheet == null)
                    {
                        throw new Exception("No worksheet found in the Excel file.");
                    }

                    // Iterate through rows
                    for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                    {
                        // Check if all cells in the row are null or empty
                        if (IsRowEmpty(worksheet, row))
                        {
                            continue; // Skip to the next row
                        }

                        // Initialize variables
                        uint idNumber;
                        string firstName, lastName, program;
                        ushort num2, num1;

                    // Read and handle potential null values

                    List<string> strings = new List<string>();
                    for (int i = 0; i < worksheet.Dimension.End.Column; i++)
                    {
                        string str = Convert.ToString(worksheet.Cells[row, i + 1].Value ?? string.Empty);

                        // Remove leading single quote
                        if (str.Length > 0 && str[0] == '\'')
                        {
                            str = str.Length > 1 ? str.Substring(1) : string.Empty;
                        }

                        // Trim leading and trailing spaces
                        strings.Add(str.Trim());
                    }


                    //try
                    //{
                    idNumber = Convert.ToUInt32(strings[0] ?? "0");
                    firstName = Convert.ToString(strings[1] ?? string.Empty);
                    lastName = Convert.ToString(strings[2] ?? string.Empty);
                    program = Convert.ToString(strings[3] ?? string.Empty);
                    if (strings[4] == "" || strings[5] == "")
                    {
                        num1 = 0;
                        num2 = 0;
                    }
                    else
                    {
                        num2 = Convert.ToUInt16(strings[4] ?? "0");
                        num1 = Convert.ToUInt16(strings[5] ?? "0");
                    }

                    //}
                    //catch (Exception ex)
                    //{
                    //    throw new Exception($"Error reading row {row}: {ex.Message}");
                    //}


                    // Process the data
                    string ulid = Ulid.NewUlid().ToBase64();

                        Person person = new Person(idNumber, firstName, lastName, program);
                        DBPresenceMe.People.Add(ulid, person);

                        // Skip RFID part if UserID, first name, lastname, or program/department is blank
                        if (!(num1 == 0 || num2 == 0))
                        {
                            uint rfid = BitwiseOperationHelpers.ConcatenateBits(num1, num2);
                            DBPresenceMe.RFIDs.Add(rfid, ulid);
                        }
                    }
                }
            //}
            //catch (Exception ex)
            //{
            //    // Log or handle the exception based on your application's requirements
            //    Console.WriteLine($"Error reading Excel file: {ex.Message}");
            //    // Alternatively, you can rethrow the exception to propagate it further
            //    // throw;
            //}
        }

        private static bool IsRowEmpty(ExcelWorksheet worksheet, int row)
        {
            for (int col = 1; col <= worksheet.Dimension.End.Column; col++)
            {
                if (worksheet.Cells[row, col].Value != null && !string.IsNullOrWhiteSpace(worksheet.Cells[row, col].Value.ToString()))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
