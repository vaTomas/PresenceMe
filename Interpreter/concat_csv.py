import csv

def main():
    # Open the first CSV file for reading
    with open('file1.csv', 'r') as file1:
        reader1 = csv.reader(file1)
        data1 = [row for row in reader1]

    # Open the second CSV file for reading
    with open('file2.csv', 'r') as file2:
        reader2 = csv.reader(file2)
        data2 = [row for row in reader2]

    # Concatenate the data from both files
    data_combined = data1 + data2

    # Write the concatenated data to a new CSV file
    with open('input.csv', 'w', newline='') as outfile:
        writer = csv.writer(outfile)
        for row in data_combined:
            writer.writerow(row)


if __name__ == '__main__':
    main()
