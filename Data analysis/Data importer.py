import os
import pandas as pd
import numpy as np

os.system('cls')
dataframe = pd.read_csv('data.csv')
print(dataframe.to_string()) 
print(dataframe.index)
print(dataframe[['Pulse']])

def print_columns(name):
    for current_data in range(len(dataframe)):
        print(dataframe.loc[current_data, name])

def locate_item(name,item_target): 
    for current_data in range(len(dataframe)):
        if (dataframe.loc[current_data, name]) == item_target:
            print(dataframe.loc[current_data])

def datasize(dataframe):
    count = 0
    for current_data in range(len(dataframe)):
        count += 1
    return count

for i in range(10):
    print("-------------------------------------------------------------------")
locate_item('Pulse','90')

print("datasize " + str(datasize(dataframe)))
