import pandas as pd
import numpy as np
import os

os.system('cls')

#dataframe = pd.DataFrame(data=data_import)
dataframe = pd.read_csv('data.csv')

#print(dataframe.to_string()) 
#print(dataframe.index)
#print(dataframe[['Pulse']])

def print_columns(dataframe,column_name):
    temp_array = []
    for current_data in range(len(dataframe)):
        temp_array.append(dataframe.loc[current_data, column_name])
    return temp_array

def datasize(dataframe):
    count = 0
    for current_data in range(len(dataframe)):
        count += 1
    return count

def return_dataframe_totext(dataframe):
    return dataframe.to_string()

# 1:greater than, 2:less than, 3:equal, 4:not equal
def filter_by_number(dataframe, column_name, operator, size):
    if operator == 1:
        return dataframe[dataframe[column_name] > size]
    elif operator == 2:
        return dataframe[dataframe[column_name] < size]
    elif operator == 3:
        return dataframe[dataframe[column_name] == size]
    elif operator == 4:
        return dataframe[dataframe[column_name] != size]

# 1:Equal, 2:not equal
def filter_by_name(dataframe, column_name, operator, name):
    if operator == 1:
        return dataframe[dataframe[column_name] == name]
    elif operator == 2:
        return dataframe[dataframe[column_name] != name]

#print(print_columns(dataframe, 'Pulse'))
#print(filter_by_number(dataframe, 'Pulse', 3, 90))
#print(datasize(dataframe))
print(return_dataframe_totext(dataframe))
