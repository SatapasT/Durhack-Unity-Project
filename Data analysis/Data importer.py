import pandas as pd
import numpy as np
import os



os.system('cls')
dataframe = pd.read_csv('data.csv')

#print(dataframe.to_string()) 
#print(dataframe.index)
#print(dataframe[['Pulse']])

def print_columns(dataframe,column_name):
    for current_data in range(len(dataframe)):
        print(dataframe.loc[current_data, column_name])

def locate_item(dataframe,column_name,item_target): 
    for index, row in dataframe.iterrows():
        if row[column_name] == item_target:
            print(row)

def datasize(dataframe):
    count = 0
    for current_data in range(len(dataframe)):
        count += 1
    return count


print_columns(dataframe, 'Pulse')
for i in range(3):
    print("-------------------------------------------------------------------")

locate_item(dataframe,'Pulse','90')

for i in range(3):
    print("-------------------------------------------------------------------")
print(datasize(dataframe))
