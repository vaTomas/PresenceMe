using OfficeOpenXml;
using PresenceMe.classes;
using PresenceMe.LocalDatabase;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PresenceMe.MyPackages
{
    internal static class ImportManager
    {
        public static void ReadExcelFile(string filePath)
        {
            // Set the license context before using EPPlus
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            try
            {
                using (var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    foreach (var worksheet in package.Workbook.Worksheets)
                    {
                        // Assuming your columns start from the second row (index 2)
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

                            // Read and handle potential null values
                            List<string> strings = ReadRowStrings(worksheet, row);

                            // Process the data
                            ProcessData(strings);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception based on your application's requirements
                Console.WriteLine($"Error reading Excel file: {ex.Message}");
                // Alternatively, you can rethrow the exception to propagate it further
                // throw;
            }
        }

        private static List<string> ReadRowStrings(ExcelWorksheet worksheet, int row)
        {
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

            return strings;
        }

        private static void ProcessData(List<string> strings)
        {
            // Read and handle potential null values
            try
            {
                uint idNumber = Convert.ToUInt32(strings[0] ?? "0");
                string firstName = Convert.ToString(strings[1] ?? string.Empty);
                string lastName = Convert.ToString(strings[2] ?? string.Empty);
                string program = Convert.ToString(strings[3] ?? string.Empty);

                ushort num2, num1;

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

                // Check if a person with the same idNumber or lastName already exists
                KeyValuePair<string, Person> existingPerson = DBPresenceMe.LocalData.People
                    .FirstOrDefault(p => p.Value.IdNumber == idNumber || p.Value.LastName == lastName);

                string ulid;
                if (existingPerson.Value != null)
                {
                    // Person with the same idNumber or lastName already exists
                    ulid = existingPerson.Key;
                }
                else
                {
                    // Generate a new ulid
                    ulid = Ulid.NewUlid().ToBase64();
                    Person person = new Person(idNumber, firstName, lastName, program);

                    // Add the person to the dictionary
                    DBPresenceMe.LocalData.People.Add(ulid, person);

                    
                }
                // Skip RFID part if RFID info is blank
                if (!(num1 == 0 || num2 == 0))
                {
                    uint rfid = BitwiseOperationHelpers.ConcatenateBits(num1, num2);
                    DBPresenceMe.LocalData.RFIDs.Add(rfid, ulid);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error processing data: {ex.Message}");
            }
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
