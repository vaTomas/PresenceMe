import csv
from datetime import datetime


def main():
    output_arr = []
    input_arr = []

    with open('input.csv', newline='') as csvfile:
        reader = csv.reader(csvfile, delimiter=',', quotechar='|')
        for row in reader:
            input_arr.append(row)

    for row in input_arr:
        existing_entry_index = None
        for i, _row in enumerate(output_arr):
            if _row [0] == row[2]:
                existing_entry_index = i
                break

        # if ID doesn't exist in B, add A entry to B
        if existing_entry_index is None:
            output_row = [row[2], row[3], row[4], row[5]]
            for i in range(16):
                output_row.append(None)
            output_arr.append(output_row)
            existing_entry_index = len(output_arr) - 1

        if len(row[1]) > 10:
            datetime_obj = convert_to_datetime(row[1])
            unit = get_attendance_time(datetime_obj)
            output_arr[existing_entry_index][3 + unit] = True

        # print(output_row)

    for row in output_arr:
        print(row)

    with open('output.csv', 'w', newline='') as csv_file:
        writer = csv.writer(csv_file)

        # Write each row of the 2D array to the CSV file
        for row in output_arr:
            writer.writerow(row)

    print('Done!')

def convert_to_datetime(timestamp):
    try:
        dt = datetime.strptime(timestamp, "%d/%m/%Y %I:%M:%S %p")
    except ValueError:
        dt = datetime.strptime(timestamp, "%d/%m/%Y %H:%M:%S")
    return dt


def get_attendance_time(timestamp):
    date = timestamp.date()
    time = timestamp.time()

    if date == datetime(2023, 4, 24).date():
        if time >= datetime(1900, 1, 1, 0, 0).time() and time < datetime(1900, 1, 1, 9, 30).time():
            return 1
        elif time >= datetime(1900, 1, 1, 9, 30).time() and time < datetime(1900, 1, 1, 12, 0).time():
            return 2
        elif time >= datetime(1900, 1, 1, 12, 0).time() and time < datetime(1900, 1, 1, 14, 30).time():
            return 3
        else:
            return 4
    elif date == datetime(2023, 4, 25).date():
        if time >= datetime(1900, 1, 1, 0, 0).time() and time < datetime(1900, 1, 1, 9, 30).time():
            return 5
        elif time >= datetime(1900, 1, 1, 9, 30).time() and time < datetime(1900, 1, 1, 12, 0).time():
            return 6
        elif time >= datetime(1900, 1, 1, 12, 0).time() and time < datetime(1900, 1, 1, 14, 30).time():
            return 7
        else:
            return 8
    elif date == datetime(2023, 4, 26).date():
        if time >= datetime(1900, 1, 1, 0, 0).time() and time < datetime(1900, 1, 1, 9, 30).time():
            return 9
        elif time >= datetime(1900, 1, 1, 9, 30).time() and time < datetime(1900, 1, 1, 12, 0).time():
            return 10
        elif time >= datetime(1900, 1, 1, 12, 0).time() and time < datetime(1900, 1, 1, 14, 30).time():
            return 11
        else:
            return 12
    else:
        if time >= datetime(1900, 1, 1, 0, 0).time() and time < datetime(1900, 1, 1, 9, 30).time():
            return 13
        elif time >= datetime(1900, 1, 1, 9, 30).time() and time < datetime(1900, 1, 1, 12, 0).time():
            return 14
        elif time >= datetime(1900, 1, 1, 12, 0).time() and time < datetime(1900, 1, 1, 14, 30).time():
            return 15
        else:
            return 16


def check_if_in_output(id_number):
    with open('output.csv', newline='') as csvfile:
        reader = csv.reader(csvfile, delimiter=',', quotechar='|')
        for row in reader:
            if row[0] == id_number:
                return row
        return None


if __name__ == '__main__':
    main()
